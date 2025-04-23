/**
  ******************************************************************************
  * File Name          : VL53L0X_DistanceSensor.h
  * Description        : This file provides code for the configuration
  *                      of the VL53L0X Distance Sensor.
  ******************************************************************************
  * @attention
  *
  * Written by Liaw Hwee Choo, 16 Oct 2020
  *
  ******************************************************************************
  */
/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef __VL53L0X_DistanceSensor_H
#define __VL53L0X_DistanceSensor_H
#ifdef __cplusplus
 extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "i2c.h"
#include "vl53l0x_api.h"
#include "vl53l0x_platform.h"

 /**I2C4 GPIO Configuration
  PF14     ------> I2C4_SCL
  PF15     ------> I2C4_SDA

  PE3   GPIO_EXTI3    DIST1_IRQ
  PE2   GPIO_EXTI2    DIST2_IRQ
  PE5   GPIO_EXTI5    DIST3_IRQ
  PE10  GPIO_Output   DIST1_XSHUT
  PE7   GPIO_Output   DIST2_XSHUT
  PE8   GPIO_Output   DIST3_XSHUT
  PF14  I2C4_SCL      DIST_I2C4_SCL
  PF15  I2C4_SDA      DIST_I2C4_SDA
  I2C settings:
  Disabled, Fast Mode, 400, 0, 0, 0, Enabled, 0x009032AE
  Disabled, Disabled, 7-bit, Disabled, 0x29
  GPIO interrupt (x3) enabled

 Note 1: GPIO Interrupt mode: (GPIO_MODE_IT_FALLING, GPIO_PULLUP)
 Note 2: I2C 8-bit addr is 0x52
         I2C 7-bit addr is 0x29
 */

#define VL53L0X01_Out_XShut_Pin         DIST1_XSHUT_Pin
#define VL53L0X01_Out_XShut_GPIO_Port   DIST1_XSHUT_GPIO_Port

#define VL53L0X02_Out_XShut_Pin         DIST2_XSHUT_Pin
#define VL53L0X02_Out_XShut_GPIO_Port   DIST2_XSHUT_GPIO_Port

#define VL53L0X03_Out_XShut_Pin         DIST3_XSHUT_Pin
#define VL53L0X03_Out_XShut_GPIO_Port   DIST3_XSHUT_GPIO_Port

#define VL53L0X_START_MEASUREMENT_WAIT_EXT_INT  1

typedef enum
{
  	LONG_RANGE 		= 0, /*!< Long range mode */
   	HIGH_SPEED 		= 1, /*!< High speed mode */
   	HIGH_ACCURACY	= 2, /*!< High accuracy mode */
} RangingConfig_e;

/*  Global ranging structure  */
extern VL53L0X_RangingMeasurementData_t   RangingMeasurementData[3];
extern VL53L0X_Dev_t     VL53L0XDevs[3];

 int  VL53L0X_DetectSensors(int nDev);
 VL53L0X_Error VL53L0X_SetupSingleShot(RangingConfig_e rangingConfig, int nDev);
 VL53L0X_Error VL53L0X_PerformSingleRanging(RangingConfig_e rangingConfig, int nDev);

 VL53L0X_Error VL53L0X_StartMeasurementWaitExtInt(RangingConfig_e rangingConfig, int nDev);

 void VL53L0X_InitializeContinuousRanging(int nDevNum );
 VL53L0X_Error VL53L0X_SetUpInterrupt(int nDevNum, int alarmMode);
 VL53L0X_Error VL53L0X_InterruptHandler(int nDevNum);
 void          VL53L0X_StopContinuousRanging(int nDevNum);

 VL53L0X_Error VL53L0X_WaitStopCompleted(VL53L0X_DEV Dev);
 void          VL53L0X_Sensor_SetNewRange(VL53L0X_Dev_t *pDev, VL53L0X_RangingMeasurementData_t *pRange);

#ifdef __cplusplus
}
#endif
#endif /*__VL53L0X_DistanceSensor_H */
