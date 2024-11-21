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
    public partial class frmStore : Form
    {
        static int Balance = 0;
        static bool[] ownerSkin = new bool[] { };
        public frmStore()
        {
            InitializeComponent();
            skinlist();
        }

        private void frmStore_Load(object sender, EventArgs e)
        {
            FileStream f = new FileStream("balance.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            string fileContent = sr.ReadToEnd();
            f.Close();
            int.TryParse(fileContent, out Balance);
            txtBalance.Text = ": " + Balance.ToString();

            readOwnerSkin();
            int cnt = ownerSkin.Length-1;
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    if (cnt >= 0 && ownerSkin[cnt]) btn.Visible = false;
                    cnt--;
                }
            }
        }
        private void readOwnerSkin()
        {
            if (File.Exists("OwnerSkin.txt"))
            {
                FileStream f = new FileStream("OwnerSkin.txt", FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(f);
                ownerSkin = new bool[9];
                string fileContent = sw.ReadToEnd();
                string[] lines = fileContent.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                for(int i = 0; i < 9; i++)
                {
                    ownerSkin[i] = bool.Parse(lines[i]);
                }
                f.Close() ;
            }
            else
            {
                ownerSkin = new bool[9] { false, false, false, false, false, false, false, false, false};
            }
        }
        private void updateBalance()
        {
            txtBalance.Text = ": " + Balance.ToString();
            FileStream g = new FileStream("balance.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(g);
            sw.Write(Balance.ToString());
            sw.Flush();
            g.Close();
        }
        private void updateOwnerSkin()
        {
            using (FileStream f = new FileStream("OwnerSkin.txt", FileMode.Create, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(f))
            {
                for (int i = 0; i < 9; i++)
                {
                    sw.WriteLine(ownerSkin[i]);
                }
            }
        }
        public  void skinlist()
        {
            var skins = new[]
            {
                Properties.Resources.kright,
                Properties.Resources.dino_right,
                Properties.Resources.white_right,
                Properties.Resources.kright,
                Properties.Resources.kright,
                Properties.Resources.kright,
                Properties.Resources.kright,
                Properties.Resources.kright,
                Properties.Resources.kright,
                Properties.Resources.kright,
            };

            pbSkin1.Image = skins[0];
            pbSkin1.SizeMode = PictureBoxSizeMode.Zoom;
            pbSkin2.Image = skins[1];
            pbSkin2.SizeMode = PictureBoxSizeMode.Zoom;
            pbSkin3.Image = skins[2];
            pbSkin3.SizeMode = PictureBoxSizeMode.Zoom;
            pbSkin4.Image = skins[3];
            pbSkin4.SizeMode = PictureBoxSizeMode.Zoom;
            pbSkin5.Image = skins[4];
            pbSkin5.SizeMode = PictureBoxSizeMode.Zoom;
            pbSkin6.Image = skins[5];
            pbSkin6.SizeMode = PictureBoxSizeMode.Zoom;
            pbSkin7.Image = skins[6];
            pbSkin7.SizeMode = PictureBoxSizeMode.Zoom;
            pbSkin8.Image = skins[7];
            pbSkin8.SizeMode = PictureBoxSizeMode.Zoom;
            pbSkin9.Image = skins[8];
            pbSkin9.SizeMode = PictureBoxSizeMode.Zoom;
            pbSkin10.Image = skins[9];
            pbSkin10.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void selectSkin1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn dùng skin này ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Select("1");
            }
        }
        private void selectSkin2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn dùng skin này ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Select("2");
            }
        }
        private void selectSkin3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn dùng skin này ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Select("3");
            }
        }
        private void selectSkin4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn dùng skin này ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Select("4");
            }
        }
        private void selectSkin5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn dùng skin này ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Select("5");
            }
        }
        private void selectSkin6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn dùng skin này ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Select("6");
            }
        }
        private void selectSkin7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn dùng skin này ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Select("7");
            }
        }
        private void selectSkin8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn dùng skin này ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Select("8");
            }
        }
        private void selectSkin9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn dùng skin này ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Select("9");
            }
        }
        private void selectSkin10_Click(object sender,EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn dùng skin này ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Select("10");
            }
        }
        private void Select(string s)
        {
            FileStream f = new FileStream("Skin.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            sw.Write(s);
            sw.Flush();
            f.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void buyBtn1_Click(object sender, EventArgs e)
        {
            if (buySkinEvent("Dino", 1, 10)) buyBtn1.Visible = false;
        }
        private void buyBtn2_Click(object sender, EventArgs e)
        {
            if (buySkinEvent("White", 2, 10)) buyBtn2.Visible = false;
        }
        private void buyBtn3_Click(object sender, EventArgs e)
        {
            if (buySkinEvent("#", 3, 10)) buyBtn3.Visible = false;
        }
        private void buyBtn4_Click(object sender, EventArgs e)
        {
            if (buySkinEvent("#", 4, 10)) buyBtn4.Visible = false;
        }
        private void buyBtn5_Click(object sender, EventArgs e)
        {
            if (buySkinEvent("#", 5, 10)) buyBtn5.Visible = false;
        }
        private void buyBtn6_Click(object sender, EventArgs e)
        {
            if(buySkinEvent("#", 6, 10))  buyBtn6.Visible = false;
        }
        private void buyBtn7_Click(object sender, EventArgs e)
        {
            if (buySkinEvent("#", 7, 10)) buyBtn7.Visible = false;
        }
        private void buyBtn8_Click(object sender, EventArgs e)
        {
            if (buySkinEvent("#", 8, 10)) buyBtn8.Visible = false;
        }
        private void buyBtn9_Click(object sender, EventArgs e)
        {
            if (buySkinEvent("#", 9, 10)) buyBtn9.Visible = false;
        }
        private bool buySkinEvent(string nameSkin, int index, int price)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn mua skin " + nameSkin + " với giá " + price +" xu", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (Balance - price >= 0)
                {
                    MessageBox.Show("Đã mua skin " + nameSkin);
                    ownerSkin[index-1] = true;
                    Balance -= price;
                    updateOwnerSkin();
                    updateBalance();
                    return true;
                }
                else
                {
                    MessageBox.Show("Không đủ xu, vui lòng cày thêm!!");
                }
            }
            return false;
        }
    }
}
