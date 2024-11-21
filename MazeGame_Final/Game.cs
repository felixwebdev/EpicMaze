using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Forms.VisualStyles;
using MazeGame_Final.Properties;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MazeGame_Final
{
    public partial class Game : Form
    {
        #region KhaiBao
        static bool goLeft, goRight, goUp, goDown, gameOver;
        static int rows, cols;
        static Random random = new Random();
        static int CellSize;
        static int[,] maze;
        static int[] parent;
        static int score;
        static int gameLevel;
        static int quizQuantity;
        static bool usedHint = false;
        static int timeSurvival;
        static string playerName;
        static int turnsLeft;
        string statusPlayer = "kright";
        static Image CharacterUp;
        static Image CharacterDown;
        static Image CharacterLeft;
        static Image CharacterRight;
        static Point playerPosition;
        static bool isSoundOn;
        static List<Point> goalPositions = new List<Point>();
        static Point oldPlayerPosition;
        static PictureBox[,] pictureBoxes;
        List<Tuple<int, int, int, int>> edges = new List<Tuple<int, int, int, int>>();
        static Stack<Tuple<string, string>> stQuiz = new Stack<Tuple<string, string>>();
        SoundPlayer moveSound = new SoundPlayer(Properties.Resources.move3);
        SoundPlayer claimCoinSound = new SoundPlayer(Properties.Resources.coin_claim);
        SoundPlayer answerSound = new SoundPlayer(Properties.Resources.quiz2);
        static List<Point> path = new List<Point>();
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        int minimunStep;
        #endregion
        class CharacterImg
        {
            public Image ImgUp;
            public Image ImgDown;
            public Image ImgLeft;
            public Image ImgRight;

            public CharacterImg(Image imgUp, Image imgDown, Image imgLeft, Image imgRight)
            {
                ImgUp = imgUp;
                ImgDown = imgDown;
                ImgLeft = imgLeft;
                ImgRight = imgRight;
            } 
        };
        public Game(int level, bool isContinue = false, string fileContinue = "")
        {
            if (File.Exists("setting.txt"))
            {
                string[] settings = File.ReadAllLines("setting.txt");
                foreach (string setting in settings)
                {
                    string[] keyValue = setting.Split('=');
                    if (keyValue[0] == "ScreenSize")
                    {
                        if (keyValue[1] == "Small") CellSize = 30;
                        if (keyValue[1] == "Medium") CellSize = 35;
                        if (keyValue[1] == "Large") CellSize = 40;
                    }
                    else if (keyValue[0] == "SoundEnabled")
                    {
                        if (keyValue[1] == "True") isSoundOn = true;
                        if (keyValue[1] == "False") isSoundOn = false;
                    }
                }
            }
            else
            {
                CellSize = 30;
                isSoundOn = true;
            }
            setSkinPlayer();
            gameOver = false;
            if (isContinue)
            {
                InitializeComponent();
                InitMazeContinue();
                InitPictureBoxes();
                StartCountdown(true);
            }
            else
            {
                gameLevel = level;
                InitializeComponent();
                InitMaze(gameLevel);
                InitPictureBoxes();
                StartCountdown();
            }
        }
        private void setSkinPlayer()
        {
            int skinNum = 1;
            if (File.Exists("Skin.txt"))
            {
                using (FileStream f = new FileStream("Skin.txt", FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(f))
                {
                    string tmp = sr.ReadToEnd();
                    int.TryParse(tmp, out skinNum);
                }
            }
            CharacterImg skin = SkinBack(skinNum);
            CharacterUp = skin.ImgUp;
            CharacterDown = skin.ImgDown;
            CharacterLeft = skin.ImgLeft;
            CharacterRight = skin.ImgRight;
        }
        private CharacterImg SkinBack(int x)
        {
            if (x == 1) 
                return new CharacterImg(Properties.Resources.kup, Properties.Resources.kdown, Properties.Resources.kleft, Properties.Resources.kright);
            else if (x == 2)
                return new CharacterImg(Properties.Resources.dino_up, Properties.Resources.dino_down, Properties.Resources.dino_left, Properties.Resources.dino_right);
            else if (x == 3)
                return new CharacterImg(Properties.Resources.white_up, Properties.Resources.white_down, Properties.Resources.white_left, Properties.Resources.white_right);
            return new CharacterImg(Properties.Resources.kup, Properties.Resources.kdown, Properties.Resources.kleft, Properties.Resources.kright);
        }
        private void readQuiz()
        {
            quizQuantity = random.Next(1,7);
            string fileContent = Properties.Resources.QuizList.ToString();

            string[] linesArray = fileContent.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            int lineQuantity = linesArray.Length;
            int startSelect = random.Next(lineQuantity - quizQuantity * 2);

            if (startSelect % 2 != 0) { startSelect += 1; }
            for (int i = startSelect; i < startSelect+quizQuantity*2; i += 2)
            {
                if (i < linesArray.Length)
                {
                    string question = linesArray[i].Trim();
                    string answer = linesArray[i + 1].Trim();
                    stQuiz.Push(new Tuple<string, string>(question, answer));
                }
            }
        }
        private void InitMaze(int level)
        {
            #region Đọc dữ liệu người chơi
            using (FileStream f = new FileStream("infPlayer.txt", FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(f))
            {
                string fileContent = sr.ReadToEnd();
                string[] linesArray = fileContent.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                playerName = linesArray[0];
                int tmpScore;
                if (int.TryParse(linesArray[1], out tmpScore))
                {
                    score = tmpScore;
                }
                else score = 0;
                sr.Close();
            }
            #endregion 
            usedHint = false;
            timeSurvival = 120 - level * 5;
            health_Bar.Maximum =timeSurvival;

            rows = cols = 21;
            maze = new int[rows, cols];

            readQuiz();
            createMazeKruskal(ref maze);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (maze[i, j] == 3)
                    {
                        Point goalPosition = new Point(i, j);
                        goalPositions.Add(goalPosition);
                    }
                }
            }
            Point tmpPosPlayer = new Point(rows / 2, cols / 2);
            int tRow = rows / 2;
            int tCol = cols / 2;
            maze[tRow, tCol] = 1;
            if (maze[tRow + 1, tCol] == 0 && maze[tRow, tCol + 1] == 0 &&
                maze[tRow - 1, tCol] == 0 && maze[tRow, tCol - 1] == 0)
            {
                if (maze[tRow + 1, tCol + 1] == 1) tmpPosPlayer = new Point(tRow + 1, tCol + 1);
                else if (maze[tRow + 1, tCol - 1] == 1) tmpPosPlayer = new Point(tRow + 1, tCol - 1);
                else if (maze[tRow - 1, tCol - 1] == 1) tmpPosPlayer = new Point(tRow - 1, tCol - 1);
                else if (maze[tRow - 1, tCol + 1] == 1) tmpPosPlayer = new Point(tRow - 1, tCol + 1);
            }
            oldPlayerPosition = playerPosition = tmpPosPlayer;
            dijkstra();
            turnsLeft = minimunStep * 2;
            if (level >= 25)
            {
                timeSurvival = 20;
                health_Bar.Maximum = 20;
                turnsLeft = minimunStep * 1;
            }
        }
        private void createMazeKruskal(ref int[,]maze)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    maze[i, j] = 0;

            parent = new int[(rows / 2) * (cols / 2)];
            for (int i = 0; i < parent.Length; i++) parent[i] = i;

            for (int i = 1; i < rows; i += 2)
            {
                for (int j = 1; j < cols; j += 2)
                {
                    if (i + 2 < rows) edges.Add(Tuple.Create(i, j, i + 2, j)); 
                    if (j + 2 < cols) edges.Add(Tuple.Create(i, j, i, j + 2)); 
                }
            }

            Shuffle(edges);

            foreach (var edge in edges)
            {
                int x1 = edge.Item1, y1 = edge.Item2;
                int x2 = edge.Item3, y2 = edge.Item4;

                int set1 = FindSet((x1 / 2) * (cols / 2) + (y1 / 2));
                int set2 = FindSet((x2 / 2) * (cols / 2) + (y2 / 2));

                if (set1 != set2) 
                {
                    Union(set1, set2); 
                    maze[x1, y1] = 1; 
                    maze[(x1 + x2) / 2, (y1 + y2) / 2] = 1;
                    maze[x2, y2] = 1; 
                }
            }
            maze[rows / 2, cols / 2] = 1;
                
            AddSpecialCells(2, quizQuantity);
            AddSpecialCells(4, random.Next(10,20));

            AddExitPaths();
           
        }
        private int  FindSet(int x)
        {
            if (parent[x] == x) return x;
            return parent[x] = FindSet(parent[x]);
        }
        private void Union(int x, int y)
        {
            parent[FindSet(x)] = FindSet(y);
        }
        private void Shuffle<T>(List<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
        private void AddSpecialCells(int value, int count)
        {
            List<Tuple<int, int>> pathCells = new List<Tuple<int, int>>();

            // Lấy tất cả các ô đường đi (giá trị là 1)
            for (int i = 1; i < rows; i += 2)
            {
                for (int j = 1; j < cols; j += 2)
                {
                    if (maze[i, j] == 1)
                        pathCells.Add(Tuple.Create(i, j));
                }
            }

            // Xác định các ô đặc biệt ngẫu nhiên
            for (int i = 0; i < count; i++)
            {
                int index = random.Next(pathCells.Count);
                var cell = pathCells[index];
                maze[cell.Item1, cell.Item2] = value;
                pathCells.RemoveAt(index);
            }
        }
        private void AddExitPaths()
        {
            List<Tuple<int, int>> pathCells = new List<Tuple<int, int>>();

            // Tạo danh sách các ô gần biên mê cung (đường đi khó)
            for (int i = 1; i < rows; i += 2)
            {
                for (int j = 1; j < cols; j += 2)
                {
                    if (maze[i, j] == 1)
                    {
                        // Lựa chọn các ô nằm gần biên (các ô khó tiếp cận)
                        if (i == 1 || i == rows - 2 || j == 1 || j == cols - 2)
                        {
                            pathCells.Add(Tuple.Create(i, j));
                        }
                    }
                }
            }

            // Thêm 3 lối ra ngẫu nhiên từ danh sách các ô khó
            for (int i = 0; i < 3; i++)
            {
                int index = random.Next(pathCells.Count);
                var cell = pathCells[index];
                maze[cell.Item1, cell.Item2] = 3;
                pathCells.RemoveAt(index);
            }
        }
        private void InitMazeContinue(string fileContinue = "")
        {
            #region Đọc dữ liệu người chơi
            using (FileStream g = new FileStream("infPlayer.txt", FileMode.Open, FileAccess.Read))
            using (StreamReader srg = new StreamReader(g))
            {
                string fileContent = srg.ReadToEnd();
                string[] linesArray = fileContent.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                playerName = linesArray[0];
                int tmpScore;
                if (int.TryParse(linesArray[1], out tmpScore))
                {
                    score = tmpScore;
                }
                else score = 0;
                srg.Close();
            }
            #endregion 

            using (FileStream f = new FileStream("continue.txt", FileMode.Open, FileAccess.Read))
            using (StreamReader srf = new StreamReader(f))
            {
                string fileContent = srf.ReadToEnd();

                string[] linesArray = fileContent.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                gameLevel = int.Parse(linesArray[0]);

                if (linesArray.Length < 2)
                {
                    InitMaze(gameLevel);
                }
                else
                {
                    timeSurvival = 120 - gameLevel * 5;
                    health_Bar.Maximum = timeSurvival;
                    if (gameLevel >= 25)
                    {
                        timeSurvival = 20;
                        health_Bar.Maximum = 20;
                    }
                    rows = cols = int.Parse(linesArray[1]);
                    maze = new int[rows, cols];

                    for (int i = 0; i < rows; i++)
                    {
                        string[] line = linesArray[i + 2].Trim().Split(' ');
                        for (int j = 0; j < cols; j++)
                        {
                            maze[i, j] = int.Parse(line[j]);
                        }
                    }

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            if (maze[i, j] == 3)
                            {
                                Point goalPosition = new Point(i, j);
                                goalPositions.Add(goalPosition);
                            }
                        }
                    }

                    string[] pL = linesArray[rows + 2].Trim().Split(' ');
                    int pX = int.Parse(pL[0]);
                    int pY = int.Parse(pL[1]);
                    oldPlayerPosition = playerPosition = new Point(pX, pY);

                    usedHint = false;
                    health_Bar.Value = int.Parse(linesArray[rows + 3].Trim());
                    score = int.Parse(linesArray[rows + 4].Trim());
                    turnsLeft = int.Parse(linesArray[rows + 5].Trim());

                    for (int i = rows + 6; i < linesArray.Length; i += 2)
                    {
                        if (i + 1 < linesArray.Length)
                        {
                            string question = linesArray[i].Trim();
                            string answer = linesArray[i + 1].Trim();
                            stQuiz.Push(new Tuple<string, string>(question, answer));
                        }
                    }
    
                }
            }
        }
        private void InitPictureBoxes()
        {
            pictureBoxes = new PictureBox[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    PictureBox pb = new PictureBox
                    {
                        Width = CellSize,
                        Height = CellSize,
                        Location = new Point(j * CellSize, i * CellSize + 112),
                        BorderStyle = BorderStyle.FixedSingle,
                    };
                    if (maze[i, j] == 0)
                    {
                        pb.Image = Properties.Resources.wall;
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.Tag = "0";
                    }
                    else if (maze[i, j] == 1)
                    {
                        pb.Image = Properties.Resources.floor;
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.Tag = "1";
                    }
                    else if (maze[i, j] == 2)
                    {
                        pb.Image = Properties.Resources.quiz;
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.BackgroundImage = Properties.Resources.floor;
                        pb.BackgroundImageLayout = ImageLayout.Stretch;
                        pb.Tag = "2";
                    }
                    else if (maze[i, j] == 3)
                    {
                        pb.Image = Properties.Resources.DoorWin;
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.BackgroundImage = Properties.Resources.floor;
                        pb.BackgroundImageLayout = ImageLayout.Stretch;
                        pb.Tag = "3";
                    }
                    else if (maze[i, j] == 4)
                    {
                        pb.Image = Properties.Resources.coin;
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.BackgroundImage = Properties.Resources.floor;
                        pb.BackgroundImageLayout = ImageLayout.Stretch;
                        pb.Tag = "4";
                    }
                   
                    pb.BringToFront();
                    this.Controls.Add(pb);
                    pictureBoxes[i, j] = pb;
                }
            }

            UpdatePlayerPosition(statusPlayer);
            this.ClientSize = new Size(rows * CellSize, cols * CellSize + 110);
        }
        private void UpdatePlayerPosition(string statusPlayer)
        {
            pictureBoxes[oldPlayerPosition.X, oldPlayerPosition.Y].Image = Properties.Resources.floor;
            PictureBox player = pictureBoxes[playerPosition.X, playerPosition.Y] as PictureBox;
            player.BackgroundImage = Properties.Resources.floor;
            player.BackgroundImageLayout = ImageLayout.Stretch;

            if (statusPlayer == "kup")
                player.Image = CharacterUp;
            else if (statusPlayer == "kdown")
                player.Image = CharacterDown;
            else if (statusPlayer == "kleft")
                player.Image = CharacterLeft;
            else if (statusPlayer == "kright")
                player.Image = CharacterRight;
        }
        private void StartCountdown(bool isContinue = false)
        {
            if (!isContinue)
                health_Bar.Value = health_Bar.Maximum; 
            CountDownTimer.Start(); 
        }
        private void CountDownTimerEvent(object sender, EventArgs e)
        {
            if (health_Bar.Value > 0)
            {
                health_Bar.Value -= 1; 
            }
            else
            {
                GameOverAct("Đã hết thời gian!");
            }
        }
        private void GameTimeEvent(object sender, EventArgs e)
        {
            txtScore.Text = ": " + score.ToString();
            txtTurn.Text = ": " + turnsLeft.ToString();
            lblLevelInGame.Text = gameLevel.ToString();
            if (turnsLeft <= 0) { GameOverAct("Hết lượt đi!!"); }
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver == true) return;

            if (e.KeyCode == Keys.Escape) { 
                var ans = MessageBox.Show("Bạn có chắc muốn thoát ?", "Thoát game đang chơi",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    HistoryPlay();
                    Exit();
                }
            }
            if (e.KeyCode == Keys.H)
            {
                if (usedHint == true)
                {
                    MessageBox.Show("Đã dùng hết gợi ý vòng này!!");
                    return;
                }
                var ans = MessageBox.Show("Bạn có chắc muốn xem gợi ý? - Số điểm vòng này sẽ bị trừ toàn bộ!", "Xem gợi ý",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    usedHint = true;
                    ShowHint();
                }
            }
            oldPlayerPosition = playerPosition;
            Point newPosition = playerPosition;
            PictureBox player = pictureBoxes[playerPosition.X, playerPosition.Y] as PictureBox;

            #region Move
            if (e.KeyCode == Keys.Up && goUp == false)
            {
                goUp = true;
                newPosition.X--;
                player.Image = CharacterUp;
                statusPlayer = "kup";
            }
            if (e.KeyCode == Keys.Down && goDown == false)
            {
                goDown = true;
                newPosition.X++;
                player.Image = CharacterDown;
                statusPlayer = "kdown";
            }
            if (e.KeyCode == Keys.Left && goLeft == false)
            {
                goLeft = true;
                newPosition.Y--;
                player.Image = CharacterLeft;
                statusPlayer = "kleft";
            }
            if (e.KeyCode == Keys.Right && goRight == false)
            {
                goRight = true;
                newPosition.Y++;
                player.Image = CharacterRight;
                statusPlayer = "kright";
            }
            #endregion

            if (IsValidMove(newPosition))
            {
                if (isSoundOn) moveSound.Play();
                playerPosition = newPosition;
                UpdatePlayerPosition(statusPlayer);
                turnsLeft--;
                if (maze[newPosition.X, newPosition.Y] == 4)
                {
                    if (usedHint == false) score++;
                    maze[newPosition.X, newPosition.Y] = 1;
                    pictureBoxes[newPosition.X, newPosition.Y].Tag = "1";
                    if (isSoundOn)  claimCoinSound.Play();
                }
                else if (maze[newPosition.X, newPosition.Y] == 2)
                {
                    if (isSoundOn) answerSound.Play();
                    bool ans = AskQuestion();
                    if (ans)
                    {
                        maze[newPosition.X, newPosition.Y] = 1;
                        pictureBoxes[newPosition.X, newPosition.Y].Tag = "1";

                    }
                    else
                    {
                        maze[newPosition.X, newPosition.Y] = 0;
                        pictureBoxes[newPosition.X, newPosition.Y].Tag = "0";
                        pictureBoxes[newPosition.X, newPosition.Y].Image = Properties.Resources.wall;
                        playerPosition = oldPlayerPosition;
                        UpdatePlayerPosition(statusPlayer);
                        if (!PathToGoal())
                        {
                            GameOverAct("Toàn bộ lối ra đã bị chặn!!");                         
                        }
                        dijkstra();
                        turnsLeft = minimunStep * 2;
                    }
                }
            }
            foreach(Point goalPosition in goalPositions.ToList())
            {
                if (playerPosition == goalPosition)
                {
                    CountDownTimer.Stop();
                    GameTimer.Stop();
                    var ans = MessageBox.Show("Bạn có muốn chơi màn " + (gameLevel+1).ToString(), "Tiếp tục",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ans == DialogResult.Yes)
                    {
                        ContinueNewGame();
                        DeleteContinueFile(1);                       
                    }
                    else
                    {
                        DeleteContinueFile(0);
                        Exit();
                    }
                    return;
                }
            }
        }
        private bool BFS(Point s, Point f)
        {
            if (s.X < 0 || s.X >= rows || s.Y < 0 || s.Y >= cols ||
                f.X < 0 || f.X >= rows || f.Y < 0 || f.Y >= cols ||
                maze[s.X, s.Y] == 0 || maze[f.X, f.Y] == 0)
            {
                return false;
            }

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((s.X, s.Y));

            bool[,] visited = new bool[rows, cols];
            visited[s.X, s.Y] = true;

            int[,] dirs = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();

                if (curr.Item1 == f.X && curr.Item2 == f.Y)
                {
                    return true;
                }

                for (int i = 0; i < 4; i++)
                {
                    int newX = curr.Item1 + dirs[i, 0];
                    int newY = curr.Item2 + dirs[i, 1];

                    if (newX >= 0 && newX < rows &&
                        newY >= 0 && newY < cols &&
                        maze[newX, newY] != 0 && !visited[newX, newY])
                    {
                        queue.Enqueue((newX, newY));
                        visited[newX, newY] = true;
                    }
                }
            }

            return false;
        }
        private bool IsValidMove(Point position)
        {
            if (position.X < 0 || position.X >= maze.GetLength(1) ||
                position.Y < 0 || position.Y >= maze.GetLength(0))
            {
                return false;
            }
            return maze[position.X, position.Y] != 0;
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
        }
        private void GameOverAct(string reason)
        {
            gameOver = true;
            GameTimer.Stop();
            CountDownTimer.Stop();
            pictureBoxes[playerPosition.X, playerPosition.Y].Image = Properties.Resources.kdead;
            MessageBox.Show(reason, "Game Over");
            HistoryWinner();
            addCashToBalance();
            DeleteContinueFile(1);
            Exit();
        }
        private void HistoryWinner()
        {
            List<string> data = new List<string>()
            {
                playerName,
                gameLevel.ToString(),
                score.ToString(),
            };
            FileStream f = new FileStream("data.txt", FileMode.Append, FileAccess.Write);  
            StreamWriter sw = new StreamWriter(f);

            foreach (var line in data)
            {
                sw.WriteLine(line);
            }
      
            sw.Flush(); 
            f.Close();
        }
        private void HistoryPlay()
        {
            FileStream f = new FileStream("continue.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sr = new StreamWriter(f);
            sr.WriteLine(gameLevel.ToString());
            sr.WriteLine(rows.ToString());
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sr.Write(maze[i,j].ToString() + ' ');
                }
                sr.Write('\n');
            }
            sr.WriteLine(playerPosition.X.ToString() + " " + playerPosition.Y.ToString());
            sr.WriteLine(health_Bar.Value.ToString());
            sr.WriteLine(score.ToString());
            sr.WriteLine(turnsLeft.ToString());

            foreach (var quiz in stQuiz)
            {
                sr.WriteLine(quiz.Item1.ToString() + "\n" + quiz.Item2.ToString());
            }

            sr.Flush();
            f.Close ();
        }
        private bool AskQuestion()
        {
            var tp = new Tuple<string, string>("Hiện không có câu hỏi ! \n Bấm YES để tiếp tục", "true");
            if (stQuiz.Count > 0)
            {
                tp = stQuiz.Peek();
                stQuiz.Pop();
            }
            

            DialogResult result = MessageBox.Show(tp.Item1,
                                      "Thử thách của thần Athena",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question,
                                      MessageBoxDefaultButton.Button1);

            string answer = "true";
            if (result == DialogResult.Yes)
            {
                answer = "true";
                
            }
            else if (result == DialogResult.No)
            {
                answer = "false";
            }

            if (answer == tp.Item2)
            {
                LuckyBox();
                claimCoinSound.Play();
                return true;
            }
            else
            {
                MessageBox.Show("Tiếc quá lùi lại đi!");
                answerSound.Play();
                return false;
            }
        }
        private void dijkstra()
        {
            int[,] length = new int[rows, cols];
            Point[,] luuvet = new Point[rows, cols];
            bool[,] visited = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    length[i, j] = int.MaxValue;
                    luuvet[i, j] = new Point(-1, -1);
                    visited[i, j] = false;
                }
            }

            int startX = playerPosition.X;
            int startY = playerPosition.Y;

            length[startX, startY] = 0;

            var pq = new SortedSet<(int Length, Point Pos)>(
                Comparer<(int Length, Point Pos)>.Create((a, b) =>
                {
                    int compareLength = a.Length.CompareTo(b.Length);
                    if (compareLength != 0) return compareLength;
                    return a.Pos.X != b.Pos.X ? a.Pos.X.CompareTo(b.Pos.X) : a.Pos.Y.CompareTo(b.Pos.Y);
                })
            );

            pq.Add((0, new Point(startX, startY)));

            Point minPoint = new Point(-1, -1);

            while (pq.Count > 0)
            {
                var current = pq.Min;
                pq.Remove(current);

                int x = current.Pos.X, y = current.Pos.Y;
                visited[x, y] = true;

                if (maze[x, y] == 3)
                {
                    minPoint = new Point(x, y);
                    break;
                }

                for (int i = 0; i < 4; i++)
                {
                    int xx = x + dx[i], yy = y + dy[i];

                    if (xx >= 0 && yy >= 0 && xx < rows && yy < cols && maze[xx, yy] != 0 && !visited[xx, yy])
                    {
                        int newLength = length[x, y] + 1;

                        if (newLength < length[xx, yy])
                        {
                            pq.Remove((length[xx, yy], new Point(xx, yy)));
                            length[xx, yy] = newLength;
                            luuvet[xx, yy] = new Point(x, y);
                            pq.Add((newLength, new Point(xx, yy)));
                        }
                    }
                }
            }
            path = new List<Point>();
            while (minPoint.X != startX || minPoint.Y != startY)
            {
                path.Insert(0, minPoint);
                if (minPoint.X <= rows && minPoint.Y <= cols) minPoint = luuvet[minPoint.X, minPoint.Y];
            }
            minimunStep = path.Count;
        }
        private void LuckyBox()
        {
            int gift = random.Next(1, 4);
            switch (gift)
            {
                case 1:
                    int scoreBonus = random.Next(0, 10);
                    if (usedHint == true) scoreBonus = 0;
                    score += scoreBonus;
                    MessageBox.Show("Bạn nhận được " + scoreBonus.ToString() + " xu!");
                    break;
                case 2:
                    int turnsLeftBonus = random.Next(5, 20);
                    turnsLeft += turnsLeftBonus;
                    MessageBox.Show("Bạn nhận được " + turnsLeftBonus.ToString() + " bước đi!");
                    break;
                case 3:
                    int timeBonus = random.Next(10, 30);
                    if (health_Bar.Value + timeBonus <= health_Bar.Maximum)
                    {
                        health_Bar.Value += timeBonus;
                    }
                    else health_Bar.Value = health_Bar.Maximum;
                    MessageBox.Show("Bạn nhận được " + timeBonus.ToString() + " giây!");
                    break;
            }
        }
        private bool PathToGoal()
        {
            foreach (Point goal in goalPositions)
            {
                if (BFS(playerPosition, goal)) return true;
            }
            return false;
        }
        private void ShowHint()
        {
            txtHint.Text = ": 0";
            dijkstra();
            foreach (var point in path)
            {
                if (maze[point.X, point.Y] == 1)
                {
                    maze[point.X, point.Y] = 4;
                    pictureBoxes[point.X, point.Y].Tag = "4";
                    pictureBoxes[point.X, point.Y].Image = Properties.Resources.coin;
                    pictureBoxes[point.X, point.Y].BackgroundImage = Properties.Resources.floor;
                    pictureBoxes[point.X, point.Y].BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }
        private void Exit()
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Close();
            this.Dispose();
        }
        private void DeleteContinueFile(int mode)
        {
            string fileName = "continue.txt";
            if (mode == 1)
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        File.Delete(fileName);
                    }
                    catch { }
                }
            }
            else
            {
                FileStream f = new FileStream("continue.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sr = new StreamWriter(f);
                sr.WriteLine((gameLevel+1).ToString());

                sr.Flush();
                f.Close();
            }
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox pb && pb.Image != null)
                {
                    pb.Image.Dispose();
                }
            }
            base.OnFormClosed(e);
        }
        private void ContinueNewGame()
        {
            #region Dữ liệu người chơi
            FileStream g = new FileStream("infPlayer.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(g);
            sw.WriteLine(playerName);
            sw.WriteLine(score.ToString());
            sw.Flush();
            g.Close();
            #endregion
            pictureBoxes = null;
            maze = null;
            Game GameConsole = new Game(gameLevel+1);
            GameConsole.Show();
            this.Close();
            this.Dispose();
        }
        private void addCashToBalance()
        {
            FileStream f = new FileStream("balance.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            string fileContent = sr.ReadToEnd();
            f.Close();

            int tmpCash = 0;
            if (int.TryParse(fileContent, out tmpCash))
            {
                tmpCash += score;
            }
            else
            {
                tmpCash = score;
            }

            FileStream g = new FileStream("balance.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(g);
            sw.Write(tmpCash.ToString());
            sw.Flush();
            g.Close();
        }
    }
}
