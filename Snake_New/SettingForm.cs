using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_New {
    public partial class SettingForm : Form {
        public SettingForm() {
            InitializeComponent();

            //只允许使用下拉框
            difficultyCB.DropDownStyle = ComboBoxStyle.DropDownList;
            appleCountCB.DropDownStyle = ComboBoxStyle.DropDownList;
            appleColorCB.DropDownStyle = ComboBoxStyle.DropDownList;
            snakeColorCB.DropDownStyle = ComboBoxStyle.DropDownList;
            boundaryAccrossCB.DropDownStyle = ComboBoxStyle.DropDownList;

            //显示当前设置信息
            difficultyCB.SelectedIndex = Option.getDifficulty();
            appleCountCB.SelectedIndex = Option.getAppleCount();
            appleColorCB.SelectedIndex = Option.getAppleColor();
            snakeColorCB.SelectedIndex = Option.getSnakeColor();
            boundaryAccrossCB.SelectedIndex = Option.getBoundaryAccross();
        }

        //重置ComboBox
        public void resetCB() {
            difficultyCB.SelectedIndex = Constant.DEFAULT_DIFFICULTY;
            appleCountCB.SelectedIndex = Constant.DEFAULT_APPLE_COUNT;
            appleColorCB.SelectedIndex = Constant.DEFAULT_APPLE_COLOR;
            snakeColorCB.SelectedIndex = Constant.DEFAULT_SNAKE_COLOR;
            boundaryAccrossCB.SelectedIndex = Constant.DEFAULT_BOUNDARY_ACCROSS;
        }

        private void SettingForm_Load(object sender, EventArgs e) {

        }

        private void resetBtn_Click(object sender, EventArgs e) {
            resetCB();
            Option.reset();  //重置设置信息
        }

        private void confirmBtn_Click(object sender, EventArgs e) {
            int p1 = difficultyCB.SelectedIndex;
            int p2 = appleCountCB.SelectedIndex;
            int p3 = appleColorCB.SelectedIndex;
            int p4 = snakeColorCB.SelectedIndex;
            int p5 = boundaryAccrossCB.SelectedIndex;
            Option.set(p1, p2, p3, p4, p5);
            this.Close();
        }
    }
}
