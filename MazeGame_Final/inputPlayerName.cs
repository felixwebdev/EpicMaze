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
    public partial class inputPlayerName : Form
    {
        public static bool isNewGame = false;
        public inputPlayerName()
        {
            InitializeComponent();
        }
        private void playBtn_Click(object sender, EventArgs e)
        {
            FileStream f = new FileStream("infPlayer.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(f);
            if (txtPlayerName.Text.Length > 0)
            {
                string namePlayer = txtPlayerName.Text;
                sr.WriteLine(namePlayer);
                sr.WriteLine(0);
                sr.Flush();
                isNewGame = true;
                this.Close();
            }
            else
            {
                isNewGame = false;
                MessageBox.Show("Chưa nhập tên người chơi!!");
                txtPlayerName.Focus();  
            }
            f.Close();
        }
        private void exitBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
