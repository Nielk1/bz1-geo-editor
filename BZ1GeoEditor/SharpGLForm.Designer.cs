namespace BZ1GeoEditor
{
    partial class SharpGLForm
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
            this.openGLControl = new SharpGL.OpenGLControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportOBJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadACTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearACTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbRender = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnBackgroundColor = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lstFaces = new System.Windows.Forms.ListBox();
            this.cbTextTransp = new System.Windows.Forms.CheckBox();
            this.cbTiled = new System.Windows.Forms.CheckBox();
            this.cbPerspectiveSW = new System.Windows.Forms.CheckBox();
            this.cbTransparent = new System.Windows.Forms.ComboBox();
            this.cbShadeType = new System.Windows.Forms.ComboBox();
            this.btnFaceColor = new System.Windows.Forms.Button();
            this.cbHeaderFlag1 = new System.Windows.Forms.CheckBox();
            this.cbHeaderFlag2 = new System.Windows.Forms.CheckBox();
            this.cbHeaderFlag4 = new System.Windows.Forms.CheckBox();
            this.cbHeaderFlag3 = new System.Windows.Forms.CheckBox();
            this.cbHeaderFlag8 = new System.Windows.Forms.CheckBox();
            this.cbHeaderFlag7 = new System.Windows.Forms.CheckBox();
            this.cbHeaderFlag6 = new System.Windows.Forms.CheckBox();
            this.cbHeaderFlag5 = new System.Windows.Forms.CheckBox();
            this.cbHeaderFlag9 = new System.Windows.Forms.CheckBox();
            this.cbHeaderFlag14 = new System.Windows.Forms.CheckBox();
            this.cbHeaderFlag13 = new System.Windows.Forms.CheckBox();
            this.cbHeaderFlag12 = new System.Windows.Forms.CheckBox();
            this.cbHeaderFlag11 = new System.Windows.Forms.CheckBox();
            this.cbHeaderFlag10 = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cbTexture = new System.Windows.Forms.ComboBox();
            this.tcTabs = new System.Windows.Forms.TabControl();
            this.tpHeader = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInformation = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.tpFaces = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFaceCount = new System.Windows.Forms.Label();
            this.tpTextures = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbTexture = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddTexture = new System.Windows.Forms.Button();
            this.lbTextures = new System.Windows.Forms.ListBox();
            this.btnRemoveTexture = new System.Windows.Forms.Button();
            this.tpUV = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.lstFacesUV = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.nudZoom = new System.Windows.Forms.NumericUpDown();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tmrNotes = new System.Windows.Forms.Timer(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.tmrUV = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.cbNorms = new System.Windows.Forms.CheckBox();
            this.pbPallet = new BZ1GeoEditor.EnhancedPicture();
            this.pbTextureUV = new BZ1GeoEditor.EnhancedPicture();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tcTabs.SuspendLayout();
            this.tpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tpFaces.SuspendLayout();
            this.tpTextures.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTexture)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tpUV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudZoom)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPallet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTextureUV)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGLControl.DrawFPS = true;
            this.openGLControl.Location = new System.Drawing.Point(0, 0);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.FBO;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(969, 260);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            this.openGLControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseWheel);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.openGLControl);
            this.panel1.Location = new System.Drawing.Point(6, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 260);
            this.panel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.textureToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(981, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator2,
            this.exportOBJToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(127, 6);
            // 
            // exportOBJToolStripMenuItem
            // 
            this.exportOBJToolStripMenuItem.Name = "exportOBJToolStripMenuItem";
            this.exportOBJToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.exportOBJToolStripMenuItem.Text = "&Export OBJ";
            this.exportOBJToolStripMenuItem.Click += new System.EventHandler(this.exportOBJToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(127, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem1.Text = "E&xit";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // textureToolStripMenuItem
            // 
            this.textureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMAPToolStripMenuItem,
            this.clearMAPToolStripMenuItem,
            this.toolStripSeparator1,
            this.loadACTToolStripMenuItem,
            this.clearACTToolStripMenuItem});
            this.textureToolStripMenuItem.Name = "textureToolStripMenuItem";
            this.textureToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.textureToolStripMenuItem.Text = "&Texture";
            // 
            // loadMAPToolStripMenuItem
            // 
            this.loadMAPToolStripMenuItem.Name = "loadMAPToolStripMenuItem";
            this.loadMAPToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.loadMAPToolStripMenuItem.Text = "Load &MAP";
            // 
            // clearMAPToolStripMenuItem
            // 
            this.clearMAPToolStripMenuItem.Name = "clearMAPToolStripMenuItem";
            this.clearMAPToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.clearMAPToolStripMenuItem.Text = "Clear MAP";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // loadACTToolStripMenuItem
            // 
            this.loadACTToolStripMenuItem.Name = "loadACTToolStripMenuItem";
            this.loadACTToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.loadACTToolStripMenuItem.Text = "Load &ACT";
            // 
            // clearACTToolStripMenuItem
            // 
            this.clearACTToolStripMenuItem.Name = "clearACTToolStripMenuItem";
            this.clearACTToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.clearACTToolStripMenuItem.Text = "&Clear ACT";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "GEO files|*.geo";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // cbRender
            // 
            this.cbRender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRender.Enabled = false;
            this.cbRender.FormattingEnabled = true;
            this.cbRender.Items.AddRange(new object[] {
            "Special: TreeBranch",
            "Special: Area",
            "Special: Distance",
            "Wire",
            "Solid",
            "Color",
            "Checker",
            "Texture"});
            this.cbRender.Location = new System.Drawing.Point(33, 16);
            this.cbRender.Name = "cbRender";
            this.cbRender.Size = new System.Drawing.Size(157, 21);
            this.cbRender.TabIndex = 3;
            this.cbRender.SelectedIndexChanged += new System.EventHandler(this.cbRender_SelectedIndexChanged);
            // 
            // btnBackgroundColor
            // 
            this.btnBackgroundColor.BackColor = System.Drawing.Color.Gray;
            this.btnBackgroundColor.Location = new System.Drawing.Point(6, 16);
            this.btnBackgroundColor.Name = "btnBackgroundColor";
            this.btnBackgroundColor.Size = new System.Drawing.Size(21, 21);
            this.btnBackgroundColor.TabIndex = 4;
            this.btnBackgroundColor.UseVisualStyleBackColor = false;
            this.btnBackgroundColor.Click += new System.EventHandler(this.btnBackgroundColor_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "MAP files|*.map";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.Filter = "ACT files|*.act";
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(3, 16);
            this.txtName.MaxLength = 16;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(218, 20);
            this.txtName.TabIndex = 6;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lstFaces
            // 
            this.lstFaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFaces.Enabled = false;
            this.lstFaces.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFaces.FormattingEnabled = true;
            this.lstFaces.HorizontalScrollbar = true;
            this.lstFaces.Location = new System.Drawing.Point(209, 6);
            this.lstFaces.Name = "lstFaces";
            this.lstFaces.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFaces.Size = new System.Drawing.Size(746, 225);
            this.lstFaces.TabIndex = 8;
            this.lstFaces.SelectedIndexChanged += new System.EventHandler(this.lstFaces_SelectedIndexChanged);
            // 
            // cbTextTransp
            // 
            this.cbTextTransp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTextTransp.AutoSize = true;
            this.cbTextTransp.Checked = true;
            this.cbTextTransp.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.tableLayoutPanel3.SetColumnSpan(this.cbTextTransp, 2);
            this.cbTextTransp.Enabled = false;
            this.cbTextTransp.Location = new System.Drawing.Point(3, 130);
            this.cbTextTransp.Name = "cbTextTransp";
            this.cbTextTransp.Size = new System.Drawing.Size(194, 17);
            this.cbTextTransp.TabIndex = 10;
            this.cbTextTransp.Text = "Enable Texture Transparency Color";
            this.cbTextTransp.UseVisualStyleBackColor = true;
            this.cbTextTransp.CheckedChanged += new System.EventHandler(this.cbTextTransp_CheckedChanged);
            // 
            // cbTiled
            // 
            this.cbTiled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTiled.AutoSize = true;
            this.cbTiled.Checked = true;
            this.cbTiled.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.tableLayoutPanel3.SetColumnSpan(this.cbTiled, 2);
            this.cbTiled.Enabled = false;
            this.cbTiled.Location = new System.Drawing.Point(3, 107);
            this.cbTiled.Name = "cbTiled";
            this.cbTiled.Size = new System.Drawing.Size(194, 17);
            this.cbTiled.TabIndex = 9;
            this.cbTiled.Text = "Allow Texture Tiling";
            this.cbTiled.UseVisualStyleBackColor = true;
            this.cbTiled.CheckedChanged += new System.EventHandler(this.cbTiled_CheckedChanged);
            // 
            // cbPerspectiveSW
            // 
            this.cbPerspectiveSW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPerspectiveSW.AutoSize = true;
            this.cbPerspectiveSW.Checked = true;
            this.cbPerspectiveSW.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.tableLayoutPanel3.SetColumnSpan(this.cbPerspectiveSW, 2);
            this.cbPerspectiveSW.Enabled = false;
            this.cbPerspectiveSW.Location = new System.Drawing.Point(3, 84);
            this.cbPerspectiveSW.Name = "cbPerspectiveSW";
            this.cbPerspectiveSW.Size = new System.Drawing.Size(194, 17);
            this.cbPerspectiveSW.TabIndex = 8;
            this.cbPerspectiveSW.Text = "Perspective Texture(SW)";
            this.cbPerspectiveSW.UseVisualStyleBackColor = true;
            this.cbPerspectiveSW.CheckedChanged += new System.EventHandler(this.cbPerspectiveSW_CheckedChanged);
            // 
            // cbTransparent
            // 
            this.cbTransparent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTransparent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransparent.Enabled = false;
            this.cbTransparent.FormattingEnabled = true;
            this.cbTransparent.Items.AddRange(new object[] {
            "Solid",
            "2/3rd Transparent",
            "1/3rd Transparent"});
            this.cbTransparent.Location = new System.Drawing.Point(3, 30);
            this.cbTransparent.Name = "cbTransparent";
            this.cbTransparent.Size = new System.Drawing.Size(154, 21);
            this.cbTransparent.TabIndex = 7;
            this.cbTransparent.SelectedIndexChanged += new System.EventHandler(this.cbTransparent_SelectedIndexChanged);
            // 
            // cbShadeType
            // 
            this.cbShadeType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbShadeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShadeType.Enabled = false;
            this.cbShadeType.FormattingEnabled = true;
            this.cbShadeType.Items.AddRange(new object[] {
            "WIREFRAME",
            "SOLID_WIREFRAME",
            "CONSTANT_SHADED",
            "FLAT_SHADED",
            "GOUROUD_SHADED"});
            this.cbShadeType.Location = new System.Drawing.Point(3, 3);
            this.cbShadeType.Name = "cbShadeType";
            this.cbShadeType.Size = new System.Drawing.Size(154, 21);
            this.cbShadeType.TabIndex = 6;
            this.cbShadeType.SelectedIndexChanged += new System.EventHandler(this.cbShadeType_SelectedIndexChanged);
            // 
            // btnFaceColor
            // 
            this.btnFaceColor.BackColor = System.Drawing.SystemColors.Control;
            this.btnFaceColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFaceColor.Enabled = false;
            this.btnFaceColor.Location = new System.Drawing.Point(163, 3);
            this.btnFaceColor.Name = "btnFaceColor";
            this.tableLayoutPanel3.SetRowSpan(this.btnFaceColor, 2);
            this.btnFaceColor.Size = new System.Drawing.Size(34, 48);
            this.btnFaceColor.TabIndex = 5;
            this.btnFaceColor.UseVisualStyleBackColor = false;
            this.btnFaceColor.Click += new System.EventHandler(this.btnFaceColor_Click);
            // 
            // cbHeaderFlag1
            // 
            this.cbHeaderFlag1.AutoSize = true;
            this.cbHeaderFlag1.Checked = true;
            this.cbHeaderFlag1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHeaderFlag1.Enabled = false;
            this.cbHeaderFlag1.Location = new System.Drawing.Point(3, 3);
            this.cbHeaderFlag1.Name = "cbHeaderFlag1";
            this.cbHeaderFlag1.Size = new System.Drawing.Size(132, 17);
            this.cbHeaderFlag1.TabIndex = 7;
            this.cbHeaderFlag1.Text = "GOURAUD_SHADED";
            this.cbHeaderFlag1.UseVisualStyleBackColor = true;
            this.cbHeaderFlag1.CheckedChanged += new System.EventHandler(this.cbHeaderFlag_Check);
            // 
            // cbHeaderFlag2
            // 
            this.cbHeaderFlag2.AutoSize = true;
            this.cbHeaderFlag2.Checked = true;
            this.cbHeaderFlag2.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHeaderFlag2.Enabled = false;
            this.cbHeaderFlag2.Location = new System.Drawing.Point(3, 26);
            this.cbHeaderFlag2.Name = "cbHeaderFlag2";
            this.cbHeaderFlag2.Size = new System.Drawing.Size(103, 17);
            this.cbHeaderFlag2.TabIndex = 8;
            this.cbHeaderFlag2.Text = "TILED_BITMAP";
            this.cbHeaderFlag2.UseVisualStyleBackColor = true;
            this.cbHeaderFlag2.CheckedChanged += new System.EventHandler(this.cbHeaderFlag_Check);
            // 
            // cbHeaderFlag4
            // 
            this.cbHeaderFlag4.AutoSize = true;
            this.cbHeaderFlag4.Checked = true;
            this.cbHeaderFlag4.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHeaderFlag4.Enabled = false;
            this.cbHeaderFlag4.Location = new System.Drawing.Point(3, 72);
            this.cbHeaderFlag4.Name = "cbHeaderFlag4";
            this.cbHeaderFlag4.Size = new System.Drawing.Size(80, 17);
            this.cbHeaderFlag4.TabIndex = 10;
            this.cbHeaderFlag4.Text = "PARALLEL";
            this.cbHeaderFlag4.UseVisualStyleBackColor = true;
            this.cbHeaderFlag4.CheckedChanged += new System.EventHandler(this.cbHeaderFlag_Check);
            // 
            // cbHeaderFlag3
            // 
            this.cbHeaderFlag3.AutoSize = true;
            this.cbHeaderFlag3.Checked = true;
            this.cbHeaderFlag3.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHeaderFlag3.Enabled = false;
            this.cbHeaderFlag3.Location = new System.Drawing.Point(3, 49);
            this.cbHeaderFlag3.Name = "cbHeaderFlag3";
            this.cbHeaderFlag3.Size = new System.Drawing.Size(106, 17);
            this.cbHeaderFlag3.TabIndex = 9;
            this.cbHeaderFlag3.Text = "TEXTURE_MAP";
            this.cbHeaderFlag3.UseVisualStyleBackColor = true;
            this.cbHeaderFlag3.CheckedChanged += new System.EventHandler(this.cbHeaderFlag_Check);
            // 
            // cbHeaderFlag8
            // 
            this.cbHeaderFlag8.AutoSize = true;
            this.cbHeaderFlag8.Checked = true;
            this.cbHeaderFlag8.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHeaderFlag8.Enabled = false;
            this.cbHeaderFlag8.Location = new System.Drawing.Point(3, 164);
            this.cbHeaderFlag8.Name = "cbHeaderFlag8";
            this.cbHeaderFlag8.Size = new System.Drawing.Size(212, 17);
            this.cbHeaderFlag8.TabIndex = 14;
            this.cbHeaderFlag8.Text = "ONE_THIRD_TRANSLUCENT_PIXELS";
            this.cbHeaderFlag8.UseVisualStyleBackColor = true;
            this.cbHeaderFlag8.CheckedChanged += new System.EventHandler(this.cbHeaderFlag_Check);
            // 
            // cbHeaderFlag7
            // 
            this.cbHeaderFlag7.AutoSize = true;
            this.cbHeaderFlag7.Checked = true;
            this.cbHeaderFlag7.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHeaderFlag7.Enabled = false;
            this.cbHeaderFlag7.Location = new System.Drawing.Point(3, 141);
            this.cbHeaderFlag7.Name = "cbHeaderFlag7";
            this.cbHeaderFlag7.Size = new System.Drawing.Size(150, 17);
            this.cbHeaderFlag7.TabIndex = 13;
            this.cbHeaderFlag7.Text = "TRANSPARENT_PIXELS";
            this.cbHeaderFlag7.UseVisualStyleBackColor = true;
            this.cbHeaderFlag7.CheckedChanged += new System.EventHandler(this.cbHeaderFlag_Check);
            // 
            // cbHeaderFlag6
            // 
            this.cbHeaderFlag6.AutoSize = true;
            this.cbHeaderFlag6.Checked = true;
            this.cbHeaderFlag6.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHeaderFlag6.Enabled = false;
            this.cbHeaderFlag6.Location = new System.Drawing.Point(3, 118);
            this.cbHeaderFlag6.Name = "cbHeaderFlag6";
            this.cbHeaderFlag6.Size = new System.Drawing.Size(98, 17);
            this.cbHeaderFlag6.TabIndex = 12;
            this.cbHeaderFlag6.Text = "WIRE_FRAME";
            this.cbHeaderFlag6.UseVisualStyleBackColor = true;
            this.cbHeaderFlag6.CheckedChanged += new System.EventHandler(this.cbHeaderFlag_Check);
            // 
            // cbHeaderFlag5
            // 
            this.cbHeaderFlag5.AutoSize = true;
            this.cbHeaderFlag5.Checked = true;
            this.cbHeaderFlag5.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHeaderFlag5.Enabled = false;
            this.cbHeaderFlag5.Location = new System.Drawing.Point(3, 95);
            this.cbHeaderFlag5.Name = "cbHeaderFlag5";
            this.cbHeaderFlag5.Size = new System.Drawing.Size(136, 17);
            this.cbHeaderFlag5.TabIndex = 11;
            this.cbHeaderFlag5.Text = "TRUE_PERSPECTIVE";
            this.cbHeaderFlag5.UseVisualStyleBackColor = true;
            this.cbHeaderFlag5.CheckedChanged += new System.EventHandler(this.cbHeaderFlag_Check);
            // 
            // cbHeaderFlag9
            // 
            this.cbHeaderFlag9.AutoSize = true;
            this.cbHeaderFlag9.Checked = true;
            this.cbHeaderFlag9.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHeaderFlag9.Enabled = false;
            this.cbHeaderFlag9.Location = new System.Drawing.Point(3, 187);
            this.cbHeaderFlag9.Name = "cbHeaderFlag9";
            this.cbHeaderFlag9.Size = new System.Drawing.Size(168, 17);
            this.cbHeaderFlag9.TabIndex = 15;
            this.cbHeaderFlag9.Text = "PROJECT_POLYGON_ONLY";
            this.cbHeaderFlag9.UseVisualStyleBackColor = true;
            this.cbHeaderFlag9.CheckedChanged += new System.EventHandler(this.cbHeaderFlag_Check);
            // 
            // cbHeaderFlag14
            // 
            this.cbHeaderFlag14.AutoSize = true;
            this.cbHeaderFlag14.Checked = true;
            this.cbHeaderFlag14.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHeaderFlag14.Enabled = false;
            this.cbHeaderFlag14.Location = new System.Drawing.Point(3, 95);
            this.cbHeaderFlag14.Name = "cbHeaderFlag14";
            this.cbHeaderFlag14.Size = new System.Drawing.Size(150, 17);
            this.cbHeaderFlag14.TabIndex = 20;
            this.cbHeaderFlag14.Text = "HALLOW_WIRE_FRAME";
            this.cbHeaderFlag14.UseVisualStyleBackColor = true;
            this.cbHeaderFlag14.CheckedChanged += new System.EventHandler(this.cbHeaderFlag_Check);
            // 
            // cbHeaderFlag13
            // 
            this.cbHeaderFlag13.AutoSize = true;
            this.cbHeaderFlag13.Checked = true;
            this.cbHeaderFlag13.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHeaderFlag13.Enabled = false;
            this.cbHeaderFlag13.Location = new System.Drawing.Point(3, 72);
            this.cbHeaderFlag13.Name = "cbHeaderFlag13";
            this.cbHeaderFlag13.Size = new System.Drawing.Size(198, 17);
            this.cbHeaderFlag13.TabIndex = 19;
            this.cbHeaderFlag13.Text = "FLAT_TILED_PERSPECTIVE_MAP";
            this.cbHeaderFlag13.UseVisualStyleBackColor = true;
            this.cbHeaderFlag13.CheckedChanged += new System.EventHandler(this.cbHeaderFlag_Check);
            // 
            // cbHeaderFlag12
            // 
            this.cbHeaderFlag12.AutoSize = true;
            this.cbHeaderFlag12.Checked = true;
            this.cbHeaderFlag12.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHeaderFlag12.Enabled = false;
            this.cbHeaderFlag12.Location = new System.Drawing.Point(3, 49);
            this.cbHeaderFlag12.Name = "cbHeaderFlag12";
            this.cbHeaderFlag12.Size = new System.Drawing.Size(161, 17);
            this.cbHeaderFlag12.TabIndex = 18;
            this.cbHeaderFlag12.Text = "FLAT_PERSPECTIVE_MAP";
            this.cbHeaderFlag12.UseVisualStyleBackColor = true;
            this.cbHeaderFlag12.CheckedChanged += new System.EventHandler(this.cbHeaderFlag_Check);
            // 
            // cbHeaderFlag11
            // 
            this.cbHeaderFlag11.AutoSize = true;
            this.cbHeaderFlag11.Checked = true;
            this.cbHeaderFlag11.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHeaderFlag11.Enabled = false;
            this.cbHeaderFlag11.Location = new System.Drawing.Point(3, 26);
            this.cbHeaderFlag11.Name = "cbHeaderFlag11";
            this.cbHeaderFlag11.Size = new System.Drawing.Size(212, 17);
            this.cbHeaderFlag11.TabIndex = 17;
            this.cbHeaderFlag11.Text = "TWO_THIRD_TRANSLUCENT_PIXELS";
            this.cbHeaderFlag11.UseVisualStyleBackColor = true;
            this.cbHeaderFlag11.CheckedChanged += new System.EventHandler(this.cbHeaderFlag_Check);
            // 
            // cbHeaderFlag10
            // 
            this.cbHeaderFlag10.AutoSize = true;
            this.cbHeaderFlag10.Checked = true;
            this.cbHeaderFlag10.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHeaderFlag10.Enabled = false;
            this.cbHeaderFlag10.Location = new System.Drawing.Point(3, 3);
            this.cbHeaderFlag10.Name = "cbHeaderFlag10";
            this.cbHeaderFlag10.Size = new System.Drawing.Size(103, 17);
            this.cbHeaderFlag10.TabIndex = 16;
            this.cbHeaderFlag10.Text = "ALPHA_BLEND";
            this.cbHeaderFlag10.UseVisualStyleBackColor = true;
            this.cbHeaderFlag10.CheckedChanged += new System.EventHandler(this.cbHeaderFlag_Check);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "GEO files|*.geo";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 134);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Composit Flags";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cbHeaderFlag10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbHeaderFlag14, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbHeaderFlag11, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbHeaderFlag13, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbHeaderFlag12, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(218, 115);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Location = new System.Drawing.Point(233, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 225);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Header Flags";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.cbHeaderFlag1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbHeaderFlag2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbHeaderFlag3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbHeaderFlag9, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.cbHeaderFlag4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.cbHeaderFlag5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.cbHeaderFlag8, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.cbHeaderFlag6, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.cbHeaderFlag7, 0, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(218, 206);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtName);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 44);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Name";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbNorms);
            this.groupBox5.Controls.Add(this.btnBackgroundColor);
            this.groupBox5.Controls.Add(this.cbRender);
            this.groupBox5.Location = new System.Drawing.Point(4, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(256, 45);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Render";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.Controls.Add(this.cbShadeType, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbTransparent, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnFaceColor, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbTextTransp, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.cbTiled, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.cbPerspectiveSW, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.cbTexture, 0, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 151);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // cbTexture
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.cbTexture, 2);
            this.cbTexture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTexture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTexture.Enabled = false;
            this.cbTexture.FormattingEnabled = true;
            this.cbTexture.Location = new System.Drawing.Point(3, 57);
            this.cbTexture.Name = "cbTexture";
            this.cbTexture.Size = new System.Drawing.Size(194, 21);
            this.cbTexture.TabIndex = 11;
            this.cbTexture.SelectedIndexChanged += new System.EventHandler(this.cbTexture_SelectedIndexChanged);
            // 
            // tcTabs
            // 
            this.tcTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcTabs.Controls.Add(this.tpHeader);
            this.tcTabs.Controls.Add(this.tpFaces);
            this.tcTabs.Controls.Add(this.tpTextures);
            this.tcTabs.Controls.Add(this.tpUV);
            this.tcTabs.Location = new System.Drawing.Point(6, 1);
            this.tcTabs.Name = "tcTabs";
            this.tcTabs.SelectedIndex = 0;
            this.tcTabs.Size = new System.Drawing.Size(969, 263);
            this.tcTabs.TabIndex = 27;
            // 
            // tpHeader
            // 
            this.tpHeader.Controls.Add(this.splitContainer3);
            this.tpHeader.Location = new System.Drawing.Point(4, 22);
            this.tpHeader.Name = "tpHeader";
            this.tpHeader.Padding = new System.Windows.Forms.Padding(3);
            this.tpHeader.Size = new System.Drawing.Size(961, 237);
            this.tpHeader.TabIndex = 0;
            this.tpHeader.Text = "GEO Header";
            this.tpHeader.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer3.Size = new System.Drawing.Size(955, 231);
            this.splitContainer3.SplitterDistance = 460;
            this.splitContainer3.TabIndex = 30;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(460, 231);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox6);
            this.splitContainer1.Size = new System.Drawing.Size(491, 231);
            this.splitContainer1.SplitterDistance = 113;
            this.splitContainer1.TabIndex = 29;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtInformation);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(491, 113);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information";
            // 
            // txtInformation
            // 
            this.txtInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInformation.Location = new System.Drawing.Point(3, 16);
            this.txtInformation.Multiline = true;
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.ReadOnly = true;
            this.txtInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInformation.Size = new System.Drawing.Size(485, 94);
            this.txtInformation.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtNotes);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(491, 114);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotes.Location = new System.Drawing.Point(3, 16);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(485, 95);
            this.txtNotes.TabIndex = 0;
            this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            // 
            // tpFaces
            // 
            this.tpFaces.Controls.Add(this.label1);
            this.tpFaces.Controls.Add(this.lblFaceCount);
            this.tpFaces.Controls.Add(this.tableLayoutPanel3);
            this.tpFaces.Controls.Add(this.lstFaces);
            this.tpFaces.Location = new System.Drawing.Point(4, 22);
            this.tpFaces.Name = "tpFaces";
            this.tpFaces.Padding = new System.Windows.Forms.Padding(3);
            this.tpFaces.Size = new System.Drawing.Size(961, 237);
            this.tpFaces.TabIndex = 1;
            this.tpFaces.Text = "Faces";
            this.tpFaces.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Selected:";
            // 
            // lblFaceCount
            // 
            this.lblFaceCount.AutoSize = true;
            this.lblFaceCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaceCount.Location = new System.Drawing.Point(115, 184);
            this.lblFaceCount.Name = "lblFaceCount";
            this.lblFaceCount.Size = new System.Drawing.Size(24, 26);
            this.lblFaceCount.TabIndex = 9;
            this.lblFaceCount.Text = "0";
            // 
            // tpTextures
            // 
            this.tpTextures.Controls.Add(this.pbPallet);
            this.tpTextures.Controls.Add(this.panel3);
            this.tpTextures.Controls.Add(this.tableLayoutPanel5);
            this.tpTextures.Location = new System.Drawing.Point(4, 22);
            this.tpTextures.Name = "tpTextures";
            this.tpTextures.Padding = new System.Windows.Forms.Padding(3);
            this.tpTextures.Size = new System.Drawing.Size(961, 237);
            this.tpTextures.TabIndex = 2;
            this.tpTextures.Text = "Textures";
            this.tpTextures.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.pbTexture);
            this.panel3.Location = new System.Drawing.Point(144, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(814, 190);
            this.panel3.TabIndex = 3;
            // 
            // pbTexture
            // 
            this.pbTexture.Location = new System.Drawing.Point(3, 3);
            this.pbTexture.Name = "pbTexture";
            this.pbTexture.Size = new System.Drawing.Size(100, 50);
            this.pbTexture.TabIndex = 0;
            this.pbTexture.TabStop = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.btnAddTexture, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lbTextures, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnRemoveTexture, 1, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 6);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(135, 225);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // btnAddTexture
            // 
            this.btnAddTexture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddTexture.Enabled = false;
            this.btnAddTexture.Location = new System.Drawing.Point(3, 196);
            this.btnAddTexture.Name = "btnAddTexture";
            this.btnAddTexture.Size = new System.Drawing.Size(61, 26);
            this.btnAddTexture.TabIndex = 1;
            this.btnAddTexture.Text = "Add";
            this.btnAddTexture.UseVisualStyleBackColor = true;
            this.btnAddTexture.Click += new System.EventHandler(this.btnAddTexture_Click);
            // 
            // lbTextures
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.lbTextures, 2);
            this.lbTextures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTextures.Enabled = false;
            this.lbTextures.FormattingEnabled = true;
            this.lbTextures.Location = new System.Drawing.Point(3, 3);
            this.lbTextures.Name = "lbTextures";
            this.lbTextures.Size = new System.Drawing.Size(129, 187);
            this.lbTextures.TabIndex = 0;
            this.lbTextures.SelectedIndexChanged += new System.EventHandler(this.lbTextures_SelectedIndexChanged);
            // 
            // btnRemoveTexture
            // 
            this.btnRemoveTexture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveTexture.Enabled = false;
            this.btnRemoveTexture.Location = new System.Drawing.Point(70, 196);
            this.btnRemoveTexture.Name = "btnRemoveTexture";
            this.btnRemoveTexture.Size = new System.Drawing.Size(62, 26);
            this.btnRemoveTexture.TabIndex = 2;
            this.btnRemoveTexture.Text = "Remove";
            this.btnRemoveTexture.UseVisualStyleBackColor = true;
            this.btnRemoveTexture.Click += new System.EventHandler(this.btnRemoveTexture_Click);
            // 
            // tpUV
            // 
            this.tpUV.Controls.Add(this.splitContainer4);
            this.tpUV.Location = new System.Drawing.Point(4, 22);
            this.tpUV.Name = "tpUV";
            this.tpUV.Padding = new System.Windows.Forms.Padding(3);
            this.tpUV.Size = new System.Drawing.Size(961, 237);
            this.tpUV.TabIndex = 3;
            this.tpUV.Text = "UV";
            this.tpUV.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.lstFacesUV);
            this.splitContainer4.Panel1.Controls.Add(this.textBox1);
            this.splitContainer4.Panel1.Controls.Add(this.nudZoom);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.panel4);
            this.splitContainer4.Size = new System.Drawing.Size(955, 231);
            this.splitContainer4.SplitterDistance = 162;
            this.splitContainer4.TabIndex = 11;
            // 
            // lstFacesUV
            // 
            this.lstFacesUV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFacesUV.Enabled = false;
            this.lstFacesUV.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFacesUV.FormattingEnabled = true;
            this.lstFacesUV.HorizontalScrollbar = true;
            this.lstFacesUV.Location = new System.Drawing.Point(0, 20);
            this.lstFacesUV.Name = "lstFacesUV";
            this.lstFacesUV.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFacesUV.Size = new System.Drawing.Size(162, 191);
            this.lstFacesUV.TabIndex = 9;
            this.lstFacesUV.SelectedIndexChanged += new System.EventHandler(this.lstFacesUV_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(162, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Use WASD to nudge cursor";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudZoom
            // 
            this.nudZoom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nudZoom.Enabled = false;
            this.nudZoom.Location = new System.Drawing.Point(0, 211);
            this.nudZoom.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudZoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudZoom.Name = "nudZoom";
            this.nudZoom.Size = new System.Drawing.Size(162, 20);
            this.nudZoom.TabIndex = 11;
            this.nudZoom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudZoom.ValueChanged += new System.EventHandler(this.nudZoom_ValueChanged);
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.pbTextureUV);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(789, 231);
            this.panel4.TabIndex = 10;
            // 
            // tmrNotes
            // 
            this.tmrNotes.Interval = 1000;
            this.tmrNotes.Tick += new System.EventHandler(this.tmrNotes_Tick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 24);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tcTabs);
            this.splitContainer2.Panel1MinSize = 263;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Panel2.Controls.Add(this.trackBar1);
            this.splitContainer2.Size = new System.Drawing.Size(981, 584);
            this.splitContainer2.SplitterDistance = 263;
            this.splitContainer2.TabIndex = 28;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(263, 14);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar1.Size = new System.Drawing.Size(709, 45);
            this.trackBar1.TabIndex = 21;
            this.trackBar1.Value = 4;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // tmrUV
            // 
            this.tmrUV.Tick += new System.EventHandler(this.tmrUV_Tick);
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.Filter = "OBJ files|*.obj";
            // 
            // cbNorms
            // 
            this.cbNorms.AutoSize = true;
            this.cbNorms.Enabled = false;
            this.cbNorms.Location = new System.Drawing.Point(197, 19);
            this.cbNorms.Name = "cbNorms";
            this.cbNorms.Size = new System.Drawing.Size(56, 17);
            this.cbNorms.TabIndex = 5;
            this.cbNorms.Text = "Norms";
            this.cbNorms.UseVisualStyleBackColor = true;
            // 
            // pbPallet
            // 
            this.pbPallet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPallet.Interpolation = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pbPallet.Location = new System.Drawing.Point(144, 202);
            this.pbPallet.Name = "pbPallet";
            this.pbPallet.Size = new System.Drawing.Size(814, 26);
            this.pbPallet.TabIndex = 1;
            this.pbPallet.TabStop = false;
            // 
            // pbTextureUV
            // 
            this.pbTextureUV.Interpolation = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pbTextureUV.Location = new System.Drawing.Point(3, 3);
            this.pbTextureUV.Name = "pbTextureUV";
            this.pbTextureUV.Size = new System.Drawing.Size(100, 50);
            this.pbTextureUV.TabIndex = 0;
            this.pbTextureUV.TabStop = false;
            this.pbTextureUV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbTextureUV_MouseDown);
            this.pbTextureUV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbTextureUV_MouseMove);
            this.pbTextureUV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbTextureUV_MouseUp);
            // 
            // SharpGLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 608);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(592, 645);
            this.Name = "SharpGLForm";
            this.Text = "BZ1 GEO Editor";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tcTabs.ResumeLayout(false);
            this.tpHeader.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tpFaces.ResumeLayout(false);
            this.tpFaces.PerformLayout();
            this.tpTextures.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTexture)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tpUV.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudZoom)).EndInit();
            this.panel4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPallet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTextureUV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbRender;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnBackgroundColor;
        private System.Windows.Forms.ToolStripMenuItem textureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMAPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMAPToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem loadACTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearACTToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ListBox lstFaces;
        private System.Windows.Forms.Button btnFaceColor;
        private System.Windows.Forms.ComboBox cbShadeType;
        private System.Windows.Forms.ComboBox cbTransparent;
        private System.Windows.Forms.CheckBox cbTextTransp;
        private System.Windows.Forms.CheckBox cbTiled;
        private System.Windows.Forms.CheckBox cbPerspectiveSW;
        private System.Windows.Forms.CheckBox cbHeaderFlag1;
        private System.Windows.Forms.CheckBox cbHeaderFlag2;
        private System.Windows.Forms.CheckBox cbHeaderFlag4;
        private System.Windows.Forms.CheckBox cbHeaderFlag3;
        private System.Windows.Forms.CheckBox cbHeaderFlag8;
        private System.Windows.Forms.CheckBox cbHeaderFlag7;
        private System.Windows.Forms.CheckBox cbHeaderFlag6;
        private System.Windows.Forms.CheckBox cbHeaderFlag5;
        private System.Windows.Forms.CheckBox cbHeaderFlag9;
        private System.Windows.Forms.CheckBox cbHeaderFlag14;
        private System.Windows.Forms.CheckBox cbHeaderFlag13;
        private System.Windows.Forms.CheckBox cbHeaderFlag12;
        private System.Windows.Forms.CheckBox cbHeaderFlag11;
        private System.Windows.Forms.CheckBox cbHeaderFlag10;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cbTexture;
        private System.Windows.Forms.TabControl tcTabs;
        private System.Windows.Forms.TabPage tpHeader;
        private System.Windows.Forms.TabPage tpFaces;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtInformation;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Timer tmrNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFaceCount;
        private System.Windows.Forms.TabPage tpTextures;
        private System.Windows.Forms.Button btnAddTexture;
        private System.Windows.Forms.ListBox lbTextures;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnRemoveTexture;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pbTexture;
        private EnhancedPicture pbPallet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TabPage tpUV;
        private System.Windows.Forms.ListBox lstFacesUV;
        private System.Windows.Forms.Panel panel4;
        private BZ1GeoEditor.EnhancedPicture pbTextureUV;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Timer tmrUV;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown nudZoom;
        private System.Windows.Forms.ToolStripMenuItem exportOBJToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.CheckBox cbNorms;
    }
}

