using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MazeGame_Final
{
    public partial class Form1 : Form
    {
        string level;
        SoundPlayer clickSound = new SoundPlayer(Properties.Resources.quiz2);
        public Form1()
        {
            InitializeComponent();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            var ans = MessageBox.Show("Bạn chắc chứ dũng sĩ !!", "Thoát Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void IntroClick(object sender, EventArgs e)
        {
            clickSound.Play();
            intro introform = new intro();
            introform.Show();
        }
        private void WinnerHis_Btn_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            historyWinner winner = new historyWinner();
            winner.ShowDialog();
        }
        private void NewGameClick(object sender, EventArgs e)
        {
            clickSound.Play();
            inputPlayerName frmInputName =  new inputPlayerName();
            frmInputName.ShowDialog();

            using (FileStream f = new FileStream("infPlayer.txt", FileMode.OpenOrCreate, FileAccess.Read))
            using (StreamReader sr = new StreamReader(f))
            {
                string fileContent = sr.ReadToEnd();
                if (inputPlayerName.isNewGame)
                {
                    Game GameConsole = new Game(1);
                    this.Hide();
                    GameConsole.Show();
                }
                sr.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = "continue.txt";  

            if (File.Exists(filePath))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {

                        level = sr.ReadLine();
                        if (level != null)
                        {
                            Button btnContinue = new Button();
                            btnContinue.Text = "Tiếp tục";
                            btnContinue.Click += continueGame;
                            btnContinue.Top = 245 - 75;
                            btnContinue.Left = 303;
                            btnContinue.Size = new Size(163, 71);
                            btnContinue.BackColor = Color.Gray;
                            btnContinue.Font = new Font("Tahoma", 12, FontStyle.Bold);
                            btnContinue.ForeColor = Color.White;
                            this.Controls.Add(btnContinue);
                        }

                    }
                }
                catch { }
            }
        }
        private void continueGame(object sender, EventArgs e)
        {
            clickSound.Play();
            Game GameConsole = new Game(0 , true, "continue.txt");
            this.Hide();
            GameConsole.Show();
        }
        private void shopBtn_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            frmStore frmStore = new frmStore();
            frmStore.ShowDialog();
        }
        private void introBtn_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            intro frmIntro = new intro();
            frmIntro.ShowDialog();
        }
        private void settingBtn_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            frmSetting frmST = new frmSetting();
            frmST.ShowDialog();
        }
    }
}
