/**
  ******************************************************************************
  * File Name          : VL53L0X_DistanceSensor.c
  * Description        : This file provides code for the configuration
  *                      of the INA219 device
  ******************************************************************************
  * @attention
  *
  * Written by Liaw Hwee Choo, 09 Nov2021
  *
  ******************************************************************************
  */

/* Includes ------------------------------------------------------------------*/
#include "VL53L0X_DistanceSensor.h"

// Global ranging structure

VL53L0X_RangingMeasurementData_t RangingMeasurementData[3] = {0};

VL53L0X_Dev_t VL53L0XDevs[3] =
{
         {.Id=1, .DevLetter='a', .I2cHandle=&hi2c4, .I2cDevAddr=0x52},
         {.Id=2, .DevLetter='b', .I2cHandle=&hi2c4, .I2cDevAddr=0x52},
         {.Id=3, .DevLetter='c', .I2cHandle=&hi2c4, .I2cDevAddr=0x52},
};


struct AlrmMode_t
{
     const int VL53L0X_Mode;
     const char *Name;
     uint32_t ThreshLow;
     uint32_t ThreshHigh;
};

struct AlrmMode_t AlarmModes[]=
{
         { .VL53L0X_Mode = VL53L0X_GPIOFUNCTIONALITY_THRESHOLD_CROSSED_LOW , .Name= "Lo" , .ThreshLow=300<<16 ,  .ThreshHigh=0<<16  },
         { .VL53L0X_Mode = VL53L0X_GPIOFUNCTIONALITY_THRESHOLD_CROSSED_HIGH, .Name= "hi" , .ThreshLow=0<<16   ,  .ThreshHigh=300<<16},
         { .VL53L0X_Mode = VL53L0X_GPIOFUNCTIONALITY_THRESHOLD_CROSSED_OUT , .Name= "out", .ThreshLow=300<<16 ,  .ThreshHigh=400<<16},
};


/** Reset all sensor then do presence detection
 * All present devices are data initiated and assigned to their final I2C address
 * @return
 */
int VL53L0X_DetectSensors(int nDev)
{
    int i;
    uint16_t Id;
    int status = VL53L0X_ERROR_NONE;
    int FinalAddress;

    int nDevPresent = 0;  // number of device presented

    // disable all VL53L0Xs, set XSHUT to low to disable the device
    HAL_GPIO_WritePin(VL53L0X01_Out_XShut_GPIO_Port, VL53L0X01_Out_XShut_Pin, GPIO_PIN_RESET);
    HAL_GPIO_WritePin(VL53L0X02_Out_XShut_GPIO_Port, VL53L0X02_Out_XShut_Pin, GPIO_PIN_RESET);
    HAL_GPIO_WritePin(VL53L0X03_Out_XShut_GPIO_Port, VL53L0X03_Out_XShut_Pin, GPIO_PIN_RESET);

    /* detect all sensors */
    for (i = 0; i < nDev; i++)
    {
        VL53L0X_Dev_t *pDev;
        pDev = &VL53L0XDevs[i];
        pDev->I2cDevAddr = 0x52;
        pDev->Present = 0;
        HAL_Delay(2);

        // set XSHUT to high to enable the device
        if(0 == i) HAL_GPIO_WritePin(VL53L0X01_Out_XShut_GPIO_Port, VL53L0X01_Out_XShut_Pin, GPIO_PIN_SET);
        if(1 == i) HAL_GPIO_WritePin(VL53L0X02_Out_XShut_GPIO_Port, VL53L0X02_Out_XShut_Pin, GPIO_PIN_SET);
        if(2 == i) HAL_GPIO_WritePin(VL53L0X03_Out_XShut_GPIO_Port, VL53L0X03_Out_XShut_Pin, GPIO_PIN_SET);

        // note default or after XShut, the i2c addr = 0x52
        // under normal operation, 1st, 2nd, & third devices are configured to 0x54, 0x56, & 0x58, respectively.
        FinalAddress = 0x52 + (i+1)*2;
        HAL_Delay(10);

        status = 0;
		/* Set I2C standard mode (400 KHz) before doing the first register access */
		if (status == VL53L0X_ERROR_NONE) status = VL53L0X_WrByte(pDev, 0x88, 0x00);
		if (status != 0)
		{
			printf("\r\n#%d, WrByte, index = 0x88, data = 0x00, status = %d \r\n", i+1,status);
			// break;
		}

		Id = 0;
		/* Try to read one register using default 0x52 address */
		status = VL53L0X_RdWord(pDev, VL53L0X_REG_IDENTIFICATION_MODEL_ID, &Id);
		if (status != 0)
		{
			printf("#%d Read id failed.\r\n", i+1);
			// break;
		}
		if (Id == 0xEEAA)
		{
			/* Sensor is found => Change its I2C address to final one */
			status = VL53L0X_SetDeviceAddress(pDev,FinalAddress);
			if (status != 0)
			{
				printf("#%d VL53L0X_SetDeviceAddress failed.\r\n", i+1);
				// break;
			}
			pDev->I2cDevAddr = FinalAddress;

			/* Check all is OK with the new I2C address and initialize the sensor */
			status = VL53L0X_RdWord(pDev, VL53L0X_REG_IDENTIFICATION_MODEL_ID, &Id);
			if (status != 0)
			{
				printf("#%d VL53L0X_RdWord failed.\r\n", i+1);
				// break;
			}

			status = VL53L0X_DataInit(pDev);
			if(status != 0)
			{
				printf("#%d VL53L0X_DataInit failed.\r\n", i+1);
				// break;
			}
			printf("\r\nVL53L0X, Id = #%d, Present and initiated to final 0x%x \r\n", pDev->Id, pDev->I2cDevAddr);
			nDevPresent++;
			pDev->Present = 1;
			pDev->Enabled = 1;
			HAL_Delay(5);
		}
		else
		{
			printf("#%d unknown ID %x\r\n", i+1, Id);
			status = 1;
		}

     }
     return nDevPresent;
}


/** Setup all detected sensors for single shot mode and setup ranging configuration  */
VL53L0X_Error VL53L0X_SetupSingleShot(RangingConfig_e rangingConfig, int nDev)
{
    int i;
    VL53L0X_Error status = VL53L0X_ERROR_NONE;
    uint8_t VhvSettings;
    uint8_t PhaseCal;
    uint32_t refSpadCount;
	uint8_t isApertureSpads;
	FixPoint1616_t signalLimit = (FixPoint1616_t)(0.25*65536);
	FixPoint1616_t sigmaLimit = (FixPoint1616_t)(18*65536);
	uint32_t timingBudget = 33000;
	uint8_t preRangeVcselPeriod = 14;
	uint8_t finalRangeVcselPeriod = 10;

    for( i = 0; i < nDev; i++)
    {
        if( VL53L0XDevs[i].Present)
        {
        	// printf("VL53L0X_StaticInit, i = %d \r\n",i+1);

            status=VL53L0X_StaticInit(&VL53L0XDevs[i]);
            if( status )
            {
                printf("VL53L0X_StaticInit %d failed.\r\n",i+1);
            }

            status = VL53L0X_PerformRefSpadManagement(&VL53L0XDevs[i], &refSpadCount, &isApertureSpads);
			if( status )
			{
				printf("VL53L0X_PerformRefSpadManagement failed.\r\n");
			}

            status = VL53L0X_PerformRefCalibration(&VL53L0XDevs[i], &VhvSettings, &PhaseCal);
			if( status )
			{
			    printf("VL53L0X_PerformRefCalibration failed.\r\n");
			}

            status = VL53L0X_SetDeviceMode(&VL53L0XDevs[i], VL53L0X_DEVICEMODE_SINGLE_RANGING); // Setup in single ranging mode
            if( status )
            {
                printf("VL53L0X_SetDeviceMode failed.\r\n");
            }

            status = VL53L0X_SetLimitCheckEnable(&VL53L0XDevs[i], VL53L0X_CHECKENABLE_SIGMA_FINAL_RANGE, 1); // Enable Sigma limit
			if( status )
			{
			    printf("VL53L0X_SetLimitCheckEnable failed.\r\n");
			}

			status = VL53L0X_SetLimitCheckEnable(&VL53L0XDevs[i], VL53L0X_CHECKENABLE_SIGNAL_RATE_FINAL_RANGE, 1); // Enable Signa limit
			if( status )
			{
			    printf("VL53L0X_SetLimitCheckEnable failed.\r\n");
			}
			/* Ranging configuration */
            switch(rangingConfig) {
            case LONG_RANGE:
            	signalLimit = (FixPoint1616_t)(0.1*65536);
            	sigmaLimit = (FixPoint1616_t)(60*65536);
            	timingBudget = 33000;
            	preRangeVcselPeriod = 18;
            	finalRangeVcselPeriod = 14;
            	break;
            case HIGH_ACCURACY:
				signalLimit = (FixPoint1616_t)(0.25*65536);
				sigmaLimit = (FixPoint1616_t)(18*65536);
				timingBudget = 200000;
				preRangeVcselPeriod = 14;
				finalRangeVcselPeriod = 10;
				break;
            case HIGH_SPEED:
				signalLimit = (FixPoint1616_t)(0.25*65536);
				sigmaLimit = (FixPoint1616_t)(32*65536);
				timingBudget = 20000;
				preRangeVcselPeriod = 14;
				finalRangeVcselPeriod = 10;
				break;
            default:
            	printf("Not Supported.\r\n");
            }

            status = VL53L0X_SetLimitCheckValue(&VL53L0XDevs[i],  VL53L0X_CHECKENABLE_SIGNAL_RATE_FINAL_RANGE, signalLimit);
			if( status )
			{
			    printf("VL53L0X_SetLimitCheckValue failed.\r\n");
			}

			status = VL53L0X_SetLimitCheckValue(&VL53L0XDevs[i],  VL53L0X_CHECKENABLE_SIGMA_FINAL_RANGE, sigmaLimit);
			if( status )
			{
			    printf("VL53L0X_SetLimitCheckValue failed.\r\n");
			}

            status = VL53L0X_SetMeasurementTimingBudgetMicroSeconds(&VL53L0XDevs[i],  timingBudget);
            if( status )
            {
                printf("VL53L0X_SetMeasurementTimingBudgetMicroSeconds failed.\r\n");
            }

            status = VL53L0X_SetVcselPulsePeriod(&VL53L0XDevs[i],  VL53L0X_VCSEL_PERIOD_PRE_RANGE, preRangeVcselPeriod);
			if( status )
			{
			   printf("VL53L0X_SetVcselPulsePeriod failed.\r\n");
			}

            status = VL53L0X_SetVcselPulsePeriod(&VL53L0XDevs[i],  VL53L0X_VCSEL_PERIOD_FINAL_RANGE, finalRangeVcselPeriod);
			if( status )
			{
			   printf("VL53L0X_SetVcselPulsePeriod failed.\r\n");
			}

			status = VL53L0X_PerformRefCalibration(&VL53L0XDevs[i], &VhvSettings, &PhaseCal);
			if( status )
			{
			   printf("VL53L0X_PerformRefCalibration failed.\r\n");
			}

            VL53L0XDevs[i].LeakyFirst = 1;
        }
    }
	return status;
}


/**
 * Implement the single ranging with all modes
 * @param rangingConfig Ranging configuration to be used (same for all sensors)
 */
VL53L0X_Error VL53L0X_PerformSingleRanging(RangingConfig_e rangingConfig, int nDev)
{
	VL53L0X_Error status = VL53L0X_ERROR_NONE;

    /* Setup all sensors in Single Shot mode */
    // VL53L0X_SetupSingleShot(rangingConfig, nDev);

    /* Start ranging  */
	for(int i = 0; i < nDev; i++)
	{
		if( ! VL53L0XDevs[i].Present ) continue;

		/* Call All-In-One blocking API function */
		status = VL53L0X_PerformSingleRangingMeasurement(&VL53L0XDevs[i], &RangingMeasurementData[i]);
	    if( status )
	    {
			Error_Handler();
	    }

		/* Push data logging to UART */
		// printf("i = %d, id = %d, RS = %d, R_MilliMeter = %d, SRateRMC = %ld \r\n", i+1, VL53L0XDevs[i].Id,
	    // RangingMeasurementData.RangeStatus, RangingMeasurementData.RangeMilliMeter, RangingMeasurementData.SignalRateRtnMegaCps);

		/* Store new ranging distance */
		VL53L0X_Sensor_SetNewRange(&VL53L0XDevs[i], &RangingMeasurementData[i]);
		VL53L0XDevs[i].Ready = 1;
	}
	return status;
}


// Not working
// start measurement and wait for external interrupt
VL53L0X_Error VL53L0X_StartMeasurementWaitExtInt(RangingConfig_e rangingConfig, int nDev)
{
    VL53L0X_Error status = VL53L0X_ERROR_NONE;

    // Setup all sensors in Single Shot mode
    // VL53L0X_SetupSingleShot(rangingConfig, nDev);

	// start measurement on enabled devices
	for(int i=0; i<nDev; i++)
	{
	    if( ! VL53L0XDevs[i].Present )   continue; // || ! VL53L0XDevs[i].Enabled

		VL53L0X_SetDeviceMode(&VL53L0XDevs[i], VL53L0X_DEVICEMODE_SINGLE_RANGING );

		/* set sensor interrupt mode */
		VL53L0X_StopMeasurement(&VL53L0XDevs[i]);           // it is safer to do this while sensor is stopped
		VL53L0X_SetGpioConfig(  &VL53L0XDevs[i], 0,  VL53L0X_DEVICEMODE_SINGLE_RANGING, VL53L0X_GPIOFUNCTIONALITY_NEW_MEASURE_READY, VL53L0X_INTERRUPTPOLARITY_HIGH );

		status = VL53L0X_ClearInterruptMask(&VL53L0XDevs[i], 0);  // clear interrupt pending if any

		status = VL53L0X_StartMeasurement(&VL53L0XDevs[i]);
		if( status )
		{
		    printf("VL53L0X_StartMeasurement failed on device %d",i+1);
		}
	    VL53L0XDevs[i].Ready = 0;
	}
	return status;
}


void VL53L0X_InitializeContinuousRanging(int nDevNum)
{
	VL53L0X_Dev_t *pDev;
    uint8_t VhvSettings;
    uint8_t PhaseCal;
    uint32_t refSpadCount;
	uint8_t isApertureSpads;
	// VL53L0X_RangingMeasurementData_t RangingMeasurementData;
    // int status;

    /* Only one device is initialized */
    pDev = &VL53L0XDevs[nDevNum-1];

    /* Initialize the device in continuous ranging mode */
	VL53L0X_StaticInit(pDev);
	VL53L0X_PerformRefSpadManagement(pDev, &refSpadCount, &isApertureSpads);
	VL53L0X_PerformRefCalibration(pDev, &VhvSettings, &PhaseCal);
	VL53L0X_SetInterMeasurementPeriodMilliSeconds(pDev, 250);
	VL53L0X_SetDeviceMode(pDev, VL53L0X_DEVICEMODE_CONTINUOUS_RANGING);
}

// alarmMode = 0, 1, or 2 for different alarm-modes
VL53L0X_Error VL53L0X_SetUpInterrupt(int nDevNum, int alarmMode)
{
	VL53L0X_Dev_t *pDev;
	VL53L0X_Error status = VL53L0X_ERROR_NONE;

	pDev = &VL53L0XDevs[nDevNum-1];

    /* set sensor interrupt mode */
    VL53L0X_StopMeasurement(pDev);           // it is safer to do this while sensor is stopped
    // VL53L0X_SetInterruptThresholds(pDev, VL53L0X_DEVICEMODE_CONTINUOUS_RANGING ,   AlarmModes[alarmMode].ThreshLow ,  AlarmModes[alarmMode].ThreshHigh);
    // status = VL53L0X_SetGpioConfig(pDev, 0, VL53L0X_DEVICEMODE_CONTINUOUS_RANGING, AlarmModes[alarmMode].VL53L0X_Mode, VL53L0X_INTERRUPTPOLARITY_HIGH);

    VL53L0X_SetInterruptThresholds(pDev, VL53L0X_DEVICEMODE_SINGLE_RANGING ,   AlarmModes[alarmMode].ThreshLow ,  AlarmModes[alarmMode].ThreshHigh);
    status = VL53L0X_SetGpioConfig(pDev, 0, VL53L0X_DEVICEMODE_SINGLE_RANGING, AlarmModes[alarmMode].VL53L0X_Mode, VL53L0X_INTERRUPTPOLARITY_HIGH);

    status = VL53L0X_ClearInterruptMask(pDev, 0); // clear interrupt pending if any

    /* Start continuous ranging */
    status = VL53L0X_StartMeasurement(pDev);

    if( status )
	{
		printf("VL53L0X_StartMeasurement failed on device %d", nDevNum);
	}
	VL53L0XDevs[nDevNum-1].Ready = 0;

    return status;
}


VL53L0X_Error VL53L0X_InterruptHandler(int nDevNum)
{
	VL53L0X_Dev_t *pDev;
	VL53L0X_Error status = VL53L0X_ERROR_NONE;
	// uint8_t NewDataReady;

    pDev = &VL53L0XDevs[nDevNum-1];

    /* Is new sample ready ? */
   	// status = VL53L0X_GetMeasurementDataReady(pDev, &NewDataReady);
   	// if( status )
   	// {
    //		printf("VL53L0X_GetMeasurementDataReady failed on device %d", nDevNum);
   	// }
   	/* Skip if new sample not ready */
   	// if (1 == NewDataReady)
   	// {
        /* get new ranging data and store */
        status = VL53L0X_GetRangingMeasurementData(pDev, &RangingMeasurementData[nDevNum-1]);
        if( status )
        {
            // printf("VL53L0X_GetRangingMeasurementData failed on device %d", nDevNum);
        }

	    VL53L0X_Sensor_SetNewRange(pDev, &RangingMeasurementData[nDevNum-1]);
	    pDev->Ready = 1;

        /* Clear interrupt */
         status = VL53L0X_ClearInterruptMask(pDev, 0);
   	// }
    return status;
}


void VL53L0X_StopContinuousRanging(int nDevNum)
{
	VL53L0X_Dev_t *pDev;
	pDev = &VL53L0XDevs[nDevNum-1];

	/* Stop continuous ranging */
	VL53L0X_StopMeasurement(pDev);

	/* Ensure device is ready for other commands */
	VL53L0X_WaitStopCompleted(pDev);
}


VL53L0X_Error VL53L0X_WaitStopCompleted(VL53L0X_DEV Dev)
{
    VL53L0X_Error status = VL53L0X_ERROR_NONE;
    uint32_t StopCompleted = 0;
    uint32_t LoopNb;

    // Wait until it finished
    // use timeout to avoid deadlock
    if (status == VL53L0X_ERROR_NONE)
    {
        LoopNb = 0;
        do
        {
            status = VL53L0X_GetStopCompletedStatus(Dev, &StopCompleted);
            if ((StopCompleted == 0x00) || status != VL53L0X_ERROR_NONE)
            {
                break;
            }
            LoopNb = LoopNb + 1;
            VL53L0X_PollingDelay(Dev);
        } while (LoopNb < VL53L0X_DEFAULT_MAX_LOOP);

        if (LoopNb >= VL53L0X_DEFAULT_MAX_LOOP)
        {
            status = VL53L0X_ERROR_TIME_OUT;
        }
    }
    return status;
}


/* Store new ranging data into the device structure, apply leaky integrator if needed */
void VL53L0X_Sensor_SetNewRange(VL53L0X_Dev_t *pDev, VL53L0X_RangingMeasurementData_t *pRange)
{
	/** leaky factor for filtered range
	   * r(n) = averaged_r(n-1)*leaky +r(n)(1-leaky)  * */
	int LeakyFactorFix8 = (int)( 0.6 * 256);

    if( pRange->RangeStatus == 0 )
    {
        if( pDev->LeakyFirst )
        {
            pDev->LeakyFirst = 0;
            pDev->LeakyRange = pRange->RangeMilliMeter;
        }
        else
        {
            pDev->LeakyRange = (pDev->LeakyRange*LeakyFactorFix8 + (256-LeakyFactorFix8)*pRange->RangeMilliMeter)>>8;
        }
    }
    else
    {
        pDev->LeakyFirst = 1;
    }
}

