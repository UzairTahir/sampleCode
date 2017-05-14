namespace iTrack_1.UserControls
{
    partial class VideoPallet
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
            this.lblFile = new System.Windows.Forms.Label();
            this.playbtn = new System.Windows.Forms.Button();
            this.btnTrack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(3, 15);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(35, 13);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "label1";
            this.lblFile.Click += new System.EventHandler(this.lblFile_Click);
            // 
            // playbtn
            // 
            this.playbtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.playbtn.Image = global::iTrack_1.Properties.Resources._1483487972_play_alt;
            this.playbtn.Location = new System.Drawing.Point(84, 3);
            this.playbtn.Name = "playbtn";
            this.playbtn.Size = new System.Drawing.Size(37, 30);
            this.playbtn.TabIndex = 2;
            this.playbtn.UseVisualStyleBackColor = false;
            this.playbtn.Click += new System.EventHandler(this.playbtn_Click);
            // 
            // btnTrack
            // 
            this.btnTrack.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnTrack.Image = global::iTrack_1.Properties.Resources.eye_tracking;
            this.btnTrack.Location = new System.Drawing.Point(127, 3);
            this.btnTrack.Name = "btnTrack";
            this.btnTrack.Size = new System.Drawing.Size(37, 30);
            this.btnTrack.TabIndex = 1;
            this.btnTrack.UseVisualStyleBackColor = false;
            this.btnTrack.Click += new System.EventHandler(this.btnTrack_Click);
            // 
            // VideoPallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.playbtn);
            this.Controls.Add(this.btnTrack);
            this.Controls.Add(this.lblFile);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "VideoPallet";
            this.Size = new System.Drawing.Size(171, 36);
            this.Load += new System.EventHandler(this.VideoPallet_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.VideoPallet_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnTrack;
        private System.Windows.Forms.Button playbtn;
    }
}
