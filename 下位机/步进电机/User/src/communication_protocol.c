/**
  ******************************************************************************
  * @file    stm32f1_demo/communication_protocol.c
  * @author  CheXl
  * @version V1.0
  * @date    28-Nov.-2019
  * @brief   CRC
  ******************************************************************************
  */
/* Includes ------------------------------------------------------------------*/
#include <stdint.h>
#include "communication.h"
#include "communication_crc.h"
#include "communication_protocol.h"
#include "led.h"
    
/* Private typedef -----------------------------------------------------------*/

/* Private define ------------------------------------------------------------*/

/* Private macro -------------------------------------------------------------*/

/* Private variables ---------------------------------------------------------*/
u16 testReceiveNum = 0;
u16 testReceivePack = 0;
/* Private function prototypes -----------------------------------------------*/
uint16_t get_queue_location(uint16_t head ,uint16_t distance );
void process_command(uint8_t * commandBuf);
/* Public function -----------------------------------------------------------*/
/**
  * @brief  接收命令处理。 
  * @param  None
  * @retval None
  */
void receive_poll(void)
{
  uint8_t tempBuf[CRC_LENGTH+2],i;
  uint16_t tempHp;
    /*如果接收到12个数据择处理数据，如果接收到有效命令则处理命令，并发送应答*/
      if ((( receiveQueue.rp - receiveQueue.hp) >= 12) ||((( (receiveQueue.rp +QUEUE_BUF_SIZE)-receiveQueue.hp)>=12)  &&  (receiveQueue.rp < receiveQueue.hp)))
      {//命令队列里数据量大于等于12开始处理
        if (receiveQueue.data[receiveQueue.hp] == CMD_FIRSTBIT && receiveQueue.data[get_queue_location( receiveQueue.hp,11)] == CMD_LASTBIT)
        {//报头和报尾正确则处理
            receiveQueue.hp++ ;  
          if ( receiveQueue.hp >= QUEUE_BUF_SIZE) receiveQueue.hp = 0 ; 
          tempHp = receiveQueue.hp;
          for(i=0;i<10;i++)
          {
             tempBuf[i] =receiveQueue.data[receiveQueue.hp]; 
             receiveQueue.hp ++ ;
             if ( receiveQueue.hp >= QUEUE_BUF_SIZE) receiveQueue.hp = 0 ;        
          }
          if(usMBCRC16(tempBuf,CRC_LENGTH) == (uint16_t)(tempBuf[8]<<8)+(uint16_t)tempBuf[9]) 
          {//CRC校验成功
            testReceivePack++;
            receiveQueue.hp++;
            if ( receiveQueue.hp >= QUEUE_BUF_SIZE) receiveQueue.hp = 0 ;  
             process_command(tempBuf);  
          }
          else
             receiveQueue.hp = tempHp; //CRC校验没成功，则指针加一
        }
        else 
        {//报头和报尾不正确指针加一
          receiveQueue.hp ++ ;
          if ( receiveQueue.hp >= QUEUE_BUF_SIZE) receiveQueue.hp = 0 ;           
        }
      }
}

/* Private functions ---------------------------------------------------------*/
/**
  * @brief  协议命令处理函数
  * @param  None
  * @retval None
  */
void process_command(uint8_t * commandBuf)
{
	int m,num;
  uint16_t crcData;
  uint8_t ackBuf[12];

  
  /*处理命令*/
  switch(commandBuf[0])
  {
  case CMD_MOTOR_CW://顺时针,收缩
		ackBuf [1] = CMD_MOTOR_CW;
		m = commandBuf[2]+commandBuf[3]*10+commandBuf[4]*100+commandBuf[5]*1000+commandBuf[6]*10000;
    motor_direction_cw(commandBuf[1],m);
    break;
	case CMD_MOTOR_CCW://逆时针，拉伸
    ackBuf [1] = CMD_MOTOR_CCW ;
	  m = commandBuf[2]+commandBuf[3]*10+commandBuf[4]*100+commandBuf[5]*1000+commandBuf[6]*10000;
    motor_direction_ccw(commandBuf[1],m);
    break;
	case CMD_MOTOR_CYCLE:
		ackBuf [1] = CMD_MOTOR_CYCLE;
		m = commandBuf[2]+commandBuf[3]*10+commandBuf[4]*100+commandBuf[5]*1000+commandBuf[6]*10000;
		num = commandBuf[7];
		motor_direction_cycle(commandBuf[1],m,num);
		break;
  default:
    break;
  }
  /*存储应答*/
  ackBuf [0] = CMD_FIRSTBIT ;
  ackBuf [2] = commandBuf[1] ;
  ackBuf [3] = commandBuf[2];
  ackBuf [4] = commandBuf[3] ;
  ackBuf [5] = commandBuf[4];   
  ackBuf [6] = commandBuf[5];
  ackBuf [7] = commandBuf[6]; 
  ackBuf [8] = commandBuf[7];
  crcData = usMBCRC16 (&ackBuf[1], CRC_LENGTH);
  ackBuf [9] = (uint8_t)((crcData & 0xFF00) >> 8);  //CRC校验码
  ackBuf [10] = (uint8_t)(crcData & 0x00FF);  //CRC校验码
  ackBuf [11] = CMD_LASTBIT ;
  transmit_data(ackBuf,12);
}
/**
  * @brief  确定队列里与head相距distance数据的实际位置。 
  * @param  None
  * @retval None
  */
uint16_t get_queue_location(uint16_t head ,uint16_t distance )
{
  uint16_t location;
  
  if((head + distance) >= QUEUE_BUF_SIZE)
  {
    location = head + distance - QUEUE_BUF_SIZE;
  }
  else
    location = head + distance;
  return location;
}
