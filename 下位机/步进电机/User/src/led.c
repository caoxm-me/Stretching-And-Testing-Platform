/* Includes ------------------------------------------------------------------*/
#include "stm32f10x.h"
#include "led.h"
#include "bsp_SysTick.h"
#include "sys.h"

/* Private typedef -----------------------------------------------------------*/
/* Private define ------------------------------------------------------------*/
/* Private macro -------------------------------------------------------------*/
/* Private variables ---------------------------------------------------------*/
/* Private function prototypes -----------------------------------------------*/
void motor_gpio_config(void);

/* Public function -----------------------------------------------------------*/
/**
  * @brief  motor 初始化 
  * @param  None
  * @retval None
  */
void motor_init(void)
{
  motor_gpio_config();
}
/**
  * @brief  电机方向选择,顺势针cw,逆时针ccw，往复模式cycle
  * @param  None
  * @retval None
  */
void motor_direction_cw(int speed,int m)//顺时针，收缩
{
	int i;
	MOTOR1 = 1;
	SysTick_Delay_Us(10);
	for(i = 0 ;i < m;i++)
		{
			MOTOR2 = 0;
			SysTick_Delay_Us((6-speed)*10+5);
			MOTOR2 = 1;
			SysTick_Delay_Us((6-speed)*10+5);
		}
}

void motor_direction_ccw(int speed,int m)//逆时针，拉伸
{
	int i;
	MOTOR1 = 0;
	SysTick_Delay_Us(10);
	for(i = 0;i < m;i++)
		{
			MOTOR2 = 0;
			SysTick_Delay_Us((6-speed)*10+5);
			MOTOR2 = 1;
			SysTick_Delay_Us((6-speed)*10+5);	
		}
}

void motor_direction_cycle(int speed,int m,int num)//往复模式，在一次往复中先拉伸，后收缩
{
	int j;//往复运动的次数
	for(j = 0;j < num;j++)
		{
			motor_direction_ccw(speed,m);
			SysTick_Delay_Us(100);
			motor_direction_cw(speed,m);
			SysTick_Delay_Us(100);
		}
}
/**
  * @brief  MOTOR GPIO 配置
  * @param  None
  * @retval None
  */
void motor_gpio_config(void)
{
  GPIO_InitTypeDef GPIO_InitStructure;
  
  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_10 | GPIO_Pin_11  ;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
  GPIO_Init(GPIOE, &GPIO_InitStructure);
 
}
