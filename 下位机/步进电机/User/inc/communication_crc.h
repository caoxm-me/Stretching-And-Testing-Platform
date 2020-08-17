/**
  ******************************************************************************
  * @file    stm32f1_demo/communication_crc.h 
  * @author  CheXl
  * @version V1.0
  * @date    28-Nov.-2019
  * @brief   CRC
  ******************************************************************************
  */
/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef _COMMUNICATION_CRC_H_
#define _COMMUNICATION_CRC_H_
/* Includes ------------------------------------------------------------------*/
/* Exported constants --------------------------------------------------------*/
/* Exported types ------------------------------------------------------------*/
/* Exported macro ------------------------------------------------------------*/
/* Exported functions ------------------------------------------------------- */
unsigned short usMBCRC16( unsigned char * pucFrame, unsigned short usLen );
#endif
