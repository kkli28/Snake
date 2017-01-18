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
    public partial class GameOverForm : Form {
        int record;
        int score;
        public GameOverForm(int r,int s,int gameMode,int recordIndex) {
            InitializeComponent();
            record = r;
            score = s;

            if (record < Constant.MIN_SCORE || record > Constant.MAX_SCORE || score < Constant.MIN_SCORE || score > Constant.MAX_SCORE)
                throw new Exception("GameOverForm.GameOverForm()，记录值或分数值错误!");

            if (gameMode == Constant.CUSTOM_MODE) {
                recordLB.Visible = false;
                newRecordLB.Visible = false;

                //只显示分数
                scoreLB.Text = score.ToString();
                return;
            }

            if (record < score) {
                record = score;

                //经典模式
                if (gameMode == Constant.CLASSIC_MODE) {
                    string[] records = File.ReadAllLines(Constant.RECORD_FILE);
                    records[recordIndex] = record.ToString();
                    File.WriteAllLines(Constant.RECORD_FILE, records);
                }

                //挑战模式
                else if (gameMode == Constant.CHALLENGE_MODE) {
                    string[] records = File.ReadAllLines(Constant.HURDLE_RECORD_FILE);
                    records[recordIndex] = record.ToString();
                    File.WriteAllLines(Constant.HURDLE_RECORD_FILE, records);
                }
                newRecordLB.Visible = true;
            }
            
            recordLB.Text = record.ToString();
            scoreLB.Text = score.ToString();
        }

        private void GameOverForm_Load(object sender, EventArgs e) {

        }
    }
}
