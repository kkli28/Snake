namespace Snake_New {
    partial class SettingForm {
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
            this.difficultyLB = new System.Windows.Forms.Label();
            this.difficultyCB = new System.Windows.Forms.ComboBox();
            this.appleCountLB = new System.Windows.Forms.Label();
            this.appleCountCB = new System.Windows.Forms.ComboBox();
            this.appleColorLB = new System.Windows.Forms.Label();
            this.appleColorCB = new System.Windows.Forms.ComboBox();
            this.snakeColorLB = new System.Windows.Forms.Label();
            this.snakeColorCB = new System.Windows.Forms.ComboBox();
            this.boundaryAccrossLB = new System.Windows.Forms.Label();
            this.boundaryAccrossCB = new System.Windows.Forms.ComboBox();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // difficultyLB
            // 
            this.difficultyLB.AutoSize = true;
            this.difficultyLB.Location = new System.Drawing.Point(15, 32);
            this.difficultyLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.difficultyLB.Name = "difficultyLB";
            this.difficultyLB.Size = new System.Drawing.Size(42, 21);
            this.difficultyLB.TabIndex = 3;
            this.difficultyLB.Text = "难度";
            // 
            // difficultyCB
            // 
            this.difficultyCB.BackColor = System.Drawing.Color.White;
            this.difficultyCB.FormattingEnabled = true;
            this.difficultyCB.Items.AddRange(new object[] {
            "困难",
            "普通",
            "简单"});
            this.difficultyCB.Location = new System.Drawing.Point(15, 56);
            this.difficultyCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.difficultyCB.Name = "difficultyCB";
            this.difficultyCB.Size = new System.Drawing.Size(150, 29);
            this.difficultyCB.TabIndex = 4;
            // 
            // appleCountLB
            // 
            this.appleCountLB.AutoSize = true;
            this.appleCountLB.Location = new System.Drawing.Point(15, 102);
            this.appleCountLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.appleCountLB.Name = "appleCountLB";
            this.appleCountLB.Size = new System.Drawing.Size(74, 21);
            this.appleCountLB.TabIndex = 6;
            this.appleCountLB.Text = "苹果个数";
            // 
            // appleCountCB
            // 
            this.appleCountCB.BackColor = System.Drawing.Color.White;
            this.appleCountCB.FormattingEnabled = true;
            this.appleCountCB.Items.AddRange(new object[] {
            "1",
            "2",
            "5",
            "10"});
            this.appleCountCB.Location = new System.Drawing.Point(15, 126);
            this.appleCountCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.appleCountCB.Name = "appleCountCB";
            this.appleCountCB.Size = new System.Drawing.Size(150, 29);
            this.appleCountCB.TabIndex = 7;
            // 
            // appleColorLB
            // 
            this.appleColorLB.AutoSize = true;
            this.appleColorLB.Location = new System.Drawing.Point(15, 171);
            this.appleColorLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.appleColorLB.Name = "appleColorLB";
            this.appleColorLB.Size = new System.Drawing.Size(74, 21);
            this.appleColorLB.TabIndex = 8;
            this.appleColorLB.Text = "苹果颜色";
            // 
            // appleColorCB
            // 
            this.appleColorCB.BackColor = System.Drawing.Color.White;
            this.appleColorCB.FormattingEnabled = true;
            this.appleColorCB.Items.AddRange(new object[] {
            "红",
            "橙",
            "紫"});
            this.appleColorCB.Location = new System.Drawing.Point(15, 195);
            this.appleColorCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.appleColorCB.Name = "appleColorCB";
            this.appleColorCB.Size = new System.Drawing.Size(150, 29);
            this.appleColorCB.TabIndex = 9;
            // 
            // snakeColorLB
            // 
            this.snakeColorLB.AutoSize = true;
            this.snakeColorLB.Location = new System.Drawing.Point(201, 32);
            this.snakeColorLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.snakeColorLB.Name = "snakeColorLB";
            this.snakeColorLB.Size = new System.Drawing.Size(74, 21);
            this.snakeColorLB.TabIndex = 10;
            this.snakeColorLB.Text = "蛇身颜色";
            // 
            // snakeColorCB
            // 
            this.snakeColorCB.BackColor = System.Drawing.Color.White;
            this.snakeColorCB.FormattingEnabled = true;
            this.snakeColorCB.Items.AddRange(new object[] {
            "绿",
            "黄",
            "灰"});
            this.snakeColorCB.Location = new System.Drawing.Point(206, 56);
            this.snakeColorCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.snakeColorCB.Name = "snakeColorCB";
            this.snakeColorCB.Size = new System.Drawing.Size(150, 29);
            this.snakeColorCB.TabIndex = 11;
            // 
            // boundaryAccrossLB
            // 
            this.boundaryAccrossLB.AutoSize = true;
            this.boundaryAccrossLB.Location = new System.Drawing.Point(201, 102);
            this.boundaryAccrossLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.boundaryAccrossLB.Name = "boundaryAccrossLB";
            this.boundaryAccrossLB.Size = new System.Drawing.Size(74, 21);
            this.boundaryAccrossLB.TabIndex = 12;
            this.boundaryAccrossLB.Text = "边界跨越";
            // 
            // boundaryAccrossCB
            // 
            this.boundaryAccrossCB.BackColor = System.Drawing.Color.White;
            this.boundaryAccrossCB.FormattingEnabled = true;
            this.boundaryAccrossCB.Items.AddRange(new object[] {
            "不允许",
            "允许"});
            this.boundaryAccrossCB.Location = new System.Drawing.Point(206, 126);
            this.boundaryAccrossCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.boundaryAccrossCB.Name = "boundaryAccrossCB";
            this.boundaryAccrossCB.Size = new System.Drawing.Size(150, 29);
            this.boundaryAccrossCB.TabIndex = 13;
            // 
            // confirmBtn
            // 
            this.confirmBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.confirmBtn.FlatAppearance.BorderSize = 0;
            this.confirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmBtn.Location = new System.Drawing.Point(276, 252);
            this.confirmBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(80, 35);
            this.confirmBtn.TabIndex = 14;
            this.confirmBtn.Text = "确定";
            this.confirmBtn.UseVisualStyleBackColor = false;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.resetBtn.FlatAppearance.BorderSize = 0;
            this.resetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetBtn.Location = new System.Drawing.Point(85, 252);
            this.resetBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(80, 35);
            this.resetBtn.TabIndex = 15;
            this.resetBtn.Text = "重置";
            this.resetBtn.UseVisualStyleBackColor = false;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "下列设置仅限于经典模式";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(379, 299);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.boundaryAccrossCB);
            this.Controls.Add(this.boundaryAccrossLB);
            this.Controls.Add(this.snakeColorCB);
            this.Controls.Add(this.snakeColorLB);
            this.Controls.Add(this.appleColorCB);
            this.Controls.Add(this.appleColorLB);
            this.Controls.Add(this.appleCountCB);
            this.Controls.Add(this.appleCountLB);
            this.Controls.Add(this.difficultyCB);
            this.Controls.Add(this.difficultyLB);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label difficultyLB;
        private System.Windows.Forms.ComboBox difficultyCB;
        private System.Windows.Forms.Label appleCountLB;
        private System.Windows.Forms.ComboBox appleCountCB;
        private System.Windows.Forms.Label appleColorLB;
        private System.Windows.Forms.ComboBox appleColorCB;
        private System.Windows.Forms.Label snakeColorLB;
        private System.Windows.Forms.ComboBox snakeColorCB;
        private System.Windows.Forms.Label boundaryAccrossLB;
        private System.Windows.Forms.ComboBox boundaryAccrossCB;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Label label1;
    }
}