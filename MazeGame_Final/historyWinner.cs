using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGame_Final
{
    public partial class historyWinner : Form
    {
        class objWinner
        {
            private string Name;
            private int Score;
            private int Level;

            public objWinner(string _Name = "", int _Score = 0, int _Level = 0)
            {
                Name = _Name; Score = _Score; Level = _Level;
            }

            public string NamePlayer { get => Name; set => Name = value; }
            public int ScorePlayer { get => Score; set => Score = value; }
            public int LevelPlayer { get => Level; set => Level = value; }
            public int AVG() { return ScorePlayer*2 +  LevelPlayer; }
        }
        public historyWinner()
        {
            InitializeComponent();
            FileStream f = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);

            string data = sr.ReadToEnd();
            if (data.Length > 2)
            {
                string[] line = data.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                List<objWinner> listPlayer = new List<objWinner>();
                for (int i = 0; i < line.Length; i += 3)
                {
                    if (i < line.Length && i + 1 < line.Length && i + 2 < line.Length)
                    { 
                        objWinner obj = new objWinner(line[i], int.Parse(line[i + 1]), int.Parse(line[i + 2]));
                        listPlayer.Add(obj);
                    }
                }

                listPlayer.Sort((x, y) => y.AVG().CompareTo(x.AVG()));
                dataGridView1.DataSource = listPlayer;
                dataGridView1.Columns[0].Width = 160;
                dataGridView1.Columns[1].Width = 158;
                dataGridView1.Columns[2].Width = 158;

                generateDeleteALLBtn();
            }
            f.Close();
        }
        private void generateDeleteALLBtn()
        {
            Button btnContinue = new Button();
            btnContinue.Text = "Xóa bảng xếp hạng";
            btnContinue.Click += deleteAllBtn_Click;
            btnContinue.Top = 340;
            btnContinue.Left = 263;
            btnContinue.Size = new Size(200, 43);
            btnContinue.BackColor = Color.Gray;
            btnContinue.Font = new Font("Tahoma", 12, FontStyle.Bold);
            btnContinue.ForeColor = Color.White;
            this.Controls.Add(btnContinue);
        }
        private void deleteAllBtn_Click(object sender, EventArgs e)
        {
            var ans = MessageBox.Show("Bạn có chắc muốn xóa bảng xếp hạng?", "Xóa bảng xếp hạng",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                FileStream f = new FileStream("data.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(f);
                sw.Write("");
                sw.Flush();
                f.Close();
                MessageBox.Show("Đã xóa bảng xếp hạng!!");
                this.Close();
                this.Dispose();
            }
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void historyWinner_Load(object sender, EventArgs e)
        {
            //FileStream f = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
            //StreamReader sr = new StreamReader(f);

            //string data = sr.ReadToEnd();
            //if (data.Length < 2)
            //{
            //    MessageBox.Show("Chưa có ai đạt thành tựu!!");
            //    this.Close();
            //    this.Dispose();
            //}
            //f.Close();
        }
    }
}
