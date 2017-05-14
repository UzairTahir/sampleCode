namespace iTrack_1.UserControls
{
    partial class BodyFeatureView
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
            this.components = new System.ComponentModel.Container();
            this.histogramBox = new Emgu.CV.UI.HistogramBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRgb = new System.Windows.Forms.Label();
            this.lblHs = new System.Windows.Forms.Label();
            this.lblHog = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbBodyImage = new System.Windows.Forms.PictureBox();
            this.ibBodyImage = new Emgu.CV.UI.ImageBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBodyImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibBodyImage)).BeginInit();
            this.SuspendLayout();
            // 
            // histogramBox
            // 
            this.histogramBox.BackColor = System.Drawing.SystemColors.Control;
            this.histogramBox.Location = new System.Drawing.Point(83, 0);
            this.histogramBox.Name = "histogramBox";
            this.histogramBox.Size = new System.Drawing.Size(280, 228);
            this.histogramBox.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRgb);
            this.groupBox1.Controls.Add(this.lblHs);
            this.groupBox1.Controls.Add(this.lblHog);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(85, 72);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Distances";
            // 
            // lblRgb
            // 
            this.lblRgb.AutoSize = true;
            this.lblRgb.Location = new System.Drawing.Point(31, 46);
            this.lblRgb.Name = "lblRgb";
            this.lblRgb.Size = new System.Drawing.Size(13, 13);
            this.lblRgb.TabIndex = 5;
            this.lblRgb.Text = "0";
            // 
            // lblHs
            // 
            this.lblHs.AutoSize = true;
            this.lblHs.Location = new System.Drawing.Point(31, 33);
            this.lblHs.Name = "lblHs";
            this.lblHs.Size = new System.Drawing.Size(13, 13);
            this.lblHs.TabIndex = 4;
            this.lblHs.Text = "0";
            // 
            // lblHog
            // 
            this.lblHog.AutoSize = true;
            this.lblHog.Location = new System.Drawing.Point(31, 20);
            this.lblHog.Name = "lblHog";
            this.lblHog.Size = new System.Drawing.Size(13, 13);
            this.lblHog.TabIndex = 3;
            this.lblHog.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "HOG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "HS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "RGB";
            // 
            // pbBodyImage
            // 
            this.pbBodyImage.Location = new System.Drawing.Point(53, 81);
            this.pbBodyImage.Name = "pbBodyImage";
            this.pbBodyImage.Size = new System.Drawing.Size(75, 150);
            this.pbBodyImage.TabIndex = 5;
            this.pbBodyImage.TabStop = false;
            this.pbBodyImage.Visible = false;
            // 
            // ibBodyImage
            // 
            this.ibBodyImage.Location = new System.Drawing.Point(4, 4);
            this.ibBodyImage.Name = "ibBodyImage";
            this.ibBodyImage.Size = new System.Drawing.Size(75, 150);
            this.ibBodyImage.TabIndex = 2;
            this.ibBodyImage.TabStop = false;
            // 
            // BodyFeatureView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ibBodyImage);
            this.Controls.Add(this.pbBodyImage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.histogramBox);
            this.Name = "BodyFeatureView";
            this.Size = new System.Drawing.Size(368, 231);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBodyImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibBodyImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Emgu.CV.UI.HistogramBox histogramBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRgb;
        private System.Windows.Forms.Label lblHs;
        private System.Windows.Forms.Label lblHog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbBodyImage;
        private Emgu.CV.UI.ImageBox ibBodyImage;
    }
}
