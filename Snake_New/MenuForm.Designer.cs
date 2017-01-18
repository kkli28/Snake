namespace Snake_New {
    partial class MenuForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.helpBtn = new System.Windows.Forms.Button();
            this.setBtn = new System.Windows.Forms.Button();
            this.classicBtn = new System.Windows.Forms.Button();
            this.recordBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.challengeBtn = new System.Windows.Forms.Button();
            this.customBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // helpBtn
            // 
            this.helpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpBtn.ForeColor = System.Drawing.Color.Black;
            this.helpBtn.Location = new System.Drawing.Point(114, 12);
            this.helpBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(160, 48);
            this.helpBtn.TabIndex = 0;
            this.helpBtn.Text = "帮助";
            this.helpBtn.UseVisualStyleBackColor = true;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // setBtn
            // 
            this.setBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setBtn.ForeColor = System.Drawing.Color.Black;
            this.setBtn.Location = new System.Drawing.Point(114, 72);
            this.setBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.setBtn.Name = "setBtn";
            this.setBtn.Size = new System.Drawing.Size(160, 48);
            this.setBtn.TabIndex = 1;
            this.setBtn.Text = "设置";
            this.setBtn.UseVisualStyleBackColor = true;
            this.setBtn.Click += new System.EventHandler(this.setBtn_Click);
            // 
            // classicBtn
            // 
            this.classicBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classicBtn.ForeColor = System.Drawing.Color.Black;
            this.classicBtn.Location = new System.Drawing.Point(114, 192);
            this.classicBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.classicBtn.Name = "classicBtn";
            this.classicBtn.Size = new System.Drawing.Size(160, 48);
            this.classicBtn.TabIndex = 2;
            this.classicBtn.Text = "经典模式";
            this.classicBtn.UseVisualStyleBackColor = true;
            this.classicBtn.Click += new System.EventHandler(this.classicBtn_Click);
            // 
            // recordBtn
            // 
            this.recordBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recordBtn.ForeColor = System.Drawing.Color.Black;
            this.recordBtn.Location = new System.Drawing.Point(114, 132);
            this.recordBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.recordBtn.Name = "recordBtn";
            this.recordBtn.Size = new System.Drawing.Size(160, 48);
            this.recordBtn.TabIndex = 4;
            this.recordBtn.Text = "记录";
            this.recordBtn.UseVisualStyleBackColor = true;
            this.recordBtn.Click += new System.EventHandler(this.recordBtn_Click);
            // 
            // challengeBtn
            // 
            this.challengeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.challengeBtn.ForeColor = System.Drawing.Color.Black;
            this.challengeBtn.Location = new System.Drawing.Point(114, 252);
            this.challengeBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.challengeBtn.Name = "challengeBtn";
            this.challengeBtn.Size = new System.Drawing.Size(160, 48);
            this.challengeBtn.TabIndex = 5;
            this.challengeBtn.Text = "挑战模式";
            this.challengeBtn.UseVisualStyleBackColor = true;
            this.challengeBtn.Click += new System.EventHandler(this.challengeBtn_Click);
            // 
            // customBtn
            // 
            this.customBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customBtn.ForeColor = System.Drawing.Color.Black;
            this.customBtn.Location = new System.Drawing.Point(114, 312);
            this.customBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.customBtn.Name = "customBtn";
            this.customBtn.Size = new System.Drawing.Size(160, 48);
            this.customBtn.TabIndex = 6;
            this.customBtn.Text = "自定义模式";
            this.customBtn.UseVisualStyleBackColor = true;
            this.customBtn.Click += new System.EventHandler(this.customBtn_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(404, 381);
            this.Controls.Add(this.customBtn);
            this.Controls.Add(this.challengeBtn);
            this.Controls.Add(this.recordBtn);
            this.Controls.Add(this.classicBtn);
            this.Controls.Add(this.setBtn);
            this.Controls.Add(this.helpBtn);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "菜单";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.Button setBtn;
        private System.Windows.Forms.Button classicBtn;
        private System.Windows.Forms.Button recordBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button challengeBtn;
        private System.Windows.Forms.Button customBtn;
    }
}