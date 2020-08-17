/**
  ******************************************************************************
  * @file    stm32f1_demo/communication_protocol.h
  * @author  CheXl
  * @version V1.0
  * @date    28-Nov.-2019
  * @brief   CRC
  ******************************************************************************
**/
/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef _COMMUNICATION_PROTOCOL_H_
#define _COMMUNICATION_PROTOCOL_H_
/* Includes ------------------------------------------------------------------*/
/* Exported constants --------------------------------------------------------*/
#define CMD_FIRSTBIT    0x55
#define CMD_LASTBIT     0xAA
#define CRC_LENGTH      0x08
//commanbuff[1]����˳ʱ�����ʱ��    
#define CMD_MOTOR_CW            0x01//˳ʱ��
#define CMD_MOTOR_CCW           0x02//��ʱ��
#define CMD_MOTOR_CYCLE         0x03//����ģʽ
/* Exported types ------------------------------------------------------------*/
/* Exported macro ------------------------------------------------------------*/
/* Exported variables ------------------------------------------------------- */
extern u16 testReceiveNum;
/* Exported functions ------------------------------------------------------- */
void receive_poll(void);
#endif

