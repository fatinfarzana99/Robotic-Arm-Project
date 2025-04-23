/**
  ******************************************************************************
  * @file    sd_card.c
  * @brief   This file provides code for the SD Card.
  ******************************************************************************
  */

/* Includes ------------------------------------------------------------------*/
#include "sd_card.h"

// variables for FatFs
FATFS FatFs;  //Fatfs handle
FIL fil;   //File handle
FRESULT fres;   //Result after operations

//statistics from the SD card
DWORD free_clusters, free_sectors, total_sectors;
FATFS* getFreeFs;

// for read 50 bytes from file on the SD card
 BYTE readBuf[51];

void myprintf(const char *fmt, ...)
{
    static char buffer[256];
    va_list args;
    va_start(args, fmt);
    vsnprintf(buffer, sizeof(buffer), fmt, args);
    va_end(args);

    int len = strlen(buffer);
    HAL_UART_Transmit(&huart3, (uint8_t*)buffer, len, -1);
}

void sd_mount(void)
{
    myprintf("\r\n~ SD card demo by kiwih ~\r\n\r\n");
    HAL_Delay(1000); //a short delay is important to let the SD card settle

    // Open the file system
    fres = f_mount(&FatFs, "", 1); // 1 = mount now
    if (fres != FR_OK)
    {
     myprintf("f_mount error (status = %i)\r\n", fres);
     // while(1);
    }
    else
    {
     myprintf("f_mounted (status = %i)\r\n", fres);
    }
}

void sd_get_free(void)
{
 fres = f_getfree("", &free_clusters, &getFreeFs);
 if (fres != FR_OK)
 {
  myprintf("f_getfree error (status = %i)\r\n", fres);
  // while(1);
 }
 else
 {
  myprintf("f_getfree clusters (status = %i)\r\n", fres);
 }

 // Formula comes from ChaN's documentation
 total_sectors = (getFreeFs->n_fatent - 2) * getFreeFs->csize;
 free_sectors = free_clusters * getFreeFs->csize;

 myprintf("SD card status:\r\n%10lu KB total drive space.\r\n%10lu KB available.\r\n",
                                          total_sectors / 2, free_sectors / 2);
}

void sd_open_file(void)
{
 // open file "GROUP5.txt"
 fres = f_open(&fil, "GROUP5.txt", FA_WRITE | FA_CREATE_ALWAYS);
 if (fres != FR_OK)
 {
  myprintf("f_open error (status = %i)\r\n");
  // while(1);
 }
 else
 {
  myprintf("f_opened (status = %i)\r\n");
 }
 myprintf("I was able to create 'GROUP5.txt' !\r\n");


 strncpy((char*)readBuf, "MCU Temp(degC) | Current(mA) | Power(mW)\n", 43);
 UINT bytesWrote;
 fres = f_write(&fil, readBuf, 41, &bytesWrote);
 if(fres == FR_OK)
 {
  myprintf("Wrote %i bytes to 'GROUP5.txt'!\r\n", bytesWrote);
 }
 else
 {
  myprintf("f_write error (status = %i)\r\n");
 }

 // close file
 f_close(&fil);
}

void sd_write_file(float t, float c, int p)
{
 // write a file "GROUP5.txt"
 fres = f_open(&fil, "GROUP5.txt", FA_WRITE | FA_OPEN_APPEND);
 if(fres == FR_OK)
 {
  myprintf("I was able to open 'GROUP5.txt' for writing\r\n");
 }
 else
 {
  myprintf("f_open error (status = %i)\r\n", fres);
 }

 float temperature = t;
 float current = c;
 int power = p;

 memset(readBuf, 0, sizeof(readBuf));
 snprintf((char*)readBuf,sizeof(readBuf), "  %6.2f         %7.2f        %ld\n",temperature, current, power);
 readBuf[sizeof(readBuf) - 1] = '\0';
 UINT bytesWrote;
 fres = f_write(&fil, readBuf, 37, &bytesWrote);
 if(fres == FR_OK)
 {
  myprintf("Wrote %i bytes to 'GROUP5.txt'!\r\n", bytesWrote);
 }
 else
 {
  myprintf("f_write error (status = %i)\r\n");
 }

 // close file
 f_close(&fil);
}

void sd_de_mount(void)
{
    // de-mount the drive
    f_mount(NULL, "", 0);
    myprintf("SD de-mounted.\r\n");
}

/****END OF FILE****/
