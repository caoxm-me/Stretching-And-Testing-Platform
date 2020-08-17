/**
  ******************************************************************************
  * @file    stm32f1_demo/main.c 
  * @author  CheXl
  * @version V1.0
  * @date    28-Nov.-2019
  * @brief   Main program body.
  ******************************************************************************
  */ 
/* Includes ------------------------------------------------------------------*/
#include "stm32f10x.h"
#include "led.h"
#include "communication.h"
#include "communication_protocol.h"
/* Private typedef -----------------------------------------------------------*/
/* Private define ------------------------------------------------------------*/
/* Private macro -------------------------------------------------------------*/
/* Private variables ---------------------------------------------------------*/

/* Private function prototypes -----------------------------------------------*/
void NVIC_Configuration(void);
void RCC_Configuration(void);
/* Private functions ---------------------------------------------------------*/
int main(void)
{
  /* System Clocks Configuration */
  RCC_Configuration();
  
  /* NVIC Configuration */
  communication_init();
  motor_init();
  NVIC_Configuration();
  while(1)
  {
    uart_transmit();
    receive_poll();
  }
}
void RCC_Configuration(void)
{
  /* PCLK1 = HCLK/4 */
  RCC_PCLK1Config(RCC_HCLK_Div1);

  /* TIM2 clock enable */
  RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2, ENABLE);

  /* GPIOC clock enable */
  RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOE|RCC_APB2Periph_GPIOD| RCC_APB2Periph_USART1 | RCC_APB2Periph_GPIOA, ENABLE);

}

void NVIC_Configuration(void)
{
  NVIC_InitTypeDef NVIC_InitStructure;

  /* Enable the TIM2 global Interrupt */
  NVIC_InitStructure.NVIC_IRQChannel = TIM2_IRQn;
  NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
  NVIC_InitStructure.NVIC_IRQChannelSubPriority = 1;
  NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;

  NVIC_Init(&NVIC_InitStructure);
  
  NVIC_InitStructure.NVIC_IRQChannel = USART1_IRQn;
  NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
  NVIC_InitStructure.NVIC_IRQChannelSubPriority = 1;
  NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;

  NVIC_Init(&NVIC_InitStructure);
  
}

