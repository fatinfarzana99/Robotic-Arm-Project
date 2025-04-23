/**
  ******************************************************************************
  * File Name          : INA219.c
  * Description        : This file provides code for the configuration
  *                      of the INA219 device
  ******************************************************************************
  * @attention
  *
  * Written by Liaw Hwee Choo, 09 September 2021
  *
  ******************************************************************************
  */

/* Includes ------------------------------------------------------------------*/
#include "ina219.h"
#include <stdio.h>
/** default I2C address **/
// 7-bit address = 0x40  // 0x40 -> 64  (dec),  100 0000 (A0+A1=GND)
// 8-bit address = 0x80  // 0x80 -> 128 (dec), 1000 0000
// program uses 8-bit address
#define I2C_ADDRESS ((uint16_t) 0x80)

// register pointer
#define I2C_CONFIG_REG      ((uint8_t) 0x00)
#define I2C_SHUNT_VOLT_REG  ((uint8_t) 0x01)
#define I2C_BUS_VOLT_REG    ((uint8_t) 0x02)
#define I2C_POWER_REG       ((uint8_t) 0x03)
#define I2C_CURRENT_REG     ((uint8_t) 0x04)
#define I2C_CAL_REG         ((uint8_t) 0x05)

I2C_HandleTypeDef *phi2c = &hi2c2; // use i2c channel 2

// INA219 configuration:
// RST = 1   // to reset, RST = 0, self-clears after reset or after power-on
// BRNG = 1, 32 V FSR (default) (Bus voltage range)(FSR = Full Scale Range)
// PG1 PG0 = 1  1   -> Gain is /8 , range = +/- 320mV  (default)
// 12-bit, 532 usec, for BADC & SADC = 0 0 1 1        (default)
// Shunt and bus, continuous, Mode = 1 1 1            (default)
//
// Configuration value = 0 0 1 1 1 0 0 1 1 0 0 1 1 1 1 1 = 0x399F  (default)
//
// Shunt_Voltage_LSB    = 10 uV
// Bus_volatge_LSB      = 4 mV
//
// with Rshunt = 0.1 ohm and current_LSB = 0.1 mA
// Calibration register = 4096 (0x1000)
// current_LSB          = 0.1 mA
// power_LSB = 20 * 0.1 = 2 mW
//
//  Shunt voltage = (int) Shunt voltage register * 10 uV
//  Bus voltage   = (Bus voltage register >> 3)  * 4 mV = (Bus voltage register >> 1) mV
//  Current       = (int) Current register       * 0.1 mA
//  Power         = Power register               * 2 mW

// configuration data
#define CONFIG_DATA_HIGH    ((uint8_t) 0x39)
#define CONFIG_DATA_LOW     ((uint8_t) 0x9F)

// calibration data
#define CAL_DATA_HIGH       ((uint8_t) 0x10)
#define CAL_DATA_LOW        ((uint8_t) 0x00)

/* Buffer used for transmission and reception */
// uint8_t aTxData[3];
// uint8_t aRxData[2];

void INA219_Init(void)
{
	uint8_t aTxData[3];
	HAL_StatusTypeDef status;

    // INA219: configure
    // note that the below three bytes must be sent in one function - HAL_I2C_Master_Transmit()
    aTxData[0] = I2C_CONFIG_REG;
    aTxData[1] = CONFIG_DATA_HIGH;
    aTxData[2] = CONFIG_DATA_LOW;

    status = HAL_I2C_Master_Transmit(phi2c, (uint16_t)I2C_ADDRESS, (uint8_t*)aTxData, 3, 100);
    if(status != HAL_OK)
    {
 	    // Error_Handler();
    	printf("INA219 init TX1 error\r\n");
    }

    // INA219: program calibration register
    aTxData[0] = I2C_CAL_REG;
    aTxData[1] = CAL_DATA_HIGH;
    aTxData[2] = CAL_DATA_LOW;

    status = HAL_I2C_Master_Transmit(phi2c, (uint16_t)I2C_ADDRESS, (uint8_t*)aTxData, 3, 100);
    if(status != HAL_OK)
    {
   	    // Error_Handler();
        printf("INA219 init TX2 error\r\n");
    }
}

// unit is uV
int32_t INA219_shunt_voltage(void)
{
	uint16_t tmpUint16;
	int32_t tmpInt32;
	uint8_t aTxData[1];
	uint8_t aRxData[2];
	HAL_StatusTypeDef status;

    // shunt voltage = Shunt voltage register * 10 uV
	aTxData[0] = I2C_SHUNT_VOLT_REG;

	// set INA219 I2C internal register pointer
	status = HAL_I2C_Master_Transmit(phi2c, (uint16_t)I2C_ADDRESS, (uint8_t*)aTxData, 1, 100);
	if (status != HAL_OK)
	{
		printf("INA219 get shunt voltage TX error\r\n");
	}
	status = HAL_I2C_Master_Receive (phi2c, (uint16_t)I2C_ADDRESS, (uint8_t*)aRxData, 2, 100);
	if (status != HAL_OK)
	{
		printf("INA219 get shunt voltage RX error\r\n");
	}

	tmpUint16 = (aRxData[0] << 8) | aRxData[1];
	tmpInt32 = (int32_t)tmpUint16 * 10;
	// printf("\r\nShunt voltage = %d (%d uV) \r\n", tmpUint16, tmpInt*10);

	return tmpInt32;
}

// unit is mV
int32_t INA219_bus_voltage(void)
{
	uint16_t tmpUint16;
	int32_t tmpInt32;
	uint8_t aTxData[1];
	uint8_t aRxData[2];
	HAL_StatusTypeDef status;

   	//  Bus voltage   = Bus voltage register * 4 mV
	aTxData[0] = I2C_BUS_VOLT_REG;

	// set INA219 I2C internal register pointer
	status = HAL_I2C_Master_Transmit(phi2c, (uint16_t)I2C_ADDRESS, (uint8_t*)aTxData, 1, 100);
	if (status != HAL_OK)
	{
		printf("INA219 get bus voltage TX error\r\n");
	}
	status = HAL_I2C_Master_Receive (phi2c, (uint16_t)I2C_ADDRESS, (uint8_t*)aRxData, 2, 100);
	if (status != HAL_OK)
	{
		printf("INA219 get bus voltage RX error\r\n");
	}

	tmpUint16 = (( (aRxData[0] << 8) | aRxData[1] ) >> 3) & 0x1FFF;
	tmpInt32 = (int32_t)tmpUint16 * 4;

	// Above and below give slightly different results 10 mW diff.,52 mA below and 47 mA above
	// tmpUint16 = (( (aRxData[0] << 8) | aRxData[1] ) >> 1) & 0xEFFC;
	// tmpInt32 = (int32_t)tmpUint16;
	// printf("Bus voltage = %d (%d mV) \r\n", tmpUint16, tmpUint16*4);

	return tmpInt32;
}

// unit is 0.1 mA
int32_t INA219_current(void)
{
	uint16_t  tmpUint16;
	int32_t   tmpInt32;
	uint8_t   aTxData[1];
	uint8_t   aRxData[2];
	HAL_StatusTypeDef status;

	//  Current = Current register * 0.1 mA
	aTxData[0] = I2C_CURRENT_REG;

	// set INA219 I2C internal register pointer
	status = HAL_I2C_Master_Transmit(phi2c, (uint16_t)I2C_ADDRESS, (uint8_t*)aTxData, 1, 100);
	if (status != HAL_OK)
	{
		printf("INA219 get current TX error\r\n");
	}
	status = HAL_I2C_Master_Receive (phi2c, (uint16_t)I2C_ADDRESS, (uint8_t*)aRxData, 2, 100);
	if (status != HAL_OK)
	{
		printf("INA219 get current RX error\r\n");
	}
	tmpUint16 = (aRxData[0] << 8) | aRxData[1];
	tmpInt32 = (int32_t)tmpUint16;
	// printf("Current = %d ( * 0.1 mA) \r\n", tmpInt);

	return tmpInt32;
}

// unit is mW
int32_t INA219_power(void)
{
	uint16_t tmpUint16;
	int32_t tmpInt32;
	uint8_t aTxData[1];
	uint8_t aRxData[2];
	HAL_StatusTypeDef status;

	//  Power = Power register * 2 mW
	aTxData[0] = I2C_POWER_REG;

	// set INA219 I2C internal register pointer
	status = HAL_I2C_Master_Transmit(phi2c, (uint16_t)I2C_ADDRESS, (uint8_t*)aTxData, 1, 100);
	if (status != HAL_OK)
	{
		printf("INA219 get power TX error\r\n");
	}
	status = HAL_I2C_Master_Receive (phi2c, (uint16_t)I2C_ADDRESS, (uint8_t*)aRxData, 2, 100);
	if (status != HAL_OK)
	{
		printf("INA219 get power RX error\r\n");
	}

	tmpUint16 = (aRxData[0] << 8) | aRxData[1];
	tmpInt32 = (int32_t)tmpUint16 * 2;
	// printf("Power = %d ( %d mW) \r\n", tmpUint16, tmpUint16*2);

	return tmpInt32;
}


/****END OF FILE****/
