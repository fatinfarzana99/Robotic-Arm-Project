/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * File Name          : freertos.c
  * Description        : Code for freertos applications
  ******************************************************************************
  * @attention
  *
  * Copyright (c) 2024 STMicroelectronics.
  * All rights reserved.
  *
  * This software is licensed under terms that can be found in the LICENSE file
  * in the root directory of this software component.
  * If no LICENSE file comes with this software, it is provided AS-IS.
  *
  ******************************************************************************
  */
/* USER CODE END Header */

/* Includes ------------------------------------------------------------------*/
#include "FreeRTOS.h"
#include "task.h"
#include "main.h"
#include "cmsis_os.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "adc.h"
#include "crc.h"
#include "fatfs.h"
#include "sd_card.h"
#include "i2c.h"
#include "spi.h"
#include "tim.h"
#include "usart.h"
#include "gpio.h"
#include "ina219.h"
#include "VL53L0x_DistanceSensor.h"
#include "LCD_Driver.h"
#include "GUI.h"
#include "BNO085_spi.h"
#include "command.h"
#include "actuator.h"
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */
#define DEBUG_PRINT_DELAY (3000) // Task 1
#define ADC_TASK_DELAY (2000) // Task 2
#define CURRENT_SENSE_DELAY (2000) // Task 3
#define DISTANCE_SENSE_DELAY (1000) // Task 4
#define SD_CARD_TASK_DELAY (2000) // Task 5
#define MTR_SAMPLING_TIME (5) // Task 6 (5) 200 Hz
#define SRV_PWM_UPDATE_TIME (20) // Task 7 (20) 50 Hz
// #define COMMAND_RX_DELAY (20) // Task 8
#define GUI_LCD_DISP_DELAY (3000) // Task 9
#define IMU_TASK_DELAY (1000) // Task 10

#define EVT_SYS_FLAG_GUI_READY (uint32_t)(0x00000001)
#define EVT_SYS_FLAG_DIS_READY (uint32_t)(0x00000002)
#define EVT_SYS_FLAG_ADC_READY (uint32_t)(0x00000004)
#define EVT_SYS_FLAG_CUR_READY (uint32_t)(0x00000008)
#define EVT_SYS_FLAG_SDC_READY (uint32_t)(0x00000010)
#define EVT_SYS_FLAG_IMU_READY (uint32_t)(0x00000020)
#define EVT_SYS_FLAG_ALL_READY (uint32_t)(0x00000040)

// temperature sensor calibration value addresses
#define TS_CAL1 ((uint16_t*)((uint32_t)0x08FFF814))
#define TS_CAL2 ((uint16_t*)((uint32_t)0x08FFF818))

/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/
/* USER CODE BEGIN Variables */
// Global structure
extern ROBOT robot;
extern CMD_HANDLE g_CmdHandle;
/* USER CODE END Variables */
/* Definitions for debugPrintTask */
osThreadId_t debugPrintTaskHandle;
const osThreadAttr_t debugPrintTask_attributes = {
  .name = "debugPrintTask",
  .stack_size = 2048 * 4,
  .priority = (osPriority_t) osPriorityNormal,
};
/* Definitions for adcTask */
osThreadId_t adcTaskHandle;
const osThreadAttr_t adcTask_attributes = {
  .name = "adcTask",
  .stack_size = 2048 * 4,
  .priority = (osPriority_t) osPriorityHigh,
};
/* Definitions for curSenTask */
osThreadId_t curSenTaskHandle;
const osThreadAttr_t curSenTask_attributes = {
  .name = "curSenTask",
  .stack_size = 2048 * 4,
  .priority = (osPriority_t) osPriorityHigh,
};
/* Definitions for distSenTask */
osThreadId_t distSenTaskHandle;
const osThreadAttr_t distSenTask_attributes = {
  .name = "distSenTask",
  .stack_size = 2048 * 4,
  .priority = (osPriority_t) osPriorityHigh,
};
/* Definitions for sdCardTask */
osThreadId_t sdCardTaskHandle;
const osThreadAttr_t sdCardTask_attributes = {
  .name = "sdCardTask",
  .stack_size = 2048 * 4,
  .priority = (osPriority_t) osPriorityLow,
};
/* Definitions for mtrEncoderTask */
osThreadId_t mtrEncoderTaskHandle;
const osThreadAttr_t mtrEncoderTask_attributes = {
  .name = "mtrEncoderTask",
  .stack_size = 2048 * 4,
  .priority = (osPriority_t) osPriorityRealtime,
};
/* Definitions for srvPwmUpdateTask */
osThreadId_t srvPwmUpdateTaskHandle;
const osThreadAttr_t srvPwmUpdateTask_attributes = {
  .name = "srvPwmUpdateTask",
  .stack_size = 2048 * 4,
  .priority = (osPriority_t) osPriorityHigh,
};
/* Definitions for cmdRxTask */
osThreadId_t cmdRxTaskHandle;
const osThreadAttr_t cmdRxTask_attributes = {
  .name = "cmdRxTask",
  .stack_size = 2048 * 4,
  .priority = (osPriority_t) osPriorityHigh,
};
/* Definitions for guiLcdDispTask */
osThreadId_t guiLcdDispTaskHandle;
const osThreadAttr_t guiLcdDispTask_attributes = {
  .name = "guiLcdDispTask",
  .stack_size = 2048 * 4,
  .priority = (osPriority_t) osPriorityNormal,
};
/* Definitions for imuTask */
osThreadId_t imuTaskHandle;
const osThreadAttr_t imuTask_attributes = {
  .name = "imuTask",
  .stack_size = 2048 * 4,
  .priority = (osPriority_t) osPriorityHigh,
};
/* Definitions for SemaUartTx */
osSemaphoreId_t SemaUartTxHandle;
const osSemaphoreAttr_t SemaUartTx_attributes = {
  .name = "SemaUartTx"
};
/* Definitions for eventSysFlags */
osEventFlagsId_t eventSysFlagsHandle;
const osEventFlagsAttr_t eventSysFlags_attributes = {
  .name = "eventSysFlags"
};
/* Definitions for eventLcdReady */
osEventFlagsId_t eventLcdReadyHandle;
const osEventFlagsAttr_t eventLcdReady_attributes = {
  .name = "eventLcdReady"
};
/* Definitions for eventUartTxReady */
osEventFlagsId_t eventUartTxReadyHandle;
const osEventFlagsAttr_t eventUartTxReady_attributes = {
  .name = "eventUartTxReady"
};
/* Definitions for eventUartRxReady */
osEventFlagsId_t eventUartRxReadyHandle;
const osEventFlagsAttr_t eventUartRxReady_attributes = {
  .name = "eventUartRxReady"
};

/* Private function prototypes -----------------------------------------------*/
/* USER CODE BEGIN FunctionPrototypes */
static void _LcdInit( void );
/* USER CODE END FunctionPrototypes */

void StartDebugPrintTask(void *argument);
void StartAdcTask(void *argument);
void StartCurSenTask(void *argument);
void StartDistSenTask(void *argument);
void StartSdCardTask(void *argument);
void StartMtrEncoderTask(void *argument);
void StartSrvPwmUpdateTask(void *argument);
void StartCmdRxTask(void *argument);
void StartGuiLcdDispTask(void *argument);
void StartImuTask(void *argument);

void MX_FREERTOS_Init(void); /* (MISRA C 2004 rule 8.1) */

/* Hook prototypes */
void vApplicationStackOverflowHook(xTaskHandle xTask, signed char *pcTaskName);
void vApplicationMallocFailedHook(void);

/* USER CODE BEGIN 4 */
void vApplicationStackOverflowHook(xTaskHandle xTask, signed char *pcTaskName)
{
   /* Run time stack overflow checking is performed if
   configCHECK_FOR_STACK_OVERFLOW is defined to 1 or 2. This hook function is
   called if a stack overflow is detected. */
	printf("FreeRTOS: %s Out of stack\r\n", pcTaskName );
	printf("FreeRTOS: %s Out of stack\r\n", pcTaskName );
	while(1){};

}
/* USER CODE END 4 */

/* USER CODE BEGIN 5 */
void vApplicationMallocFailedHook(void)
{
   /* vApplicationMallocFailedHook() will only be called if
   configUSE_MALLOC_FAILED_HOOK is set to 1 in FreeRTOSConfig.h. It is a hook
   function that will get called if a call to pvPortMalloc() fails.
   pvPortMalloc() is called internally by the kernel whenever a task, queue,
   timer or semaphore is created. It is also called by various parts of the
   demo application. If heap_1.c or heap_2.c are used, then the size of the
   heap available to pvPortMalloc() is defined by configTOTAL_HEAP_SIZE in
   FreeRTOSConfig.h, and the xPortGetFreeHeapSize() API function can be used
   to query the size of free heap space that remains (although it does not
   provide information on how the remaining heap might be fragmented). */
	printf("FreeRTOS: Out of heap\r\n");
	printf("FreeRTOS: Out of heap\r\n");
	while(1){};

}
/* USER CODE END 5 */

/**
  * @brief  FreeRTOS initialization
  * @param  None
  * @retval None
  */
void MX_FREERTOS_Init(void) {
  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* USER CODE BEGIN RTOS_MUTEX */
  /* add mutexes, ... */
  /* USER CODE END RTOS_MUTEX */

  /* Create the semaphores(s) */
  /* creation of SemaUartTx */
  SemaUartTxHandle = osSemaphoreNew(1, 0, &SemaUartTx_attributes);

  /* USER CODE BEGIN RTOS_SEMAPHORES */
  // Semaphore is initialized with zero count, osSemaphoreRelease is to get one count,
  // i.e., ready for osSemaphoreAcquire
  osSemaphoreRelease( SemaUartTxHandle );
  /* add semaphores, ... */
  /* USER CODE END RTOS_SEMAPHORES */

  /* USER CODE BEGIN RTOS_TIMERS */
  /* start timers, add new ones, ... */
  /* USER CODE END RTOS_TIMERS */

  /* USER CODE BEGIN RTOS_QUEUES */
  /* add queues, ... */
  /* USER CODE END RTOS_QUEUES */

  /* Create the thread(s) */
  /* creation of debugPrintTask */
  debugPrintTaskHandle = osThreadNew(StartDebugPrintTask, (void*) &robot, &debugPrintTask_attributes);

  /* creation of adcTask */
  adcTaskHandle = osThreadNew(StartAdcTask, (void*) &robot, &adcTask_attributes);

  /* creation of curSenTask */
  curSenTaskHandle = osThreadNew(StartCurSenTask, (void*) &robot, &curSenTask_attributes);

  /* creation of distSenTask */
  distSenTaskHandle = osThreadNew(StartDistSenTask, (void*) &robot, &distSenTask_attributes);

  /* creation of sdCardTask */
  sdCardTaskHandle = osThreadNew(StartSdCardTask, (void*) &robot, &sdCardTask_attributes);

  /* creation of mtrEncoderTask */
  mtrEncoderTaskHandle = osThreadNew(StartMtrEncoderTask, (void*) &robot, &mtrEncoderTask_attributes);

  /* creation of srvPwmUpdateTask */
  srvPwmUpdateTaskHandle = osThreadNew(StartSrvPwmUpdateTask, (void*) &robot, &srvPwmUpdateTask_attributes);

  /* creation of cmdRxTask */
  cmdRxTaskHandle = osThreadNew(StartCmdRxTask, (void*) &robot, &cmdRxTask_attributes);

  /* creation of guiLcdDispTask */
  guiLcdDispTaskHandle = osThreadNew(StartGuiLcdDispTask, (void*) &robot, &guiLcdDispTask_attributes);

  /* creation of imuTask */
  imuTaskHandle = osThreadNew(StartImuTask, (void*) &robot, &imuTask_attributes);

  /* USER CODE BEGIN RTOS_THREADS */
  /* add threads, ... */
  /* USER CODE END RTOS_THREADS */

  /* Create the event(s) */
  /* creation of eventSysFlags */
  eventSysFlagsHandle = osEventFlagsNew(&eventSysFlags_attributes);

  /* creation of eventLcdReady */
  eventLcdReadyHandle = osEventFlagsNew(&eventLcdReady_attributes);

  /* creation of eventUartTxReady */
  eventUartTxReadyHandle = osEventFlagsNew(&eventUartTxReady_attributes);

  /* creation of eventUartRxReady */
  eventUartRxReadyHandle = osEventFlagsNew(&eventUartRxReady_attributes);

  /* USER CODE BEGIN RTOS_EVENTS */
  /* add events, ... */
  /* USER CODE END RTOS_EVENTS */

}

/* USER CODE BEGIN Header_StartDebugPrintTask */
/**
  * @brief  Function implementing the debugPrintTask thread.
  * @param  argument: Not used
  * @retval None
  */
/* USER CODE END Header_StartDebugPrintTask */
void StartDebugPrintTask(void *argument)
{
  /* USER CODE BEGIN StartDebugPrintTask */
  // Task 1
  // Debug Print Task
  ROBOT * rcvData = (ROBOT *) argument;
  char str[128];
  float temperature = 0.0;
  /* Wait for all devices ready */
  osEventFlagsWait( eventSysFlagsHandle, ( EVT_SYS_FLAG_ALL_READY ),
  (osFlagsNoClear | osFlagsWaitAll), osWaitForever );

  /* Infinite loop */
  for(;;)
  {
	  // ADC2 measurement
	  temperature = 100.0 * ((float)rcvData->mcuTempU32 - (float)(*TS_CAL1)) /
	  (float)((*TS_CAL2 - *TS_CAL1)) + 30.0;
	  printf("T_CAL_1_2 = %d %d, Temp = %5.2f (C) \r\n", *TS_CAL1, *TS_CAL2, temperature);
	  // current sensing
	  printf("ShtV = %ld (uV)\r\n", rcvData->dataINA219.shunt_voltage);
	  printf("BusV = %ld (mV)\r\n", rcvData->dataINA219.bus_voltage);
	  // printf("Cur = %ld (0.1 mA) ", rcvData->dataINA219.current);
	  printf("Cur = %7.2f (mA)\r\n", ( (float)(rcvData->dataINA219.current) / 10.0) );
	  printf("Pwr = %ld (mW) \r\n", rcvData->dataINA219.power);

	  for(int i = 0; i < 3; i++)
	  {
		  printf("i = %d, TS= %ld, RS = %d, R_mm = %d \r\n", i+1,
		  rcvData->dataVL53L0X.TimeStamp[i],
		  rcvData->dataVL53L0X.RangeStatus[i],
		  rcvData->dataVL53L0X.RangeMilliMeter[i]);
	  }
	  // motor encoder
	  printf("Mtr 1 encoder = %d \r\n", rcvData->dataEncoder.mtrCnt16AL[0]);
	  printf("Mtr 1 prev cnt = %5d %5d %5d %5d \r\n", rcvData->dataEncoder.mtrCnt16AL[1],
	  rcvData->dataEncoder.mtrCnt16AL[2],
	  rcvData->dataEncoder.mtrCnt16AL[3],
	  rcvData->dataEncoder.mtrCnt16AL[4]);
	  printf("Mtr 2 encoder = %d \r\n", rcvData->dataEncoder.mtrCnt16BR[0]);
	  printf("Mtr 2 prev cnt = %5d %5d %5d %5d \r\n", rcvData->dataEncoder.mtrCnt16BR[1],
	  rcvData->dataEncoder.mtrCnt16BR[2],
	  rcvData->dataEncoder.mtrCnt16BR[3],
	  rcvData->dataEncoder.mtrCnt16BR[4]);
	  printf("Encoder vel 1 = %ld \r\n", rcvData->dataEncoder.mtrVel32AL[0]);
	  printf("Encoder vel 2 = %ld \r\n", rcvData->dataEncoder.mtrVel32BR[0]);
	  printf("S1, L Arm = %ld (x100 deg)\r\n", rcvData->dataSrvPos.jointAngle[0]);
	  printf("S2, U ARM = %ld (x100 deg)\r\n", rcvData->dataSrvPos.jointAngle[1]);
	  printf("S3, RotG = %ld (x100 deg)\r\n", rcvData->dataSrvPos.jointAngle[2]);
	  printf("S4, Grip = %ld (x100 deg)\r\n", rcvData->dataSrvPos.jointAngle[3]);
	  printf("S7, Pan = %ld (x100 deg)\r\n", rcvData->dataSrvPos.jointAngle[6]);
	  printf("S8, Tilt = %ld (x100 deg)\r\n", rcvData->dataSrvPos.jointAngle[7]);
	  sprintf(str, "Cmd Hex: %x %x %x %x %x %x ", g_CmdHandle.uCmd[0], g_CmdHandle.uCmd[1],
	  g_CmdHandle.uCmd[2], g_CmdHandle.uCmd[3], g_CmdHandle.uCmd[4], g_CmdHandle.uCmd[5] );


	  sprintf(str, "Srv PWM: %d %d %d %d %d %d ", rcvData->dataSrvPwm.currentPwm[0],
	  rcvData->dataSrvPwm.currentPwm[1],
	  rcvData->dataSrvPwm.currentPwm[2],
	  rcvData->dataSrvPwm.currentPwm[3],
	  // rcvData->dataSrvPwm.currentPwm[4],
	  // rcvData->dataSrvPwm.currentPwm[5],
	  rcvData->dataSrvPwm.currentPwm[6],
	  rcvData->dataSrvPwm.currentPwm[7] );
	  printf("%s \r\n", str);
	  sprintf(str, "Mtr PWM: %4.1f %4.1f ", rcvData->dataMtrPwm.dDutyCycPercentAL,
	  rcvData->dataMtrPwm.dDutyCycPercentBR );
	  printf("%s \r\n", str);
	  sprintf(str, "Rotation Vector: r:%0.6f i:%0.6f j:%0.6f k:%0.6f", // a:%0.6f deg t:%f",
	  rcvData->dataBNO085.real,
	  rcvData->dataBNO085.i,
	  rcvData->dataBNO085.j,
	  rcvData->dataBNO085.k
	  // rcvData->dataBNO085.accuracy,
	  // (float)(rcvData->dataBNO085.timestamp_uS /1000000.0)
	  );
	  printf("%s \r\n\r\n", str);

    osDelay( DEBUG_PRINT_DELAY);
  }
  /* USER CODE END StartDebugPrintTask */
}

/* USER CODE BEGIN Header_StartAdcTask */
/**
* @brief Function implementing the adcTask thread.
* @param argument: Not used
* @retval None
*/
/* USER CODE END Header_StartAdcTask */
void StartAdcTask(void *argument)
{
  /* USER CODE BEGIN StartAdcTask */
	// Task 2
	// ADC Task
	/* Wait for DISTANCE_SEN_READY ready */
	osEventFlagsWait( eventSysFlagsHandle, EVT_SYS_FLAG_DIS_READY, osFlagsNoClear, osWaitForever );
	// start ADC to measure voltages of MCU temp
	HAL_ADC_Start_IT(&hadc2);
	osDelay( 20 );
	/* ADC Task is ready */
	printf("\r\nADC initialized.\r\n");
	osEventFlagsSet (eventSysFlagsHandle, EVT_SYS_FLAG_ADC_READY);
	/* Wait for all devices ready */
	osEventFlagsWait( eventSysFlagsHandle, ( EVT_SYS_FLAG_ALL_READY ),
	( osFlagsNoClear | osFlagsWaitAll ), osWaitForever );

  /* Infinite loop */
  for(;;)
  {
	  // HAL_GPIO_TogglePin(LD1_GREEN_OB_GPIO_Port, LD1_GREEN_OB_Pin);
	  // HAL_GPIO_TogglePin(LD1_GREEN_SHLD_GPIO_Port, LD1_GREEN_SHLD_Pin);
	  HAL_ADC_Start_IT(&hadc2);
	  osDelay( ADC_TASK_DELAY );

  }
  /* USER CODE END StartAdcTask */
}

/* USER CODE BEGIN Header_StartCurSenTask */
/**
* @brief Function implementing the curSenTask thread.
* @param argument: Not used
* @retval None
*/
/* USER CODE END Header_StartCurSenTask */
void StartCurSenTask(void *argument)
{
  /* USER CODE BEGIN StartCurSenTask */
	// Task 3
	// Current Sensing Task
	ROBOT * rcvData = (ROBOT *) argument;
	/* Wait for ADC ready */
	osEventFlagsWait( eventSysFlagsHandle, EVT_SYS_FLAG_ADC_READY,
	osFlagsNoClear, osWaitForever );
	INA219_Init();
	osDelay( 20 );
	printf("\r\nINA219 initialized.\r\n");
	osEventFlagsSet (eventSysFlagsHandle, EVT_SYS_FLAG_CUR_READY);
	/* Wait for all devices ready */
	osEventFlagsWait( eventSysFlagsHandle, ( EVT_SYS_FLAG_ALL_READY ),
	( osFlagsNoClear | osFlagsWaitAll ), osWaitForever );

  /* Infinite loop */
  for(;;)
  {
	  rcvData->dataINA219.shunt_voltage = INA219_shunt_voltage();
	  rcvData->dataINA219.bus_voltage = INA219_bus_voltage();
	  rcvData->dataINA219.current = INA219_current();
	  rcvData->dataINA219.power = INA219_power();
	  osDelay( CURRENT_SENSE_DELAY );

  }
  /* USER CODE END StartCurSenTask */
}

/* USER CODE BEGIN Header_StartDistSenTask */
/**
* @brief Function implementing the distSenTask thread.
* @param argument: Not used
* @retval None
*/
/* USER CODE END Header_StartDistSenTask */
void StartDistSenTask(void *argument)
{
  /* USER CODE BEGIN StartDistSenTask */
	// Task 4
	// Distance Sensing Task
	ROBOT * rcvData = (ROBOT *) argument;
	/* VL53L0X */
	int nDevPresent = 0;
	int nDev = 3; // no. of VL53L0X devices
	char strBuf[64] = {0};
	/* Wait for GUI ready */
	osEventFlagsWait( eventSysFlagsHandle, EVT_SYS_FLAG_GUI_READY,
	osFlagsNoClear, osWaitForever );
	// VL53L0X: LONG_RANGE, HIGH_SPEED, HIGH_ACCURACY
	RangingConfig_e rangingConfig = HIGH_ACCURACY;
	// initialize all VL53L0X sensors
	printf("\r\nInitialize VL53L0X . . .\r\n");
	// get the number of detected devices
	nDevPresent = VL53L0X_DetectSensors(nDev);
	printf("\r\nVL53L0X: nDevPresent (detected) = %d, nDev (specified) = %d \r\n", nDevPresent,
	nDev);
	osDelay(10);
	// Setup all detected sensors for single shot mode and setup ranging configuration
	VL53L0X_SetupSingleShot(rangingConfig, nDev);
	osDelay(10);
	// start distance sensing measurement
	VL53L0X_StartMeasurementWaitExtInt(rangingConfig, nDev);
	// osDelay( DISTANCE_SENSE_DELAY );
	osDelay(20);
	/* distance sensing task is ready */
	printf("\r\nVL53L0X initialized.\r\n");
	osEventFlagsSet (eventSysFlagsHandle, EVT_SYS_FLAG_DIS_READY);
	/* Wait for all devices ready */
	osEventFlagsWait( eventSysFlagsHandle, ( EVT_SYS_FLAG_ALL_READY ),
	( osFlagsNoClear | osFlagsWaitAll ), osWaitForever );

  /* Infinite loop */
  for(;;)
  {
	  HAL_GPIO_TogglePin(LD2_YELLOW_OB_GPIO_Port, LD2_YELLOW_OB_Pin);
	  // HAL_GPIO_TogglePin(LD1_GREEN_OB_GPIO_Port, LD1_GREEN_OB_Pin);
	  // send to PC the first measured distance
	  sprintf(strBuf,"@D%4d#", rcvData->dataVL53L0X.RangeMilliMeter[0]);
	  CommandSendToHost( &g_CmdHandle, strBuf, strlen(strBuf));
	  // start distance sensing measurement
	  VL53L0X_StartMeasurementWaitExtInt(rangingConfig, nDev);
	  osDelay( 100 );
  }
  /* USER CODE END StartDistSenTask */
}

/* USER CODE BEGIN Header_StartSdCardTask */
/**
* @brief Function implementing the sdCardTask thread.
* @param argument: Not used
* @retval None
*/
/* USER CODE END Header_StartSdCardTask */
void StartSdCardTask(void *argument)
{
  /* USER CODE BEGIN StartSdCardTask */
	// Task 5
	 // SD Card Data Storing Task
	 ROBOT * rcvData = (ROBOT *) argument;
	 float temperature;
	 float current;
	 int power;
	 /* Wait for CUR ready */
	 osEventFlagsWait( eventSysFlagsHandle, EVT_SYS_FLAG_CUR_READY,
	 osFlagsNoClear, osWaitForever );
	 /* SD Card initialization */
	 printf("\r\nInitialize SD Card . . .\r\n");
	 sd_mount();
	 sd_get_free();
	 sd_open_file();
	 // sd_de_mount();
	 osDelay( 20 );
	 printf("\r\nSD Card initialized.\r\n");
	 osEventFlagsSet (eventSysFlagsHandle, EVT_SYS_FLAG_SDC_READY);
	 /* Wait for all devices ready */
	 osEventFlagsWait( eventSysFlagsHandle, ( EVT_SYS_FLAG_ALL_READY ),
	 ( osFlagsNoClear | osFlagsWaitAll ), osWaitForever );
	 /* Infinite loop */
	 for(;;)
	 {
	  HAL_GPIO_TogglePin(LD1_GREEN_OB_GPIO_Port, LD1_GREEN_OB_Pin);
	  temperature = 100.0 * ((float)rcvData->mcuTempU32 - (float)(*TS_CAL1)) /
	    (float)((*TS_CAL2 - *TS_CAL1)) + 30.0;
	  current = (float)(rcvData->dataINA219.current) / 10.0;
	  power = rcvData->dataINA219.power;
	  sd_write_file(temperature,current,power); //write mcu temp, current, power
	  osDelay( SD_CARD_TASK_DELAY );
	 }
  /* USER CODE END StartSdCardTask */
}

/* USER CODE BEGIN Header_StartMtrEncoderTask */
/**
* @brief Function implementing the mtrEncoderTask thread.
* @param argument: Not used
* @retval None
*/
/* USER CODE END Header_StartMtrEncoderTask */
void StartMtrEncoderTask(void *argument)
{
  /* USER CODE BEGIN StartMtrEncoderTask */
	// Task 6
	// Motor Encoder Reading Task
	ROBOT * rcvData = (ROBOT *) argument;
	int i = 0;
	uint32_t wakeuptime;
	wakeuptime = osKernelSysTick();
  /* Infinite loop */
  for(;;)
  {
	  for (i = 4; i > 0; i--)
	  {
		  // update previous counts and velocities
		  rcvData->dataEncoder.mtrCnt16AL[i] = rcvData->dataEncoder.mtrCnt16AL[i-1]; // motor 1
		  rcvData->dataEncoder.mtrCnt16BR[i] = rcvData->dataEncoder.mtrCnt16BR[i-1]; // motor 2
		  rcvData->dataEncoder.mtrVel32AL[i] = rcvData->dataEncoder.mtrVel32AL[i-1]; // motor 1
		  rcvData->dataEncoder.mtrVel32BR[i] = rcvData->dataEncoder.mtrVel32BR[i-1]; // motor 2
	  }
	  // obtain motor encoder counts
		  rcvData->dataEncoder.mtrCnt16AL[0] = (int16_t)(E1_TIM_BASE->CNT)*(-1); // motor 1
		  rcvData->dataEncoder.mtrCnt16BR[0] = (int16_t)(E2_TIM_BASE->CNT); // motor 2
	  // obtain motor velocities

      rcvData->dataEncoder.mtrVel32AL[0] = (int32_t)((int16_t)(rcvData->dataEncoder.mtrCnt16AL[0] - rcvData->dataEncoder.mtrCnt16AL[1]));
	  rcvData->dataEncoder.mtrVel32BR[0] = (int32_t)((int16_t)(rcvData->dataEncoder.mtrCnt16BR[0] - rcvData->dataEncoder.mtrCnt16BR[1]));

	  wakeuptime += (uint32_t)MTR_SAMPLING_TIME;
	  osDelayUntil( wakeuptime );
  }
  /* USER CODE END StartMtrEncoderTask */
}

/* USER CODE BEGIN Header_StartSrvPwmUpdateTask */
/**
* @brief Function implementing the srvPwmUpdateTask thread.
* @param argument: Not used
* @retval None
*/
/* USER CODE END Header_StartSrvPwmUpdateTask */
void StartSrvPwmUpdateTask(void *argument)
{
  /* USER CODE BEGIN StartSrvPwmUpdateTask */
	// Task 7
	// Servo PWM Update Task
	ROBOT * rcvData = (ROBOT *) argument;
	int i = 0;
	int diff = 0;
	char strBuf[64] = {0};
	/* Wait for all devices ready */
	osEventFlagsWait( eventSysFlagsHandle, ( EVT_SYS_FLAG_ALL_READY ),
	( osFlagsNoClear | osFlagsWaitAll ), osWaitForever );

  /* Infinite loop */
  for(;;)
  {
	  // We have 8 servos to move. This is a method to move servo gradually by certain steps
	  for( i=0; i<8; i++ )
	  {
		  // Check if current PWM is matched with desired PWM.
		  if( g_CmdHandle.TargetPwm[i].Value == rcvData->dataSrvPwm.currentPwm[i])
		  {
			  // ensure servo motor is updated with the current PWM duty-cycle
			  ServoSetDuty( (i+1), rcvData->dataSrvPwm.currentPwm[i] );
			  // If PC application needs to know PWM movement is done
			  if( 0 != g_CmdHandle.TargetPwm[i].bReqCompleted )
			  {
				  g_CmdHandle.TargetPwm[i].bReqCompleted = 0; // request completed
				  // Send to wifi router via UART then it will route to PC app over TCP
				  strBuf[0] = '@';
				  strBuf[1] = 'C';
				  strBuf[2] = '0';
				  strBuf[3] = (i+1) + 0x30;// Convert to ascii
				  strBuf[4] = '#';
				  strBuf[5] = 0;
				  CommandSendToHost( &g_CmdHandle, strBuf, strlen(strBuf) );
			  }
			  // go to next servo
			  continue;
		  }
		  // If current PWM is not same as desired PWM, we need to step it
		  // Calculate the difference
		  diff = g_CmdHandle.TargetPwm[i].Value - rcvData->dataSrvPwm.currentPwm[i];
		  // If difference is too small, smaller a step value, just set it to desired value
		  if( abs(diff) <= g_CmdHandle.nDutyStep ) // <= 1% g_CmdHandle.nDutyStep
		  {
			  rcvData->dataSrvPwm.currentPwm[i] = g_CmdHandle.TargetPwm[i].Value;
		  }
		  else
		  {
			  // Otherwise, we step servo base on direction
			  if( diff < 0 )
			  {
				  rcvData->dataSrvPwm.currentPwm[i] -= g_CmdHandle.nDutyStep;
			  }
			  else
			  {
				  rcvData->dataSrvPwm.currentPwm[i] += g_CmdHandle.nDutyStep;
			  }
		  }
		  // Set physically the PWNM duty cycle for servo
		  switch( i+1 ) // Servo start from 1
		  {
			  case CMD_SV1_TARGET_ANGLE:
			  ServoSetDuty( 1, rcvData->dataSrvPwm.currentPwm[i] );
			  break;
			  case CMD_SV2_TARGET_ANGLE:
			  ServoSetDuty( 2, rcvData->dataSrvPwm.currentPwm[i] );
			  break;
			  case CMD_SV3_TARGET_ANGLE:
			  ServoSetDuty( 3, rcvData->dataSrvPwm.currentPwm[i] );
			  break;
			  case CMD_SV4_TARGET_ANGLE:
			  ServoSetDuty( 4, rcvData->dataSrvPwm.currentPwm[i] );
			  break;
			  case CMD_SV5_TARGET_ANGLE:
			  ServoSetDuty( 5, rcvData->dataSrvPwm.currentPwm[i] );
			  break;
			  case CMD_SV6_TARGET_ANGLE:
			  ServoSetDuty( 6, rcvData->dataSrvPwm.currentPwm[i] );
			  break;
			  case CMD_SV7_TARGET_ANGLE:
			  ServoSetDuty( 7, rcvData->dataSrvPwm.currentPwm[i] );
			  break;
			  case CMD_SV8_TARGET_ANGLE:
			  ServoSetDuty( 8, rcvData->dataSrvPwm.currentPwm[i] );
			  break;
			  default:
			  break;
		  }
	  }
	  osDelay( SRV_PWM_UPDATE_TIME );
  }
  /* USER CODE END StartSrvPwmUpdateTask */
}

/* USER CODE BEGIN Header_StartCmdRxTask */
/**
* @brief Function implementing the cmdRxTask thread.
* @param argument: Not used
* @retval None
*/
/* USER CODE END Header_StartCmdRxTask */
void StartCmdRxTask(void *argument)
{
  /* USER CODE BEGIN StartCmdRxTask */
	// Task 8
	// Command Receive Task
	// ROBOT * rcvData = (ROBOT *) argument;
	/* WiFi Serial to net command initialization */
	// put in main.c
	// CommandInit( &g_CmdHandle, &huart2 );
	/* Wait for all devices ready */
	osEventFlagsWait( eventSysFlagsHandle, ( EVT_SYS_FLAG_ALL_READY ),
	( osFlagsNoClear | osFlagsWaitAll ), osWaitForever );
  /* Infinite loop */
  for(;;)
  {
	  CommandRxExe( &g_CmdHandle );
	  // osDelay( COMMAND_RX_DELAY );

  }
  /* USER CODE END StartCmdRxTask */
}

/* USER CODE BEGIN Header_StartGuiLcdDispTask */
/**
* @brief Function implementing the guiLcdDispTask thread.
* @param argument: Not used
* @retval None
*/
/* USER CODE END Header_StartGuiLcdDispTask */
void StartGuiLcdDispTask(void *argument)
{
  /* USER CODE BEGIN StartGuiLcdDispTask */
	// Task 9
	// GUI LCD Display Task
	ROBOT * rcvData = (ROBOT *) argument;
	char str[128] = {0};
	float temperature = 0.0;
	int i = 0;
	/* LCD initialization */
	_LcdInit();
	GUI_SetFont(&GUI_Font6x8);
	/* LCD is ready */
	printf("\r\nLCD initialized.\r\n");
	osEventFlagsSet (eventSysFlagsHandle, EVT_SYS_FLAG_GUI_READY);
	/* Wait for all devices ready */
	osEventFlagsWait( eventSysFlagsHandle, ( EVT_SYS_FLAG_ALL_READY ),
	( osFlagsNoClear | osFlagsWaitAll ), osWaitForever );

  /* Infinite loop */
  for(;;)
  {
	  HAL_GPIO_TogglePin(LD3_RED_OB_GPIO_Port, LD3_RED_OB_Pin);
	  sprintf(str, "Cmd Hex: %x %x %x %x %x %x ",
	  g_CmdHandle.uCmd[0],
	  g_CmdHandle.uCmd[1],
	  g_CmdHandle.uCmd[2],
	  g_CmdHandle.uCmd[3],
	  g_CmdHandle.uCmd[4],
	  g_CmdHandle.uCmd[5] );
	  GUI_SetBkColor(GUI_BLUE);
	  GUI_DispStringAt( str, 2, 60 );
	  sprintf(str, "Srv PWM: %d %d %d %d %d %d ",
		  rcvData->dataSrvPwm.currentPwm[0],
		  rcvData->dataSrvPwm.currentPwm[1],
		  rcvData->dataSrvPwm.currentPwm[2],
		  rcvData->dataSrvPwm.currentPwm[3],
		  // rcvData->dataSrvPwm.currentPwm[4],
		  // rcvData->dataSrvPwm.currentPwm[5],
		  rcvData->dataSrvPwm.currentPwm[6],
		  rcvData->dataSrvPwm.currentPwm[7] );
	  GUI_SetBkColor(GUI_BLUE);
	  GUI_DispStringAt( str, 2, 75 );

	  sprintf(str, "Mtr Enc: %5d %5d ", rcvData->dataEncoder.mtrCnt16AL[0],
			  rcvData->dataEncoder.mtrCnt16BR[0] );
	  GUI_SetBkColor(GUI_BLUE);
	  GUI_DispStringAt( str, 2, 90 );

	  /*************************************************************************/
	  sprintf(str, "Cur: %4.1ld ", rcvData->dataINA219.current);
	  GUI_SetBkColor(GUI_BLUE);
	  GUI_DispStringAt( str, 2, 105 );

	  sprintf(str, "Pwr: %4.1ld", rcvData->dataINA219.power);
	  GUI_SetBkColor(GUI_BLUE);
	  GUI_DispStringAt( str, 2, 120 );
	  /*************************************************************************/
	  temperature = 100.0 * ((float)rcvData->mcuTempU32 - (float)(*TS_CAL1)) /
		  (float)((*TS_CAL2 - *TS_CAL1)) + 30.0;

	  sprintf(str, "MCU Temp: %6.2f (degC)\r\n", temperature);
	  GUI_SetBkColor(GUI_BLUE);
	  GUI_DispStringAt(str, 2, 150 );
	  sprintf(str, "%2d", i);
	  i++;
	  if (i >= 100) i = 0;
	  GUI_SetBkColor(GUI_BLUE);
	  GUI_DispStringAt( str, 2, 165 );
	  osDelay( 300 );
  }
  /* USER CODE END StartGuiLcdDispTask */
}

/* USER CODE BEGIN Header_StartImuTask */
/**
* @brief Function implementing the imuTask thread.
* @param argument: Not used
* @retval None
*/
/* USER CODE END Header_StartImuTask */
void StartImuTask(void *argument)
{
  /* USER CODE BEGIN StartImuTask */
	// Task 10
	// IMU Task Task
	// ROBOT * rcvData = (ROBOT *) argument;
	/* Wait for SD Card ready */
	osEventFlagsWait( eventSysFlagsHandle, EVT_SYS_FLAG_SDC_READY,
	osFlagsNoClear, osWaitForever );
	// Initialize the BNO085
	printf("\r\nInitialize BNO085 . . .\r\n");
	HAL_TIM_Base_Start(&htim5);
	BNO085_init();
	osDelay( 20 );
	printf("\r\nBNO085 initialized.\r\n");
	osEventFlagsSet (eventSysFlagsHandle, EVT_SYS_FLAG_IMU_READY);
	osEventFlagsSet (eventSysFlagsHandle, EVT_SYS_FLAG_ALL_READY);
	/* Wait for all devices ready */
	osEventFlagsWait( eventSysFlagsHandle, ( EVT_SYS_FLAG_ALL_READY ),
	( osFlagsNoClear | osFlagsWaitAll ), osWaitForever );

  /* Infinite loop */
  for(;;)
  {
	  // HAL_GPIO_TogglePin(LD3_RED_OB_GPIO_Port, LD3_RED_OB_Pin);
	  BNO085_service();
	  osDelay( IMU_TASK_DELAY ); // 25 Hz, timing is set in BNO085_spi.c

  }
  /* USER CODE END StartImuTask */
}

/* Private application code --------------------------------------------------*/
/* USER CODE BEGIN Application */
static void _LcdInit( void )
{
	// Choosing a landscape orientation
	LcdInit( &hspi2, LCD_LANDSCAPE_180 );
	GUI_Init();
	GUI_SetBkColor(GUI_BLUE);
	GUI_Clear();
	GUI_SetFont(&GUI_Font8x18);
	GUI_SetTextMode(GUI_TM_NORMAL);
	GUI_SetColor(GUI_BLACK);
	GUI_DispStringHCenterAt("Welcome to ECE225/SEM4405", 110, 10 );
	GUI_DispStringHCenterAt("Robotics", 110, 25 );
	GUI_DispStringHCenterAt("by Gan LC & Liaw HC, 2024", 110, 40 );
}
void HAL_ADC_ConvCpltCallback(ADC_HandleTypeDef* hadc)
{
	if( hadc->Instance == ADC2 ) robot.mcuTempU32 = HAL_ADC_GetValue(&hadc2);
}
void HAL_GPIO_EXTI_Callback(uint16_t GPIO_Pin)
{
		if( GPIO_Pin == GPIO_PIN_13 )
		{
			HAL_GPIO_TogglePin(LD3_RED_OB_GPIO_Port, LD3_RED_OB_Pin);
		}
	if( GPIO_Pin == IMU_INT_IRQ_Pin ) // IMU
	{
		IMU_Activate();
	}
	// Interrupt handler called each time an interrupt is produced by the ranging sensor
	#if (VL53L0X_ALARM_INTERRUPT_MODE || VL53L0X_START_MEASUREMENT_WAIT_EXT_INT)
	if(GPIO_Pin == GPIO_PIN_2) // DIST1_IRQ EXTI2_Pin
	{
		// first device
		VL53L0X_InterruptHandler(1);
		robot.dataVL53L0X.TimeStamp[0] = RangingMeasurementData[0].TimeStamp;
		robot.dataVL53L0X.RangeStatus[0] = RangingMeasurementData[0].RangeStatus;
		robot.dataVL53L0X.RangeMilliMeter[0] = RangingMeasurementData[0].RangeMilliMeter;
		robot.dataVL53L0X.SignalRateRtnMegaCps[0] = RangingMeasurementData[0].SignalRateRtnMegaCps;
		robot.dataVL53L0X.AmbientRateRtnMegaCps[0] = RangingMeasurementData[0].AmbientRateRtnMegaCps;
		robot.dataVL53L0X.EffectiveSpadRtnCount[0] = RangingMeasurementData[0].EffectiveSpadRtnCount;
		robot.dataVL53L0X.RangeDMaxMilliMeter[0] = RangingMeasurementData[0].RangeDMaxMilliMeter;
	}

	if(GPIO_Pin == GPIO_PIN_3) // DIST2_IRQ EXTI3_Pin
	{
		// second device
		VL53L0X_InterruptHandler(2);
		robot.dataVL53L0X.TimeStamp[1] = RangingMeasurementData[1].TimeStamp;
		robot.dataVL53L0X.RangeStatus[1] = RangingMeasurementData[1].RangeStatus;
		robot.dataVL53L0X.RangeMilliMeter[1] = RangingMeasurementData[1].RangeMilliMeter;
		robot.dataVL53L0X.SignalRateRtnMegaCps[1] = RangingMeasurementData[1].SignalRateRtnMegaCps;
		robot.dataVL53L0X.AmbientRateRtnMegaCps[1] = RangingMeasurementData[1].AmbientRateRtnMegaCps;
		robot.dataVL53L0X.EffectiveSpadRtnCount[1] = RangingMeasurementData[1].EffectiveSpadRtnCount;
		robot.dataVL53L0X.RangeDMaxMilliMeter[1] = RangingMeasurementData[1].RangeDMaxMilliMeter;
	}
	if(GPIO_Pin == GPIO_PIN_4) // DIST3_IRQ EXTI4_Pin
	{
		// third device
		VL53L0X_InterruptHandler(3);
		robot.dataVL53L0X.TimeStamp[2] = RangingMeasurementData[2].TimeStamp;
		robot.dataVL53L0X.RangeStatus[2] = RangingMeasurementData[2].RangeStatus;
		robot.dataVL53L0X.RangeMilliMeter[2] = RangingMeasurementData[2].RangeMilliMeter;
		robot.dataVL53L0X.SignalRateRtnMegaCps[2] = RangingMeasurementData[2].SignalRateRtnMegaCps;
		robot.dataVL53L0X.AmbientRateRtnMegaCps[2] = RangingMeasurementData[2].AmbientRateRtnMegaCps;
		robot.dataVL53L0X.EffectiveSpadRtnCount[2] = RangingMeasurementData[2].EffectiveSpadRtnCount;
		robot.dataVL53L0X.RangeDMaxMilliMeter[2] = RangingMeasurementData[2].RangeDMaxMilliMeter;
	}
	#endif
}
int __io_putchar(int ch)
{
uint8_t c[1];
c[0] = ch & 0x00FF; // &c[0]
HAL_UART_Transmit(&huart3, &*c, 1, 10);
return ch;
}

	/*
	int _write(int file, char *ptr, int len)
	{
		int DataIdx;
		for(DataIdx= 0; DataIdx< len; DataIdx++)
		{
			__io_putchar(*ptr++);
		}
		return len;
	}*/

/* USER CODE END Application */

