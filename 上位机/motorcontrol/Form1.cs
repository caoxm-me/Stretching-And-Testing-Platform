using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace motorcontrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            //自动获取电脑已经识别的串口
            ComNum.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());

            //serialport没有串口接收事件，必须手动添加串口接收事件
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] readBuffer = new byte[12];
            byte[] dataBuffer = new byte[12];
            int dataLength = 0;

            ushort crcData;
            crcClass crcValue = new crcClass();//校验
            int bytes = serialPort1.BytesToRead; //查看缓冲区内的字符数
            while ((bytes + dataLength) >= 12)
            {//数据量大于12，开始处理数据 

                serialPort1.Read(readBuffer, 0, 12 - dataLength);//从串口读取数据，放到readBuffer里
                for (int i = dataLength; i < 12; i++)
                {
                    dataBuffer[i] = readBuffer[i - dataLength];
                }
                if (dataBuffer[0] == 0x55 && dataBuffer[11] == 0xaa)
                {//头码和尾码正确，则继续
                    crcData = (ushort)(dataBuffer[9] * 256 + dataBuffer[10]); //求得校验码
                    for (int i = 0; i < 11; i++)
                    {
                        dataBuffer[i] = dataBuffer[i + 1];//去掉dateBuffer[12]中的第1位(头码)，只取后11位，得到dateBuffer[11]
                    }
                    if (crcValue.usMBCRC16(dataBuffer, 8) == crcData)
                    {//CRC校验成功，进行数据处理   头码移除了，dataBuffer【0】为命令

                        Thread.Sleep(1000);

                        dataLength = 0;//移除所有数据
                    }
                    else
                    {//CRC校验没有成功，移除第一个数据 

                        dataLength = 11;
                    }
                }
                else
                {//头码和尾码不正确，移除第一个数据

                    for (int i = 0; i < 11; i++)
                    {
                        dataBuffer[i] = dataBuffer[i + 1];
                        dataLength = 11;
                    }
                }
                bytes = serialPort1.BytesToRead; //查看缓冲区内的字符数
            }

        }

        //点击发送按钮，如果串口打开，发送数据
        private void SendClick_Click(object sender, EventArgs e)
        {
            byte[] crcData = new byte[8];//有效命令为8位数组
            byte[] sendData = new byte[12];//发送12个字节的数组
            ushort temp;
            crcClass crcValue = new crcClass();

            sendData[0] = 0x55;//头码，第1位
            sendData[11] = 0xaa;//尾码，第12位
            
            //发送数据第2位决定转向
            if (Direction.Text == "收缩")
                crcData[0] = sendData[1] = 0X01;//顺时针发送0X01，收缩
            else if(Direction.Text == "拉伸")
                crcData[0] = sendData[1] = 0X02;//逆时针发送0X02，拉伸
            else
                crcData[0] = sendData[1] = 0X03;//逆时针发送0X03,往复模式
            //发送数据第3位决定速度
            if (Speed.Text == "10.0")
                crcData[1] = sendData[2] = 0x00;//转化为16进制整数，速度为1cm/s
            else
                crcData[1] = sendData[2] = 0x01;//转化为16进制整数，速度为1.18cm/s

            //发送数据第4到8位决定步数
            double x = Convert.ToDouble(StepNum.Text) * 770;//移动距离转化为步数
            uint stepnum = Convert.ToUInt32(x);//将步数转化为整数类型

            string message =Convert.ToString(stepnum);
            MessageBox.Show("电机" + Direction.Text + message + "步。", "提示");//显示步数转化的结果
            //步数从0到99999
            crcData[2] = sendData[3] = Convert.ToByte(stepnum % 10);
            crcData[3] = sendData[4] = Convert.ToByte((stepnum % 100 - stepnum % 10)/ 10);
            crcData[4] = sendData[5] = Convert.ToByte((stepnum % 1000 - stepnum % 100) / 100);
            crcData[5] = sendData[6] = Convert.ToByte((stepnum % 10000 - stepnum % 1000) / 1000);
            crcData[6] = sendData[7] = Convert.ToByte((stepnum % 100000 - stepnum % 10000) / 10000);

            //发送数据第9位决定往复次数
            uint cyclenum = Convert.ToUInt32(CycleNum.Text);//将往复次数转化为整数类型
            crcData[7] = sendData[8] = Convert.ToByte(cyclenum);

            //发送数据第10、11位是crc检验位
            temp = crcValue.usMBCRC16(crcData, 8);
            sendData[10] = (byte)temp;
            temp >>= 8;
            sendData[9] = (byte)temp;

            

            //发送数据
            if (serialPort1.IsOpen)
            {
                try
                {
                    ReceiveDate.Text += "电机" + Direction.Text + "，" + "距离为" + StepNum.Text + "毫米。" + "\r\n";
                    serialPort1.Write(sendData, 0, 12);//写入数据
                }
                catch
                {
                    MessageBox.Show("串口数据写入错误","错误");
                    serialPort1.Close();
                    OpenCom.Enabled = true;
                    CloseCom.Enabled = false;//关闭串口后只能点击打开串口
                }
            }
        }

        //点击打开串口按钮
        private void OpenCom_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = ComNum.Text;//选择串口
                serialPort1.BaudRate = Convert.ToInt32(BaudRate.Text);//选择波特率
                serialPort1.Open();//打开串口
                OpenCom.Enabled = false;
                CloseCom.Enabled = true;//打开串口后只能点击关闭串口
            }
            catch
            {
                MessageBox.Show("端口错误，请检查串口", "错误");
            }
        }

        //点击关闭串口按钮
        private void CloseCom_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();//关闭串口
                OpenCom.Enabled = true;
                CloseCom.Enabled = false;//关闭串口后只能点击打开串口
            }
            catch
            {
                
            }
        }
        
        //清空接收框里的内容
        private void ClearReceive_Click(object sender, EventArgs e) => ReceiveDate.Text = "";

        //使接收框的滚动条一直保持在最下方
        private void ReceiveDate_TextChanged(object sender, EventArgs e)
        {
            this.ReceiveDate.SelectionStart = 0;//设置文本的开始位置
            this.ReceiveDate.SelectionLength = this.ReceiveDate.Text.Length;//设置为要选择的文本的长度
            ReceiveDate.ScrollToCaret();
        }

        //用来设置刚开始时两个夹具之间膜的长度（此时设置的距离 = 两夹具之间最小距离 + 需要移动的距离）
        private void Init_Click(object sender, EventArgs e)
        {
            byte[] crcData = new byte[8];//有效命令为8位数组
            byte[] sendData = new byte[12];//发送12个字节的数组
            ushort temp;
            crcClass crcValue = new crcClass();

            sendData[0] = 0x55;//头码，第1位
            sendData[11] = 0xaa;//尾码，第12位

            //发送数据第2位决定转向
            if (Direction.Text == "收缩")
                crcData[0] = sendData[1] = 0X01;//顺时针发送0X01，收缩
            else
                crcData[0] = sendData[1] = 0X02;//逆时针发送0X02，拉伸
            //发送数据第3位决定速度
            if (Speed.Text == "10.0")
                crcData[1] = sendData[2] = 0x00;//转化为16进制整数，速度为1cm/s
            else
                crcData[1] = sendData[2] = 0x01;//转化为16进制整数，速度为1.18cm/s

            //发送数据第4到9位决定步数
            double x =( Convert.ToDouble(StepNum.Text) - 5.4 ) * 770 ;//移动距离转化为步数
            uint stepnum = Convert.ToUInt32(x);//将步数转化为整数类型

            string message = Convert.ToString(stepnum);
            MessageBox.Show("初始间距为" + StepNum.Text + "毫米。","提示");//显示步数转化的结果
            MessageBox.Show("电机" + Direction.Text + message + "步。", "提示");//显示步数转化的结果
            //步数从0到99999
            crcData[2] = sendData[3] = Convert.ToByte(stepnum % 10);
            crcData[3] = sendData[4] = Convert.ToByte((stepnum % 100 - stepnum % 10) / 10);
            crcData[4] = sendData[5] = Convert.ToByte((stepnum % 1000 - stepnum % 100) / 100);
            crcData[5] = sendData[6] = Convert.ToByte((stepnum % 10000 - stepnum % 1000) / 1000);
            crcData[6] = sendData[7] = Convert.ToByte((stepnum % 100000 - stepnum % 10000) / 10000);
            crcData[7] = sendData[8] = 0X00;

            //发送数据第10、11位是crc检验位
            temp = crcValue.usMBCRC16(crcData, 8);
            sendData[10] = (byte)temp;
            temp >>= 8;
            sendData[9] = (byte)temp;



            //发送数据
            if (serialPort1.IsOpen)
            {
                try
                {
                    ReceiveDate.Text += "电机" + Direction.Text + "，" + "距离为" + StepNum.Text + "毫米。" + "\r\n";
                    serialPort1.Write(sendData, 0, 12);//写入数据
                }
                catch
                {
                    MessageBox.Show("串口数据写入错误", "错误");
                    serialPort1.Close();
                    OpenCom.Enabled = true;
                    CloseCom.Enabled = false;//关闭串口后只能点击打开串口
                }
            }
        }
    }
}
