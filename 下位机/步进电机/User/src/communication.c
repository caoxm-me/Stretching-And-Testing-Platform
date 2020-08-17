/* Includes ------------------------------------------------------------------*/
#include "stm32f10x.h"
#include "communication.h"

/* Private typedef -----------------------------------------------------------*/

/* Private define ------------------------------------------------------------*/

/* Private macro -------------------------------------------------------------*/

/* Private variables ---------------------------------------------------------*/
uartQueue_t receiveQueue={{0},0,0};
uartQueue_t transmitQueue={{0},0,0};
/* Private function prototypes -----------------------------------------------*/
void uart_config(void);
/* Public function -----------------------------------------------------------*/

/**
  * @brief  ���������ݷ�����ն�����.  
  * @param  None
  * @retval None
  */
void receive_data( u8 data)
{
    receiveQueue.data[receiveQueue.rp++]= data;
    if(receiveQueue.rp >= QUEUE_BUF_SIZE) receiveQueue.rp = 0;
}

/**
  * @brief  ��Ҫ���͵����ݷ��뷢�Ͷ����У�һ��������16������.  
  * @param  data ���ݣ�length ���ݳ���
  * @retval None
  */
void transmit_data( u8 * data, u8 length)
{
	int i = 0;
  for (i =0; i<length ; i++)
  {
    transmitQueue.data[transmitQueue.rp++]= data[i];
    if(transmitQueue.rp >= QUEUE_BUF_SIZE) transmitQueue.rp = 0;
  }
}

/**
  * @brief  ͨ��UART�˿ڷ��Ͷ��������ݡ� 
  * @param  None
  * @retval None
  */
void uart_transmit(void)
{
  if(transmitQueue.rp != transmitQueue.hp && USART_GetFlagStatus(USART1,USART_FLAG_TXE))
  {
     USART_SendData(USARTy,transmitQueue.data[transmitQueue.hp++]);
     if(transmitQueue.hp >= QUEUE_BUF_SIZE) transmitQueue.hp = 0;
  }
}
/**
  * @brief  ͨѶ��ʼ�������� 
  * @param  None
  * @retval None
  */
void communication_init(void)
{
  uart_config();
  receiveQueue.rp = receiveQueue.hp = 0;
  transmitQueue.rp = transmitQueue.hp = 0;
}

/* Private functions ---------------------------------------------------------*/

/**
  * @brief  UART GPIO ���á� 
  * @param  None
  * @retval None
  */
void uart_gpio_config(void)
{
   GPIO_InitTypeDef GPIO_InitStructure;
   
  /* Configure USARTy Tx as alternate function push-pull */
  GPIO_InitStructure.GPIO_Pin = USARTy_TxPin;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;
  GPIO_Init(USARTy_GPIO, &GPIO_InitStructure);
  
  /* Configure USARTy Rx as input floating */
  GPIO_InitStructure.GPIO_Pin = USARTy_RxPin;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN_FLOATING;
  GPIO_Init(USARTy_GPIO, &GPIO_InitStructure);
}

/**
  * @brief  UARTͨѶ���á� 
  * @param  None
  * @retval None
  */
void uart_config(void)
{ 
  USART_InitTypeDef USART_InitStructure;

  USART_DeInit(USARTy);
  uart_gpio_config();
  
  USART_InitStructure.USART_BaudRate = 115200;
  USART_InitStructure.USART_WordLength = USART_WordLength_8b;
  USART_InitStructure.USART_StopBits = USART_StopBits_1;
  USART_InitStructure.USART_Parity = USART_Parity_No ;
  USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
  USART_InitStructure.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;
  
  /* Configure the USARTy */
  USART_Init(USARTy, &USART_InitStructure);
  /* Enable Receive interrupt */
  USART_ITConfig(USART1, USART_IT_RXNE, ENABLE);
  /* Enable the USARTy */
  USART_Cmd(USARTy, ENABLE);
}
