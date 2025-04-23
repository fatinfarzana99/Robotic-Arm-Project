################################################################################
# Automatically-generated file. Do not edit!
# Toolchain: GNU Tools for STM32 (11.3.rel1)
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../Drivers/GUI/GUIConf.c \
../Drivers/GUI/GUIDRV_X.c \
../Drivers/GUI/GUI_X_OS.c \
../Drivers/GUI/LCDConf_FlexColor.c \
../Drivers/GUI/LCD_ILI9225DS.c 

OBJS += \
./Drivers/GUI/GUIConf.o \
./Drivers/GUI/GUIDRV_X.o \
./Drivers/GUI/GUI_X_OS.o \
./Drivers/GUI/LCDConf_FlexColor.o \
./Drivers/GUI/LCD_ILI9225DS.o 

C_DEPS += \
./Drivers/GUI/GUIConf.d \
./Drivers/GUI/GUIDRV_X.d \
./Drivers/GUI/GUI_X_OS.d \
./Drivers/GUI/LCDConf_FlexColor.d \
./Drivers/GUI/LCD_ILI9225DS.d 


# Each subdirectory must supply rules for building sources it contributes
Drivers/GUI/%.o Drivers/GUI/%.su Drivers/GUI/%.cyclo: ../Drivers/GUI/%.c Drivers/GUI/subdir.mk
	arm-none-eabi-gcc "$<" -mcpu=cortex-m7 -std=gnu11 -g3 -DDEBUG -DUSE_HAL_DRIVER -DSTM32H7A3xxQ -c -I../Core/Inc -I../Drivers/GUI -I../Drivers/BNO085_SPI -I../Drivers/GUI/inc -I../Drivers/VL53L0X -I../Drivers/STM32H7xx_HAL_Driver/Inc -I../Drivers/STM32H7xx_HAL_Driver/Inc/Legacy -I../Drivers/CMSIS/Device/ST/STM32H7xx/Include -I../Drivers/CMSIS/Include -I../FATFS/Target -I../FATFS/App -I../Middlewares/Third_Party/FreeRTOS/Source/include -I../Middlewares/Third_Party/FreeRTOS/Source/CMSIS_RTOS_V2 -I../Middlewares/Third_Party/FreeRTOS/Source/portable/GCC/ARM_CM4F -I../Middlewares/Third_Party/FatFs/src -O0 -ffunction-sections -fdata-sections -Wall -fstack-usage -fcyclomatic-complexity -MMD -MP -MF"$(@:%.o=%.d)" -MT"$@" --specs=nano.specs -mfpu=fpv5-d16 -mfloat-abi=hard -mthumb -o "$@"

clean: clean-Drivers-2f-GUI

clean-Drivers-2f-GUI:
	-$(RM) ./Drivers/GUI/GUIConf.cyclo ./Drivers/GUI/GUIConf.d ./Drivers/GUI/GUIConf.o ./Drivers/GUI/GUIConf.su ./Drivers/GUI/GUIDRV_X.cyclo ./Drivers/GUI/GUIDRV_X.d ./Drivers/GUI/GUIDRV_X.o ./Drivers/GUI/GUIDRV_X.su ./Drivers/GUI/GUI_X_OS.cyclo ./Drivers/GUI/GUI_X_OS.d ./Drivers/GUI/GUI_X_OS.o ./Drivers/GUI/GUI_X_OS.su ./Drivers/GUI/LCDConf_FlexColor.cyclo ./Drivers/GUI/LCDConf_FlexColor.d ./Drivers/GUI/LCDConf_FlexColor.o ./Drivers/GUI/LCDConf_FlexColor.su ./Drivers/GUI/LCD_ILI9225DS.cyclo ./Drivers/GUI/LCD_ILI9225DS.d ./Drivers/GUI/LCD_ILI9225DS.o ./Drivers/GUI/LCD_ILI9225DS.su

.PHONY: clean-Drivers-2f-GUI

