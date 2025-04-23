/**
  ******************************************************************************
  * File Name          : INA219.h
  * Description        : This file provides code for the configuration
  *                      of the INA219 device.
  ******************************************************************************
  * @attention
  *
  * Written by Liaw Hwee Choo, 09 September 2021
  *
  ******************************************************************************
  */
/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef __INA219_H__
#define __INA219_H__
#ifdef __cplusplus
extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "i2c.h"

void INA219_Init(void);
int32_t INA219_shunt_voltage(void);
int32_t INA219_bus_voltage(void);
int32_t INA219_current(void);
int32_t INA219_power(void);

#ifdef __cplusplus
}
#endif
#endif /*__INA219_H__ */

/****END OF FILE****/
