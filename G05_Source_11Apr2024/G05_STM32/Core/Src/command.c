/*****************************************************************************
 @Project	: 
 @File 		: Command.c
 @Details  	: Robot Command Interpreter
 @Author	: Gan Lian Chai, modified by Liaw Hwee Choo, 08 Jan2022
 @Hardware	: 
 
 --------------------------------------------------------------------------
 @Revision	:
  Ver  	Author    	Date        	Changes
 --------------------------------------------------------------------------
   1.0  Name     XXXX-XX-XX  		Initial Release
   
******************************************************************************/
#include <stdio.h>
#include <string.h>
#include "FreeRTOS.h"
#include "task.h"
#include "main.h"
#include "cmsis_os.h"

#include "usart.h"
#include "Command.h"
#include "Actuator.h"

// #include "GUI.h"
// #include "usart.h"

/*****************************************************************************
 Define
******************************************************************************/
#define EVENT_BIT_ONTX		0x0001
#define EVENT_BIT_ONRX		0x0002

#define ASSERT assert_param		/* Using cubemx assert tool if enabled */

/*****************************************************************************
 Type definition
******************************************************************************/


/*****************************************************************************
 Global Variables
******************************************************************************/
extern ROBOT  robot;

extern osEventFlagsId_t eventUartTxReadyHandle;
extern osEventFlagsId_t eventUartRxReadyHandle;
extern osSemaphoreId_t  SemaUartTxHandle;

/*****************************************************************************
 Local Variables
******************************************************************************/

/*****************************************************************************
 Local functions
******************************************************************************/

/*****************************************************************************
 Callback functions
******************************************************************************/
static void _UART_TxCpltCallback(UART_HandleTypeDef *huart);
static void _UART_RxCpltCallback(UART_HandleTypeDef *huart);

/*****************************************************************************
 Implementation 
******************************************************************************/
void CommandInit( CMD_HANDLE *pHandle, void  *pUartHandle )
{
	ASSERT( 0 != pHandle );
	ASSERT( 0 != pUartHandle );

	pHandle->pUartHandle = (UART_HandleTypeDef *)pUartHandle;

	HAL_UART_RegisterCallback(pUartHandle, HAL_UART_TX_COMPLETE_CB_ID, _UART_TxCpltCallback );
	HAL_UART_RegisterCallback(pUartHandle, HAL_UART_RX_COMPLETE_CB_ID, _UART_RxCpltCallback );

//	pHandle->bOpticallaserEnable = TRUE; // not used
	pHandle->nDutyStep = 2; // 0.02%  // 100;   // 1%
//	pHandle->nPwmStepIntervalMs = 20; // not used
	pHandle->bRobotArmEnable = FALSE;

	// set TargetPwm

	pHandle->TargetPwm[0].Value = 750;   // PWM is set to 7.5%
    pHandle->TargetPwm[1].Value = 1100;  // duty cycle in (x100 %)
	pHandle->TargetPwm[2].Value = 750;
	pHandle->TargetPwm[3].Value = 600;    // gripper
	pHandle->TargetPwm[4].Value = 750;
	pHandle->TargetPwm[5].Value = 750;
	pHandle->TargetPwm[6].Value = 750;
	pHandle->TargetPwm[7].Value = 750;

	// set current PWM with Target Pwm values
	for (int i = 0; i < 8; i++)
	{
		robot.dataSrvPwm.currentPwm[i] = pHandle->TargetPwm[i].Value;  // duty cycle in (x100 %)
		pHandle->TargetPwm[i].bReqCompleted = 0;    //request completed
	}

	// set servos with current PWM values
	for (int i = 0; i < 8; i++)
	{
		ServoSetDuty( i+1, robot.dataSrvPwm.currentPwm[i]);
	}

	for (int i = 0; i < sizeof(pHandle->uRxCmd); i++) pHandle->uRxCmd[i] = 0;
	for (int i = 0; i < sizeof(pHandle->uCmd);   i++) pHandle->uCmd[i]   = 0;

}

/*
void CommandReset( CMD_HANDLE *pHandle )
{
	pHandle->TargetPwm[0].Value = 750;
	pHandle->TargetPwm[0].bReqComp = 0;

	pHandle->TargetPwm[1].Value = 750;
	pHandle->TargetPwm[1].bReqComp = 0;

	pHandle->TargetPwm[2].Value = 750;
	pHandle->TargetPwm[2].bReqComp = 0;

	pHandle->TargetPwm[3].Value = 600;
	pHandle->TargetPwm[3].bReqComp = 0;

	pHandle->TargetPwm[4].Value = 750;
	pHandle->TargetPwm[4].bReqComp = 0;

	pHandle->TargetPwm[5].Value = 750;
	pHandle->TargetPwm[5].bReqComp = 0;

	pHandle->TargetPwm[6].Value = 750;
	pHandle->TargetPwm[6].bReqComp = 0;

	pHandle->TargetPwm[7].Value = 750;
	pHandle->TargetPwm[7].bReqComp = 0;
}
*/


// void CommandForceInRx( CMD_HANDLE *pHandle )
// {
// 	HAL_UART_AbortReceive( pHandle->pUartHandle );
//	HAL_UART_Receive_IT( pHandle->pUartHandle, pHandle->uRxCmd, sizeof(pHandle->uRxCmd) );
// }


int CommandRxExe( CMD_HANDLE *pHandle )
{
	uint8_t 	buf[8];
	uint16_t 	nDutyCyc100Percent;
	PCMD_PKT 	cmdptr;
	char 		ack = 0;
	int 		etxIdx = PACKET_BYTE_TOTAL - 1;
	int32_t 	event;

	ASSERT( 0 != pHandle );
	
	// USART is ready, go to receive mode to wait for packet
	HAL_UART_Receive_IT( pHandle->pUartHandle, pHandle->uRxCmd, sizeof(pHandle->uRxCmd) );

	/* Command received need to be real-time to prevent any packets lost.
	It has to be an event-based, and has to read the USART immediately once event triggered  */
	while(1)
	{
		event = osEventFlagsWait(eventUartRxReadyHandle, EVENT_BIT_ONRX, osFlagsWaitAll, 500);
		if( event < 0 ) // STM32Cube modified FreeRTOS event such that negative value as error flags
		{
			// no incoming data, or partially received data, clear it and wait again
			HAL_UART_AbortReceive(pHandle->pUartHandle);
			HAL_UART_Receive_IT( pHandle->pUartHandle, pHandle->uRxCmd, sizeof(pHandle->uRxCmd) );
			continue;
		}

		// backup received packet into handle for later use
		memcpy( pHandle->uCmd, pHandle->uRxCmd, sizeof(pHandle->uRxCmd) );

		// abort it in case host sent extra bytes, and then put in receive mode again
		HAL_UART_AbortReceive(pHandle->pUartHandle);
		HAL_UART_Receive_IT( pHandle->pUartHandle, pHandle->uRxCmd, sizeof(pHandle->uRxCmd) );

		// now, we validate the packet based on STX, ETX
		if( STX != pHandle->uCmd[0] )
		{
			printf("Host CMD: STX error\r\n");
			continue;
		}

		if( ETX != pHandle->uCmd[etxIdx] )
		{
			printf("Host CMD: ETX error\r\n");
			continue;
		}

		// STX and ETX matched, we parse the content to command
		cmdptr = (PCMD_PKT)pHandle->uCmd;
		switch( cmdptr->c.Type )
		{
			case TYPE_WHEEL:
				switch( cmdptr->Wheel.Cmd )
				{
					case CMD_WHEEL_FWD:
						WheelMoveForward();
						ack = 1;
						printf("Host CMD: Wheel Forward\r\n");
					break;

					case CMD_WHEEL_BWD:
						WheelMoveBackward();
						ack = 1;
						printf("Host CMD: Wheel Backward\r\n");
					break;

					case CMD_WHEEL_LEFT:
						WheelRotateLeft();
						ack = 1;
						printf("Host CMD: Wheel Rotates Left\r\n");
					break;

					case CMD_WHEEL_RIGHT:
						WheelRotateRight();
						ack = 1;
						printf("Host CMD: Wheel Rotates Right\r\n");
					break;

					case CMD_WHEEL_STOP:
						WheelAllStop();
						ack = 1;
						printf("Host CMD: Wheel Stopped\r\n");
					break;

					case CMD_WHEEL_LEFT_DUTY:
						robot.dataMtrPwm.dDutyCycPercentAL = (double)cmdptr->Wheel.nDutyCyc100Percent / 100.0;
						WheelLeftSetDuty( robot.dataMtrPwm.dDutyCycPercentAL );
						ack = 1;
						printf("Host CMD: Left Wheel Duty(x100) Set to %d\r\n", cmdptr->Wheel.nDutyCyc100Percent);
					break;

					case CMD_WHEEL_RIGHT_DUTY:
						robot.dataMtrPwm.dDutyCycPercentBR = (double)cmdptr->Wheel.nDutyCyc100Percent / 100.0;
						WheelRightSetDuty( robot.dataMtrPwm.dDutyCycPercentBR );
						ack = 1;
						printf("Host CMD: Right Wheel Duty(x100) Set to %d\r\n", cmdptr->Wheel.nDutyCyc100Percent);
					break;

					case CMD_WHEEL_ALL_DUTY:
						robot.dataMtrPwm.dDutyCycPercentAL = (double)cmdptr->Wheel.nDutyCyc100Percent / 100.0;
						robot.dataMtrPwm.dDutyCycPercentBR = robot.dataMtrPwm.dDutyCycPercentAL;
						WheelAllSetDuty( robot.dataMtrPwm.dDutyCycPercentAL );
						ack = 1;
						printf("Host CMD: All Wheel Duty(x100) Set to %d\r\n", cmdptr->Wheel.nDutyCyc100Percent);
					break;

					default:
						printf("Host CMD: No such a param\r\n");
					break;
				}
			break;

			case TYPE_SERVO:
				switch( cmdptr->servo.Cmd )
				{
					case CMD_SV1_TARGET_ANGLE:
					case CMD_SV2_TARGET_ANGLE:
					case CMD_SV3_TARGET_ANGLE:
					case CMD_SV4_TARGET_ANGLE:
					case CMD_SV5_TARGET_ANGLE:
					case CMD_SV6_TARGET_ANGLE:
					case CMD_SV7_TARGET_ANGLE:
					case CMD_SV8_TARGET_ANGLE:

						if( 0 != cmdptr->servo.Cmd )
						{
							nDutyCyc100Percent = ServoJointAngleToPWM( (int)cmdptr->servo.Cmd, (int32_t)cmdptr->servo.nJointAngle );

							pHandle->TargetPwm[cmdptr->servo.Cmd-1].Value = nDutyCyc100Percent;
							pHandle->TargetPwm[cmdptr->servo.Cmd-1].bReqCompleted = 1; /* completed = 0, inform Application when done */
							ack = 1;
							sprintf( (char *)buf, "@C0%d#", cmdptr->servo.Cmd );

							CommandSendToHost( pHandle, buf, 5U );
						}
					break;

				//	case CMD_SV_ASTEP_INTERVAL_MS:  // not used
				//		pHandle->nPwmStepIntervalMs = cmdptr->servoTime.nIntervalms;
				//		ack = 1;
				//	break;

				//	case CMD_SV_ASTEP_RES:
				//		pHandle->nDutyStep = cmdptr->servoStep.nStepDutyPercent;
				//		ack = 1;
				//	break;

					case CMD_ARM_ENABLE:
						pHandle->bRobotArmEnable = TRUE;
						ServosAllOutputEnable( pHandle->bRobotArmEnable );
						ack = 1;
					break;

					case CMD_ARM_DISABLE:
						pHandle->bRobotArmEnable = FALSE;
						ServosAllOutputEnable( pHandle->bRobotArmEnable );
						ack = 1;
					break;

					default:
						printf("Host CMD: No such a param\r\n");
					break;
				}

			break;

		//	case TYPE_DIST_SENSOR:  // not used
		//		switch(cmdptr->DistSensor.Cmd )
		//		{
		//			case  CMD_DIST_SENSOR_DIS:
		//				pHandle->bOpticallaserEnable = FALSE;
		//			break;

		//			case CMD_DIST_SENSOR_EN:
		//				pHandle->bOpticallaserEnable = TRUE;
		//			break;

		//			case  CMD_DIST_SENSOR_INTERVAL_MS:
		//			break;

		//			default:
		//				printf("Host CMD: No such a param\r\n");
		//			break;
		//		}
		//	break;

			default:
				ack = 0;
				printf("Host CMD: No such a command\r\n");
			break;
		}

		if( 1 == ack )
		{
			// send "ACK" is required
			CommandSendToHost( pHandle, (uint8_t *)ACK_TO_HOST, strlen(ACK_TO_HOST) );
		}
	}
	return 1;
}


void CommandSendToHost( CMD_HANDLE *pHandle, void *pData, int nSize )
{
	if( osOK == osSemaphoreAcquire( SemaUartTxHandle, 100 ) )
	{
		HAL_UART_Transmit_IT( pHandle->pUartHandle, pData, nSize );
		uint32_t evt = osEventFlagsWait( eventUartTxReadyHandle, EVENT_BIT_ONTX, osFlagsWaitAll, 500 );
		if( evt < 0 )
		{
			/* Timeout. Not supposed to happen */
			printf("Command USART Transmit Data Error\r\n");
		}
		osSemaphoreRelease( SemaUartTxHandle );
	}
}


/*****************************************************************************
 Callback functions
******************************************************************************/

static void _UART_TxCpltCallback(UART_HandleTypeDef *huart)
{
	// set TX ready event to indicate transmission has been completed
	osEventFlagsSet( eventUartTxReadyHandle, EVENT_BIT_ONTX );
}


static void _UART_RxCpltCallback(UART_HandleTypeDef *huart)
{
	// set RX ready event to indicate reception with correct length has been completed
	osEventFlagsSet( eventUartRxReadyHandle, EVENT_BIT_ONRX );
}

/*****************************************************************************
 Local functions
******************************************************************************/


/*****************************************************************************
 Interrupt functions
******************************************************************************/


















