/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef _LED_H_
#define _LED_H_
/* Includes ------------------------------------------------------------------*/
/* Exported types ------------------------------------------------------------*/
/* Exported constants --------------------------------------------------------*/
/* Exported macro ------------------------------------------------------------*/
/* Exported functions ------------------------------------------------------- */

#define MOTOR1  PEout(10)
#define MOTOR2  PEout(11)

void motor_init(void);
void motor_direction_cw(int speed,int m);
void motor_direction_ccw(int speed,int m);
void motor_direction_cycle(int speed,int m,int num);
#endif

