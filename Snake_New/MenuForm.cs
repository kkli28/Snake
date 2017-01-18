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
    public partial class MenuForm : Form {
        public static Form thisForm;  //当前窗体指针
        public MenuForm() {
            InitializeComponent();
            thisForm = this;
        }

        private void setBtn_Click(object sender, EventArgs e) {
            SettingForm sf = new SettingForm();
            sf.ShowDialog();
        }

        private void helpBtn_Click(object sender, EventArgs e) {
            HelpForm hf = new HelpForm();
            hf.ShowDialog();
        }

        private void MenuForm_Load(object sender, EventArgs e) {

        }

        private void classicBtn_Click(object sender, EventArgs e) {
            GameForm gf = new GameForm(Constant.CLASSIC_MODE);
            gf.Show();
            this.Hide();
        }

        private void challengeBtn_Click(object sender, EventArgs e) {
            ChooseHurdleForm chf = new ChooseHurdleForm();
            chf.Show();
            this.Hide();
        }

        private void recordBtn_Click(object sender, EventArgs e) {
            RecordForm rf = new RecordForm();
            rf.ShowDialog();
        }

        private void customBtn_Click(object sender, EventArgs e) {
            CustomForm cf = new CustomForm();
            cf.Show();
            this.Hide();
        }
    }
}
