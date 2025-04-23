/*****************************************************************************
 @Project	: 
 @File 		: Actuator.c
 @Details  	: 
 @Author	: Gan Lian Chai
 @Hardware	: 
 
 --------------------------------------------------------------------------
 @Revision	:
  Ver  	Author    	Date        	Changes
 --------------------------------------------------------------------------
   1.0  Name     XXXX-XX-XX  		Initial Release
   
******************************************************************************/

#include "main.h"
#include "tim.h"
#include "Actuator.h"

/*****************************************************************************
 Define
******************************************************************************/


/*****************************************************************************
 Type definition
******************************************************************************/


/*****************************************************************************
 Global Variables
******************************************************************************/
extern ROBOT  robot;

/*****************************************************************************
 Local Variables
******************************************************************************/


/*****************************************************************************
 Local functions
******************************************************************************/


/*****************************************************************************
 Callback functions
******************************************************************************/


/*****************************************************************************
 Implementation 
******************************************************************************/

// motor

void WheelMoveForward( void )
{
	HAL_TIM_PWM_Stop(&M1_TIM, M1_CHANNEL);
	HAL_TIM_PWM_Stop(&M2_TIM, M2_CHANNEL);
	HAL_GPIO_WritePin(M1_DIR_GPIO_Port, M1_DIR_Pin, GPIO_PIN_RESET);
	HAL_GPIO_WritePin(M2_DIR_GPIO_Port, M2_DIR_Pin, GPIO_PIN_RESET);
	HAL_TIM_PWM_Start(&M1_TIM, M1_CHANNEL);
	HAL_TIM_PWM_Start(&M2_TIM, M2_CHANNEL);
}


void WheelMoveBackward( void )
{
	HAL_TIM_PWM_Stop(&M1_TIM, M1_CHANNEL);
	HAL_TIM_PWM_Stop(&M2_TIM, M2_CHANNEL);
	HAL_GPIO_WritePin(M1_DIR_GPIO_Port, M1_DIR_Pin, GPIO_PIN_SET);
	HAL_GPIO_WritePin(M2_DIR_GPIO_Port, M2_DIR_Pin, GPIO_PIN_SET);
	HAL_TIM_PWM_Start(&M1_TIM, M1_CHANNEL);
	HAL_TIM_PWM_Start(&M2_TIM, M2_CHANNEL);
}


void WheelRotateLeft( void )
{
	HAL_TIM_PWM_Stop(&M1_TIM, M1_CHANNEL);
	HAL_TIM_PWM_Stop(&M2_TIM, M2_CHANNEL);
	HAL_GPIO_WritePin(M1_DIR_GPIO_Port, M1_DIR_Pin, GPIO_PIN_SET);
	HAL_GPIO_WritePin(M2_DIR_GPIO_Port, M2_DIR_Pin, GPIO_PIN_RESET);
	HAL_TIM_PWM_Start(&M1_TIM, M1_CHANNEL);
	HAL_TIM_PWM_Start(&M2_TIM, M2_CHANNEL);
}


void WheelRotateRight( void )
{
	HAL_TIM_PWM_Stop(&M1_TIM, M1_CHANNEL);
	HAL_TIM_PWM_Stop(&M2_TIM, M2_CHANNEL);
	HAL_GPIO_WritePin(M1_DIR_GPIO_Port, M1_DIR_Pin, GPIO_PIN_RESET);
	HAL_GPIO_WritePin(M2_DIR_GPIO_Port, M2_DIR_Pin, GPIO_PIN_SET);
	HAL_TIM_PWM_Start(&M1_TIM, M1_CHANNEL);
	HAL_TIM_PWM_Start(&M2_TIM, M2_CHANNEL);
}


void WheelAllStop( void )
{
  HAL_TIM_PWM_Stop(&M1_TIM, M1_CHANNEL);
  HAL_TIM_PWM_Stop(&M2_TIM, M2_CHANNEL);
}


void WheelLeftSetDuty( double dDutyCycPercent )
{
	TIM_Wheel_PWM_SetDuty( &M1_TIM, M1_CHANNEL, dDutyCycPercent );
}


void WheelRightSetDuty( double dDutyCycPercent )
{
	TIM_Wheel_PWM_SetDuty( &M2_TIM, M2_CHANNEL, dDutyCycPercent );
}


void WheelAllSetDuty( double dDutyCycPercent )
{
	TIM_Wheel_PWM_SetDuty( &M1_TIM, M1_CHANNEL, dDutyCycPercent );
	TIM_Wheel_PWM_SetDuty( &M2_TIM, M2_CHANNEL, dDutyCycPercent );
}


// servo
/*
void ServoInit( void )
{
	// PWM for Servo Motor Initialization
	HAL_TIM_PWM_Stop(&S1_TIM, S1_CHANNEL);
	HAL_TIM_PWM_Stop(&S2_TIM, S2_CHANNEL);
	HAL_TIM_PWM_Stop(&S3_TIM, S3_CHANNEL);
	HAL_TIM_PWM_Stop(&S4_TIM, S4_CHANNEL);

	HAL_TIM_PWM_Stop(&S5_TIM, S5_CHANNEL);
	HAL_TIM_PWM_Stop(&S6_TIM, S6_CHANNEL);
	HAL_TIM_PWM_Stop(&S7_TIM, S7_CHANNEL);
	HAL_TIM_PWM_Stop(&S8_TIM, S8_CHANNEL);

	ServoSetDuty( 1, 750 ); // nDutyCyc100Percent
	ServoSetDuty( 2, 750 );
	ServoSetDuty( 3, 750 );
	ServoSetDuty( 4, 750 );

	ServoSetDuty( 5, 750 );
	ServoSetDuty( 6, 750 );
	ServoSetDuty( 7, 750 );
	ServoSetDuty( 8, 750 );
}

*/

uint16_t ServoJointAngleToPWM( int nIdx, int32_t nJointAngle )
{
	uint16_t nDutyCyc100Percent;
	int32_t nAngle;

	// nAngle in (x100 deg) is the actual physical angle
    // nJointAngle in (x100 deg) is w.r.t. a reference position

	if( nJointAngle > robot.dataSrvPos.jointAnglePlusLimit[nIdx-1] )
	{
		nJointAngle = robot.dataSrvPos.jointAnglePlusLimit[nIdx-1];
	}

	if( nJointAngle < robot.dataSrvPos.jointAngleMinusLimit[nIdx-1] )
	{
		nJointAngle = robot.dataSrvPos.jointAngleMinusLimit[nIdx-1];
	}

	robot.dataSrvPos.jointAngle[nIdx-1] = nJointAngle;

	nAngle = nJointAngle * robot.dataSrvPos.jointAngleDir[nIdx-1] + robot.dataSrvPos.jointAngleOffset[nIdx-1];

	// additional precaution
	if( nAngle < 0 ) nAngle = 0;
	if( nAngle > 18000 ) nAngle = 18000;

	// nDutyCyc100Percent = ((nAngle*(12.0-3.0))/180.0) + 300.0;

	nDutyCyc100Percent = (uint16_t)( (nAngle/20) + 300 );

	return nDutyCyc100Percent;
}


int32_t PWMToServoJointAngle( int nIdx, uint16_t nDutyCyc100Percent )
{
	int32_t nAngle, nJointAngle;

	// nAngle & nJointAngle are in (x100 deg)
	// nDutyCyc100Percent is in (x100 %)

	// nDutyCyc100Percent = ((nAngle*(12.0-3.0))/180.0) + 300.0;

	nAngle = 20 * ( (int32_t)nDutyCyc100Percent - 300 );

	nJointAngle = ( nAngle - robot.dataSrvPos.jointAngleOffset[nIdx-1] ) * robot.dataSrvPos.jointAngleDir[nIdx-1];

	return nJointAngle;
}


void ServoSetDuty( int nIdx, uint16_t nDutyCyc100Percent )
{
	// nDutyCyc100Percent is in (x100 %) and dDutyCycPercent is in (%)
	double dDutyCycPercent = (double)nDutyCyc100Percent / 100.0;

	switch( nIdx )
	{
		case 1:
			TIM_Servo_PWM_SetDuty( &S1_TIM, S1_CHANNEL, dDutyCycPercent );
		break;
		
		case 2:
			TIM_Servo_PWM_SetDuty( &S2_TIM, S2_CHANNEL, dDutyCycPercent );
		break;
		
		case 3:
			TIM_Servo_PWM_SetDuty( &S3_TIM, S3_CHANNEL, dDutyCycPercent );
		break;
		
		case 4:
			TIM_Servo_PWM_SetDuty( &S4_TIM, S4_CHANNEL, dDutyCycPercent );
		break;
		
		case 5:
			TIM_Servo_PWM_SetDuty( &S5_TIM, S5_CHANNEL, dDutyCycPercent );
		break;

		case 6:
		//	TIM_Servo_PWM_SetDuty( &S6_TIM, S6_CHANNEL, dDutyCycPercent );
		break;
		
		case 7:
			TIM_Servo_PWM_SetDuty( &S7_TIM, S7_CHANNEL, dDutyCycPercent );
		break;
		
		case 8:
			TIM_Servo_PWM_SetDuty( &S8_TIM, S8_CHANNEL, dDutyCycPercent );
		break;
		
		default:
		break;
	}
}


void ServosAllOutputEnable( BOOL bEN )
{
	if( TRUE == bEN )
	{
		HAL_TIM_PWM_Start(&S1_TIM, S1_CHANNEL);
		HAL_TIM_PWM_Start(&S2_TIM, S2_CHANNEL);
		HAL_TIM_PWM_Start(&S3_TIM, S3_CHANNEL);
		HAL_TIM_PWM_Start(&S4_TIM, S4_CHANNEL);

		HAL_TIM_PWM_Start(&S5_TIM, S5_CHANNEL);
	//	HAL_TIM_PWM_Start(&S6_TIM, S6_CHANNEL);
		HAL_TIM_PWM_Start(&S7_TIM, S7_CHANNEL);
		HAL_TIM_PWM_Start(&S8_TIM, S8_CHANNEL);
	}
	else
	{
		HAL_TIM_PWM_Stop(&S1_TIM, S1_CHANNEL);
		HAL_TIM_PWM_Stop(&S2_TIM, S2_CHANNEL);
		HAL_TIM_PWM_Stop(&S3_TIM, S3_CHANNEL);
		HAL_TIM_PWM_Stop(&S4_TIM, S4_CHANNEL);

		HAL_TIM_PWM_Stop(&S5_TIM, S5_CHANNEL);
	//	HAL_TIM_PWM_Stop(&S6_TIM, S6_CHANNEL);
		HAL_TIM_PWM_Stop(&S7_TIM, S7_CHANNEL);
		HAL_TIM_PWM_Stop(&S8_TIM, S8_CHANNEL);
	}
}
			

	
/*****************************************************************************
 Callback functions
******************************************************************************/


/*****************************************************************************
 Local functions
******************************************************************************/


/*****************************************************************************
 Interrupt functions
******************************************************************************/


















