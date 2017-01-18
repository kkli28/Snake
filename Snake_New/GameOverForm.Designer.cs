namespace Snake_New {
    partial class GameOverForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newRecordLB = new System.Windows.Forms.Label();
            this.recordLB = new System.Windows.Forms.Label();
            this.scoreLB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(53, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "记录：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(53, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "分数：";
            // 
            // newRecordLB
            // 
            this.newRecordLB.AutoSize = true;
            this.newRecordLB.BackColor = System.Drawing.Color.Transparent;
            this.newRecordLB.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newRecordLB.ForeColor = System.Drawing.Color.Red;
            this.newRecordLB.Location = new System.Drawing.Point(73, 144);
            this.newRecordLB.Name = "newRecordLB";
            this.newRecordLB.Size = new System.Drawing.Size(73, 28);
            this.newRecordLB.TabIndex = 2;
            this.newRecordLB.Text = "New !";
            this.newRecordLB.Visible = false;
            // 
            // recordLB
            // 
            this.recordLB.AutoSize = true;
            this.recordLB.BackColor = System.Drawing.Color.Transparent;
            this.recordLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recordLB.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recordLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.recordLB.Location = new System.Drawing.Point(134, 27);
            this.recordLB.Name = "recordLB";
            this.recordLB.Size = new System.Drawing.Size(24, 28);
            this.recordLB.TabIndex = 3;
            this.recordLB.Text = "0";
            // 
            // scoreLB
            // 
            this.scoreLB.AutoSize = true;
            this.scoreLB.BackColor = System.Drawing.Color.Transparent;
            this.scoreLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scoreLB.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scoreLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.scoreLB.Location = new System.Drawing.Point(134, 88);
            this.scoreLB.Name = "scoreLB";
            this.scoreLB.Size = new System.Drawing.Size(24, 28);
            this.scoreLB.TabIndex = 4;
            this.scoreLB.Text = "0";
            // 
            // GameOverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(224, 201);
            this.Controls.Add(this.scoreLB);
            this.Controls.Add(this.recordLB);
            this.Controls.Add(this.newRecordLB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GameOverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.GameOverForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label newRecordLB;
        private System.Windows.Forms.Label recordLB;
        private System.Windows.Forms.Label scoreLB;
    }
}