/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef _COMMUNICATION_H_
#define _COMMUNICATION_H_
/* Includes ------------------------------------------------------------------*/
#include "stm32f10x.h"
#include "communication.h"

/* Exported constants --------------------------------------------------------*/
 #define USARTy                   USART1
 #define USARTy_GPIO              GPIOA
 #define USARTy_CLK               RCC_APB2Periph_USART1
 #define USARTy_GPIO_CLK          RCC_APB2Periph_GPIOA
 #define USARTy_RxPin             GPIO_Pin_10
 #define USARTy_TxPin             GPIO_Pin_9

 #define QUEUE_BUF_SIZE 64
/* Exported types ------------------------------------------------------------*/
typedef struct {
uint8_t data[QUEUE_BUF_SIZE];
uint8_t hp;
uint8_t rp;
}uartQueue_t;

/* Exported macro ------------------------------------------------------------*/

/* Exported variable ------------------------------------------------------------*/
extern uartQueue_t receiveQueue;
extern uartQueue_t transmitQueue;
/* Exported functions ------------------------------------------------------- */
void communication_init(void);
void uart_transmit(void);
void transmit_data( u8 * data, u8 length);
void receive_data( u8 data);
void USART_Config(void);
void Usart_SendByte( USART_TypeDef * pUSARTx, uint8_t ch);
void Usart_SendString( USART_TypeDef * pUSARTx, char *str);
void Usart_SendHalfWord( USART_TypeDef * pUSARTx, uint16_t ch);
#endif
