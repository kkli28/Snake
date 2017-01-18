using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Snake_New {
    public partial class GameForm : Form {

        Random random;              //随机数生成器对象
        Map map;                          //游戏地图
        int score;                            //分数
        int record;                          //游戏记录
        Snake snake;
        bool inGame;                     //游戏中
        bool gameIsOver;                //游戏结束
        int direction;                      //蛇移动方向
        int appleCount;                 //苹果个数
        Point[] apple;                    //苹果数组
        Color appleColor;              //苹果的颜色
        Color snakeHeadColor;     //蛇头颜色
        Color snakeBodyColor;     //蛇身颜色
        int interval;                        //毫秒数
        int boundaryAccross;        //穿越边界

        int gameMode;                 //游戏模式
        int hurdleIndex;                //挑战模式关卡索引
        Color postColor;              //柱子颜色
        int recordIndex;                //经典模式游戏记录位置
        int[] customPostArray;      //自定义模式柱子数组

        //构造函数
        //mode：游戏模式    hi：关卡索引    ba：是否跨越边界    cpa：自定义模式柱子数组
        public GameForm(int mode, int hi=-1, int ba = Constant.NO_BOUNDARY_ACCROSS,int[] cpa=null) {
            InitializeComponent();

            gameMode = mode;
            postColor = Color.Gray;
            hurdleIndex = hi;

            recordIndex = Option.getRecordIndex();
            customPostArray = new int[Constant.MAX_INDEX + 1];
            switch (gameMode) {
                //经典模式
                case Constant.CLASSIC_MODE:
                    try {
                        appleCount = Option.AppleCount();
                        appleColor = Option.AppleColor();
                        snakeBodyColor = Option.SnakeColor();
                        interval = Option.Interval();
                        boundaryAccross = Option.getBoundaryAccross();

                        record = Int32.Parse(File.ReadAllLines(Constant.RECORD_FILE)[recordIndex]);
                    } catch (Exception e) {
                        MessageBox.Show("获取游戏记录失败，已重置记录！\n" + e.Message);
                        string[] s = new string[Constant.MAX_RECORD_COUNT + 1];
                        for (int i = 0; i < Constant.MAX_RECORD_COUNT + 1; i++)
                            s[i] = "0";
                        File.WriteAllLines(Constant.RECORD_FILE, s);
                        record = 0;
                    }
                    break;
                //挑战模式
                case Constant.CHALLENGE_MODE:
                    try {
                        appleCount = 1;
                        appleColor = Color.Red;
                        snakeBodyColor = Color.Lime;
                        interval = Constant.CHALLENGE_INTERVAL;
                        boundaryAccross = ba;

                        record = Int32.Parse(File.ReadAllLines(Constant.HURDLE_RECORD_FILE)[hurdleIndex]);
                    } catch (Exception e) {
                        MessageBox.Show("获取游戏记录失败，已重置记录！");
                        record = 0;
                    }
                    break;

                 //自定义模式
                case Constant.CUSTOM_MODE:
                    try {
                        appleCount = 1;
                        appleColor = Color.Red;
                        snakeBodyColor = Color.Lime;
                        interval = Constant.CUSTOM_INTERVAL;
                        boundaryAccross = ba;
                        recordLB.Visible = false;  //不显示记录

                        //获取柱子信息
                        for (int i = 0; i < Constant.MAX_INDEX + 1; i++)
                            customPostArray[i] = cpa[i];

                        record = 0;
                    }catch(Exception e) {
                        MessageBox.Show("加载自定义模式失败！");
                        record = 0;
                    }
                    break;
                default: throw new Exception("GameForm.GameForm()，游戏模式错误！");
            }

            random = new Random();
            map = new Map();
            score = 0;
            snake = new Snake();
            inGame = false;
            gameIsOver = false;
            direction = Constant.DIRECTION_RIGHT;
            apple = new Point[appleCount];
            snakeHeadColor = Color.Blue;
            timer1.Interval = interval;
            recordLB.Text = record.ToString();

            if (gameMode == Constant.CHALLENGE_MODE)
                setAndShowPost();
            else if(gameMode==Constant.CLASSIC_MODE){
                difficultyLB.Visible = true;
                appleCountLB.Visible = true;
                boundaryAccrossLB.Visible = true;
            }else {
                boundaryAccrossLB.Visible = true;
                setAndShowCustomPost();
            }
           
            //显示设置信息
            string d = "未知";
            switch (Option.getDifficulty()) {
                case 0: d = "困难"; break;
                case 1: d = "普通"; break;
                case 2: d = "简单"; break;
                default: break;
            }
            difficultyLB.Text = d;
            appleCountLB.Text = appleCount.ToString();
            if (boundaryAccross == Constant.NO_BOUNDARY_ACCROSS) boundaryAccrossLB.Text = "否";
            else boundaryAccrossLB.Text = "是";
        }

        //显示自定义模式柱子
        public void setAndShowCustomPost() {
            for(int i = 0; i < Constant.MAX_INDEX + 1; i++) {
                if (customPostArray[i] == Constant.BUTTON_STATE1) {
                    map.set(i, Constant.POST);
                    getPictureBox(i).BackColor = postColor;
                }
            }
        }

        //蛇重生
        public void snakeBorn() {
            Point[] s = new Point[3] {
                new Point(2,1), new Point(2,2),new Point(2,3)
            };

            //添加点到蛇身体中
            snake.append(s[0]);
            snake.append(s[1]);
            snake.append(s[2]);

            //设置对应图信息
            map.set(s[0], Constant.SNAKE_BODY);
            map.set(s[1], Constant.SNAKE_BODY);
            map.set(s[2], Constant.SNAKE_BODY);
        }

        //游戏结束处理
        public void gameOver() {
            timer1.Stop();
            inGame = false;
            GameOverForm gof;
            if (gameMode == Constant.CLASSIC_MODE)
                gof = new GameOverForm(record, score, gameMode, recordIndex);
            else if (gameMode == Constant.CHALLENGE_MODE)
                gof = new GameOverForm(record, score, gameMode, hurdleIndex);
            else
                gof = new GameOverForm(record, score, gameMode, 0);
            
            gof.ShowDialog();
            resetPBBackColor();

            //挑战模式或自定义模式，则显示柱子
            if (gameMode == Constant.CHALLENGE_MODE) setAndShowPost();
            else if (gameMode == Constant.CUSTOM_MODE) setAndShowCustomPost();

            if (record < score) record = score;
            recordLB.Text = record.ToString();
        }

        //开始游戏
        public void start() {
            map.reset();              //重置地图
            resetPBBackColor();  //重置PictureBox
            snake.reset();            //重置蛇

            //若是挑战模式，则设置柱子
            if (gameMode == Constant.CHALLENGE_MODE)
                setAndShowPost();
            else if (gameMode == Constant.CUSTOM_MODE)
                setAndShowCustomPost();

            snakeBorn();             //蛇重生
            getAllApple();           //获取所有的苹果
            showSnake();            //显示蛇
            showApple();            //显示苹果
            score = 0;                 //重置分数
            timer1.Start();
            inGame = true;
            gameIsOver = false;
            direction = Constant.DIRECTION_RIGHT;

            scoreLB.Text = "0";
            recordLB.Text = record.ToString();
        }

        //刷新PictureBox
        public void refreshPBBackColor() {
            //显示蛇
            int snakeCount = snake.getCount();
            Point[] s = snake.getSnake();
            for (int i = 1; i < snakeCount - 1; i++) {
                getPictureBox(s[i]).BackColor = snakeBodyColor;
            }
            getPictureBox(s[snakeCount - 1]).BackColor = Color.Blue;

            //显示苹果
            for (int i = 0; i < appleCount; i++)
                getPictureBox(apple[i]).BackColor = appleColor;
        }

        //显示蛇
        public void showSnake() {
            int snakeCount = snake.getCount();
            Point[] s = snake.getSnake();

            //蛇身体
            for (int i = 1; i < snakeCount - 1; i++)
                getPictureBox(s[i]).BackColor = snakeBodyColor;

            //蛇头
            getPictureBox(s[snakeCount - 1]).BackColor = snakeHeadColor;
        }

        //刷新蛇
        //TODO
        public void refreshSnake() {
            int snakeCount = snake.getCount();
            Point[] s = snake.getSnake();
            getPictureBox(s[0]).BackColor = Color.White;
            getPictureBox(s[snakeCount - 2]).BackColor = snakeBodyColor;
            getPictureBox(s[snakeCount - 1]).BackColor = snakeHeadColor;
        }

        //显示苹果
        public void showApple() {
            for (int i = 0; i < appleCount; i++)
                getPictureBox(apple[i]).BackColor = appleColor;
        }

        //刷新苹果
        public void refreshApple() {
            getPictureBox(apple[0]).BackColor = appleColor;
        }

        //获取所有的苹果
        public void getAllApple() {
            int index = 0;
            for (int i = 0; i < appleCount; i++) {
                do {
                    index = random.Next(Constant.MAX_INDEX);  //不是...+1，因为最后一个位置用于蛇初始化时的“之前的尾巴”
                } while (map.getValue(index) != Constant.NULL);

                apple[i] = new Point(index);
                map.set(apple[i], Constant.APPLE);
            }
        }

        //获取一个苹果
        public void getApple() {
            int index = 0;

            int free = map.getFree();
            if (free < appleCount) return;  //当剩余格子不足生成苹果时，不再添加新苹果

            //直到随机出的点位置为空为止
            do {
                index = random.Next(Constant.MAX_INDEX + 1);
            } while (map.getValue(index) != Constant.NULL);
            apple[0] = new Point(index);
            map.set(apple[0], Constant.APPLE);
        }

        //重置PictureBox背景色
        public void resetPBBackColor() {
            foreach (Control c in this.Controls)
                if (c is PictureBox) c.BackColor = Color.White;
        }

        //通过索引获取PictureBox
        public PictureBox getPictureBox(int index) {
            if (index < Constant.MIN_INDEX || index > Constant.MAX_INDEX)
                throw new Exception("GameForm.getPictureBox()，索引错误!");
            foreach (Control c in this.Controls) {
                if (c is PictureBox) {
                    if (c.Name == "pictureBox" + index.ToString()) return (PictureBox)c;
                }
            }
            return null;
        }

        //通过点获取PictureBox
        public PictureBox getPictureBox(Point p) {
            if (!p.Valid) throw new Exception("GameForm.getPictureBox()，点不合法!");
            int index = p.X * (Constant.MAX_Y + 1) + p.Y;
            return getPictureBox(index);
        }

        private void timer1_Tick(object sender, EventArgs e) {
            inGame = false;  //匹配末尾的inGame=true，避免在此函数执行时用户按键导致行为不一致
            if (gameIsOver) {
                timer1.Stop();
                inGame = false;
                gameOver();
                return;
            }

            int result = snake.move(map, direction, apple, appleCount, boundaryAccross);  //自动前进
            if (result == Constant.MOVE_DEAD) {
                gameIsOver = true;
                return;
            } else if (result == Constant.MOVE_EAT_APPLE) {
                score++;  //吃了苹果
                getApple();
            }
            refreshSnake();
            refreshApple();
            scoreLB.Text = score.ToString();
            inGame = true;
        }

        private void startBtn_Click(object sender, EventArgs e) {
            timer1.Stop();

            //确认窗口
            if (inGame) {
                timer1.Stop();
                inGame = false;
                if (new ConfirmForm().ShowDialog() == DialogResult.Yes) start();
                else {
                    timer1.Start();
                    inGame = true;
                }
            } else start();
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e) {
            MenuForm.thisForm.Show();
        }

        //按键
        public void keyPress(int d) {
            int result = snake.move(map, d, apple, appleCount, boundaryAccross);
            int temp = direction;
            direction = d;

            if (result == Constant.MOVE_DEAD) {
                gameIsOver = true;
                return;
            } else if (result == Constant.MOVE_EAT_APPLE) {
                score++;
                getApple();
            } else if (result == Constant.MOVE_NEG_DIRECTION) direction = temp;

            refreshSnake();
            refreshApple();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e) {
            if (inGame) {
                timer1.Stop();
                timer1.Enabled = false;
                switch (e.KeyCode) {
                    case Keys.W: {
                            keyPress(Constant.DIRECTION_UP);
                            break;
                        }
                    case Keys.S: {
                            keyPress(Constant.DIRECTION_DOWN);
                            break;
                        }
                    case Keys.A: {
                            keyPress(Constant.DIRECTION_LEFT);
                            break;
                        }
                    case Keys.D: {
                            keyPress(Constant.DIRECTION_RIGHT);
                            break;
                        }
                    default: break;
                }
                timer1.Enabled = true;
                timer1.Start();
            }
        }

        private void GameForm_Load(object sender, EventArgs e) {

        }

        //通过整型数组设置柱子，注意！！！只供setAndShowPost()函数使用
        public void setPost_Array(int[] array, int count) {
            if (count <= 0 || count >= 100) throw new Exception("错误的长度！！！");
            for (int i = 0; i < count; i++) {
                map.set(array[i], Constant.POST);
                getPictureBox(array[i]).BackColor = postColor;
            }
        }

        //通过循环设置柱子，注意！！！只供setAndShowPost()函数使用
        public void setPost_Loop(int beg, int end, int space) {
            if (beg < 0 || beg > Constant.MAX_INDEX) {
                MessageBox.Show("循环初始变量不合法！");
                return;
            }
            if (end < 0 || end > Constant.MAX_INDEX) {
                MessageBox.Show("循环结束变量不合法！");
                return;
            }
            if (beg >= end) {
                MessageBox.Show("循环初始变量大于等于循环结束变量！");
                return;
            }

            int count = space + 1;
            for (int i = beg; i <= end; i++) {
                if (count % space == 0) {
                    count = 1;
                    map.set(i, Constant.POST);
                    getPictureBox(i).BackColor = postColor;
                    continue;
                }
                count++;
            }
        }

        //通过点设置柱子，注意！！！只供setAndShowPost()函数使用
        public void setPost_Point(int beg, int end, int space) {
            if (beg < 0 || beg > Constant.MAX_INDEX) {
                MessageBox.Show("循环初始变量不合法！");
                return;
            }
            if (end < 0 || end > Constant.MAX_INDEX) {
                MessageBox.Show("循环结束变量不合法！");
                return;
            }
            if (beg >= end) {
                MessageBox.Show("循环初始变量大于等于循环结束变量！");
                return;
            }

            int count = space + 1;
            for (int i = beg; i <= end; i++) {
                if (count % space == 0) {
                    count = 1;
                    map.set(i, Constant.POST);
                    getPictureBox(i).BackColor = postColor;

                    Point p = new Point(i);
                    p.set(p.X + 1, p.Y + 1);
                    if (p.Valid) {
                        map.set(p, Constant.POST);
                        getPictureBox(p).BackColor = postColor;
                    }
                    continue;
                }
                count++;
            }
        }

        //获取柱子
        public void setAndShowPost() {
            switch (hurdleIndex) {
                //第一关
                case 0: {
                        setPost_Array(new int[5] { 125, 126, 127, 149, 173 }, 5);
                        setPost_Array(new int[5] { 450, 426, 402, 449, 448 }, 5);
                        break;
                    }

                //第二关
                case 1: {
                        for (int i = 172; i <= 187; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }
                        for (int i = 364; i <= 379; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }
                        break;
                    }

                //第三关
                case 2: {
                        for (int i = 168; i <= 179; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }
                        for (int i = 372; i <= 383; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }
                        break;
                    }

                //第四关
                case 3: {
                        for (int i = 168; i <= 175; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }
                        for (int i = 400; i <= 407; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }

                        setPost_Array(new int[8] { 391, 415, 439, 463, 487, 511, 535, 559 }, 8);
                        setPost_Array(new int[8] { 16, 40, 64, 88, 112, 136, 160, 184 }, 8);
                        break;
                    }

                //第五关
                case 4: {
                        for (int i = 104; i <= 111; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }
                        for (int i = 464; i <= 471; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }

                        setPost_Array(new int[8] { 196, 220, 244, 268, 292, 316, 340, 364 }, 8);
                        setPost_Array(new int[8] { 211, 235, 259, 283, 307, 331, 355, 379 }, 8);
                        break;
                    }

                //第六关
                case 5: {
                        setPost_Array(new int[5] { 125, 126, 127, 149, 173 }, 5);
                        setPost_Array(new int[5] { 450, 426, 402, 449, 448 }, 5);
                        setPost_Array(new int[5] { 136, 137, 138, 162, 186 }, 5);
                        setPost_Array(new int[5] { 389, 413, 437, 438, 439 }, 5);
                        break;
                    }

                //第七关
                case 6: {
                        for (int i = 98; i <= 105; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }

                        for (int i = 110; i <= 117; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }

                        for (int i = 458; i <= 465; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }

                        for (int i = 470; i <= 477; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }

                        for (int i = 272; i <= 275; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }

                        for (int i = 300; i <= 303; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }

                        break;
                    }

                //第八关
                case 7: {
                        setPost_Loop(460, 475, 1);
                        setPost_Loop(345, 355, 1);
                        setPost_Loop(230, 235, 1);

                        map.set(115, Constant.POST);
                        getPictureBox(115).BackColor = postColor;

                        Point[] array = new Point[16];
                        array[0] = new Point(460);
                        for (int i = 1; i < 16; i++) {
                            array[i] = new Point(array[0].X - i, array[0].Y);
                            map.set(array[i], Constant.POST);
                            getPictureBox(array[i]).BackColor = postColor;
                        }

                        array = new Point[11];
                        array[0] = new Point(345);
                        for (int i = 1; i < 11; i++) {
                            array[i] = new Point(array[0].X - i, array[0].Y);
                            map.set(array[i], Constant.POST);
                            getPictureBox(array[i]).BackColor = postColor;
                        }

                        array = new Point[6];
                        array[0] = new Point(230);
                        for (int i = 1; i < 6; i++) {
                            array[i] = new Point(array[0].X - i, array[0].Y);
                            map.set(array[i], Constant.POST);
                            getPictureBox(array[i]).BackColor = postColor;
                        }

                        break;
                    }

                //第九关
                case 8: {
                        setPost_Array(new int[5] { 125, 126, 127, 149, 173 }, 5);
                        setPost_Array(new int[5] { 450, 426, 402, 449, 448 }, 5);
                        setPost_Array(new int[5] { 136, 137, 138, 162, 186 }, 5);
                        setPost_Array(new int[5] { 389, 413, 437, 438, 439 }, 5);
                        setPost_Array(new int[4] { 228, 252, 323, 347 }, 4);

                        for (int i = 273; i <= 276; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }
                        for (int i = 299; i <= 302; i++) {
                            map.set(i, Constant.POST);
                            getPictureBox(i).BackColor = postColor;
                        }

                        break;
                    }

                //第十关
                case 9: {
                        int[] array = new int[32] {
                            99,100,104,105,109,110,114,115,
                            219,220,224,225,229,230,234,235,
                            339,340,344,345,349,350,354,355,
                            459,460,464,465,469,470,474,475
                        };
                        setPost_Array(array, 32);
                        
                        break;
                    }

                //第十一关
                case 10: {
                        setPost_Loop(72, 94, 4);
                        setPost_Loop(168, 190, 4);
                        setPost_Loop(264, 286, 4);
                        setPost_Loop(360, 382, 4);
                        setPost_Loop(456, 478, 4);

                        break;
                    }

                //第十二关
                case 11: {
                        setPost_Point(69, 93, 6);
                        setPost_Point(168, 189, 6);
                        setPost_Point(261, 285, 6);
                        setPost_Point(360, 382, 6);
                        setPost_Point(453, 477, 6);

                        break;
                    }
                default: MessageBox.Show("关卡索引错误，无法加载关卡信息！"); break;
            }
        }
    }
}
