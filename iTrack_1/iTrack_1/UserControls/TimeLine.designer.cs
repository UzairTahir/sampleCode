namespace iTrack_1.UserControls
{
    partial class TimeLine
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTimeLine = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlTimeLine
            // 
            this.pnlTimeLine.AutoSize = true;
            this.pnlTimeLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimeLine.Location = new System.Drawing.Point(0, 0);
            this.pnlTimeLine.Name = "pnlTimeLine";
            this.pnlTimeLine.Size = new System.Drawing.Size(526, 0);
            this.pnlTimeLine.TabIndex = 0;
            // 
            // TimeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.pnlTimeLine);
            this.Name = "TimeLine";
            this.Size = new System.Drawing.Size(526, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTimeLine;
    }
}
