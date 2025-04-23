/**
  ******************************************************************************
  * @file    sd_card.h
  * @brief   This file contains all the function prototypes for
  *          the sd_card.c file
  ******************************************************************************
  */
/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef __SD_CARD_H__
#define __SD_CARD_H__
#ifdef __cplusplus
extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "fatfs.h"
#include "usart.h"
#include <stdio.h>
#include <string.h>
#include <stdarg.h> //for va_list var arg functions

// extern uint32_t flag_count;

void myprintf(const char *fmt, ...);
void sd_mount(void);
void sd_get_free(void);
void sd_open_file(void);
void sd_write_file(float, float, int);
void sd_de_mount(void);

#ifdef __cplusplus
}
#endif
#endif /*__SD_CARD_H__ */

/****END OF FILE****/
