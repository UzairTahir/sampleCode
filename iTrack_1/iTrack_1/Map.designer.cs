namespace iTrack_1
{
    partial class Map
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.picpnl = new System.Windows.Forms.Panel();
            this.optionpanal = new System.Windows.Forms.Panel();
            this.mulcamerabtn = new System.Windows.Forms.Button();
            this.addcamerabtn = new System.Windows.Forms.Button();
            this.pboptionpanel = new System.Windows.Forms.Panel();
            this.ODbtn = new System.Windows.Forms.Button();
            this.streambtn = new System.Windows.Forms.Button();
            this.RemoveCamerabtn = new System.Windows.Forms.Button();
            this.rotatebtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.regpnl = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.odcameralst = new MetroFramework.Controls.MetroComboBox();
            this.trackchk = new System.Windows.Forms.CheckBox();
            this.identificationchk = new System.Windows.Forms.CheckBox();
            this.Regchk = new System.Windows.Forms.CheckBox();
            this.pwdlbl = new System.Windows.Forms.Label();
            this.pwdtxt = new System.Windows.Forms.TextBox();
            this.userlbl = new System.Windows.Forms.Label();
            this.usertxt = new System.Windows.Forms.TextBox();
            this.camlbl = new System.Windows.Forms.Label();
            this.cameralst = new System.Windows.Forms.ComboBox();
            this.IPlbl = new System.Windows.Forms.Label();
            this.neighbourlbl = new System.Windows.Forms.Label();
            this.cameraNamelbl = new System.Windows.Forms.Label();
            this.cameralist = new System.Windows.Forms.CheckedListBox();
            this.iptxt = new System.Windows.Forms.TextBox();
            this.prodonebtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.donebtn = new System.Windows.Forms.Button();
            this.nxtbtn = new System.Windows.Forms.Button();
            this.camera1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.picpnl.SuspendLayout();
            this.optionpanal.SuspendLayout();
            this.pboptionpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.regpnl.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camera1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picpnl);
            this.panel1.Controls.Add(this.regpnl);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 628);
            this.panel1.TabIndex = 0;
            // 
            // picpnl
            // 
            this.picpnl.Controls.Add(this.optionpanal);
            this.picpnl.Controls.Add(this.pboptionpanel);
            this.picpnl.Controls.Add(this.pictureBox1);
            this.picpnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picpnl.Location = new System.Drawing.Point(0, 0);
            this.picpnl.Name = "picpnl";
            this.picpnl.Size = new System.Drawing.Size(725, 528);
            this.picpnl.TabIndex = 6;
            // 
            // optionpanal
            // 
            this.optionpanal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.optionpanal.Controls.Add(this.mulcamerabtn);
            this.optionpanal.Controls.Add(this.addcamerabtn);
            this.optionpanal.Location = new System.Drawing.Point(190, 83);
            this.optionpanal.Name = "optionpanal";
            this.optionpanal.Size = new System.Drawing.Size(172, 96);
            this.optionpanal.TabIndex = 2;
            this.optionpanal.Visible = false;
            this.optionpanal.Paint += new System.Windows.Forms.PaintEventHandler(this.optionpanal_Paint);
            // 
            // mulcamerabtn
            // 
            this.mulcamerabtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mulcamerabtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SlateGray;
            this.mulcamerabtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mulcamerabtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mulcamerabtn.Image = global::iTrack_1.Properties.Resources.multiple_shots;
            this.mulcamerabtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mulcamerabtn.Location = new System.Drawing.Point(0, 50);
            this.mulcamerabtn.Name = "mulcamerabtn";
            this.mulcamerabtn.Size = new System.Drawing.Size(169, 46);
            this.mulcamerabtn.TabIndex = 4;
            this.mulcamerabtn.Text = "Add Multiple Camera";
            this.toolTip1.SetToolTip(this.mulcamerabtn, "Add MultipleCamera");
            this.mulcamerabtn.UseVisualStyleBackColor = true;
            this.mulcamerabtn.Click += new System.EventHandler(this.mulcamerabtn_Click_1);
            // 
            // addcamerabtn
            // 
            this.addcamerabtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addcamerabtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SlateGray;
            this.addcamerabtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addcamerabtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addcamerabtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addcamerabtn.Image = global::iTrack_1.Properties.Resources.image_add_button;
            this.addcamerabtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addcamerabtn.Location = new System.Drawing.Point(0, 0);
            this.addcamerabtn.Name = "addcamerabtn";
            this.addcamerabtn.Size = new System.Drawing.Size(169, 51);
            this.addcamerabtn.TabIndex = 0;
            this.addcamerabtn.Text = "Add Camera";
            this.toolTip1.SetToolTip(this.addcamerabtn, "Add Camera");
            this.addcamerabtn.UseVisualStyleBackColor = true;
            this.addcamerabtn.Click += new System.EventHandler(this.addcamerabtn_Click);
            // 
            // pboptionpanel
            // 
            this.pboptionpanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pboptionpanel.Controls.Add(this.ODbtn);
            this.pboptionpanel.Controls.Add(this.streambtn);
            this.pboptionpanel.Controls.Add(this.RemoveCamerabtn);
            this.pboptionpanel.Controls.Add(this.rotatebtn);
            this.pboptionpanel.Location = new System.Drawing.Point(368, 85);
            this.pboptionpanel.Name = "pboptionpanel";
            this.pboptionpanel.Size = new System.Drawing.Size(172, 183);
            this.pboptionpanel.TabIndex = 4;
            this.pboptionpanel.Visible = false;
            // 
            // ODbtn
            // 
            this.ODbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ODbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SlateGray;
            this.ODbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ODbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ODbtn.Image = global::iTrack_1.Properties.Resources._checked;
            this.ODbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ODbtn.Location = new System.Drawing.Point(0, 46);
            this.ODbtn.Name = "ODbtn";
            this.ODbtn.Size = new System.Drawing.Size(169, 46);
            this.ODbtn.TabIndex = 6;
            this.ODbtn.Text = "Set as OD Camera";
            this.toolTip1.SetToolTip(this.ODbtn, "Select camera for optical flow");
            this.ODbtn.UseVisualStyleBackColor = true;
            this.ODbtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // streambtn
            // 
            this.streambtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.streambtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SlateGray;
            this.streambtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.streambtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.streambtn.Image = global::iTrack_1.Properties.Resources.rotate_camera;
            this.streambtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.streambtn.Location = new System.Drawing.Point(0, 1);
            this.streambtn.Name = "streambtn";
            this.streambtn.Size = new System.Drawing.Size(169, 46);
            this.streambtn.TabIndex = 5;
            this.streambtn.Text = "View Streaming";
            this.toolTip1.SetToolTip(this.streambtn, "Live Streaming");
            this.streambtn.UseVisualStyleBackColor = true;
            this.streambtn.Click += new System.EventHandler(this.streambtn_Click);
            // 
            // RemoveCamerabtn
            // 
            this.RemoveCamerabtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RemoveCamerabtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SlateGray;
            this.RemoveCamerabtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveCamerabtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveCamerabtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RemoveCamerabtn.Image = global::iTrack_1.Properties.Resources.camera_remove_button;
            this.RemoveCamerabtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveCamerabtn.Location = new System.Drawing.Point(0, 135);
            this.RemoveCamerabtn.Name = "RemoveCamerabtn";
            this.RemoveCamerabtn.Size = new System.Drawing.Size(169, 46);
            this.RemoveCamerabtn.TabIndex = 4;
            this.RemoveCamerabtn.Text = "Remove Camera";
            this.toolTip1.SetToolTip(this.RemoveCamerabtn, "Remove Camera");
            this.RemoveCamerabtn.UseVisualStyleBackColor = true;
            this.RemoveCamerabtn.Click += new System.EventHandler(this.RemoveCamerabtn_Click);
            // 
            // rotatebtn
            // 
            this.rotatebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rotatebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SlateGray;
            this.rotatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rotatebtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rotatebtn.Image = global::iTrack_1.Properties.Resources.rotate_camera;
            this.rotatebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rotatebtn.Location = new System.Drawing.Point(0, 91);
            this.rotatebtn.Name = "rotatebtn";
            this.rotatebtn.Size = new System.Drawing.Size(169, 46);
            this.rotatebtn.TabIndex = 2;
            this.rotatebtn.Text = "Rotate  ";
            this.toolTip1.SetToolTip(this.rotatebtn, "Modify Direction");
            this.rotatebtn.UseVisualStyleBackColor = true;
            this.rotatebtn.Click += new System.EventHandler(this.rotatebtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(725, 528);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // regpnl
            // 
            this.regpnl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.regpnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.regpnl.Controls.Add(this.label1);
            this.regpnl.Controls.Add(this.odcameralst);
            this.regpnl.Controls.Add(this.trackchk);
            this.regpnl.Controls.Add(this.identificationchk);
            this.regpnl.Controls.Add(this.Regchk);
            this.regpnl.Controls.Add(this.pwdlbl);
            this.regpnl.Controls.Add(this.pwdtxt);
            this.regpnl.Controls.Add(this.userlbl);
            this.regpnl.Controls.Add(this.usertxt);
            this.regpnl.Controls.Add(this.camlbl);
            this.regpnl.Controls.Add(this.cameralst);
            this.regpnl.Controls.Add(this.IPlbl);
            this.regpnl.Controls.Add(this.neighbourlbl);
            this.regpnl.Controls.Add(this.cameraNamelbl);
            this.regpnl.Controls.Add(this.cameralist);
            this.regpnl.Controls.Add(this.iptxt);
            this.regpnl.Controls.Add(this.prodonebtn);
            this.regpnl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.regpnl.Dock = System.Windows.Forms.DockStyle.Right;
            this.regpnl.Location = new System.Drawing.Point(725, 0);
            this.regpnl.Name = "regpnl";
            this.regpnl.Size = new System.Drawing.Size(200, 528);
            this.regpnl.TabIndex = 5;
            this.toolTip1.SetToolTip(this.regpnl, "Properties");
            this.regpnl.Paint += new System.Windows.Forms.PaintEventHandler(this.regpnl_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Select OD neighbour(if any)*";
            // 
            // odcameralst
            // 
            this.odcameralst.FormattingEnabled = true;
            this.odcameralst.ItemHeight = 23;
            this.odcameralst.Location = new System.Drawing.Point(8, 306);
            this.odcameralst.Name = "odcameralst";
            this.odcameralst.Size = new System.Drawing.Size(184, 29);
            this.odcameralst.TabIndex = 29;
            // 
            // trackchk
            // 
            this.trackchk.AutoSize = true;
            this.trackchk.Location = new System.Drawing.Point(8, 239);
            this.trackchk.Name = "trackchk";
            this.trackchk.Size = new System.Drawing.Size(68, 17);
            this.trackchk.TabIndex = 28;
            this.trackchk.Text = "Tracking";
            this.toolTip1.SetToolTip(this.trackchk, "Camera Tracking");
            this.trackchk.UseVisualStyleBackColor = true;
            // 
            // identificationchk
            // 
            this.identificationchk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.identificationchk.AutoSize = true;
            this.identificationchk.Location = new System.Drawing.Point(95, 221);
            this.identificationchk.Name = "identificationchk";
            this.identificationchk.Size = new System.Drawing.Size(86, 17);
            this.identificationchk.TabIndex = 27;
            this.identificationchk.Text = "Identification";
            this.toolTip1.SetToolTip(this.identificationchk, "Identification Camera");
            this.identificationchk.UseVisualStyleBackColor = true;
            // 
            // Regchk
            // 
            this.Regchk.AutoSize = true;
            this.Regchk.Location = new System.Drawing.Point(8, 221);
            this.Regchk.Name = "Regchk";
            this.Regchk.Size = new System.Drawing.Size(85, 17);
            this.Regchk.TabIndex = 26;
            this.Regchk.Text = "Registration ";
            this.toolTip1.SetToolTip(this.Regchk, "Registration Camera");
            this.Regchk.UseVisualStyleBackColor = true;
            // 
            // pwdlbl
            // 
            this.pwdlbl.AutoSize = true;
            this.pwdlbl.Location = new System.Drawing.Point(74, 167);
            this.pwdlbl.Name = "pwdlbl";
            this.pwdlbl.Size = new System.Drawing.Size(53, 13);
            this.pwdlbl.TabIndex = 25;
            this.pwdlbl.Text = "Password";
            // 
            // pwdtxt
            // 
            this.pwdtxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pwdtxt.Location = new System.Drawing.Point(75, 183);
            this.pwdtxt.Name = "pwdtxt";
            this.pwdtxt.PasswordChar = '*';
            this.pwdtxt.Size = new System.Drawing.Size(120, 20);
            this.pwdtxt.TabIndex = 24;
            this.toolTip1.SetToolTip(this.pwdtxt, "Password");
            // 
            // userlbl
            // 
            this.userlbl.AutoSize = true;
            this.userlbl.Location = new System.Drawing.Point(75, 129);
            this.userlbl.Name = "userlbl";
            this.userlbl.Size = new System.Drawing.Size(60, 13);
            this.userlbl.TabIndex = 23;
            this.userlbl.Text = "User Name";
            // 
            // usertxt
            // 
            this.usertxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usertxt.Location = new System.Drawing.Point(76, 143);
            this.usertxt.Name = "usertxt";
            this.usertxt.Size = new System.Drawing.Size(120, 20);
            this.usertxt.TabIndex = 22;
            this.toolTip1.SetToolTip(this.usertxt, "User Name");
            // 
            // camlbl
            // 
            this.camlbl.AutoSize = true;
            this.camlbl.Location = new System.Drawing.Point(73, 40);
            this.camlbl.Name = "camlbl";
            this.camlbl.Size = new System.Drawing.Size(82, 13);
            this.camlbl.TabIndex = 21;
            this.camlbl.Text = "Choose Camera";
            // 
            // cameralst
            // 
            this.cameralst.FormattingEnabled = true;
            this.cameralst.Location = new System.Drawing.Point(74, 54);
            this.cameralst.Name = "cameralst";
            this.cameralst.Size = new System.Drawing.Size(121, 21);
            this.cameralst.TabIndex = 20;
            this.toolTip1.SetToolTip(this.cameralst, "Choose Camera");
            this.cameralst.SelectedIndexChanged += new System.EventHandler(this.cameralst_SelectedIndexChanged);
            // 
            // IPlbl
            // 
            this.IPlbl.AutoSize = true;
            this.IPlbl.Location = new System.Drawing.Point(74, 92);
            this.IPlbl.Name = "IPlbl";
            this.IPlbl.Size = new System.Drawing.Size(58, 13);
            this.IPlbl.TabIndex = 19;
            this.IPlbl.Text = "IP Address";
            // 
            // neighbourlbl
            // 
            this.neighbourlbl.AutoSize = true;
            this.neighbourlbl.Location = new System.Drawing.Point(5, 368);
            this.neighbourlbl.Name = "neighbourlbl";
            this.neighbourlbl.Size = new System.Drawing.Size(78, 13);
            this.neighbourlbl.TabIndex = 15;
            this.neighbourlbl.Text = "Add Neighbour";
            // 
            // cameraNamelbl
            // 
            this.cameraNamelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraNamelbl.AutoSize = true;
            this.cameraNamelbl.Location = new System.Drawing.Point(78, 3);
            this.cameraNamelbl.Name = "cameraNamelbl";
            this.cameraNamelbl.Size = new System.Drawing.Size(54, 13);
            this.cameraNamelbl.TabIndex = 11;
            this.cameraNamelbl.Text = "Properties";
            // 
            // cameralist
            // 
            this.cameralist.FormattingEnabled = true;
            this.cameralist.Location = new System.Drawing.Point(8, 381);
            this.cameralist.Name = "cameralist";
            this.cameralist.Size = new System.Drawing.Size(184, 94);
            this.cameralist.TabIndex = 14;
            this.cameralist.ThreeDCheckBoxes = true;
            this.toolTip1.SetToolTip(this.cameralist, "Camera List");
            // 
            // iptxt
            // 
            this.iptxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iptxt.Location = new System.Drawing.Point(76, 106);
            this.iptxt.Name = "iptxt";
            this.iptxt.Size = new System.Drawing.Size(120, 20);
            this.iptxt.TabIndex = 18;
            this.toolTip1.SetToolTip(this.iptxt, "IP Address");
            // 
            // prodonebtn
            // 
            this.prodonebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prodonebtn.Location = new System.Drawing.Point(70, 494);
            this.prodonebtn.Name = "prodonebtn";
            this.prodonebtn.Size = new System.Drawing.Size(75, 23);
            this.prodonebtn.TabIndex = 17;
            this.prodonebtn.Text = "Next";
            this.toolTip1.SetToolTip(this.prodonebtn, "Next Property");
            this.prodonebtn.UseVisualStyleBackColor = true;
            this.prodonebtn.Click += new System.EventHandler(this.prodonebtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.donebtn);
            this.panel2.Controls.Add(this.nxtbtn);
            this.panel2.Controls.Add(this.camera1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 528);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(925, 100);
            this.panel2.TabIndex = 0;
            this.toolTip1.SetToolTip(this.panel2, "Bottom Bar");
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(206, 35);
            this.trackBar1.Maximum = 180;
            this.trackBar1.Minimum = -180;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar1.Size = new System.Drawing.Size(200, 45);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.TickFrequency = 20;
            this.trackBar1.Value = 10;
            this.trackBar1.Visible = false;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // donebtn
            // 
            this.donebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.donebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.donebtn.Location = new System.Drawing.Point(410, 36);
            this.donebtn.Name = "donebtn";
            this.donebtn.Size = new System.Drawing.Size(50, 25);
            this.donebtn.TabIndex = 4;
            this.donebtn.Text = "Done";
            this.toolTip1.SetToolTip(this.donebtn, "Done");
            this.donebtn.UseVisualStyleBackColor = true;
            this.donebtn.Visible = false;
            this.donebtn.Click += new System.EventHandler(this.donebtn_Click);
            // 
            // nxtbtn
            // 
            this.nxtbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nxtbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nxtbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nxtbtn.Location = new System.Drawing.Point(750, 35);
            this.nxtbtn.Name = "nxtbtn";
            this.nxtbtn.Size = new System.Drawing.Size(84, 25);
            this.nxtbtn.TabIndex = 2;
            this.nxtbtn.Text = "Next";
            this.toolTip1.SetToolTip(this.nxtbtn, "To Home");
            this.nxtbtn.UseVisualStyleBackColor = true;
            this.nxtbtn.Click += new System.EventHandler(this.nxtbtn_Click);
            // 
            // camera1
            // 
            this.camera1.Image = global::iTrack_1.Properties.Resources.Untitled;
            this.camera1.Location = new System.Drawing.Point(12, 8);
            this.camera1.Name = "camera1";
            this.camera1.Size = new System.Drawing.Size(28, 25);
            this.camera1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.camera1.TabIndex = 1;
            this.camera1.TabStop = false;
            this.camera1.Visible = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Choose Map";
            this.toolTip1.SetToolTip(this.button1, "Choose Map");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 628);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Map";
            this.ShowIcon = false;
            this.Text = "Map";
            this.panel1.ResumeLayout(false);
            this.picpnl.ResumeLayout(false);
            this.optionpanal.ResumeLayout(false);
            this.pboptionpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.regpnl.ResumeLayout(false);
            this.regpnl.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camera1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel optionpanal;
        private System.Windows.Forms.Button addcamerabtn;
        private System.Windows.Forms.PictureBox camera1;
        private System.Windows.Forms.Button nxtbtn;
        private System.Windows.Forms.Panel pboptionpanel;
        private System.Windows.Forms.Button rotatebtn;
        private System.Windows.Forms.Button RemoveCamerabtn;
        private System.Windows.Forms.Button mulcamerabtn;
        private System.Windows.Forms.Button donebtn;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel regpnl;
        private System.Windows.Forms.Panel picpnl;
        private System.Windows.Forms.ComboBox cameralst;
        private System.Windows.Forms.Label IPlbl;
        private System.Windows.Forms.Label neighbourlbl;
        private System.Windows.Forms.Label cameraNamelbl;
        private System.Windows.Forms.CheckedListBox cameralist;
        private System.Windows.Forms.TextBox iptxt;
        private System.Windows.Forms.Button prodonebtn;
        private System.Windows.Forms.Label camlbl;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label pwdlbl;
        private System.Windows.Forms.TextBox pwdtxt;
        private System.Windows.Forms.Label userlbl;
        private System.Windows.Forms.TextBox usertxt;
        private System.Windows.Forms.CheckBox trackchk;
        private System.Windows.Forms.CheckBox identificationchk;
        private System.Windows.Forms.CheckBox Regchk;
        private System.Windows.Forms.Button streambtn;
        private System.Windows.Forms.Button ODbtn;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroComboBox odcameralst;
    }
}