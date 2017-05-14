namespace iTrack_1.Test
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.leftPanel = new System.Windows.Forms.Panel();
            this.btnExpand = new System.Windows.Forms.Button();
            this.sliderTimer = new System.Windows.Forms.Timer(this.components);
            this.btnIdentify = new System.Windows.Forms.Button();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.leftPanel.Controls.Add(this.btnIdentify);
            this.leftPanel.Controls.Add(this.btnExpand);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(185, 529);
            this.leftPanel.TabIndex = 0;
            // 
            // btnExpand
            // 
            this.btnExpand.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExpand.FlatAppearance.BorderSize = 0;
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand.Image")));
            this.btnExpand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExpand.Location = new System.Drawing.Point(0, 0);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(185, 52);
            this.btnExpand.TabIndex = 0;
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.button1_Click);
            // 
            // sliderTimer
            // 
            this.sliderTimer.Interval = 25;
            this.sliderTimer.Tick += new System.EventHandler(this.sliderTimer_Tick);
            // 
            // btnIdentify
            // 
            this.btnIdentify.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIdentify.FlatAppearance.BorderSize = 0;
            this.btnIdentify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIdentify.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIdentify.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnIdentify.Image = ((System.Drawing.Image)(resources.GetObject("btnIdentify.Image")));
            this.btnIdentify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIdentify.Location = new System.Drawing.Point(0, 52);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(185, 52);
            this.btnIdentify.TabIndex = 1;
            this.btnIdentify.Text = "Identify";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 529);
            this.Controls.Add(this.leftPanel);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.leftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Timer sliderTimer;
        private System.Windows.Forms.Button btnIdentify;
    }
}