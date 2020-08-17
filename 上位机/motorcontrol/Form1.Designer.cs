namespace motorcontrol
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ComNum = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.StepNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SendClick = new System.Windows.Forms.Button();
            this.ReceiveDate = new System.Windows.Forms.TextBox();
            this.OpenCom = new System.Windows.Forms.Button();
            this.CloseCom = new System.Windows.Forms.Button();
            this.ClearReceive = new System.Windows.Forms.Button();
            this.Direction = new System.Windows.Forms.ComboBox();
            this.Speed = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BaudRate = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Init = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CycleNum = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComNum
            // 
            this.ComNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComNum.FormattingEnabled = true;
            this.ComNum.Location = new System.Drawing.Point(98, 23);
            this.ComNum.Name = "ComNum";
            this.ComNum.Size = new System.Drawing.Size(121, 28);
            this.ComNum.TabIndex = 0;
            this.ComNum.Text = "COM10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "移动距离(mm)";
            // 
            // StepNum
            // 
            this.StepNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StepNum.Location = new System.Drawing.Point(144, 20);
            this.StepNum.Name = "StepNum";
            this.StepNum.Size = new System.Drawing.Size(122, 30);
            this.StepNum.TabIndex = 5;
            this.StepNum.Text = "1.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "转速 (mm/s)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "方      向";
            // 
            // SendClick
            // 
            this.SendClick.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SendClick.Location = new System.Drawing.Point(144, 161);
            this.SendClick.Name = "SendClick";
            this.SendClick.Size = new System.Drawing.Size(122, 30);
            this.SendClick.TabIndex = 12;
            this.SendClick.Text = "启动";
            this.SendClick.UseVisualStyleBackColor = true;
            this.SendClick.Click += new System.EventHandler(this.SendClick_Click);
            // 
            // ReceiveDate
            // 
            this.ReceiveDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReceiveDate.Location = new System.Drawing.Point(12, 225);
            this.ReceiveDate.Multiline = true;
            this.ReceiveDate.Name = "ReceiveDate";
            this.ReceiveDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ReceiveDate.Size = new System.Drawing.Size(529, 146);
            this.ReceiveDate.TabIndex = 13;
            // 
            // OpenCom
            // 
            this.OpenCom.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OpenCom.Location = new System.Drawing.Point(16, 94);
            this.OpenCom.Name = "OpenCom";
            this.OpenCom.Size = new System.Drawing.Size(118, 45);
            this.OpenCom.TabIndex = 14;
            this.OpenCom.Text = "打开串口";
            this.OpenCom.UseVisualStyleBackColor = true;
            this.OpenCom.Click += new System.EventHandler(this.OpenCom_Click);
            // 
            // CloseCom
            // 
            this.CloseCom.Enabled = false;
            this.CloseCom.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CloseCom.Location = new System.Drawing.Point(16, 145);
            this.CloseCom.Name = "CloseCom";
            this.CloseCom.Size = new System.Drawing.Size(118, 46);
            this.CloseCom.TabIndex = 15;
            this.CloseCom.Text = "关闭串口";
            this.CloseCom.UseVisualStyleBackColor = true;
            this.CloseCom.Click += new System.EventHandler(this.CloseCom_Click);
            // 
            // ClearReceive
            // 
            this.ClearReceive.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClearReceive.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.ClearReceive.Location = new System.Drawing.Point(140, 94);
            this.ClearReceive.Name = "ClearReceive";
            this.ClearReceive.Size = new System.Drawing.Size(79, 97);
            this.ClearReceive.TabIndex = 16;
            this.ClearReceive.Text = "清空  接收";
            this.ClearReceive.UseVisualStyleBackColor = true;
            this.ClearReceive.Click += new System.EventHandler(this.ClearReceive_Click);
            // 
            // Direction
            // 
            this.Direction.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Direction.FormattingEnabled = true;
            this.Direction.Items.AddRange(new object[] {
            "收缩",
            "拉伸",
            "往复"});
            this.Direction.Location = new System.Drawing.Point(144, 92);
            this.Direction.Name = "Direction";
            this.Direction.Size = new System.Drawing.Size(122, 28);
            this.Direction.TabIndex = 17;
            this.Direction.Text = "拉伸";
            // 
            // Speed
            // 
            this.Speed.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Speed.FormattingEnabled = true;
            this.Speed.Items.AddRange(new object[] {
            "10.0",
            "11.8"});
            this.Speed.Location = new System.Drawing.Point(144, 56);
            this.Speed.Name = "Speed";
            this.Speed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Speed.Size = new System.Drawing.Size(122, 28);
            this.Speed.TabIndex = 18;
            this.Speed.Text = "10.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(18, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "波特率";
            // 
            // BaudRate
            // 
            this.BaudRate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaudRate.FormattingEnabled = true;
            this.BaudRate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "115200"});
            this.BaudRate.Location = new System.Drawing.Point(98, 59);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(121, 28);
            this.BaudRate.TabIndex = 19;
            this.BaudRate.Text = "115200";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CycleNum);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Init);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.StepNum);
            this.groupBox1.Controls.Add(this.Speed);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Direction);
            this.groupBox1.Controls.Add(this.SendClick);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(255, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 207);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "拉伸设置";
            // 
            // Init
            // 
            this.Init.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Init.Location = new System.Drawing.Point(10, 162);
            this.Init.Name = "Init";
            this.Init.Size = new System.Drawing.Size(115, 29);
            this.Init.TabIndex = 19;
            this.Init.Text = "初始化";
            this.Init.UseVisualStyleBackColor = true;
            this.Init.Click += new System.EventHandler(this.Init_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ClearReceive);
            this.groupBox2.Controls.Add(this.ComNum);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.BaudRate);
            this.groupBox2.Controls.Add(this.OpenCom);
            this.groupBox2.Controls.Add(this.CloseCom);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 207);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "串口设置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(6, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "往 复 次 数";
            // 
            // CycleNum
            // 
            this.CycleNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CycleNum.FormattingEnabled = true;
            this.CycleNum.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.CycleNum.Location = new System.Drawing.Point(144, 129);
            this.CycleNum.Name = "CycleNum";
            this.CycleNum.Size = new System.Drawing.Size(122, 28);
            this.CycleNum.TabIndex = 21;
            this.CycleNum.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 380);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ReceiveDate);
            this.Name = "Form1";
            this.Text = "步进电机控制程序";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComNum;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox StepNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SendClick;
        private System.Windows.Forms.TextBox ReceiveDate;
        private System.Windows.Forms.Button OpenCom;
        private System.Windows.Forms.Button CloseCom;
        private System.Windows.Forms.Button ClearReceive;
        private System.Windows.Forms.ComboBox Direction;
        private System.Windows.Forms.ComboBox Speed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BaudRate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Init;
        private System.Windows.Forms.ComboBox CycleNum;
        private System.Windows.Forms.Label label6;
    }
}

