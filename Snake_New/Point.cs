using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_New {
    public class Point {
        private int x;                 //横坐标
        private int y;                 //纵坐标
        private bool valid;        //点是否合法

        //判断坐标是否合法--静态函数
        public static bool isValidPos(int posX, int posY) {
            if (posX < Constant.MIN_X || posX > Constant.MAX_X) return false;
            if (posY < Constant.MIN_Y || posY > Constant.MAX_Y) return false;
            return true;
        }

        //构造函数--无参
        public Point() {
            x = -1;
            y = -1;
            valid = false;
        }

        //构造函数--根据横纵坐标设定
        public Point(int posX, int posY) {
            x = posX;
            y = posY;
            valid = isValidPos(x, y);
        }

        //构造函数--根据索引设定
        public Point(int index) {
            if (index < Constant.MIN_INDEX || index > Constant.MAX_INDEX)
                throw new Exception("Point.Point()，索引错误!");
            x = index / (Constant.MAX_Y + 1);
            y = index % (Constant.MAX_Y + 1);
            valid = isValidPos(x, y);
        }

        //构造函数--复制
        public Point(Point p) {
            x = p.x;
            y = p.y;
            valid = isValidPos(x, y);
        }

        //获取某点对应方向上的点
        public static Point getDirectionPoint(Point p,int direction) {
            Point pp;
            switch (direction) {
                case Constant.DIRECTION_UP: pp = new Point(p.X - 1, p.Y); break;
                case Constant.DIRECTION_DOWN: pp = new Point(p.X + 1, p.Y); break;
                case Constant.DIRECTION_LEFT: pp = new Point(p.X, p.Y - 1); break;
                case Constant.DIRECTION_RIGHT: pp = new Point(p.X, p.Y + 1);break;
                default: throw new Exception("Point.getDirectionPoint()，方向错误!");
            }
            return pp;
        }

        //判断是否和另一点相同
        public bool equal(Point p) {
            if (x == p.x && y == p.y) return true;
            return false;
        }

        //设置点信息--通过横纵坐标
        public void set(int posX, int posY) {
            x = posX;
            y = posY;
            valid = isValidPos(x, y);
        }

        //设置点信息--通过索引
        public void set(int index) {
            if (index < Constant.MIN_INDEX || index > Constant.MAX_INDEX)
                throw new Exception("Point类获取到错误的索引，请检查程序中的错误!");
            x = index / (Constant.MAX_Y + 1);
            y = index % (Constant.MAX_Y + 1);
        }

        //X
        public int X {
            get { return x; }
            //无set，设置x和y必须 通过set进行安全地设置
        }

        //Y
        public int Y {
            get { return y; }
        }

        //Valid
        public bool Valid {
            get { return valid; }
            //无set，必须根据x和y的值来进行自动设置
        }

        //获取点信息
        public string getInfo() {
            return "x:" + x.ToString() + "  y:" + y.ToString() + "  valid:" + valid.ToString();
        }
    }
}
