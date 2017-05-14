namespace iTrack_1.View
{
    partial class Indentification
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
            this.pnlControlPanel = new System.Windows.Forms.Panel();
            this.gbExpert = new System.Windows.Forms.GroupBox();
            this.cbUseGpu = new System.Windows.Forms.CheckBox();
            this.lblFps = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.pbView = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlControlPanel.SuspendLayout();
            this.gbExpert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControlPanel
            // 
            this.pnlControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControlPanel.Controls.Add(this.gbExpert);
            this.pnlControlPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControlPanel.Location = new System.Drawing.Point(671, 0);
            this.pnlControlPanel.Name = "pnlControlPanel";
            this.pnlControlPanel.Size = new System.Drawing.Size(200, 540);
            this.pnlControlPanel.TabIndex = 0;
            // 
            // gbExpert
            // 
            this.gbExpert.Controls.Add(this.cbUseGpu);
            this.gbExpert.Controls.Add(this.lblFps);
            this.gbExpert.Controls.Add(this.label2);
            this.gbExpert.Controls.Add(this.tbConsole);
            this.gbExpert.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbExpert.Location = new System.Drawing.Point(0, 325);
            this.gbExpert.Name = "gbExpert";
            this.gbExpert.Size = new System.Drawing.Size(198, 213);
            this.gbExpert.TabIndex = 2;
            this.gbExpert.TabStop = false;
            this.gbExpert.Text = "Debug";
            // 
            // cbUseGpu
            // 
            this.cbUseGpu.AutoSize = true;
            this.cbUseGpu.Location = new System.Drawing.Point(6, 19);
            this.cbUseGpu.Name = "cbUseGpu";
            this.cbUseGpu.Size = new System.Drawing.Size(71, 17);
            this.cbUseGpu.TabIndex = 3;
            this.cbUseGpu.Text = "Use GPU";
            this.cbUseGpu.UseVisualStyleBackColor = true;
            this.cbUseGpu.CheckedChanged += new System.EventHandler(this.cbUseGpu_CheckedChanged);
            // 
            // lblFps
            // 
            this.lblFps.AutoSize = true;
            this.lblFps.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFps.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFps.Location = new System.Drawing.Point(150, 37);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(44, 31);
            this.lblFps.TabIndex = 4;
            this.lblFps.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "FPS";
            // 
            // tbConsole
            // 
            this.tbConsole.AcceptsReturn = true;
            this.tbConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbConsole.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbConsole.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbConsole.HideSelection = false;
            this.tbConsole.Location = new System.Drawing.Point(3, 71);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ReadOnly = true;
            this.tbConsole.Size = new System.Drawing.Size(192, 139);
            this.tbConsole.TabIndex = 0;
            // 
            // pbView
            // 
            this.pbView.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbView.Location = new System.Drawing.Point(0, 0);
            this.pbView.Name = "pbView";
            this.pbView.Size = new System.Drawing.Size(671, 540);
            this.pbView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbView.TabIndex = 1;
            this.pbView.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 476);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 64);
            this.panel1.TabIndex = 2;
            // 
            // Indentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(871, 540);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbView);
            this.Controls.Add(this.pnlControlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Indentification";
            this.Text = "Indentification";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Indentification_FormClosed);
            this.pnlControlPanel.ResumeLayout(false);
            this.gbExpert.ResumeLayout(false);
            this.gbExpert.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControlPanel;
        private System.Windows.Forms.PictureBox pbView;
        private System.Windows.Forms.GroupBox gbExpert;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbUseGpu;
        private System.Windows.Forms.Panel panel1;
    }
}