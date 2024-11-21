using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGame_Final
{
    public partial class frmSetting : Form
    {
        static bool changed;
        public frmSetting()
        {
            changed = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (changed)
            {
                var ans = MessageBox.Show("Thoát mà không lưu ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ans == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("setting.txt"))
            {
                if (rbtnGraphic1.Checked) sw.WriteLine("ScreenSize=Small");
                if (rbtnGraphic2.Checked) sw.WriteLine("ScreenSize=Medium");
                if (rbtnGraphic3.Checked) sw.WriteLine("ScreenSize=Large");

                if (rbtnSoundOn.Checked) sw.WriteLine("SoundEnabled=True");
                if (rbtnSoundOff.Checked) sw.WriteLine("SoundEnabled=False");
            }

            MessageBox.Show("Cài đặt đã được lưu!");
            this.Close();
        }
        private void frmSetting_Load(object sender, EventArgs e)
        {
            if (!File.Exists("setting.txt"))
            {
                using (StreamWriter sw = new StreamWriter("setting.txt"))
                {
                    sw.WriteLine("ScreenSize=Small");  
                    sw.WriteLine("SoundEnabled=True");
                }
            }

            string[] settings = File.ReadAllLines("setting.txt");
            foreach (string setting in settings)
            {
                string[] keyValue = setting.Split('=');
                if (keyValue[0] == "ScreenSize")
                {
                    if (keyValue[1] == "Small") rbtnGraphic1.Checked = true;
                    if (keyValue[1] == "Medium") rbtnGraphic2.Checked = true;
                    if (keyValue[1] == "Large") rbtnGraphic3.Checked = true;
                }
                else if (keyValue[0] == "SoundEnabled")
                {
                    if (keyValue[1] == "True") rbtnSoundOn.Checked = true;
                    if (keyValue[1] == "False") rbtnSoundOff.Checked = true;
                }
            }
        }

        private void rbtnGraphic1_MouseClick(object sender, MouseEventArgs e)
        {
            button2.Enabled = true;
            changed = true;
        }
        private void rbtnGraphic2_MouseClick(object sender, MouseEventArgs e)
        {
            button2.Enabled = true;
            changed = true;
        }
        private void rbtnGraphic3_MouseClick(object sender, MouseEventArgs e)
        {
            button2.Enabled = true;
            changed = true;
        }
        private void rbtnSoundOn_MouseClick(object sender, MouseEventArgs e)
        {
            button2.Enabled = true;
            changed = true;
        }
        private void rbtnSoundOff_MouseClick(object sender, MouseEventArgs e)
        {
            button2.Enabled = true;
            changed = true;
        }
    }
}
