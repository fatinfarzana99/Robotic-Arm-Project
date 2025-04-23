/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.h
  * @brief          : Header for main.c file.
  *                   This file contains the common defines of the application.
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

/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef __MAIN_H
#define __MAIN_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include "stm32h7xx_hal.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */

/* USER CODE END Includes */

/* Exported types ------------------------------------------------------------*/
/* USER CODE BEGIN ET */

/* USER CODE END ET */

/* Exported constants --------------------------------------------------------*/
/* USER CODE BEGIN EC */

/* USER CODE END EC */

/* Exported macro ------------------------------------------------------------*/
/* USER CODE BEGIN EM */

/* USER CODE END EM */

/* Exported functions prototypes ---------------------------------------------*/
void Error_Handler(void);

/* USER CODE BEGIN EFP */

/* USER CODE END EFP */

/* Private defines -----------------------------------------------------------*/
#define DIST1_IRQ_Pin GPIO_PIN_2
#define DIST1_IRQ_GPIO_Port GPIOE
#define DIST1_IRQ_EXTI_IRQn EXTI2_IRQn
#define DIST2_IRQ_Pin GPIO_PIN_3
#define DIST2_IRQ_GPIO_Port GPIOE
#define DIST2_IRQ_EXTI_IRQn EXTI3_IRQn
#define DIST3_IRQ_Pin GPIO_PIN_4
#define DIST3_IRQ_GPIO_Port GPIOE
#define DIST3_IRQ_EXTI_IRQn EXTI4_IRQn
#define SV1_PWM_T15C1_Pin GPIO_PIN_5
#define SV1_PWM_T15C1_GPIO_Port GPIOE
#define SV2_PWM_T15C2_Pin GPIO_PIN_6
#define SV2_PWM_T15C2_GPIO_Port GPIOE
#define USR_BTN_IRQ_Pin GPIO_PIN_13
#define USR_BTN_IRQ_GPIO_Port GPIOC
#define USR_BTN_IRQ_EXTI_IRQn EXTI15_10_IRQn
#define OSC32_IN_Pin GPIO_PIN_14
#define OSC32_IN_GPIO_Port GPIOC
#define OSC32_OUT_Pin GPIO_PIN_15
#define OSC32_OUT_GPIO_Port GPIOC
#define SV5_PWM_T16C1_Pin GPIO_PIN_6
#define SV5_PWM_T16C1_GPIO_Port GPIOF
#define SV3_PWM_T17C1_Pin GPIO_PIN_7
#define SV3_PWM_T17C1_GPIO_Port GPIOF
#define SV4_PWM_T13C1_Pin GPIO_PIN_8
#define SV4_PWM_T13C1_GPIO_Port GPIOF
#define SV7_PWM_T14C1_Pin GPIO_PIN_9
#define SV7_PWM_T14C1_GPIO_Port GPIOF
#define PH0_MCU_Pin GPIO_PIN_0
#define PH0_MCU_GPIO_Port GPIOH
#define LCD_SPI2_MOSI_Pin GPIO_PIN_1
#define LCD_SPI2_MOSI_GPIO_Port GPIOC
#define W1_DIR_Pin GPIO_PIN_2
#define W1_DIR_GPIO_Port GPIOC
#define W2_DIR_Pin GPIO_PIN_3
#define W2_DIR_GPIO_Port GPIOC
#define W1_PWM_T2C1_Pin GPIO_PIN_0
#define W1_PWM_T2C1_GPIO_Port GPIOA
#define W2_PWM_T2C2_Pin GPIO_PIN_1
#define W2_PWM_T2C2_GPIO_Port GPIOA
#define W3_PWM_T2C3_Pin GPIO_PIN_2
#define W3_PWM_T2C3_GPIO_Port GPIOA
#define W4_PWM_T2C4_Pin GPIO_PIN_3
#define W4_PWM_T2C4_GPIO_Port GPIOA
#define SD_SPI1_SCK_Pin GPIO_PIN_5
#define SD_SPI1_SCK_GPIO_Port GPIOA
#define SD_SPI1_MISO_Pin GPIO_PIN_6
#define SD_SPI1_MISO_GPIO_Port GPIOA
#define SD_SPI1_MOSI_Pin GPIO_PIN_7
#define SD_SPI1_MOSI_GPIO_Port GPIOA
#define LD1_GREEN_OB_Pin GPIO_PIN_0
#define LD1_GREEN_OB_GPIO_Port GPIOB
#define LCD_RST_Pin GPIO_PIN_1
#define LCD_RST_GPIO_Port GPIOB
#define LCD_CS_Pin GPIO_PIN_11
#define LCD_CS_GPIO_Port GPIOF
#define DIST_I2C4_SCL_Pin GPIO_PIN_14
#define DIST_I2C4_SCL_GPIO_Port GPIOF
#define DIST_I2C4_SDA_Pin GPIO_PIN_15
#define DIST_I2C4_SDA_GPIO_Port GPIOF
#define DIST1_XSHUT_Pin GPIO_PIN_7
#define DIST1_XSHUT_GPIO_Port GPIOE
#define DIST2_XSHUT_Pin GPIO_PIN_8
#define DIST2_XSHUT_GPIO_Port GPIOE
#define DIST3_XSHUT_Pin GPIO_PIN_9
#define DIST3_XSHUT_GPIO_Port GPIOE
#define LD2_BLUE_SHLD_Pin GPIO_PIN_10
#define LD2_BLUE_SHLD_GPIO_Port GPIOE
#define W1_ENC_T1C2_INB_Pin GPIO_PIN_11
#define W1_ENC_T1C2_INB_GPIO_Port GPIOE
#define DIP_SW1_Pin GPIO_PIN_12
#define DIP_SW1_GPIO_Port GPIOE
#define DIP_SW2_Pin GPIO_PIN_13
#define DIP_SW2_GPIO_Port GPIOE
#define DIP_SW3_Pin GPIO_PIN_14
#define DIP_SW3_GPIO_Port GPIOE
#define DIP_SW4_Pin GPIO_PIN_15
#define DIP_SW4_GPIO_Port GPIOE
#define CUR_I2C2_SCL_Pin GPIO_PIN_10
#define CUR_I2C2_SCL_GPIO_Port GPIOB
#define CUR_I2C2_SDA_Pin GPIO_PIN_11
#define CUR_I2C2_SDA_GPIO_Port GPIOB
#define LD3_RED_OB_Pin GPIO_PIN_14
#define LD3_RED_OB_GPIO_Port GPIOB
#define SV8_PWM_T12C2_Pin GPIO_PIN_15
#define SV8_PWM_T12C2_GPIO_Port GPIOB
#define DBG_USART3_TX_Pin GPIO_PIN_8
#define DBG_USART3_TX_GPIO_Port GPIOD
#define DBG_USART3_RX_Pin GPIO_PIN_9
#define DBG_USART3_RX_GPIO_Port GPIOD
#define W3_ENC_T4C1_INA_Pin GPIO_PIN_12
#define W3_ENC_T4C1_INA_GPIO_Port GPIOD
#define W3_ENC_T4C2_INB_Pin GPIO_PIN_13
#define W3_ENC_T4C2_INB_GPIO_Port GPIOD
#define LD1_GREEN_SHLD_Pin GPIO_PIN_6
#define LD1_GREEN_SHLD_GPIO_Port GPIOG
#define IMU_RST_Pin GPIO_PIN_8
#define IMU_RST_GPIO_Port GPIOG
#define W4_ENC_T8C1_INA_Pin GPIO_PIN_6
#define W4_ENC_T8C1_INA_GPIO_Port GPIOC
#define W4_ENC_T8C2_INB_Pin GPIO_PIN_7
#define W4_ENC_T8C2_INB_GPIO_Port GPIOC
#define W1_ENC_T1C1_INA_Pin GPIO_PIN_8
#define W1_ENC_T1C1_INA_GPIO_Port GPIOA
#define DBG_SWDIO_Pin GPIO_PIN_13
#define DBG_SWDIO_GPIO_Port GPIOA
#define DBG_SWCLK_Pin GPIO_PIN_14
#define DBG_SWCLK_GPIO_Port GPIOA
#define W3_DIR_Pin GPIO_PIN_10
#define W3_DIR_GPIO_Port GPIOC
#define W4_DIR_Pin GPIO_PIN_11
#define W4_DIR_GPIO_Port GPIOC
#define IMU_SCL_SPI6_SCK_Pin GPIO_PIN_12
#define IMU_SCL_SPI6_SCK_GPIO_Port GPIOC
#define IMU_P1_Pin GPIO_PIN_2
#define IMU_P1_GPIO_Port GPIOD
#define LCD_SPI2_SCK_Pin GPIO_PIN_3
#define LCD_SPI2_SCK_GPIO_Port GPIOD
#define IMU_P0_WAKEN_Pin GPIO_PIN_4
#define IMU_P0_WAKEN_GPIO_Port GPIOD
#define WIFI_USART2_TX_Pin GPIO_PIN_5
#define WIFI_USART2_TX_GPIO_Port GPIOD
#define WIFI_USART2_RX_Pin GPIO_PIN_6
#define WIFI_USART2_RX_GPIO_Port GPIOD
#define IMU_BT_Pin GPIO_PIN_7
#define IMU_BT_GPIO_Port GPIOD
#define IMU_INT_IRQ_Pin GPIO_PIN_9
#define IMU_INT_IRQ_GPIO_Port GPIOG
#define IMU_INT_IRQ_EXTI_IRQn EXTI9_5_IRQn
#define IMU_CS_Pin GPIO_PIN_10
#define IMU_CS_GPIO_Port GPIOG
#define IMU_SDA_SPI6_MISO_Pin GPIO_PIN_12
#define IMU_SDA_SPI6_MISO_GPIO_Port GPIOG
#define IMU_DI_SPI6_MOSI_Pin GPIO_PIN_14
#define IMU_DI_SPI6_MOSI_GPIO_Port GPIOG
#define DBG_SWO_Pin GPIO_PIN_3
#define DBG_SWO_GPIO_Port GPIOB
#define W2_ENC_T3C1_INA_Pin GPIO_PIN_4
#define W2_ENC_T3C1_INA_GPIO_Port GPIOB
#define W2_ENC_T3C2_INB_Pin GPIO_PIN_5
#define W2_ENC_T3C2_INB_GPIO_Port GPIOB
#define SD_CS_Pin GPIO_PIN_6
#define SD_CS_GPIO_Port GPIOB
#define LCD_CTRL_RS_Pin GPIO_PIN_0
#define LCD_CTRL_RS_GPIO_Port GPIOE
#define LD2_YELLOW_OB_Pin GPIO_PIN_1
#define LD2_YELLOW_OB_GPIO_Port GPIOE

/* USER CODE BEGIN Private defines */
#ifdef DEBUG
    #define TRACE   printf
#else
    inline  void   PrintfEmpty( const char * string, ... ) __attribute__((always_inline));
    inline  void   PrintfEmpty( const char * string, ... ){}
    #define TRACE  PrintfEmpty
#endif

typedef int      BOOL;

#define TRUE     1
#define FALSE    0

#define ASSERT   assert_param/* Using cubemx assert function if enabled */

#define MIN( a, b )(((a)<(b))? (a) : (b))
#define MAX( a, b )(((a)<(b))? (b) : (a))

#define PI       3.141592653589793

#define SD_SPI_HANDLE hspi1

#define NUMBER_OF_DATA    50


typedef struct INA219_STRUCT
{
    int32_t shunt_voltage;  // in [uV]
    int32_t bus_voltage;    // in [mV]
    int32_t current;        // in [x0.1 mA]
    int32_t power;          // in [mW]
} INA219;

typedef struct VL53L0X_STRUCT
{                                  // refer data structure: VL53L0X_RangingMeasurementData_t
    uint32_t  TimeStamp[3];        // 32-bit time stamp
    uint8_t   RangeStatus[3];
    uint16_t  RangeMilliMeter[3];  // mm, range distance in millimeter
    uint32_t  SignalRateRtnMegaCps[3];
    uint32_t  AmbientRateRtnMegaCps[3];
    uint16_t  EffectiveSpadRtnCount[3];
    uint16_t  RangeDMaxMilliMeter[3];
} VL53L0X;

typedef struct SERVO_POSITION_STRUCT
{
    // for all the 8 servo motors
    int32_t jointAngle[8];            // joint angle, 180.00 deg = 18000, unit is (deg x 100)
    int32_t jointAnglePlusLimit[8];   // joint angle, 180.00 deg = 18000, unit is (deg x 100)
    int32_t jointAngleMinusLimit[8];  // joint angle, 180.00 deg = 18000, unit is (deg x 100)
    int32_t jointAngleOffset[8];      // offset of joint angle,           unit is (deg x 100)
    int32_t jointAngleDir[8];         // dir of joint angle, -1 for diff btw actual & joint angles
} SERVO_POS;

typedef struct SERVO_PWM_STRUCT
{
    uint16_t currentPwm[8]; // current PWM in (x100 %)
} SERVO_PWM;

typedef struct MOTOR_PWM_STRUCT
{
    double dDutyCycPercentAL; // % duty cycle of PWM for mtr 1
    double dDutyCycPercentBR; // % duty cycle of PWM for mtr 2
} MOTOR_PWM;

typedef struct ENCODER_STRUCT
{
    // for each wheel encoder (at t0) and previous sampled data (at t-1, t-2, t-3, t-4)
    int16_t mtrCnt16AL[5]; // motor encoder count: c[0] = current (k), c[1] = previous (k-1),
    int16_t mtrCnt16BR[5]; // c[2] = previous (k-2), c[3] = previous (k-3), ...
    int32_t mtrVel32AL[5]; // motor velocity: AL = motor A, left side (in forward/heading dir)
    int32_t mtrVel32BR[5]; //                 BR = motor B, right side
} ENCODER;

typedef struct VEHICLE_STRUCT
{
    double  dWheelVelAL;
    double  dWheelVelBR;
    double  dPosX;     // vehicle position in x-direction w.r.t. a reference point (Xr, Yr, Tr)
    double  dPosY;     // vehicle position in y-direction w.r.t. a reference point (Xr, Yr, Tr)
    double  dAngle;    // vehicle orientation angle or theta
    double  dVelX;     // vehicle velocity in x-direction                      (Tr is theta_r)
    double  dVelY;     // vehicle velocity in y-direction
    double  dVelAngle; // vehicle angular velocity (Yaw)
    int32_t flag;
} VEHICLE;

// Based on sh2_RotationVectorWAcc
typedef struct BNO085_STRUCT
{
	uint64_t  timestamp_uS;  /**< [uS] */
    float     real;       /**< @brief Quaternion component, real */
    float     i;          /**< @brief Quaternion component i */
    float     j;          /**< @brief Quaternion component j */
    float     k;          /**< @brief Quaternion component k */
    float     accuracy;   /**< @brief Accuracy estimate [radians] */
} BNO085;

typedef struct ROBOT_STRUCT
{
	BNO085         dataBNO085;
    INA219         dataINA219;
    VL53L0X        dataVL53L0X;
    SERVO_POS      dataSrvPos;
    SERVO_PWM      dataSrvPwm;
    MOTOR_PWM      dataMtrPwm;
    ENCODER        dataEncoder;
    VEHICLE        dataVehicle;
    uint8_t        dipSwValue;
    uint32_t       mcuTempU32;
} ROBOT;
/* USER CODE END Private defines */

#ifdef __cplusplus
}
#endif

#endif /* __MAIN_H */
