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
    public partial class CustomForm : Form {
        int[] states;                            //标示对应按钮的状态，共有两种状态：0未选中，1选中
        bool cursorLeftClick;             //鼠标是否已左击
        Color borderColor0;             //未选中时边框颜色
        Color borderColor1;             //选中时边框颜色

        bool clickStart;                      //是否点了开始按钮。如果是通过点击开始按钮，构造游戏主界面从而关闭当前窗口，则不会显菜单窗口
        public CustomForm() {
            InitializeComponent();

            states = new int[Constant.MAX_INDEX + 1];
            for (int i = 0; i < Constant.MAX_INDEX + 1; i++)
                states[i] = Constant.BUTTON_STATE0;
            borderColor0 = Color.FromArgb(224, 224, 224);
            borderColor1 = Color.Blue;

            boundaryAccrossCB.SelectedIndex = 0;  //默认选中第0项，即不跨越边界
            clickStart = false;
        }

        private void pictureBox0_Click(object sender, EventArgs e) {
            MessageBox.Show("pictureBox" + ((PictureBox)sender).Name);
        }

        private void button0_Click(object sender, EventArgs e) {
            Button btn;
            try {
                btn = ((Button)sender);
            }catch(Exception err) {
                MessageBox.Show(err.Message);
                return;
            }
            for(int i = 0; i < Constant.MAX_INDEX + 1; i++) {
                if (btn.Name == "button" + i.ToString()) {
                    if (states[i] == Constant.BUTTON_STATE0) {
                        states[i] = Constant.BUTTON_STATE1;
                        btn.FlatAppearance.BorderColor = borderColor1;
                    } else {
                        states[i] = Constant.BUTTON_STATE0;
                        btn.FlatAppearance.BorderColor = borderColor0;
                    }
                }
            }
        }
        
        private void CustomForm_Load(object sender, EventArgs e) {

        }

        private void startBtn_Click(object sender, EventArgs e) {
            clickStart = true;

            GameForm gf = 
                new GameForm(Constant.CUSTOM_MODE, -1, boundaryAccrossCB.SelectedIndex,states);
            gf.Show();
            this.Close();
        }

        private void CustomForm_FormClosed(object sender, FormClosedEventArgs e) {
            if (!clickStart) MenuForm.thisForm.Show();
        }

        private void resetBtn_Click(object sender, EventArgs e) {
            for(int i = 0; i < Constant.MAX_INDEX + 1; i++) {
                //只刷新选中的按钮
                if (states[i] == Constant.BUTTON_STATE1) {
                    foreach (Control c in this.Controls) {
                        if (c is Button) {
                            if (c.Name == "button" + i) ((Button)c).FlatAppearance.BorderColor = borderColor0;
                        }
                    }
                }
                states[i] = Constant.BUTTON_STATE0;
            }
        }
    }
}
