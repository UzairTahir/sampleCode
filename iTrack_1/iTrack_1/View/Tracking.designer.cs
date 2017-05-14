namespace iTrack_1.View
{
    partial class Tracking
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
            this.lbTime = new System.Windows.Forms.ListBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbSuspects = new System.Windows.Forms.GroupBox();
            this.flpsuspects = new System.Windows.Forms.FlowLayoutPanel();
            this.gbTarget = new System.Windows.Forms.GroupBox();
            this.closebtn = new System.Windows.Forms.Button();
            this.bfvTarget = new iTrack_1.UserControls.BodyFeatureView();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbreiden = new System.Windows.Forms.RadioButton();
            this.rbIndentification = new System.Windows.Forms.RadioButton();
            this.pbBody = new System.Windows.Forms.PictureBox();
            this.gbExpert = new System.Windows.Forms.GroupBox();
            this.cbUseGpu = new System.Windows.Forms.CheckBox();
            this.lblFps = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pbView = new System.Windows.Forms.PictureBox();
            this.timeLine = new iTrack_1.UserControls.TimeLine();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_pause = new System.Windows.Forms.CheckBox();
            this.pnlControlPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbSuspects.SuspendLayout();
            this.gbTarget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBody)).BeginInit();
            this.gbExpert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControlPanel
            // 
            this.pnlControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControlPanel.Controls.Add(this.btn_pause);
            this.pnlControlPanel.Controls.Add(this.lbTime);
            this.pnlControlPanel.Controls.Add(this.checkBox2);
            this.pnlControlPanel.Controls.Add(this.checkBox1);
            this.pnlControlPanel.Controls.Add(this.panel1);
            this.pnlControlPanel.Controls.Add(this.lblEnd);
            this.pnlControlPanel.Controls.Add(this.lblStart);
            this.pnlControlPanel.Controls.Add(this.label3);
            this.pnlControlPanel.Controls.Add(this.label1);
            this.pnlControlPanel.Controls.Add(this.rbreiden);
            this.pnlControlPanel.Controls.Add(this.rbIndentification);
            this.pnlControlPanel.Controls.Add(this.pbBody);
            this.pnlControlPanel.Controls.Add(this.gbExpert);
            this.pnlControlPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControlPanel.Location = new System.Drawing.Point(552, 0);
            this.pnlControlPanel.Name = "pnlControlPanel";
            this.pnlControlPanel.Size = new System.Drawing.Size(613, 624);
            this.pnlControlPanel.TabIndex = 1;
            // 
            // lbTime
            // 
            this.lbTime.FormattingEnabled = true;
            this.lbTime.Location = new System.Drawing.Point(3, 12);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(180, 186);
            this.lbTime.TabIndex = 14;
            this.toolTip1.SetToolTip(this.lbTime, "TimeLine");
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(8, 390);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(100, 17);
            this.checkBox2.TabIndex = 20;
            this.checkBox2.Text = "Clean OF (Test)";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(8, 367);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(94, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Only OF (Test)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbSuspects);
            this.panel1.Controls.Add(this.gbTarget);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(187, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 622);
            this.panel1.TabIndex = 18;
            // 
            // gbSuspects
            // 
            this.gbSuspects.Controls.Add(this.flpsuspects);
            this.gbSuspects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSuspects.Location = new System.Drawing.Point(0, 263);
            this.gbSuspects.Name = "gbSuspects";
            this.gbSuspects.Size = new System.Drawing.Size(424, 359);
            this.gbSuspects.TabIndex = 18;
            this.gbSuspects.TabStop = false;
            this.gbSuspects.Text = "Suspects";
            this.toolTip1.SetToolTip(this.gbSuspects, "Suspects Picture");
            // 
            // flpsuspects
            // 
            this.flpsuspects.AutoScroll = true;
            this.flpsuspects.AutoSize = true;
            this.flpsuspects.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpsuspects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpsuspects.Location = new System.Drawing.Point(3, 16);
            this.flpsuspects.Name = "flpsuspects";
            this.flpsuspects.Size = new System.Drawing.Size(418, 340);
            this.flpsuspects.TabIndex = 16;
            // 
            // gbTarget
            // 
            this.gbTarget.Controls.Add(this.closebtn);
            this.gbTarget.Controls.Add(this.bfvTarget);
            this.gbTarget.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTarget.Location = new System.Drawing.Point(0, 0);
            this.gbTarget.Name = "gbTarget";
            this.gbTarget.Size = new System.Drawing.Size(424, 263);
            this.gbTarget.TabIndex = 17;
            this.gbTarget.TabStop = false;
            this.gbTarget.Text = "Target";
            this.toolTip1.SetToolTip(this.gbTarget, "Target Picture");
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.BackColor = System.Drawing.Color.Transparent;
            this.closebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.closebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closebtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closebtn.FlatAppearance.BorderSize = 0;
            this.closebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.closebtn.Location = new System.Drawing.Point(389, 0);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(35, 32);
            this.closebtn.TabIndex = 16;
            this.closebtn.Text = "X";
            this.toolTip1.SetToolTip(this.closebtn, "Close");
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // bfvTarget
            // 
            this.bfvTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bfvTarget.Location = new System.Drawing.Point(6, 19);
            this.bfvTarget.Name = "bfvTarget";
            this.bfvTarget.Size = new System.Drawing.Size(368, 231);
            this.bfvTarget.TabIndex = 15;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(94, 228);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(0, 13);
            this.lblEnd.TabIndex = 13;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(94, 206);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(0, 13);
            this.lblStart.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "End Time";
            this.toolTip1.SetToolTip(this.label3, "End Time");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Start Time";
            this.toolTip1.SetToolTip(this.label1, "Start Time");
            // 
            // rbreiden
            // 
            this.rbreiden.AutoSize = true;
            this.rbreiden.Location = new System.Drawing.Point(8, 312);
            this.rbreiden.Name = "rbreiden";
            this.rbreiden.Size = new System.Drawing.Size(102, 17);
            this.rbreiden.TabIndex = 9;
            this.rbreiden.TabStop = true;
            this.rbreiden.Text = "Re-Identification";
            this.toolTip1.SetToolTip(this.rbreiden, "Re-Identification");
            this.rbreiden.UseVisualStyleBackColor = true;
            // 
            // rbIndentification
            // 
            this.rbIndentification.AutoSize = true;
            this.rbIndentification.Checked = true;
            this.rbIndentification.Location = new System.Drawing.Point(8, 289);
            this.rbIndentification.Name = "rbIndentification";
            this.rbIndentification.Size = new System.Drawing.Size(91, 17);
            this.rbIndentification.TabIndex = 8;
            this.rbIndentification.TabStop = true;
            this.rbIndentification.Text = "Indentification";
            this.toolTip1.SetToolTip(this.rbIndentification, "Indentification");
            this.rbIndentification.UseVisualStyleBackColor = true;
            // 
            // pbBody
            // 
            this.pbBody.Location = new System.Drawing.Point(124, 338);
            this.pbBody.Name = "pbBody";
            this.pbBody.Size = new System.Drawing.Size(64, 128);
            this.pbBody.TabIndex = 7;
            this.pbBody.TabStop = false;
            // 
            // gbExpert
            // 
            this.gbExpert.Controls.Add(this.cbUseGpu);
            this.gbExpert.Controls.Add(this.lblFps);
            this.gbExpert.Controls.Add(this.label2);
            this.gbExpert.Controls.Add(this.tbConsole);
            this.gbExpert.Location = new System.Drawing.Point(0, 472);
            this.gbExpert.Name = "gbExpert";
            this.gbExpert.Size = new System.Drawing.Size(188, 152);
            this.gbExpert.TabIndex = 2;
            this.gbExpert.TabStop = false;
            this.gbExpert.Text = "Debug";
            // 
            // cbUseGpu
            // 
            this.cbUseGpu.AutoSize = true;
            this.cbUseGpu.Location = new System.Drawing.Point(5, 36);
            this.cbUseGpu.Name = "cbUseGpu";
            this.cbUseGpu.Size = new System.Drawing.Size(71, 17);
            this.cbUseGpu.TabIndex = 5;
            this.cbUseGpu.Text = "Use GPU";
            this.cbUseGpu.UseVisualStyleBackColor = true;
            this.cbUseGpu.CheckedChanged += new System.EventHandler(this.cbUseGpu_CheckedChanged);
            // 
            // lblFps
            // 
            this.lblFps.AutoSize = true;
            this.lblFps.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFps.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFps.Location = new System.Drawing.Point(493, 22);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(44, 31);
            this.lblFps.TabIndex = 4;
            this.lblFps.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "fps";
            // 
            // tbConsole
            // 
            this.tbConsole.AcceptsReturn = true;
            this.tbConsole.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbConsole.Cursor = System.Windows.Forms.Cursors.No;
            this.tbConsole.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbConsole.HideSelection = false;
            this.tbConsole.Location = new System.Drawing.Point(3, 53);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ReadOnly = true;
            this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbConsole.Size = new System.Drawing.Size(182, 96);
            this.tbConsole.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pbView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.timeLine);
            this.splitContainer.Size = new System.Drawing.Size(552, 624);
            this.splitContainer.SplitterDistance = 448;
            this.splitContainer.TabIndex = 4;
            // 
            // pbView
            // 
            this.pbView.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbView.Location = new System.Drawing.Point(0, 0);
            this.pbView.Name = "pbView";
            this.pbView.Size = new System.Drawing.Size(552, 448);
            this.pbView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbView.TabIndex = 2;
            this.pbView.TabStop = false;
            // 
            // timeLine
            // 
            this.timeLine.AutoScroll = true;
            this.timeLine.BackColor = System.Drawing.SystemColors.Window;
            this.timeLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeLine.Location = new System.Drawing.Point(0, 0);
            this.timeLine.Name = "timeLine";
            this.timeLine.Size = new System.Drawing.Size(552, 142);
            this.timeLine.TabIndex = 3;
            // 
            // btn_pause
            // 
            this.btn_pause.AutoSize = true;
            this.btn_pause.Location = new System.Drawing.Point(8, 449);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(101, 17);
            this.btn_pause.TabIndex = 21;
            this.btn_pause.Text = "Pause Tracking";
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.CheckedChanged += new System.EventHandler(this.btn_pause_CheckedChanged);
            // 
            // Tracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1165, 624);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.pnlControlPanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Tracking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tracking";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Tracking_FormClosed);
            this.Load += new System.EventHandler(this.Tracking_Load);
            this.pnlControlPanel.ResumeLayout(false);
            this.pnlControlPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gbSuspects.ResumeLayout(false);
            this.gbSuspects.PerformLayout();
            this.gbTarget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBody)).EndInit();
            this.gbExpert.ResumeLayout(false);
            this.gbExpert.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControlPanel;
        private System.Windows.Forms.GroupBox gbExpert;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.PictureBox pbView;
        private System.Windows.Forms.CheckBox cbUseGpu;
        private System.Windows.Forms.PictureBox pbBody;
        private System.Windows.Forms.RadioButton rbreiden;
        private System.Windows.Forms.RadioButton rbIndentification;
        private UserControls.TimeLine timeLine;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbTime;
        private UserControls.BodyFeatureView bfvTarget;
        private System.Windows.Forms.FlowLayoutPanel flpsuspects;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbTarget;
        private System.Windows.Forms.GroupBox gbSuspects;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox btn_pause;
    }
}