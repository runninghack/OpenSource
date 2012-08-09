namespace GridDaemon
{
    partial class GridClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_ServiceStart = new System.Windows.Forms.Button();
            this.Btn_ServiceStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Tbx_MainFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Tbx_DockPath = new System.Windows.Forms.TextBox();
            this.Tbx_IP = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Lb_Status = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LB_CPU = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LB_IP = new System.Windows.Forms.Label();
            this.Btn_deleteFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_ServiceStart
            // 
            this.Btn_ServiceStart.Location = new System.Drawing.Point(319, 163);
            this.Btn_ServiceStart.Name = "Btn_ServiceStart";
            this.Btn_ServiceStart.Size = new System.Drawing.Size(75, 23);
            this.Btn_ServiceStart.TabIndex = 1;
            this.Btn_ServiceStart.Text = "启动服务";
            this.Btn_ServiceStart.UseVisualStyleBackColor = true;
            this.Btn_ServiceStart.Click += new System.EventHandler(this.Btn_ServiceStart_Click);
            // 
            // Btn_ServiceStop
            // 
            this.Btn_ServiceStop.Location = new System.Drawing.Point(319, 192);
            this.Btn_ServiceStop.Name = "Btn_ServiceStop";
            this.Btn_ServiceStop.Size = new System.Drawing.Size(75, 23);
            this.Btn_ServiceStop.TabIndex = 3;
            this.Btn_ServiceStop.Text = "停止服务";
            this.Btn_ServiceStop.UseVisualStyleBackColor = true;
            this.Btn_ServiceStop.Click += new System.EventHandler(this.Btn_ServiceStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Template Folder";
            // 
            // Tbx_MainFolder
            // 
            this.Tbx_MainFolder.Location = new System.Drawing.Point(128, 19);
            this.Tbx_MainFolder.Name = "Tbx_MainFolder";
            this.Tbx_MainFolder.Size = new System.Drawing.Size(161, 21);
            this.Tbx_MainFolder.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Server IP Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dock Folder";
            // 
            // Tbx_DockPath
            // 
            this.Tbx_DockPath.Location = new System.Drawing.Point(128, 85);
            this.Tbx_DockPath.Name = "Tbx_DockPath";
            this.Tbx_DockPath.Size = new System.Drawing.Size(161, 21);
            this.Tbx_DockPath.TabIndex = 6;
            // 
            // Tbx_IP
            // 
            this.Tbx_IP.Location = new System.Drawing.Point(128, 52);
            this.Tbx_IP.Name = "Tbx_IP";
            this.Tbx_IP.Size = new System.Drawing.Size(100, 21);
            this.Tbx_IP.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 51);
            this.button1.TabIndex = 8;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Tbx_IP);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Tbx_DockPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Tbx_MainFolder);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 126);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数设置";
            // 
            // Lb_Status
            // 
            this.Lb_Status.AutoSize = true;
            this.Lb_Status.ForeColor = System.Drawing.Color.Blue;
            this.Lb_Status.Location = new System.Drawing.Point(12, 271);
            this.Lb_Status.Name = "Lb_Status";
            this.Lb_Status.Size = new System.Drawing.Size(47, 12);
            this.Lb_Status.TabIndex = 10;
            this.Lb_Status.Text = "Not Set";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LB_IP);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.LB_CPU);
            this.groupBox2.Location = new System.Drawing.Point(12, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 100);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "本机信息";
            // 
            // LB_CPU
            // 
            this.LB_CPU.AutoSize = true;
            this.LB_CPU.Location = new System.Drawing.Point(15, 47);
            this.LB_CPU.Name = "LB_CPU";
            this.LB_CPU.Size = new System.Drawing.Size(41, 12);
            this.LB_CPU.TabIndex = 12;
            this.LB_CPU.Text = "label4";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 71);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(273, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // LB_IP
            // 
            this.LB_IP.AutoSize = true;
            this.LB_IP.Location = new System.Drawing.Point(17, 18);
            this.LB_IP.Name = "LB_IP";
            this.LB_IP.Size = new System.Drawing.Size(41, 12);
            this.LB_IP.TabIndex = 14;
            this.LB_IP.Text = "label4";
            // 
            // Btn_deleteFile
            // 
            this.Btn_deleteFile.Location = new System.Drawing.Point(319, 222);
            this.Btn_deleteFile.Name = "Btn_deleteFile";
            this.Btn_deleteFile.Size = new System.Drawing.Size(88, 23);
            this.Btn_deleteFile.TabIndex = 12;
            this.Btn_deleteFile.Text = "删除垃圾文件";
            this.Btn_deleteFile.UseVisualStyleBackColor = true;
            this.Btn_deleteFile.Click += new System.EventHandler(this.Btn_deleteFile_Click);
            // 
            // GridClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 292);
            this.Controls.Add(this.Btn_deleteFile);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Lb_Status);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_ServiceStop);
            this.Controls.Add(this.Btn_ServiceStart);
            this.Name = "GridClient";
            this.Text = " ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_ServiceStart;
        private System.Windows.Forms.Button Btn_ServiceStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tbx_MainFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tbx_DockPath;
        private System.Windows.Forms.TextBox Tbx_IP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Lb_Status;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label LB_CPU;
        private System.Windows.Forms.Label LB_IP;
        private System.Windows.Forms.Button Btn_deleteFile;
    }
}