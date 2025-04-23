/*****************************************************************************
 @Project	: 
 @File 		: Command.h
 @Details  	:              
 @Author	: Gan Lian Chai , modified by Liaw Hwee Choo 08 Jan 2022
 @Hardware	: 
 
 --------------------------------------------------------------------------
 @Revision	:
  Ver  	Author    	Date        	Changes
 --------------------------------------------------------------------------
   1.0  Name     XXXX-XX-XX  		Initial Release
   
******************************************************************************/

#ifndef __ACTUATOR_DOT_H__
#define __ACTUATOR_DOT_H__

/*****************************************************************************
 Define
******************************************************************************/
// uncomment to use all 4 channels for 4-motor system
// #define  MOTOR_SYSTEM_1234      1

// uncomment to use channels 1 & 2 for 2-motor system
#define  MOTOR_SYSTEM_12           1

// uncomment to use channels 3 & 4 for 2-motor system
// #define  MOTOR_SYSTEM_34        1

/* Motor Channel (PWM): 4-motor system */
#if( MOTOR_SYSTEM_1234 )
	#define  M1_TIM        htim2         // Front-left motor
	#define  M1_CHANNEL    TIM_CHANNEL_1
	#define  M2_TIM        htim2         // Front-right motor
	#define  M2_CHANNEL    TIM_CHANNEL_2
	#define  M3_TIM        htim2         // Rear-left motor
	#define  M3_CHANNEL    TIM_CHANNEL_3
	#define  M4_TIM        htim2         // Rear-right motor
	#define  M4_CHANNEL    TIM_CHANNEL_4
#endif

/* Motor Channel (PWM): 2-motor system */
#if( MOTOR_SYSTEM_12 )
	 #define  M1_TIM          htim2           // left motor
	 #define  M1_CHANNEL      TIM_CHANNEL_1
	 #define  M2_TIM          htim2           // right motor
	 #define  M2_CHANNEL      TIM_CHANNEL_2
#endif

#if( MOTOR_SYSTEM_34 )
	#define  M1_TIM          htim2           // left motor
	#define  M1_CHANNEL      TIM_CHANNEL_3
	#define  M2_TIM          htim2           // right motor
	#define  M2_CHANNEL      TIM_CHANNEL_4
#endif

/* Motor Direction: 4-motor system */
#if( MOTOR_SYSTEM_1234 )
	#define  M1_DIR_GPIO_Port    W1_DIR_GPIO_Port   // Front-left motor
	#define  M1_DIR_Pin          W1_DIR_Pin
	#define  M2_DIR_GPIO_Port    W2_DIR_GPIO_Port   // Front-right motor
	#define  M2_DIR_Pin          W2_DIR_Pin
	#define  M3_DIR_GPIO_Port    W3_DIR_GPIO_Port   // Rear-left motor
	#define  M3_DIR_Pin          W3_DIR_Pin
	#define  M4_DIR_GPIO_Port    W4_DIR_GPIO_Port   // Rear-right motor
	#define  M4_DIR_Pin          W4_DIR_Pin
#endif

/* Motor Direction: 2-motor system */
#if( MOTOR_SYSTEM_12 )
	#define  M1_DIR_GPIO_Port    W1_DIR_GPIO_Port   // left motor
	#define  M1_DIR_Pin          W1_DIR_Pin
	#define  M2_DIR_GPIO_Port    W2_DIR_GPIO_Port   // right motor
	#define  M2_DIR_Pin          W2_DIR_Pin
#endif

#if( MOTOR_SYSTEM_34 )
	#define  M1_DIR_GPIO_Port    W3_DIR_GPIO_Port   // left motor
	#define  M1_DIR_Pin          W3_DIR_Pin
	#define  M2_DIR_GPIO_Port    W4_DIR_GPIO_Port   // right motor
	#define  M2_DIR_Pin          W4_DIR_Pin
#endif

/*  Encoder: for 4-motor system */
#if( MOTOR_SYSTEM_1234 )
	#define  E1_TIM        htim1         // Front-left encoder
	#define  E2_TIM        htim3         // Front-right encoder
	#define  E3_TIM        htim4         // Rear-left encoder
	#define  E4_TIM        htim8         // Rear-right encoder
#endif

/*  Encoder: for 2-motor system */
#if( MOTOR_SYSTEM_12 )
	#define  E1_TIM        htim1         // left encoder
	#define  E2_TIM        htim3         // right encoder
#endif

#if( MOTOR_SYSTEM_34 )
	#define  E1_TIM        htim4         // left encoder
	#define  E2_TIM        htim8         // right encoder
#endif

// stm32h7a3xxq.h
// #define TIM1                ((TIM_TypeDef *) TIM1_BASE)
// #define TIM3                ((TIM_TypeDef *) TIM3_BASE)
// #define TIM4                ((TIM_TypeDef *) TIM4_BASE)
// #define TIM8                ((TIM_TypeDef *) TIM8_BASE)

/*  Encoder: for 4-motor system */
#if( MOTOR_SYSTEM_1234 )
	#define E1_TIM_BASE            ((TIM_TypeDef *) TIM1_BASE)  // Front-left encoder
	#define E2_TIM_BASE            ((TIM_TypeDef *) TIM3_BASE)  // Front-right encoder
	#define E3_TIM_BASE            ((TIM_TypeDef *) TIM4_BASE)  // Rear-left encoder
	#define E4_TIM_BASE            ((TIM_TypeDef *) TIM8_BASE)  // Rear-right encoder
#endif

/*  Encoder: for 2-motor system */
#if( MOTOR_SYSTEM_12 )
	#define E1_TIM_BASE            ((TIM_TypeDef *) TIM1_BASE)     // left encoder
	#define E2_TIM_BASE            ((TIM_TypeDef *) TIM3_BASE)     // right encoder
#endif

#if( MOTOR_SYSTEM_34 )
	#define E1_TIM_BASE            ((TIM_TypeDef *) TIM4_BASE)     // left encoder
	#define E2_TIM_BASE            ((TIM_TypeDef *) TIM8_BASE)     // right encoder
#endif

// #define  TOTAL_SERVO   8

#define  S1_TIM        htim15
#define  S1_CHANNEL    TIM_CHANNEL_1

#define  S2_TIM        htim15
#define  S2_CHANNEL    TIM_CHANNEL_2

#define  S3_TIM        htim17
#define  S3_CHANNEL    TIM_CHANNEL_1

#define  S4_TIM        htim13
#define  S4_CHANNEL    TIM_CHANNEL_1

#define  S5_TIM        htim16
#define  S5_CHANNEL    TIM_CHANNEL_1

// #define  S6_TIM        htimX
// #define  S6_CHANNEL    TIM_CHANNEL_1

#define  S7_TIM        htim14
#define  S7_CHANNEL    TIM_CHANNEL_1

#define  S8_TIM        htim12
#define  S8_CHANNEL    TIM_CHANNEL_2


/*****************************************************************************
 Type definition
******************************************************************************/
// typedef int 	BOOL;
// #define TRUE 	1
// #define FALSE 	0


/******************************************************************************
 Global functions
******************************************************************************/

void WheelMoveForward     ( void );
void WheelMoveBackward    ( void );
void WheelRotateLeft      ( void );
void WheelRotateRight     ( void );
void WheelAllStop         ( void );
void WheelLeftSetDuty     ( double nDutyPercent );
void WheelRightSetDuty    ( double nDutyPercent );
void WheelAllSetDuty      ( double nDutyPercent );

// void     ServoInit            ( void );
uint16_t  ServoJointAngleToPWM   ( int nIdx, int32_t nJointAngle );
int32_t   PWMToServoJointAngle   ( int nIdx, uint16_t nDutyCyc100Percent );
void      ServoSetDuty           ( int nIdx, uint16_t nDutyCyc100Percent );
void      ServosAllOutputEnable  ( BOOL bEN );


#endif /* __ACTUATOR_DOT_H__ */
