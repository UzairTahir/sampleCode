using iTrack_1.UserControls;

namespace iTrack_1.Test
{
    partial class TestForm_2
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
            this.timeLine1 = new iTrack_1.UserControls.TimeLine();
            this.SuspendLayout();
            // 
            // timeLine1
            // 
            this.timeLine1.Location = new System.Drawing.Point(33, 32);
            this.timeLine1.Name = "timeLine1";
            this.timeLine1.Size = new System.Drawing.Size(526, 150);
            this.timeLine1.TabIndex = 0;
            // 
            // TestForm_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 261);
            this.Controls.Add(this.timeLine1);
            this.Name = "TestForm_2";
            this.Text = "TestForm_2";
            this.ResumeLayout(false);

        }

        #endregion

        private TimeLine timeLine1;
    }
}