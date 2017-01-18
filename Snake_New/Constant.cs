using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake_New {
    public class Constant {
        public const int MIN_X = 0;                     //横坐标最小值
        public const int MAX_X = 23;                  //横坐标最大值
        public const int MIN_Y = 0;                     //纵坐标最小值
        public const int MAX_Y = 23;                  //纵坐标最大值
        public const int MIN_INDEX = 0;            //索引最小值
        public const int MAX_INDEX = (MAX_X + 1) * (MAX_Y + 1) - 1;        //索引最大值

        //地图元素可取值：
        //0：无    1：蛇身体    2：苹果    3：柱子
        //
        public const int MIN_VALUE = 0;           //地图元素最小值
        public const int MAX_VALUE = 3;          //地图元素最大值
        public const int NULL = 0;                     //空元素对应的值
        public const int SNAKE_BODY = 1;      //蛇身体
        public const int APPLE = 2;                    //苹果
        public const int POST = 3;                      //柱子
        
        //难度分3类：1,2,3
        //苹果个数：1,2,5,10
        //苹果颜色：红,橙,紫
        //蛇身颜色：绿,黄,灰
        //边界跨越：不允许,允许
        //注意，更改常量的时候需要更改Option类中的转换函数如 xxxToxxx()

        //设置取值范围
        public const int MIN_DIFFICULTY = 0;
        public const int MAX_DIFFICULTY = 2;
        public const int MIN_APPLE_COUNT = 0;
        public const int MAX_APPLE_COUNT = 3;
        public const int MIN_APPLE_COLOR = 0;
        public const int MAX_APPLE_COLOR = 2;
        public const int MIN_SNAKE_COLOR = 0;
        public const int MAX_SNAKE_COLOR = 2;
        public const int MIN_BOUNDARY_ACCROSS = 0;
        public const int MAX_BOUNDARY_ACCROSS = 1;

        //默认值
        public const int DEFAULT_DIFFICULTY = 1;
        public const int DEFAULT_APPLE_COUNT = 0;
        public const int DEFAULT_APPLE_COLOR = 0;
        public const int DEFAULT_SNAKE_COLOR = 0;
        public const int DEFAULT_BOUNDARY_ACCROSS = 0;

        public const int CHALLENGE_INTERVAL = 150;

        //设置数值
        public const int NO_BOUNDARY_ACCROSS = 0;
        public const int BOUNDARY_ACCROSS = 1;

        //难度等级对应的毫秒数
        public const int DIFFICULTY0_VALUE = 50;
        public const int DIFFICULTY1_VALUE = 100;
        public const int DIFFICULTY2_VALUE = 200;
        
        //苹果个数项对应的苹果个数
        public const int APPLE_COUNT0_VALUE = 1;
        public const int APPLE_COUNT1_VALUE = 2;
        public const int APPLE_COUNT2_VALUE = 5;
        public const int APPLE_COUNT3_VALUE = 10;

        //设置文件、记录文件
        public const string OPTION_FILE = "option.txt";
        public const string RECORD_FILE = "record.txt";
        public const string HURDLE_RECORD_FILE = "hurdle_record.txt";
        
        //移动方向
        public const int DIRECTION_UP = 0;
        public const int DIRECTION_DOWN = 1;
        public const int DIRECTION_LEFT = 2;
        public const int DIRECTION_RIGHT = 3;

        //蛇尝试移动后的返回值
        public const int MOVE_DEAD = 0;
        public const int MOVE_SUCCESS = 1;
        public const int MOVE_EAT_APPLE = 2;
        public const int MOVE_NEG_DIRECTION = 3;

        //关卡目标
        public const int HURDLE_AIM = 20;

        //分数
        public const int MIN_SCORE = 0;
        public const int MAX_SCORE = 10000;

        //记录个数
        public const int MAX_RECORD_COUNT = 23;
        public const int MAX_HURDLE_RECORD_COUNT = 11;

        //游戏模式
        public const int CLASSIC_MODE = 0;
        public const int CHALLENGE_MODE = 1;
        public const int CUSTOM_MODE = 2;


        //自定义模式
        public const int CUSTOM_INTERVAL = 150;

        //按钮状态
        public const int BUTTON_STATE0 = 0;    //未选中
        public const int BUTTON_STATE1 = 1;    //选中
    }
}
