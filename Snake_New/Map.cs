using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_New {
    public class Map {
        private int[,] map;
        int free;                       //空余
        
        //构造函数
        public Map() {
            map = new int[Constant.MAX_X + 1, Constant.MAX_Y + 1];
            reset();
        }
        
        //重置图信息
        public void reset() {
            for (int i = 0; i < Constant.MAX_X + 1; i++) {
                for (int j = 0; j < Constant.MAX_Y + 1; j++)
                    map[i, j] = Constant.NULL;
            }
            free = Constant.MAX_INDEX + 1;
        }

        //设置值--通过Point类对象和值
        public void set(Point p,int value) {
            if (!p.Valid) throw new Exception("Map.set()，p.Valid为false!");
            if (value < Constant.MIN_VALUE || value > Constant.MAX_VALUE)
                throw new Exception("Map.set()，value值不和法!");

            if (value == Constant.APPLE || value == Constant.POST) free--;
            map[p.X, p.Y] = value;
        }

        //设置置--通过索引
        public void set(int index,int value) {
            if (index < Constant.MIN_INDEX || index > Constant.MAX_INDEX)
                throw new Exception("Map.set()，索引值错误！");
            if (value < Constant.MIN_VALUE || value > Constant.MAX_VALUE)
                throw new Exception("Map.set()，值错误！");
            int x = index / (Constant.MAX_Y + 1);
            int y = index % (Constant.MAX_Y + 1);

            if (value == Constant.APPLE || value==Constant.POST) free--;
            map[x, y] = value;
        }
        
        //获取值--对应点
        public int getValue(Point p) {
            if (!p.Valid) throw new Exception("Map.getValue()，p.Valid为false!");
            return map[p.X, p.Y];
        }

        //获取值--对应坐标
        public int getValue(int x,int y) {
            if (x < Constant.MIN_X || x > Constant.MAX_X || y < Constant.MIN_Y || y > Constant.MAX_Y)
                throw new Exception("Map.getValue()，x或y值不合法!");
            return map[x, y];
        }

        //获取值，通过索引
        public int getValue(int index) {
            if (index < Constant.MIN_INDEX || index > Constant.MAX_INDEX)
                throw new Exception("Map.getValue()，index值不合法!");
            int x = index / (Constant.MAX_Y + 1);
            int y = index % (Constant.MAX_Y + 1);
            return getValue(x, y);
        }

        //获取空余
        public int getFree() {
            return free;
        }

        //获取地图信息
        public string getInfo() {
            string s = "";
            for(int i = 0; i < Constant.MAX_X+1; i++) {
                for(int j = 0; j < Constant.MAX_Y+1; j++) {
                    s += map[i, j];
                }
                s += "\n";
            }
            return s;
        }
    }
}
