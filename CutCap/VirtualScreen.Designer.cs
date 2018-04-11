namespace CutCap
{
    partial class VirtualScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VirtualScreen));
            this.SuspendLayout();
            // 
            // VirtualScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(397, 414);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VirtualScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "VirtualScreen";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VirtualScreen_FormClosing);
            this.Load += new System.EventHandler(this.VirtualScreen_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VirtualScreen_MouseDown);
            this.MouseLeave += new System.EventHandler(this.VirtualScreen_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VirtualScreen_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VirtualScreen_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}