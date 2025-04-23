/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
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
#include "main.h"
#include "cmsis_os.h"
#include "adc.h"
#include "crc.h"
#include "fatfs.h"
#include "i2c.h"
#include "spi.h"
#include "tim.h"
#include "usart.h"
#include "gpio.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include "command.h"
#include "actuator.h"
#include <stdio.h>
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */

/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/

/* USER CODE BEGIN PV */
ROBOT robot = {0};
CMD_HANDLE g_CmdHandle;
/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
void MX_FREERTOS_Init(void);
/* USER CODE BEGIN PFP */

/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */

/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{
  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_USART3_UART_Init();
  MX_SPI1_Init();
  MX_USART2_UART_Init();
  MX_I2C2_Init();
  MX_I2C4_Init();
  MX_SPI2_Init();
  MX_FATFS_Init();
  MX_ADC2_Init();
  MX_CRC_Init();
  MX_SPI6_Init();
  MX_TIM1_Init();
  MX_TIM2_Init();
  MX_TIM3_Init();
  MX_TIM4_Init();
  MX_TIM5_Init();
  MX_TIM8_Init();
  MX_TIM12_Init();
  MX_TIM13_Init();
  MX_TIM14_Init();
  MX_TIM15_Init();
  MX_TIM16_Init();
  MX_TIM17_Init();
  /* USER CODE BEGIN 2 */
  // start encoder reading, motor 1 and motor 2
  HAL_TIM_Encoder_Start(&E1_TIM, TIM_CHANNEL_ALL);
  HAL_TIM_Encoder_Start(&E2_TIM, TIM_CHANNEL_ALL);
  // HAL_TIM_Encoder_Start(&E3_TIM, TIM_CHANNEL_ALL);
  // HAL_TIM_Encoder_Start(&E4_TIM, TIM_CHANNEL_ALL);

  // enable/start motor PWM outputs, motor 1 and 2 -> timer 15-1, 15-2
  HAL_TIM_PWM_Start(&M1_TIM,M1_CHANNEL);
  HAL_TIM_PWM_Start(&M2_TIM,M2_CHANNEL);
  // enable/start servo PWM outputs, servo 1,2,3,4,5,6,7,8
  HAL_TIM_PWM_Start(&S1_TIM,S1_CHANNEL); //servo 1, index[0] base link 1
  HAL_TIM_PWM_Start(&S2_TIM,S2_CHANNEL); //servo 2, index[1] link 2
  HAL_TIM_PWM_Start(&S3_TIM,S3_CHANNEL); //servo 3, index[2] rotate
  HAL_TIM_PWM_Start(&S4_TIM,S4_CHANNEL); //servo 4, index[3] gripper
  HAL_TIM_PWM_Start(&S5_TIM,S5_CHANNEL); //servo 5, index[4] not used
  // HAL_TIM_PWM_Start(&S6_TIM,S6_CHANNEL); //servo 6, index[5] not implemented
  HAL_TIM_PWM_Start(&S7_TIM,S7_CHANNEL); //servo 7, index[6] Camera pan
  HAL_TIM_PWM_Start(&S8_TIM,S8_CHANNEL); //servo 8, index[7] camera tilt
  // Dip switch value
  robot.dipSwValue = 0;
  if( HAL_GPIO_ReadPin(GPIOE, DIP_SW1_Pin) == GPIO_PIN_SET ) robot.dipSwValue = 1;
  if( HAL_GPIO_ReadPin(GPIOE, DIP_SW2_Pin) == GPIO_PIN_SET ) robot.dipSwValue += 2;
  if( HAL_GPIO_ReadPin(GPIOE, DIP_SW3_Pin) == GPIO_PIN_SET ) robot.dipSwValue += 4;
  if( HAL_GPIO_ReadPin(GPIOE, DIP_SW4_Pin) == GPIO_PIN_SET ) robot.dipSwValue += 8;
  printf("\r\nDIP_SW = %d\r\n", robot.dipSwValue);
  // WiFi Serial to net command initialization
  // initial here as more than one tasks need to access Command
  CommandInit( &g_CmdHandle, &huart2 );
  printf("\r\nRobot Command Interpreter is initialized.\r\n");
  // set PWM values in CommandInit() for robot estimated zero positions
  // set joint offset, direction, plus and minus limits
  robot.dataSrvPos.jointAngleOffset[0] = 9000; // 9000 = 90.00 degree, joint 1, lower arm
  robot.dataSrvPos.jointAngleDir[0] = -1; // +1 or -1
  robot.dataSrvPos.jointAnglePlusLimit[0] = 9000;
  robot.dataSrvPos.jointAngleMinusLimit[0] = -5000;
  robot.dataSrvPos.jointAngleOffset[1] = 17000; // joint 2, upper arm
  robot.dataSrvPos.jointAngleDir[1] = -1;
  robot.dataSrvPos.jointAnglePlusLimit[1] = 13500;
  robot.dataSrvPos.jointAngleMinusLimit[1] = -500;
  robot.dataSrvPos.jointAngleOffset[2] = 11000; // rotate gripper
  robot.dataSrvPos.jointAngleDir[2] = 1;
  robot.dataSrvPos.jointAnglePlusLimit[2] = 6000;
  robot.dataSrvPos.jointAngleMinusLimit[2] = -6000;
  robot.dataSrvPos.jointAngleOffset[3] = 6000; //gripper
  robot.dataSrvPos.jointAngleDir[3] = -1;
  robot.dataSrvPos.jointAnglePlusLimit[3] = 4000;
  robot.dataSrvPos.jointAngleMinusLimit[3] = 0;
  robot.dataSrvPos.jointAngleOffset[4] = 0;
  robot.dataSrvPos.jointAngleDir[4] = 1;
  robot.dataSrvPos.jointAnglePlusLimit[4] = 0;
  robot.dataSrvPos.jointAngleMinusLimit[4] = 0;
  robot.dataSrvPos.jointAngleOffset[5] = 0;
  robot.dataSrvPos.jointAngleDir[5] = 1;
  robot.dataSrvPos.jointAnglePlusLimit[5] = 0;
  robot.dataSrvPos.jointAngleMinusLimit[5] = 0;
  robot.dataSrvPos.jointAngleOffset[6] = 9000; // pan
  robot.dataSrvPos.jointAngleDir[6] = 1;
  robot.dataSrvPos.jointAnglePlusLimit[6] = 6000;
  robot.dataSrvPos.jointAngleMinusLimit[6] = -6000;
  robot.dataSrvPos.jointAngleOffset[7] = 9000; // title
  robot.dataSrvPos.jointAngleDir[7] = 1;
  robot.dataSrvPos.jointAnglePlusLimit[7] = 6000;
  robot.dataSrvPos.jointAngleMinusLimit[7] = -6000;
  // For each joint, set zero joint position after offset adjustment
  for (int i = 0; i < 8; i++)
  {
  robot.dataSrvPos.jointAngle[i] = 0;
  g_CmdHandle.TargetPwm[i].Value = ServoJointAngleToPWM( i+1, robot.dataSrvPos.jointAngle[i] );
  robot.dataSrvPwm.currentPwm[i] = g_CmdHandle.TargetPwm[i].Value;
  ServoSetDuty( i+1, robot.dataSrvPwm.currentPwm[i]);
  }
  /* USER CODE END 2 */

  /* Init scheduler */
  osKernelInitialize();

  /* Call init function for freertos objects (in freertos.c) */
  MX_FREERTOS_Init();

  /* Start scheduler */
  osKernelStart();

  /* We should never get here as control is now taken by the scheduler */
  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  while (1)
  {
    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */
  }
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};

  /*AXI clock gating */
  RCC->CKGAENR = 0xFFFFFFFF;

  /** Supply configuration update enable
  */
  HAL_PWREx_ConfigSupply(PWR_DIRECT_SMPS_SUPPLY);

  /** Configure the main internal regulator output voltage
  */
  __HAL_PWR_VOLTAGESCALING_CONFIG(PWR_REGULATOR_VOLTAGE_SCALE0);

  while(!__HAL_PWR_GET_FLAG(PWR_FLAG_VOSRDY)) {}

  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSE;
  RCC_OscInitStruct.HSEState = RCC_HSE_BYPASS;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSE;
  RCC_OscInitStruct.PLL.PLLM = 1;
  RCC_OscInitStruct.PLL.PLLN = 70;
  RCC_OscInitStruct.PLL.PLLP = 2;
  RCC_OscInitStruct.PLL.PLLQ = 5;
  RCC_OscInitStruct.PLL.PLLR = 2;
  RCC_OscInitStruct.PLL.PLLRGE = RCC_PLL1VCIRANGE_3;
  RCC_OscInitStruct.PLL.PLLVCOSEL = RCC_PLL1VCOWIDE;
  RCC_OscInitStruct.PLL.PLLFRACN = 0;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }

  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2
                              |RCC_CLOCKTYPE_D3PCLK1|RCC_CLOCKTYPE_D1PCLK1;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.SYSCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_HCLK_DIV1;
  RCC_ClkInitStruct.APB3CLKDivider = RCC_APB3_DIV2;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_APB1_DIV2;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_APB2_DIV2;
  RCC_ClkInitStruct.APB4CLKDivider = RCC_APB4_DIV2;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_6) != HAL_OK)
  {
    Error_Handler();
  }
}

/* USER CODE BEGIN 4 */

/* USER CODE END 4 */

/**
  * @brief  Period elapsed callback in non blocking mode
  * @note   This function is called  when TIM7 interrupt took place, inside
  * HAL_TIM_IRQHandler(). It makes a direct call to HAL_IncTick() to increment
  * a global variable "uwTick" used as application time base.
  * @param  htim : TIM handle
  * @retval None
  */
void HAL_TIM_PeriodElapsedCallback(TIM_HandleTypeDef *htim)
{
  /* USER CODE BEGIN Callback 0 */

  /* USER CODE END Callback 0 */
  if (htim->Instance == TIM7) {
    HAL_IncTick();
  }
  /* USER CODE BEGIN Callback 1 */

  /* USER CODE END Callback 1 */
}

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  __disable_irq();
  while (1)
  {
  }
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */
