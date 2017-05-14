namespace iTrack_1.View
{
    partial class ViewRecordedVideos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewRecordedVideos));
            this.wmp = new AxWMPLib.AxWindowsMediaPlayer();
            this.flpVideos = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Videolistlbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).BeginInit();
            this.flpVideos.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // wmp
            // 
            this.wmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wmp.Enabled = true;
            this.wmp.Location = new System.Drawing.Point(0, 0);
            this.wmp.Name = "wmp";
            this.wmp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmp.OcxState")));
            this.wmp.Size = new System.Drawing.Size(695, 501);
            this.wmp.TabIndex = 0;
            // 
            // flpVideos
            // 
            this.flpVideos.AutoScroll = true;
            this.flpVideos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpVideos.Controls.Add(this.panel4);
            this.flpVideos.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpVideos.Location = new System.Drawing.Point(697, 0);
            this.flpVideos.Name = "flpVideos";
            this.flpVideos.Size = new System.Drawing.Size(179, 532);
            this.flpVideos.TabIndex = 1;
            this.flpVideos.Paint += new System.Windows.Forms.PaintEventHandler(this.flpVideos_Paint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Videolistlbl);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(176, 35);
            this.panel4.TabIndex = 0;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // Videolistlbl
            // 
            this.Videolistlbl.AutoSize = true;
            this.Videolistlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Videolistlbl.Location = new System.Drawing.Point(28, 10);
            this.Videolistlbl.Name = "Videolistlbl";
            this.Videolistlbl.Size = new System.Drawing.Size(117, 17);
            this.Videolistlbl.TabIndex = 0;
            this.Videolistlbl.Text = "Recorded Videos";
            this.Videolistlbl.Click += new System.EventHandler(this.Videolistlbl_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 477);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 55);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(697, 29);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.wmp);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(697, 503);
            this.panel3.TabIndex = 4;
            // 
            // ViewRecordedVideos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 532);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpVideos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewRecordedVideos";
            this.Text = "Recorded Videos";
            this.Load += new System.EventHandler(this.ViewRecordedVideos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).EndInit();
            this.flpVideos.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer wmp;
        private System.Windows.Forms.FlowLayoutPanel flpVideos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Videolistlbl;
    }
}