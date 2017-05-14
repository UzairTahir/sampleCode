namespace iTrack_1.View
{
    partial class OdNeighbour
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
            this.cameraframepicbox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cameraframepicbox)).BeginInit();
            this.SuspendLayout();
            // 
            // cameraframepicbox
            // 
            this.cameraframepicbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cameraframepicbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraframepicbox.Location = new System.Drawing.Point(20, 100);
            this.cameraframepicbox.Name = "cameraframepicbox";
            this.cameraframepicbox.Size = new System.Drawing.Size(744, 502);
            this.cameraframepicbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.cameraframepicbox.TabIndex = 0;
            this.cameraframepicbox.TabStop = false;
            this.cameraframepicbox.Click += new System.EventHandler(this.cameraframepicbox_Click);
            this.cameraframepicbox.Paint += new System.Windows.Forms.PaintEventHandler(this.cameraframepicbox_Paint);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 40);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(631, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OdNeighbour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 622);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cameraframepicbox);
            this.Controls.Add(this.panel1);
            this.Name = "OdNeighbour";
            this.Load += new System.EventHandler(this.OdNeighbour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cameraframepicbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox cameraframepicbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}