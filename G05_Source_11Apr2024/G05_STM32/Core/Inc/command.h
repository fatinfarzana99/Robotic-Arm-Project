/*****************************************************************************
 @Project	: 
 @File 		: Command.h
 @Details  	:              
 @Author	: Gan Lian Chai
 @Hardware	: 
 
 --------------------------------------------------------------------------
 @Revision	:
  Ver  	Author    	Date        	Changes
 --------------------------------------------------------------------------
   1.0  Name     XXXX-XX-XX  		Initial Release
   
******************************************************************************/


#ifndef __COMMAND_DOT_H__
#define __COMMAND_DOT_H__

/*****************************************************************************
 Define
******************************************************************************/
#define STX								0x30
#define ETX								0x40
#define PACKET_BYTE_TOTAL				6U
#define PAYLOAD_BYTE_TOTAL				4U	/* Excluding STX and ETX */


#define TYPE_WHEEL						0x00U
#define TYPE_SERVO						0x01U
#define TYPE_DIST_SENSOR				0x02U

#define CMD_WHEEL_STOP					0x00U
#define CMD_WHEEL_FWD					0x01U
#define CMD_WHEEL_BWD					0x02U
#define CMD_WHEEL_LEFT					0x03U
#define CMD_WHEEL_RIGHT					0x04U
#define CMD_WHEEL_LEFT_DUTY				0x05U
#define CMD_WHEEL_RIGHT_DUTY			0x06U
#define CMD_WHEEL_ALL_DUTY				0x07U

#define  CMD_SV1_TARGET_ANGLE			0x01U
#define  CMD_SV2_TARGET_ANGLE			0x02U
#define  CMD_SV3_TARGET_ANGLE			0x03U
#define  CMD_SV4_TARGET_ANGLE			0x04U
#define  CMD_SV5_TARGET_ANGLE			0x05U
#define  CMD_SV6_TARGET_ANGLE			0x06U
#define  CMD_SV7_TARGET_ANGLE			0x07U
#define  CMD_SV8_TARGET_ANGLE			0x08U
// #define  CMD_SV_ASTEP_INTERVAL_MS	0x09U
// #define  CMD_SV_ASTEP_RES			0x0AU
#define  CMD_ARM_ENABLE					0x0BU
#define  CMD_ARM_DISABLE				0x0CU

// #define  CMD_DIST_SENSOR_DIS			0x00U
// #define  CMD_DIST_SENSOR_EN			0x01U
// #define  CMD_DIST_SENSOR_INTERVAL_MS	0x02U

#define ACK_TO_HOST						"@ACK#"

#define FALSE 	0
#define TRUE 	1
#define ASSERT assert_param		/* Using cubemx assert tool if enabled */

typedef int bool;

/*****************************************************************************
 Type definition
******************************************************************************/
#pragma pack(push,1)

typedef struct _tagTarget_Pwm
{
	uint16_t 	Value;
	char		bReqCompleted;  // Request completed
}TARGET_PWM, *PTARGET_PWM;


typedef union _tagCmd_PKT
{
	uint8_t aCmd[6];

	struct
	{
		uint8_t		Startbyte;
		uint8_t		Type;
		uint8_t		aDummy[3];
		uint8_t		EndByte;
	}c;
	
	struct
	{
		uint8_t		Startbyte;
		uint8_t		Type;
		uint8_t		Cmd;
		uint16_t	nDutyCyc100Percent; /* units is (x100 %) */
		uint8_t		EndByte;
	}Wheel;


	struct
	{
		uint8_t		Startbyte;
		uint8_t		Type;
		uint8_t		Cmd;
		int16_t		nJointAngle; /* unit is (x100 deg) */
		uint8_t		EndByte;
	}servo;

//	struct
//	{
//		uint8_t		Startbyte;
//		uint8_t		Type;
//		uint8_t		Cmd;
//		uint16_t	nIntervalms;
//		uint8_t		EndByte;
//	}servoTime;

//	struct
//	{
//		uint8_t		Startbyte;
//		uint8_t		Type;
//		uint8_t		Cmd;
//		uint16_t	nStepDutyPercent;
//		uint8_t		EndByte;
//	}servoStep;
		
//	struct
//	{
//		uint8_t		Startbyte;
//		uint8_t		Type;
//		uint8_t		Cmd;
//		uint16_t	nIntervalms; /* x100 */
//		uint8_t		EndByte;
//	}DistSensor;
	
}CMD_PKT, *PCMD_PKT;

#pragma pack(pop)

typedef struct _tagCmd_Handle
{
	void *pUartHandle;
	int nDutyStep;
//	int nPwmStepIntervalMs;
//	int bOpticallaserEnable;
	int bRobotArmEnable;
//	volatile int bUsartRxOn;
//	volatile int bUsartTxOn;
	uint8_t      uRxCmd[6];
	uint8_t      uCmd[6];
	TARGET_PWM TargetPwm[8];
	
}CMD_HANDLE, *PCMD_HANDLE;


/*****************************************************************************
 Macro
******************************************************************************/


/******************************************************************************
 Global functions
******************************************************************************/


/******************************************************************************
 @Description 	: 

 @param			: 
 
 @revision		: 1.0.0
 
******************************************************************************/
void CommandInit( CMD_HANDLE *pHandle, void *pUartHandle );


/******************************************************************************
 @Description 	: 

 @param			: 
 
 @revision		: 1.0.0
 
******************************************************************************/
// void CommandReset( CMD_HANDLE *pHandle );


/******************************************************************************
 @Description 	: 

 @param			: 
 
 @revision		: 1.0.0
 
******************************************************************************/
int CommandRxExe( CMD_HANDLE *pHandle );


/******************************************************************************
 @Description 	: 

 @param			: 
 
 @revision		: 1.0.0
 
******************************************************************************/
void CommandSendToHost( CMD_HANDLE *pHandle, void *pData, int nSize );


/******************************************************************************
 @Description 	: 

 @param			: 
 
 @revision		: 1.0.0
 
******************************************************************************/
// void CommandTimeout1msTick( void );


/******************************************************************************
 @Description 	:

 @param			:

 @revision		: 1.0.0

******************************************************************************/
// void CommandForceInRx( CMD_HANDLE *pHandle );


#endif /* __COMMAND_DOT_H__ */
