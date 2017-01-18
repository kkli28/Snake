using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Snake_New {
    public class Option {
        private static int difficulty = Constant.DEFAULT_DIFFICULTY;
        private static int appleCount = Constant.DEFAULT_APPLE_COUNT;
        private static int appleColor = Constant.DEFAULT_APPLE_COLOR;
        private static int snakeColor = Constant.DEFAULT_SNAKE_COLOR;
        private static int boundaryAccross = Constant.DEFAULT_BOUNDARY_ACCROSS;
        private static bool readFile = false;  //第一次使用设置信息时需要读取文件

        //从文件读取设置信息
        private static void readOption() {
            if (readFile) return;
            try {
                string[] options = File.ReadAllLines(Constant.OPTION_FILE);

                //文件中的设置信息错误（非数字），初始化设置信息
                if (!Int32.TryParse(options[0], out difficulty)
                    || !Int32.TryParse(options[1], out appleCount)
                    || !Int32.TryParse(options[2], out appleColor)
                    || !Int32.TryParse(options[3], out snakeColor)
                    || !Int32.TryParse(options[4], out boundaryAccross)) {
                    reset();
                }

                //设置信息越界
                if (!validOptions(difficulty, appleCount, appleColor, snakeColor, boundaryAccross))
                    reset();

            } catch (Exception e) {  //没有设置文件，则重置设置、新建文件并写入
                reset();
                writeToFile();
            }
            readFile = true;
        }

        //边界检查
        private static bool validOptions(int p1, int p2, int p3, int p4, int p5) {
            //边界检查
            if (p1 < Constant.MIN_DIFFICULTY || p1 > Constant.MAX_DIFFICULTY)
                return false;
            if (p2 < Constant.MIN_APPLE_COUNT || p2 > Constant.MAX_APPLE_COUNT)
                return false;
            if (p3 < Constant.MIN_APPLE_COLOR || p3 > Constant.MAX_APPLE_COLOR)
                return false;
            if (p4 < Constant.MIN_SNAKE_COLOR || p4 > Constant.MAX_SNAKE_COLOR)
                return false;
            if (p5 < Constant.MIN_BOUNDARY_ACCROSS || p5 > Constant.MAX_BOUNDARY_ACCROSS)
                return false;
            return true;
        }

        //将设置信息写入文件
        private static void writeToFile() {
            string[] options = {
                difficulty.ToString(),
                appleCount.ToString(),
                appleColor.ToString(),
                snakeColor.ToString(),
                boundaryAccross.ToString()
            };
            File.WriteAllLines(Constant.OPTION_FILE, options);  //将设置信息写入文件
        }

        //通过私有静态变量并用public函数来获取静态变量，可保证获取的设置是正确的
        public static int getDifficulty() {
            readOption();
            return difficulty;
        }

        public static int getAppleCount() {
            readOption();
            return appleCount;
        }

        public static int getAppleColor() {
            readOption();
            return appleColor;
        }

        public static int getSnakeColor() {
            readOption();
            return snakeColor;
        }

        public static int getBoundaryAccross() {
            readOption();
            return boundaryAccross;
        }

        //设置信息
        public static void set(int p1, int p2, int p3, int p4, int p5) {
            if (!validOptions(p1, p2, p3, p4, p5)) throw new Exception("Option.set()，参数错误!");
            difficulty = p1;
            appleCount = p2;
            appleColor = p3;
            snakeColor = p4;
            boundaryAccross = p5;
            writeToFile();  //将设置信息写入文件
        }

        //重置
        public static void reset() {
            difficulty = Constant.DEFAULT_DIFFICULTY;
            appleCount = Constant.DEFAULT_APPLE_COUNT;
            appleColor = Constant.DEFAULT_APPLE_COLOR;
            snakeColor = Constant.DEFAULT_SNAKE_COLOR;
            boundaryAccross = Constant.DEFAULT_BOUNDARY_ACCROSS;
            writeToFile();
        }

        //毫秒数
        public static int Interval() {
            readOption();
            switch (difficulty) {
                case 0: return Constant.DIFFICULTY0_VALUE;
                case 1: return Constant.DIFFICULTY1_VALUE;
                case 2: return Constant.DIFFICULTY2_VALUE;
                default: throw new Exception("Option.Interval()，难度参数错误!");
            }
        }

        //苹果个数
        public static int AppleCount() {
            readOption();
            switch (appleCount) {
                case 0: return Constant.APPLE_COUNT0_VALUE;
                case 1: return Constant.APPLE_COUNT1_VALUE;
                case 2: return Constant.APPLE_COUNT2_VALUE;
                case 3: return Constant.APPLE_COUNT3_VALUE;
                default: throw new Exception("Option.AppleCount()，苹果个数参数错误!");
            }
        }

        //苹果颜色
        public static Color AppleColor() {
            readOption();
            switch (appleColor) {
                case 0: return Color.Red;
                case 1: return Color.Orange;
                case 2: return Color.Purple;
                default: throw new Exception("Option.AppleColor()，颜色参数错误!");
            }
        }

        //蛇身体颜色值到颜色的转换
        public static Color SnakeColor() {
            readOption();
            switch (snakeColor) {
                case 0: return Color.Lime;
                case 1: return Color.Yellow;
                case 2: return Color.LightGray;
                default: throw new Exception("Option.SnakeColor()，颜色参数错误!");
            }
        }

        //通过游戏设置获取记录所以
        public static int getRecordIndex() {
            readOption();
            return difficulty * 8 + appleCount * 2 + boundaryAccross;
        }

        //获取设置信息
        public static string getInfo() {
            readOption();
            return "difficulty:" + difficulty.ToString() + "  appleCount:" + appleCount.ToString() +
                "  appleColor:" + appleColor.ToString() + "  snakeColor:" + snakeColor.ToString() +
                "  boundaryAccross:" + boundaryAccross.ToString();
        }
    }
}
