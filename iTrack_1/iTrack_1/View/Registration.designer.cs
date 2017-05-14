namespace iTrack_1
{
    partial class Registration
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
            this.pnlControlPanel = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.pbFace = new System.Windows.Forms.PictureBox();
            this.flpFaces = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCameraList = new System.Windows.Forms.ComboBox();
            this.gbExpert = new System.Windows.Forms.GroupBox();
            this.lblFps = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbView = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFace)).BeginInit();
            this.gbExpert.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControlPanel
            // 
            this.pnlControlPanel.BackColor = System.Drawing.SystemColors.Menu;
            this.pnlControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControlPanel.Controls.Add(this.btnClear);
            this.pnlControlPanel.Controls.Add(this.btnReg);
            this.pnlControlPanel.Controls.Add(this.tbName);
            this.pnlControlPanel.Controls.Add(this.pbFace);
            this.pnlControlPanel.Controls.Add(this.flpFaces);
            this.pnlControlPanel.Controls.Add(this.btnStart);
            this.pnlControlPanel.Controls.Add(this.label1);
            this.pnlControlPanel.Controls.Add(this.cbCameraList);
            this.pnlControlPanel.Controls.Add(this.gbExpert);
            this.pnlControlPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControlPanel.Location = new System.Drawing.Point(628, 24);
            this.pnlControlPanel.Name = "pnlControlPanel";
            this.pnlControlPanel.Size = new System.Drawing.Size(224, 516);
            this.pnlControlPanel.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(137, 97);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear All";
            this.toolTip1.SetToolTip(this.btnClear, "Clear");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(149, 289);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(63, 23);
            this.btnReg.TabIndex = 8;
            this.btnReg.Text = "Register";
            this.toolTip1.SetToolTip(this.btnReg, "Register");
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(6, 289);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(137, 20);
            this.tbName.TabIndex = 7;
            this.toolTip1.SetToolTip(this.tbName, "Name");
            // 
            // pbFace
            // 
            this.pbFace.Location = new System.Drawing.Point(6, 57);
            this.pbFace.Name = "pbFace";
            this.pbFace.Size = new System.Drawing.Size(69, 63);
            this.pbFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFace.TabIndex = 6;
            this.pbFace.TabStop = false;
            this.toolTip1.SetToolTip(this.pbFace, "Pose");
            // 
            // flpFaces
            // 
            this.flpFaces.Location = new System.Drawing.Point(6, 126);
            this.flpFaces.Name = "flpFaces";
            this.flpFaces.Size = new System.Drawing.Size(206, 157);
            this.flpFaces.TabIndex = 5;
            this.toolTip1.SetToolTip(this.flpFaces, "Poses");
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(137, 57);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.toolTip1.SetToolTip(this.btnStart, "Start");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Registration Camera";
            // 
            // cbCameraList
            // 
            this.cbCameraList.FormattingEnabled = true;
            this.cbCameraList.Location = new System.Drawing.Point(6, 30);
            this.cbCameraList.Name = "cbCameraList";
            this.cbCameraList.Size = new System.Drawing.Size(206, 21);
            this.cbCameraList.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cbCameraList, "Choose Camera");
            // 
            // gbExpert
            // 
            this.gbExpert.Controls.Add(this.lblFps);
            this.gbExpert.Controls.Add(this.label2);
            this.gbExpert.Controls.Add(this.tbConsole);
            this.gbExpert.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbExpert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbExpert.Location = new System.Drawing.Point(0, 342);
            this.gbExpert.Name = "gbExpert";
            this.gbExpert.Size = new System.Drawing.Size(222, 172);
            this.gbExpert.TabIndex = 1;
            this.gbExpert.TabStop = false;
            this.gbExpert.Text = "Debug";
            // 
            // lblFps
            // 
            this.lblFps.AutoSize = true;
            this.lblFps.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFps.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFps.Location = new System.Drawing.Point(168, 7);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(44, 31);
            this.lblFps.TabIndex = 2;
            this.lblFps.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "fps";
            // 
            // tbConsole
            // 
            this.tbConsole.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbConsole.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbConsole.HideSelection = false;
            this.tbConsole.Location = new System.Drawing.Point(3, 41);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ReadOnly = true;
            this.tbConsole.Size = new System.Drawing.Size(216, 128);
            this.tbConsole.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(852, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expertModeToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // expertModeToolStripMenuItem
            // 
            this.expertModeToolStripMenuItem.Checked = true;
            this.expertModeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.expertModeToolStripMenuItem.Name = "expertModeToolStripMenuItem";
            this.expertModeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.expertModeToolStripMenuItem.Text = "Expert Mode";
            this.expertModeToolStripMenuItem.Click += new System.EventHandler(this.expertModeToolStripMenuItem_Click);
            // 
            // pbView
            // 
            this.pbView.BackColor = System.Drawing.Color.Black;
            this.pbView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbView.Location = new System.Drawing.Point(0, 24);
            this.pbView.Name = "pbView";
            this.pbView.Size = new System.Drawing.Size(628, 516);
            this.pbView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbView.TabIndex = 2;
            this.pbView.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 496);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 44);
            this.panel1.TabIndex = 3;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 540);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbView);
            this.Controls.Add(this.pnlControlPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Registration";
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.Registration_Load);
            this.pnlControlPanel.ResumeLayout(false);
            this.pnlControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFace)).EndInit();
            this.gbExpert.ResumeLayout(false);
            this.gbExpert.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlControlPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expertModeToolStripMenuItem;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.GroupBox gbExpert;
        private System.Windows.Forms.PictureBox pbView;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCameraList;
        private System.Windows.Forms.FlowLayoutPanel flpFaces;
        private System.Windows.Forms.PictureBox pbFace;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

