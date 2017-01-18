using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_New {
    public class Snake {
        private Point[] snake;        //蛇身体数组，0下标之前的蛇尾，1下标为当前蛇尾，大下标为蛇头
        private int count;              //蛇身体长度

        //构造函数
        public Snake() {
            snake = new Point[Constant.MAX_INDEX + 1];
            snake[0] = new Point(Constant.MAX_X, Constant.MAX_Y);
            count = 1;
        }

        //重置
        public void reset() {
            count = 1;
        }

        //获取蛇头
        public Point getHead() {
            return new Point(snake[count - 1]);
        }

        //获取蛇尾
        public Point getTail() {
            return new Point(snake[1]);
        }

        //获取前一次的蛇尾
        public Point getPreTail() {
            return new Point(snake[0]);
        }

        //获取长度
        public int getCount() {
            return count;
        }

        //获取蛇数组
        public Point[] getSnake() {
            return snake;
        }

        //添加点到蛇尾（吃苹果后调用）
        public void append(Point p) {
            if (!p.Valid) throw new Exception("Snake.append()，点不合法!");
            snake[count++] = new Point(p.X, p.Y);
        }

        //移动
        //返回值0：挂了    1：移动成功    2：吃了apple    3：反方向移动
        public int move(Map map, int direction, Point[] apple, int appleCount,int boundaryAccross) {
            int x = snake[count - 1].X;         //蛇头x
            int y = snake[count - 1].Y;         //蛇头y
            Point p;                                    //待前进的点
            switch (direction) {
                case Constant.DIRECTION_UP:
                    p = new Point(x - 1, y); break;
                case Constant.DIRECTION_DOWN:
                    p = new Point(x + 1, y); break;
                case Constant.DIRECTION_LEFT:
                    p = new Point(x, y - 1); break;
                case Constant.DIRECTION_RIGHT:
                    p = new Point(x, y + 1); break;
                default:
                    throw new Exception("Snake.move()，方向信息错误!");
            }
            
            //假如允许穿越边界，则p.X或p.Y为-1或最大值时，需要将其设置为正确的对应位置
            if (boundaryAccross == Constant.BOUNDARY_ACCROSS) {
                if (p.X < 0) p.set(p.X + Constant.MAX_X + 1, p.Y);
                else if (p.X > Constant.MAX_X) p.set(p.X - Constant.MAX_X - 1, p.Y);
                if (p.Y < 0) p.set(p.X, p.Y + Constant.MAX_Y + 1);
                else if (p.Y > Constant.MAX_Y) p.set(p.X, p.Y - Constant.MAX_Y - 1);
            }
            
            //撞墙
            if (!p.Valid) return Constant.MOVE_DEAD;

            int value = map.getValue(p);    //获取点对应的地图值

            //没撞墙，方向走反
            if (p.equal(snake[count - 2])) return Constant.MOVE_NEG_DIRECTION;

            //撞上身体或柱子
            if (value == Constant.SNAKE_BODY || value==Constant.POST) return Constant.MOVE_DEAD;

            //有苹果
            if (value == Constant.APPLE) {
                snake[count++] = new Point(p.X, p.Y);    //将苹果添加到蛇数组作为蛇头
                map.set(p, Constant.SNAKE_BODY);        //更新对应地图值
                //找到苹果，并用0下标处的苹果替代
                for (int i = 0; i < appleCount; i++) {
                    if (apple[i].equal(p)) {
                        apple[i].set(apple[0].X, apple[0].Y);
                        break;
                    }
                }

                return Constant.MOVE_EAT_APPLE;
            }

            //移动成功，前方为空
            map.set(snake[1], Constant.NULL);  //蛇尾消失

            //蛇身体移动
            for (int i = 0; i < count - 1; i++)
                snake[i].set(snake[i + 1].X, snake[i + 1].Y);
            //添加新蛇头
            snake[count - 1].set(p.X, p.Y);
            map.set(p, Constant.SNAKE_BODY);             //更新地图
            return Constant.MOVE_SUCCESS;
        }
    }
}
