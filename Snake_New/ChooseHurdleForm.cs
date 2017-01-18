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
    public partial class ChooseHurdleForm : Form {

        bool selectedHurdle;    //是否选择了关卡
        string[] records;
        public ChooseHurdleForm() {
            InitializeComponent();

            boundaryAccrossCB.DropDownStyle = ComboBoxStyle.DropDownList;
            boundaryAccrossCB.SelectedIndex = Constant.NO_BOUNDARY_ACCROSS;
            selectedHurdle = false;
            records = new string[Constant.MAX_HURDLE_RECORD_COUNT+1];
            try {
                records = File.ReadAllLines(Constant.HURDLE_RECORD_FILE);
                validRecord(records, Constant.MAX_HURDLE_RECORD_COUNT);  //保证记录合法
            }catch(Exception e) {
                MessageBox.Show("读取记录错误，已重置所有记录！");
                for (int i = 0; i < Constant.MAX_HURDLE_RECORD_COUNT + 1; i++)
                    records[i] = "0";
                File.WriteAllLines(Constant.HURDLE_RECORD_FILE, records);
            }
            refreshRecordLB();
        }
        
        private void ChooseHurdleForm_FormClosed(object sender, FormClosedEventArgs e) {
            if (!selectedHurdle) MenuForm.thisForm.Show();
        }

        //判断记录是否合法
        public void validRecord(string[] r,int count) {
            int value = 0;
            for(int i = 0; i < count; i++) {
                value = Int32.Parse(r[i]);
                if (value < Constant.MIN_SCORE || value > Constant.MAX_SCORE) throw new Exception("ChooseHurdleForm.validRecord()，记录不合法！");
            }
        }

        //刷新记录标签
        void refreshRecordLB() {
            hurdle1RecordLB.Text = records[0];
            hurdle2RecordLB.Text = records[1];
            hurdle3RecordLB.Text = records[2];
            hurdle4RecordLB.Text = records[3];
            hurdle5RecordLB.Text = records[4];
            hurdle6RecordLB.Text = records[5];
            hurdle7RecordLB.Text = records[6];
            hurdle8RecordLB.Text = records[7];
            hurdle9RecordLB.Text = records[8];
            hurdle10RecordLB.Text = records[9];
            hurdle11RecordLB.Text = records[10];
            hurdle12RecordLB.Text = records[11];
        }

        //点击关卡按钮
        private void clickHurdleBtn(int index) {
            selectedHurdle = true;
            int selectBA = boundaryAccrossCB.SelectedIndex;
            GameForm gf = new GameForm(Constant.CHALLENGE_MODE, index,selectBA);
            gf.Show();
            this.Close();
        }

        private void hurdle1Btn_Click(object sender, EventArgs e) {
            clickHurdleBtn(0);
        }

        private void hurdle2Btn_Click(object sender, EventArgs e) {
            clickHurdleBtn(1);
        }

        private void hurdle3Btn_Click(object sender, EventArgs e) {
            clickHurdleBtn(2);
        }

        private void hurdle4Btn_Click(object sender, EventArgs e) {
            clickHurdleBtn(3);
        }

        private void hurdle5Btn_Click(object sender, EventArgs e) {
            clickHurdleBtn(4);
        }

        private void hurdle6Btn_Click(object sender, EventArgs e) {
            clickHurdleBtn(5);
        }

        private void hurdle7Btn_Click(object sender, EventArgs e) {
            clickHurdleBtn(6);
        }

        private void hurdle8Btn_Click(object sender, EventArgs e) {
            clickHurdleBtn(7);
        }

        private void hurdle9Btn_Click(object sender, EventArgs e) {
            clickHurdleBtn(8);
        }

        private void hurdle10Btn_Click(object sender, EventArgs e) {
            clickHurdleBtn(9);
        }

        private void hurdle11Btn_Click(object sender, EventArgs e) {
            clickHurdleBtn(10);
        }

        private void hurdle12Btn_Click(object sender, EventArgs e) {
            clickHurdleBtn(11);
        }

        private void ChooseHurdleForm_Load(object sender, EventArgs e) {

        }

        private void resetBtn_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("确定重置所有记录？", "重置记录", 
                MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes) {
                for (int i = 0; i < Constant.MAX_HURDLE_RECORD_COUNT + 1; i++)
                    records[i] = "0";
                refreshRecordLB();
                try {
                    File.WriteAllLines(Constant.HURDLE_RECORD_FILE, records);
                }catch(Exception) {
                    MessageBox.Show("记录重置失败！");
                }
            }
        }
    }
}
