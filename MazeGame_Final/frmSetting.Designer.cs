namespace MazeGame_Final
{
    partial class frmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            this.rbtnGraphic1 = new System.Windows.Forms.RadioButton();
            this.rbtnGraphic2 = new System.Windows.Forms.RadioButton();
            this.rbtnGraphic3 = new System.Windows.Forms.RadioButton();
            this.rbtnSoundOn = new System.Windows.Forms.RadioButton();
            this.rbtnSoundOff = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnGraphic1
            // 
            this.rbtnGraphic1.AutoSize = true;
            this.rbtnGraphic1.Checked = true;
            this.rbtnGraphic1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnGraphic1.Location = new System.Drawing.Point(62, 38);
            this.rbtnGraphic1.Name = "rbtnGraphic1";
            this.rbtnGraphic1.Size = new System.Drawing.Size(59, 23);
            this.rbtnGraphic1.TabIndex = 1;
            this.rbtnGraphic1.TabStop = true;
            this.rbtnGraphic1.Text = "Nhỏ";
            this.rbtnGraphic1.UseVisualStyleBackColor = true;
            this.rbtnGraphic1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbtnGraphic1_MouseClick);
            // 
            // rbtnGraphic2
            // 
            this.rbtnGraphic2.AutoSize = true;
            this.rbtnGraphic2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnGraphic2.Location = new System.Drawing.Point(220, 38);
            this.rbtnGraphic2.Name = "rbtnGraphic2";
            this.rbtnGraphic2.Size = new System.Drawing.Size(59, 23);
            this.rbtnGraphic2.TabIndex = 2;
            this.rbtnGraphic2.Text = "Vừa";
            this.rbtnGraphic2.UseVisualStyleBackColor = true;
            this.rbtnGraphic2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbtnGraphic2_MouseClick);
            // 
            // rbtnGraphic3
            // 
            this.rbtnGraphic3.AutoSize = true;
            this.rbtnGraphic3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnGraphic3.Location = new System.Drawing.Point(370, 38);
            this.rbtnGraphic3.Name = "rbtnGraphic3";
            this.rbtnGraphic3.Size = new System.Drawing.Size(56, 23);
            this.rbtnGraphic3.TabIndex = 3;
            this.rbtnGraphic3.Text = "Lớn";
            this.rbtnGraphic3.UseVisualStyleBackColor = true;
            this.rbtnGraphic3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbtnGraphic3_MouseClick);
            // 
            // rbtnSoundOn
            // 
            this.rbtnSoundOn.AutoSize = true;
            this.rbtnSoundOn.Checked = true;
            this.rbtnSoundOn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSoundOn.Location = new System.Drawing.Point(63, 35);
            this.rbtnSoundOn.Name = "rbtnSoundOn";
            this.rbtnSoundOn.Size = new System.Drawing.Size(55, 23);
            this.rbtnSoundOn.TabIndex = 5;
            this.rbtnSoundOn.TabStop = true;
            this.rbtnSoundOn.Text = "Bật";
            this.rbtnSoundOn.UseVisualStyleBackColor = true;
            this.rbtnSoundOn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbtnSoundOn_MouseClick);
            // 
            // rbtnSoundOff
            // 
            this.rbtnSoundOff.AutoSize = true;
            this.rbtnSoundOff.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSoundOff.Location = new System.Drawing.Point(220, 35);
            this.rbtnSoundOff.Name = "rbtnSoundOff";
            this.rbtnSoundOff.Size = new System.Drawing.Size(55, 23);
            this.rbtnSoundOff.TabIndex = 6;
            this.rbtnSoundOff.Text = "Tắt";
            this.rbtnSoundOff.UseVisualStyleBackColor = true;
            this.rbtnSoundOff.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbtnSoundOff_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnGraphic3);
            this.groupBox1.Controls.Add(this.rbtnGraphic2);
            this.groupBox1.Controls.Add(this.rbtnGraphic1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 90);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kích thước màn hình";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnSoundOn);
            this.groupBox2.Controls.Add(this.rbtnSoundOff);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(24, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 79);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Âm thanh";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(30, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(148, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 33);
            this.button2.TabIndex = 10;
            this.button2.Text = "Lưu cài đặt";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 275);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSetting";
            this.Text = "Cài đặt";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnGraphic1;
        private System.Windows.Forms.RadioButton rbtnGraphic2;
        private System.Windows.Forms.RadioButton rbtnGraphic3;
        private System.Windows.Forms.RadioButton rbtnSoundOn;
        private System.Windows.Forms.RadioButton rbtnSoundOff;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}