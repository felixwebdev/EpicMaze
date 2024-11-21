namespace MazeGame_Final
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.exit_Btn = new System.Windows.Forms.Button();
            this.WinnerHis_Btn = new System.Windows.Forms.Button();
            this.btnNewgame = new System.Windows.Forms.Button();
            this.shopBtn = new System.Windows.Forms.Button();
            this.introBtn = new System.Windows.Forms.Button();
            this.settingBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exit_Btn
            // 
            this.exit_Btn.BackColor = System.Drawing.Color.Gray;
            this.exit_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit_Btn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_Btn.ForeColor = System.Drawing.Color.White;
            this.exit_Btn.Location = new System.Drawing.Point(23, 550);
            this.exit_Btn.Name = "exit_Btn";
            this.exit_Btn.Size = new System.Drawing.Size(72, 38);
            this.exit_Btn.TabIndex = 4;
            this.exit_Btn.Text = "Thoát";
            this.exit_Btn.UseVisualStyleBackColor = false;
            this.exit_Btn.Click += new System.EventHandler(this.Exit_Click);
            // 
            // WinnerHis_Btn
            // 
            this.WinnerHis_Btn.BackColor = System.Drawing.Color.Gray;
            this.WinnerHis_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WinnerHis_Btn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinnerHis_Btn.ForeColor = System.Drawing.Color.White;
            this.WinnerHis_Btn.Location = new System.Drawing.Point(304, 399);
            this.WinnerHis_Btn.Name = "WinnerHis_Btn";
            this.WinnerHis_Btn.Size = new System.Drawing.Size(162, 74);
            this.WinnerHis_Btn.TabIndex = 5;
            this.WinnerHis_Btn.Text = "Bảng xếp hạng";
            this.WinnerHis_Btn.UseVisualStyleBackColor = false;
            this.WinnerHis_Btn.Click += new System.EventHandler(this.WinnerHis_Btn_Click);
            // 
            // btnNewgame
            // 
            this.btnNewgame.BackColor = System.Drawing.Color.Gray;
            this.btnNewgame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewgame.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewgame.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNewgame.Location = new System.Drawing.Point(303, 245);
            this.btnNewgame.Name = "btnNewgame";
            this.btnNewgame.Size = new System.Drawing.Size(162, 74);
            this.btnNewgame.TabIndex = 6;
            this.btnNewgame.Text = "Chơi mới";
            this.btnNewgame.UseVisualStyleBackColor = false;
            this.btnNewgame.Click += new System.EventHandler(this.NewGameClick);
            // 
            // shopBtn
            // 
            this.shopBtn.BackColor = System.Drawing.Color.Gray;
            this.shopBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shopBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.shopBtn.Location = new System.Drawing.Point(303, 322);
            this.shopBtn.Name = "shopBtn";
            this.shopBtn.Size = new System.Drawing.Size(162, 74);
            this.shopBtn.TabIndex = 7;
            this.shopBtn.Text = "Cửa hàng";
            this.shopBtn.UseVisualStyleBackColor = false;
            this.shopBtn.Click += new System.EventHandler(this.shopBtn_Click);
            // 
            // introBtn
            // 
            this.introBtn.BackColor = System.Drawing.Color.Gray;
            this.introBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.introBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.introBtn.ForeColor = System.Drawing.Color.White;
            this.introBtn.Location = new System.Drawing.Point(303, 479);
            this.introBtn.Name = "introBtn";
            this.introBtn.Size = new System.Drawing.Size(162, 74);
            this.introBtn.TabIndex = 8;
            this.introBtn.Text = "Hướng dẫn";
            this.introBtn.UseVisualStyleBackColor = false;
            this.introBtn.Click += new System.EventHandler(this.introBtn_Click);
            // 
            // settingBtn
            // 
            this.settingBtn.BackColor = System.Drawing.Color.Gray;
            this.settingBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingBtn.ForeColor = System.Drawing.Color.White;
            this.settingBtn.Location = new System.Drawing.Point(101, 550);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(102, 38);
            this.settingBtn.TabIndex = 9;
            this.settingBtn.Text = "Cài đặt";
            this.settingBtn.UseVisualStyleBackColor = false;
            this.settingBtn.Click += new System.EventHandler(this.settingBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MazeGame_Final.Properties.Resources.backGroundMenu2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(796, 600);
            this.Controls.Add(this.settingBtn);
            this.Controls.Add(this.introBtn);
            this.Controls.Add(this.shopBtn);
            this.Controls.Add(this.btnNewgame);
            this.Controls.Add(this.WinnerHis_Btn);
            this.Controls.Add(this.exit_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "EpicGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button exit_Btn;
        private System.Windows.Forms.Button WinnerHis_Btn;
        private System.Windows.Forms.Button btnNewgame;
        private System.Windows.Forms.Button shopBtn;
        private System.Windows.Forms.Button introBtn;
        private System.Windows.Forms.Button settingBtn;
    }
}

