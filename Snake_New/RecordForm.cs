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
    public partial class RecordForm : Form {
        public RecordForm() {
            InitializeComponent();

            string[] records = new string[Constant.MAX_RECORD_COUNT + 1];
            string[] hurdleRecords = new string[Constant.MAX_HURDLE_RECORD_COUNT + 1];

            //确保记录文件正确，并添加到对应ListBox中
            try {
                records = File.ReadAllLines(Constant.RECORD_FILE);
                int value = -1;
                for (int i = 0; i < Constant.MAX_RECORD_COUNT + 1; i++) {
                    value = Int32.Parse(records[i]);
                    if (value < Constant.MIN_SCORE || value > Constant.MAX_SCORE)
                        throw new Exception("RecordForm.RecordForm()，经典模式记录文件数据错误！");
                    listBox1.Items.Add(value.ToString());
                }
            } catch (Exception e) {  //出错则重置记录和ListBox
                listBox1.Items.Clear();  //之前可能部分添加项，因此需要清空
                for (int i = 0; i < Constant.MAX_RECORD_COUNT + 1; i++) {
                    records[i] = "0";
                    listBox1.Items.Add(records[i]);
                }
                File.WriteAllLines(Constant.RECORD_FILE, records);
                MessageBox.Show("经典模式记录文件损坏，已重置经典模式所有记录！");
            }

            try {
                hurdleRecords = File.ReadAllLines(Constant.HURDLE_RECORD_FILE);
                int value = -1;
                for (int i = 0; i < Constant.MAX_HURDLE_RECORD_COUNT + 1; i++) {
                    value = Int32.Parse(hurdleRecords[i]);
                    if (value < Constant.MIN_SCORE || value > Constant.MAX_SCORE)
                        throw new Exception("RecordForm.RecordForm()，挑战模式记录文件数据错误！");
                    listBox2.Items.Add(value.ToString());
                }
            } catch (Exception e) {
                listBox2.Items.Clear();
                for (int i = 0; i < Constant.MAX_HURDLE_RECORD_COUNT + 1; i++) {
                    hurdleRecords[i] = "0";
                    listBox2.Items.Add(records[i]);
                }
                File.WriteAllLines(Constant.HURDLE_RECORD_FILE, hurdleRecords);
                MessageBox.Show("挑战模式记录文件损坏，已充值挑战模式所有记录！");
            }
        }

        private void RecordForm_Load(object sender, EventArgs e) {

        }

        private void resetBtn_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("确定要重置所有记录？", "重置记录",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No) return;  //选择取消则退出

            string[] records = new string[Constant.MAX_RECORD_COUNT + 1];
            string[] hurdleRecords = new string[Constant.MAX_HURDLE_RECORD_COUNT + 1];

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            for (int i = 0; i < Constant.MAX_RECORD_COUNT + 1; i++) {
                records[i] = "0";
                listBox1.Items.Add(records[i]);
            }
            for (int i = 0; i < Constant.MAX_HURDLE_RECORD_COUNT + 1; i++) {
                hurdleRecords[i] = "0";
                listBox2.Items.Add(hurdleRecords[i]);
            }

            //写入文件
            try {
                File.WriteAllLines(Constant.RECORD_FILE, records);
                File.WriteAllLines(Constant.HURDLE_RECORD_FILE, hurdleRecords);
            } catch (Exception err) {
                MessageBox.Show("重置记录失败！" + err.Message);
            }
        }
    }
}
