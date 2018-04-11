namespace CutCap
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_savepath = new System.Windows.Forms.TextBox();
            this.button_dialog = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button_close = new System.Windows.Forms.Button();
            this.button_Accept = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_wakeup = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "保存先：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "範囲指定して保存：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "範囲指定してコピー：";
            // 
            // textBox_savepath
            // 
            this.textBox_savepath.Location = new System.Drawing.Point(65, 22);
            this.textBox_savepath.Name = "textBox_savepath";
            this.textBox_savepath.Size = new System.Drawing.Size(338, 19);
            this.textBox_savepath.TabIndex = 2;
            // 
            // button_dialog
            // 
            this.button_dialog.Location = new System.Drawing.Point(409, 20);
            this.button_dialog.Name = "button_dialog";
            this.button_dialog.Size = new System.Drawing.Size(75, 23);
            this.button_dialog.TabIndex = 3;
            this.button_dialog.Text = "保存先";
            this.button_dialog.UseVisualStyleBackColor = true;
            this.button_dialog.Click += new System.EventHandler(this.button_dialog_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(127, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(131, 19);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Shift + Ctrl + Alt + 4";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(127, 60);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(131, 19);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "Shift + Ctrl + 4";
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(429, 183);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(75, 23);
            this.button_close.TabIndex = 6;
            this.button_close.Text = "終了";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_Accept
            // 
            this.button_Accept.Location = new System.Drawing.Point(328, 183);
            this.button_Accept.Name = "button_Accept";
            this.button_Accept.Size = new System.Drawing.Size(75, 23);
            this.button_Accept.TabIndex = 7;
            this.button_Accept.Text = "適用";
            this.button_Accept.UseVisualStyleBackColor = true;
            this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(14, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 104);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ショートカット";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "起動時に自動起動：";
            // 
            // checkBox_wakeup
            // 
            this.checkBox_wakeup.AutoSize = true;
            this.checkBox_wakeup.Location = new System.Drawing.Point(141, 187);
            this.checkBox_wakeup.Name = "checkBox_wakeup";
            this.checkBox_wakeup.Size = new System.Drawing.Size(15, 14);
            this.checkBox_wakeup.TabIndex = 9;
            this.checkBox_wakeup.UseVisualStyleBackColor = true;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 225);
            this.Controls.Add(this.checkBox_wakeup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_Accept);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_dialog);
            this.Controls.Add(this.textBox_savepath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Config";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.Config_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_savepath;
        private System.Windows.Forms.Button button_dialog;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_Accept;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_wakeup;
    }
}