################################################################################
# Automatically-generated file. Do not edit!
# Toolchain: GNU Tools for STM32 (11.3.rel1)
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../Drivers/BNO085_SPI/sh2.c \
../Drivers/BNO085_SPI/sh2_SensorValue.c \
../Drivers/BNO085_SPI/sh2_util.c \
../Drivers/BNO085_SPI/shtp.c 

OBJS += \
./Drivers/BNO085_SPI/sh2.o \
./Drivers/BNO085_SPI/sh2_SensorValue.o \
./Drivers/BNO085_SPI/sh2_util.o \
./Drivers/BNO085_SPI/shtp.o 

C_DEPS += \
./Drivers/BNO085_SPI/sh2.d \
./Drivers/BNO085_SPI/sh2_SensorValue.d \
./Drivers/BNO085_SPI/sh2_util.d \
./Drivers/BNO085_SPI/shtp.d 


# Each subdirectory must supply rules for building sources it contributes
Drivers/BNO085_SPI/%.o Drivers/BNO085_SPI/%.su Drivers/BNO085_SPI/%.cyclo: ../Drivers/BNO085_SPI/%.c Drivers/BNO085_SPI/subdir.mk
	arm-none-eabi-gcc "$<" -mcpu=cortex-m7 -std=gnu11 -g3 -DDEBUG -DUSE_HAL_DRIVER -DSTM32H7A3xxQ -c -I../Core/Inc -I../Drivers/GUI -I../Drivers/BNO085_SPI -I../Drivers/GUI/inc -I../Drivers/VL53L0X -I../Drivers/STM32H7xx_HAL_Driver/Inc -I../Drivers/STM32H7xx_HAL_Driver/Inc/Legacy -I../Drivers/CMSIS/Device/ST/STM32H7xx/Include -I../Drivers/CMSIS/Include -I../FATFS/Target -I../FATFS/App -I../Middlewares/Third_Party/FreeRTOS/Source/include -I../Middlewares/Third_Party/FreeRTOS/Source/CMSIS_RTOS_V2 -I../Middlewares/Third_Party/FreeRTOS/Source/portable/GCC/ARM_CM4F -I../Middlewares/Third_Party/FatFs/src -O0 -ffunction-sections -fdata-sections -Wall -fstack-usage -fcyclomatic-complexity -MMD -MP -MF"$(@:%.o=%.d)" -MT"$@" --specs=nano.specs -mfpu=fpv5-d16 -mfloat-abi=hard -mthumb -o "$@"

clean: clean-Drivers-2f-BNO085_SPI

clean-Drivers-2f-BNO085_SPI:
	-$(RM) ./Drivers/BNO085_SPI/sh2.cyclo ./Drivers/BNO085_SPI/sh2.d ./Drivers/BNO085_SPI/sh2.o ./Drivers/BNO085_SPI/sh2.su ./Drivers/BNO085_SPI/sh2_SensorValue.cyclo ./Drivers/BNO085_SPI/sh2_SensorValue.d ./Drivers/BNO085_SPI/sh2_SensorValue.o ./Drivers/BNO085_SPI/sh2_SensorValue.su ./Drivers/BNO085_SPI/sh2_util.cyclo ./Drivers/BNO085_SPI/sh2_util.d ./Drivers/BNO085_SPI/sh2_util.o ./Drivers/BNO085_SPI/sh2_util.su ./Drivers/BNO085_SPI/shtp.cyclo ./Drivers/BNO085_SPI/shtp.d ./Drivers/BNO085_SPI/shtp.o ./Drivers/BNO085_SPI/shtp.su

.PHONY: clean-Drivers-2f-BNO085_SPI

