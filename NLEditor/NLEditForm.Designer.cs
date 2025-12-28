namespace NLEditor
{
    partial class NLEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NLEditForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToINIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.playLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.cleanseLevelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteInPlaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ungroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLevelWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPieceBrowserWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandAllTabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.highlightGroupedPiecesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightEraserPiecesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.clearPhysicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.terrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triggerAreasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deprecatedPiecesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchPiecesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snapToGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showMissingPiecesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshStylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.pic_Level = new System.Windows.Forms.PictureBox();
            this.tabLvlProperties = new System.Windows.Forms.TabControl();
            this.tabGlobalInfo = new System.Windows.Forms.TabPage();
            this.chk_Lvl_AutoStart = new System.Windows.Forms.CheckBox();
            this.lbl_Global_Version = new System.Windows.Forms.Label();
            this.but_RandomID = new System.Windows.Forms.Button();
            this.txt_LevelID = new System.Windows.Forms.TextBox();
            this.lbl_Global_ID = new System.Windows.Forms.Label();
            this.lbStartY = new System.Windows.Forms.Label();
            this.lbStartX = new System.Windows.Forms.Label();
            this.lbSizeH = new System.Windows.Forms.Label();
            this.lbSizeW = new System.Windows.Forms.Label();
            this.check_Lvl_InfTime = new System.Windows.Forms.CheckBox();
            this.combo_Music = new System.Windows.Forms.ComboBox();
            this.num_Lvl_TimeSec = new NLEditor.NumUpDownOverwrite();
            this.num_Lvl_TimeMin = new NLEditor.NumUpDownOverwrite();
            this.lbl_Global_TimeLimit = new System.Windows.Forms.Label();
            this.num_Lvl_RR = new NLEditor.NumUpDownOverwrite();
            this.lbl_Global_SR = new System.Windows.Forms.Label();
            this.num_Lvl_Rescue = new NLEditor.NumUpDownOverwrite();
            this.lbl_Global_Rescue = new System.Windows.Forms.Label();
            this.num_Lvl_Lems = new NLEditor.NumUpDownOverwrite();
            this.lbl_Global_Lemmings = new System.Windows.Forms.Label();
            this.num_Lvl_StartY = new NLEditor.NumUpDownOverwrite();
            this.num_Lvl_StartX = new NLEditor.NumUpDownOverwrite();
            this.num_Lvl_SizeY = new NLEditor.NumUpDownOverwrite();
            this.num_Lvl_SizeX = new NLEditor.NumUpDownOverwrite();
            this.lbl_Global_Music = new System.Windows.Forms.Label();
            this.txt_LevelAuthor = new System.Windows.Forms.TextBox();
            this.lbl_Global_Author = new System.Windows.Forms.Label();
            this.txt_LevelTitle = new System.Windows.Forms.TextBox();
            this.lbl_Global_Title = new System.Windows.Forms.Label();
            this.num_Lvl_SI = new NLEditor.NumUpDownOverwrite();
            this.tabPieces = new System.Windows.Forms.TabPage();
            this.gbPieceMetaData = new System.Windows.Forms.GroupBox();
            this.lblPieceSize = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.but_LoadStyle = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPieceType = new System.Windows.Forms.Label();
            this.lblStyle = new System.Windows.Forms.Label();
            this.lblPieceStyle = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblPieceName = new System.Windows.Forms.Label();
            this.but_UngroupSelection = new System.Windows.Forms.Button();
            this.but_GroupSelection = new System.Windows.Forms.Button();
            this.check_Pieces_OneWay = new System.Windows.Forms.CheckBox();
            this.check_Pieces_OnlyOnTerrain = new System.Windows.Forms.CheckBox();
            this.check_Pieces_NoOv = new System.Windows.Forms.CheckBox();
            this.check_Pieces_Erase = new System.Windows.Forms.CheckBox();
            this.but_MoveBackOne = new NLEditor.RepeatButton();
            this.but_MoveFrontOne = new NLEditor.RepeatButton();
            this.but_MoveBack = new NLEditor.NoPaddingButton();
            this.but_MoveFront = new NLEditor.NoPaddingButton();
            this.but_FlipPieces = new NLEditor.RepeatButton();
            this.but_InvertPieces = new NLEditor.RepeatButton();
            this.but_RotatePieces = new NLEditor.RepeatButton();
            this.tabSkills = new System.Windows.Forms.TabPage();
            this.num_AllNonZeroSkillsToN = new NLEditor.NumUpDownOverwrite();
            this.btnAllNonZeroSkillsToN = new System.Windows.Forms.Button();
            this.lbl_Skill_Digger = new System.Windows.Forms.Label();
            this.lbl_Skill_Miner = new System.Windows.Forms.Label();
            this.lbl_Skill_Basher = new System.Windows.Forms.Label();
            this.lbl_Skill_Builder = new System.Windows.Forms.Label();
            this.lbl_Skill_Bomber = new System.Windows.Forms.Label();
            this.lbl_Skill_Blocker = new System.Windows.Forms.Label();
            this.lbl_Skill_Floater = new System.Windows.Forms.Label();
            this.lbl_Skill_Climber = new System.Windows.Forms.Label();
            this.gbRandomSkillset = new System.Windows.Forms.GroupBox();
            this.btnRandomSkillset = new System.Windows.Forms.Button();
            this.num_RandomMaxLimit = new NLEditor.NumUpDownOverwrite();
            this.lblRandomMinLimit = new System.Windows.Forms.Label();
            this.num_RandomMinLimit = new NLEditor.NumUpDownOverwrite();
            this.lblRandomMaxLimit = new System.Windows.Forms.Label();
            this.gbCustomSkillset = new System.Windows.Forms.GroupBox();
            this.btnSaveAsCustomSkillset = new System.Windows.Forms.Button();
            this.combo_CustomSkillset = new System.Windows.Forms.ComboBox();
            this.btnCustomSkillset = new System.Windows.Forms.Button();
            this.num_Ski_Digger = new NLEditor.NumUpDownOverwrite();
            this.num_Ski_Miner = new NLEditor.NumUpDownOverwrite();
            this.num_Ski_Basher = new NLEditor.NumUpDownOverwrite();
            this.num_Ski_Builder = new NLEditor.NumUpDownOverwrite();
            this.num_Ski_Bomber = new NLEditor.NumUpDownOverwrite();
            this.num_Ski_Blocker = new NLEditor.NumUpDownOverwrite();
            this.num_Ski_Floater = new NLEditor.NumUpDownOverwrite();
            this.num_Ski_Climber = new NLEditor.NumUpDownOverwrite();
            this.tabMisc = new System.Windows.Forms.TabPage();
            this.check_Lvl_Superlemming = new System.Windows.Forms.CheckBox();
            this.btnEditPostview = new System.Windows.Forms.Button();
            this.btnEditPreview = new System.Windows.Forms.Button();
            this.toolTipPieces = new System.Windows.Forms.ToolTip(this.components);
            this.scrollPicLevelHoriz = new System.Windows.Forms.HScrollBar();
            this.scrollPicLevelVert = new System.Windows.Forms.VScrollBar();
            this.toolTipButton = new System.Windows.Forms.ToolTip(this.components);
            this.but_PieceRight = new NLEditor.RepeatButton();
            this.but_PieceLeft = new NLEditor.RepeatButton();
            this.timerAutosave = new System.Windows.Forms.Timer(this.components);
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusBarLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.showMissingPiecesStatusBarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oKStatusBarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMissingPiecesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabLvlPieces = new System.Windows.Forms.TabControl();
            this.tabLvlSkills = new System.Windows.Forms.TabControl();
            this.tabLvlMisc = new System.Windows.Forms.TabControl();
            this.panelPieceBrowser = new System.Windows.Forms.Panel();
            this.picPiece7 = new System.Windows.Forms.PictureBox();
            this.but_PieceSteel = new System.Windows.Forms.Button();
            this.but_SearchPieces = new System.Windows.Forms.Button();
            this.but_PieceTerr = new System.Windows.Forms.Button();
            this.but_PieceObj = new System.Windows.Forms.Button();
            this.but_PieceSketches = new System.Windows.Forms.Button();
            this.but_PieceBackground = new System.Windows.Forms.Button();
            this.but_ClearBackground = new System.Windows.Forms.Button();
            this.picPiece6 = new System.Windows.Forms.PictureBox();
            this.picPiece5 = new System.Windows.Forms.PictureBox();
            this.picPiece4 = new System.Windows.Forms.PictureBox();
            this.picPiece3 = new System.Windows.Forms.PictureBox();
            this.picPiece2 = new System.Windows.Forms.PictureBox();
            this.picPiece1 = new System.Windows.Forms.PictureBox();
            this.picPiece0 = new System.Windows.Forms.PictureBox();
            this.combo_PieceStyle = new System.Windows.Forms.ComboBox();
            this.txt_FocusPieceBrowser = new NLEditor.FocusTextBox();
            this.pic_DragNewPiece = new System.Windows.Forms.PictureBox();
            this.txt_Focus = new NLEditor.FocusTextBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Level)).BeginInit();
            this.tabLvlProperties.SuspendLayout();
            this.tabGlobalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_TimeSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_TimeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_RR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_Rescue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_Lems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_StartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_StartX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_SizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_SizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_SI)).BeginInit();
            this.tabPieces.SuspendLayout();
            this.gbPieceMetaData.SuspendLayout();
            this.tabSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_AllNonZeroSkillsToN)).BeginInit();
            this.gbRandomSkillset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_RandomMaxLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_RandomMinLimit)).BeginInit();
            this.gbCustomSkillset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Digger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Miner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Basher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Builder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Bomber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Blocker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Floater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Climber)).BeginInit();
            this.tabMisc.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.panelPieceBrowser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DragNewPiece)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1478, 33);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportAsToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.toolStripSeparator1,
            this.playLevelToolStripMenuItem,
            this.validateLevelToolStripMenuItem,
            this.toolStripSeparator9,
            this.cleanseLevelsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(354, 34);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(354, 34);
            this.loadToolStripMenuItem.Text = "Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(354, 34);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+S";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(354, 34);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exportAsToolStripMenuItem
            // 
            this.exportAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsImageToolStripMenuItem,
            this.exportToINIToolStripMenuItem});
            this.exportAsToolStripMenuItem.Name = "exportAsToolStripMenuItem";
            this.exportAsToolStripMenuItem.Size = new System.Drawing.Size(354, 34);
            this.exportAsToolStripMenuItem.Text = "Export As...";
            // 
            // saveAsImageToolStripMenuItem
            // 
            this.saveAsImageToolStripMenuItem.Name = "saveAsImageToolStripMenuItem";
            this.saveAsImageToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Alt+S";
            this.saveAsImageToolStripMenuItem.Size = new System.Drawing.Size(310, 34);
            this.saveAsImageToolStripMenuItem.Text = "Image (.png)";
            this.saveAsImageToolStripMenuItem.Click += new System.EventHandler(this.saveAsImageToolStripMenuItem_Click);
            // 
            // exportToINIToolStripMenuItem
            // 
            this.exportToINIToolStripMenuItem.Name = "exportToINIToolStripMenuItem";
            this.exportToINIToolStripMenuItem.Size = new System.Drawing.Size(310, 34);
            this.exportToINIToolStripMenuItem.Text = "RetroLemmini Level (.ini)";
            this.exportToINIToolStripMenuItem.Click += new System.EventHandler(this.exportToINIToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(354, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(351, 6);
            // 
            // playLevelToolStripMenuItem
            // 
            this.playLevelToolStripMenuItem.Name = "playLevelToolStripMenuItem";
            this.playLevelToolStripMenuItem.ShortcutKeyDisplayString = "F12";
            this.playLevelToolStripMenuItem.Size = new System.Drawing.Size(354, 34);
            this.playLevelToolStripMenuItem.Text = "Play Level";
            this.playLevelToolStripMenuItem.Click += new System.EventHandler(this.playLevelToolStripMenuItem_Click);
            // 
            // validateLevelToolStripMenuItem
            // 
            this.validateLevelToolStripMenuItem.Name = "validateLevelToolStripMenuItem";
            this.validateLevelToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F12";
            this.validateLevelToolStripMenuItem.Size = new System.Drawing.Size(354, 34);
            this.validateLevelToolStripMenuItem.Text = "Validate Level";
            this.validateLevelToolStripMenuItem.Click += new System.EventHandler(this.validateLevelToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(351, 6);
            // 
            // cleanseLevelsToolStripMenuItem
            // 
            this.cleanseLevelsToolStripMenuItem.Name = "cleanseLevelsToolStripMenuItem";
            this.cleanseLevelsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+F12";
            this.cleanseLevelsToolStripMenuItem.Size = new System.Drawing.Size(354, 34);
            this.cleanseLevelsToolStripMenuItem.Text = "Cleanse Levels";
            this.cleanseLevelsToolStripMenuItem.Click += new System.EventHandler(this.cleanseLevelsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.pasteInPlaceToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.groupToolStripMenuItem,
            this.ungroupToolStripMenuItem,
            this.toolStripSeparator3});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(58, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Z";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(334, 34);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Y";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(334, 34);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(334, 34);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(334, 34);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(334, 34);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(334, 34);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // pasteInPlaceToolStripMenuItem
            // 
            this.pasteInPlaceToolStripMenuItem.Name = "pasteInPlaceToolStripMenuItem";
            this.pasteInPlaceToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+V";
            this.pasteInPlaceToolStripMenuItem.Size = new System.Drawing.Size(334, 34);
            this.pasteInPlaceToolStripMenuItem.Text = "Paste-In-Place";
            this.pasteInPlaceToolStripMenuItem.Click += new System.EventHandler(this.pasteInPlaceToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.ShortcutKeyDisplayString = "C";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(334, 34);
            this.duplicateToolStripMenuItem.Text = "Duplicate-In-Place";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.ShortcutKeyDisplayString = "G";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(334, 34);
            this.groupToolStripMenuItem.Text = "Group Pieces";
            this.groupToolStripMenuItem.Click += new System.EventHandler(this.groupToolStripMenuItem_Click);
            // 
            // ungroupToolStripMenuItem
            // 
            this.ungroupToolStripMenuItem.Name = "ungroupToolStripMenuItem";
            this.ungroupToolStripMenuItem.ShortcutKeyDisplayString = "H";
            this.ungroupToolStripMenuItem.Size = new System.Drawing.Size(334, 34);
            this.ungroupToolStripMenuItem.Text = "Ungroup Pieces";
            this.ungroupToolStripMenuItem.Click += new System.EventHandler(this.ungroupToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(331, 6);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLevelWindowToolStripMenuItem,
            this.openPieceBrowserWindowToolStripMenuItem,
            this.expandAllTabsToolStripMenuItem,
            this.toolStripSeparator6,
            this.highlightGroupedPiecesToolStripMenuItem,
            this.highlightEraserPiecesToolStripMenuItem,
            this.toolStripSeparator7,
            this.clearPhysicsToolStripMenuItem,
            this.toolStripSeparator8,
            this.terrainToolStripMenuItem,
            this.objectToolStripMenuItem,
            this.triggerAreasToolStripMenuItem,
            this.screenStartToolStripMenuItem,
            this.backgroundToolStripMenuItem,
            this.deprecatedPiecesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // openLevelWindowToolStripMenuItem
            // 
            this.openLevelWindowToolStripMenuItem.Name = "openLevelWindowToolStripMenuItem";
            this.openLevelWindowToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F9";
            this.openLevelWindowToolStripMenuItem.Size = new System.Drawing.Size(460, 34);
            this.openLevelWindowToolStripMenuItem.Text = "Open Level Arranger Window";
            this.openLevelWindowToolStripMenuItem.Click += new System.EventHandler(this.openLevelWindowToolStripMenuItem_Click);
            // 
            // openPieceBrowserWindowToolStripMenuItem
            // 
            this.openPieceBrowserWindowToolStripMenuItem.Name = "openPieceBrowserWindowToolStripMenuItem";
            this.openPieceBrowserWindowToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+F9";
            this.openPieceBrowserWindowToolStripMenuItem.Size = new System.Drawing.Size(460, 34);
            this.openPieceBrowserWindowToolStripMenuItem.Text = "Open Piece Browser Window";
            this.openPieceBrowserWindowToolStripMenuItem.Click += new System.EventHandler(this.openPieceBrowserWindowToolStripMenuItem_Click);
            // 
            // expandAllTabsToolStripMenuItem
            // 
            this.expandAllTabsToolStripMenuItem.Name = "expandAllTabsToolStripMenuItem";
            this.expandAllTabsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F10";
            this.expandAllTabsToolStripMenuItem.Size = new System.Drawing.Size(460, 34);
            this.expandAllTabsToolStripMenuItem.Text = "Expand All Tabs";
            this.expandAllTabsToolStripMenuItem.Click += new System.EventHandler(this.expandAllTabsToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(457, 6);
            // 
            // highlightGroupedPiecesToolStripMenuItem
            // 
            this.highlightGroupedPiecesToolStripMenuItem.CheckOnClick = true;
            this.highlightGroupedPiecesToolStripMenuItem.Name = "highlightGroupedPiecesToolStripMenuItem";
            this.highlightGroupedPiecesToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+G";
            this.highlightGroupedPiecesToolStripMenuItem.Size = new System.Drawing.Size(460, 34);
            this.highlightGroupedPiecesToolStripMenuItem.Text = "Highlight Grouped Pieces";
            this.highlightGroupedPiecesToolStripMenuItem.Click += new System.EventHandler(this.highlightGroupedPiecesToolStripMenuItem_Click);
            // 
            // highlightEraserPiecesToolStripMenuItem
            // 
            this.highlightEraserPiecesToolStripMenuItem.CheckOnClick = true;
            this.highlightEraserPiecesToolStripMenuItem.Name = "highlightEraserPiecesToolStripMenuItem";
            this.highlightEraserPiecesToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+E";
            this.highlightEraserPiecesToolStripMenuItem.Size = new System.Drawing.Size(460, 34);
            this.highlightEraserPiecesToolStripMenuItem.Text = "Highlight Eraser Pieces";
            this.highlightEraserPiecesToolStripMenuItem.Click += new System.EventHandler(this.highlightEraserPiecesToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(457, 6);
            // 
            // clearPhysicsToolStripMenuItem
            // 
            this.clearPhysicsToolStripMenuItem.CheckOnClick = true;
            this.clearPhysicsToolStripMenuItem.Name = "clearPhysicsToolStripMenuItem";
            this.clearPhysicsToolStripMenuItem.ShortcutKeyDisplayString = "F1";
            this.clearPhysicsToolStripMenuItem.Size = new System.Drawing.Size(460, 34);
            this.clearPhysicsToolStripMenuItem.Text = "Clear Physics Mode";
            this.clearPhysicsToolStripMenuItem.Click += new System.EventHandler(this.clearPhysicsToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(457, 6);
            // 
            // terrainToolStripMenuItem
            // 
            this.terrainToolStripMenuItem.Checked = true;
            this.terrainToolStripMenuItem.CheckOnClick = true;
            this.terrainToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.terrainToolStripMenuItem.Name = "terrainToolStripMenuItem";
            this.terrainToolStripMenuItem.ShortcutKeyDisplayString = "F2";
            this.terrainToolStripMenuItem.Size = new System.Drawing.Size(460, 34);
            this.terrainToolStripMenuItem.Text = "Show/Hide Terrain";
            this.terrainToolStripMenuItem.Click += new System.EventHandler(this.terrainToolStripMenuItem_Click);
            // 
            // objectToolStripMenuItem
            // 
            this.objectToolStripMenuItem.Checked = true;
            this.objectToolStripMenuItem.CheckOnClick = true;
            this.objectToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.objectToolStripMenuItem.Name = "objectToolStripMenuItem";
            this.objectToolStripMenuItem.ShortcutKeyDisplayString = "F3";
            this.objectToolStripMenuItem.Size = new System.Drawing.Size(460, 34);
            this.objectToolStripMenuItem.Text = "Show/Hide Objects";
            this.objectToolStripMenuItem.Click += new System.EventHandler(this.objectToolStripMenuItem_Click);
            // 
            // triggerAreasToolStripMenuItem
            // 
            this.triggerAreasToolStripMenuItem.CheckOnClick = true;
            this.triggerAreasToolStripMenuItem.Name = "triggerAreasToolStripMenuItem";
            this.triggerAreasToolStripMenuItem.ShortcutKeyDisplayString = "F4";
            this.triggerAreasToolStripMenuItem.Size = new System.Drawing.Size(460, 34);
            this.triggerAreasToolStripMenuItem.Text = "Show/Hide Triggers";
            this.triggerAreasToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.triggerAreasToolStripMenuItem.Click += new System.EventHandler(this.triggerAreasToolStripMenuItem_Click);
            // 
            // screenStartToolStripMenuItem
            // 
            this.screenStartToolStripMenuItem.CheckOnClick = true;
            this.screenStartToolStripMenuItem.Name = "screenStartToolStripMenuItem";
            this.screenStartToolStripMenuItem.ShortcutKeyDisplayString = "F5";
            this.screenStartToolStripMenuItem.Size = new System.Drawing.Size(460, 34);
            this.screenStartToolStripMenuItem.Text = "Show/Hide Screen Start";
            this.screenStartToolStripMenuItem.Click += new System.EventHandler(this.screenStartToolStripMenuItem_Click);
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.CheckOnClick = true;
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.ShortcutKeyDisplayString = "F6";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(460, 34);
            this.backgroundToolStripMenuItem.Text = "Show/Hide Background";
            this.backgroundToolStripMenuItem.Click += new System.EventHandler(this.backgroundToolStripMenuItem_Click);
            // 
            // deprecatedPiecesToolStripMenuItem
            // 
            this.deprecatedPiecesToolStripMenuItem.CheckOnClick = true;
            this.deprecatedPiecesToolStripMenuItem.Name = "deprecatedPiecesToolStripMenuItem";
            this.deprecatedPiecesToolStripMenuItem.ShortcutKeyDisplayString = "F7";
            this.deprecatedPiecesToolStripMenuItem.Size = new System.Drawing.Size(460, 34);
            this.deprecatedPiecesToolStripMenuItem.Text = "Show/Hide Deprecated";
            this.deprecatedPiecesToolStripMenuItem.Click += new System.EventHandler(this.deprecatedPiecesToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchPiecesToolStripMenuItem,
            this.snapToGridToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.hotkeysToolStripMenuItem,
            this.toolStripSeparator5,
            this.showMissingPiecesToolStripMenuItem,
            this.refreshStylesToolStripMenuItem,
            this.styleManagerToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem,
            this.toolStripSeparator4});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.optionsToolStripMenuItem.Text = "Tools";
            // 
            // searchPiecesToolStripMenuItem
            // 
            this.searchPiecesToolStripMenuItem.Name = "searchPiecesToolStripMenuItem";
            this.searchPiecesToolStripMenuItem.ShortcutKeyDisplayString = "F8";
            this.searchPiecesToolStripMenuItem.Size = new System.Drawing.Size(410, 34);
            this.searchPiecesToolStripMenuItem.Text = "Search Pieces";
            this.searchPiecesToolStripMenuItem.Click += new System.EventHandler(this.searchPiecesToolStripMenuItem_Click);
            // 
            // snapToGridToolStripMenuItem
            // 
            this.snapToGridToolStripMenuItem.Name = "snapToGridToolStripMenuItem";
            this.snapToGridToolStripMenuItem.ShortcutKeyDisplayString = "F9";
            this.snapToGridToolStripMenuItem.Size = new System.Drawing.Size(410, 34);
            this.snapToGridToolStripMenuItem.Text = "Snap to Grid";
            this.snapToGridToolStripMenuItem.Click += new System.EventHandler(this.snapToGridToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.ShortcutKeyDisplayString = "F10";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(410, 34);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // hotkeysToolStripMenuItem
            // 
            this.hotkeysToolStripMenuItem.Name = "hotkeysToolStripMenuItem";
            this.hotkeysToolStripMenuItem.ShortcutKeyDisplayString = "F11";
            this.hotkeysToolStripMenuItem.Size = new System.Drawing.Size(410, 34);
            this.hotkeysToolStripMenuItem.Text = "Configure Hotkeys";
            this.hotkeysToolStripMenuItem.Click += new System.EventHandler(this.hotkeysToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(407, 6);
            // 
            // showMissingPiecesToolStripMenuItem
            // 
            this.showMissingPiecesToolStripMenuItem.Name = "showMissingPiecesToolStripMenuItem";
            this.showMissingPiecesToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F8";
            this.showMissingPiecesToolStripMenuItem.Size = new System.Drawing.Size(410, 34);
            this.showMissingPiecesToolStripMenuItem.Text = "Show Missing Pieces";
            this.showMissingPiecesToolStripMenuItem.Click += new System.EventHandler(this.showMissingPiecesToolStripMenuItem_Click);
            // 
            // refreshStylesToolStripMenuItem
            // 
            this.refreshStylesToolStripMenuItem.Name = "refreshStylesToolStripMenuItem";
            this.refreshStylesToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+F8";
            this.refreshStylesToolStripMenuItem.Size = new System.Drawing.Size(410, 34);
            this.refreshStylesToolStripMenuItem.Text = "Refresh Styles";
            this.refreshStylesToolStripMenuItem.Click += new System.EventHandler(this.refreshStylesToolStripMenuItem_Click);
            // 
            // styleManagerToolStripMenuItem
            // 
            this.styleManagerToolStripMenuItem.Name = "styleManagerToolStripMenuItem";
            this.styleManagerToolStripMenuItem.Size = new System.Drawing.Size(410, 34);
            this.styleManagerToolStripMenuItem.Text = "Style Manager";
            this.styleManagerToolStripMenuItem.Click += new System.EventHandler(this.styleManagerToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(407, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F11";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(410, 34);
            this.aboutToolStripMenuItem.Text = "About RetroLemmini Editor";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(407, 6);
            // 
            // pic_Level
            // 
            this.pic_Level.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pic_Level.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_Level.Location = new System.Drawing.Point(386, 42);
            this.pic_Level.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pic_Level.Name = "pic_Level";
            this.pic_Level.Size = new System.Drawing.Size(1002, 820);
            this.pic_Level.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_Level.TabIndex = 36;
            this.pic_Level.TabStop = false;
            this.pic_Level.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_Level_MouseDown);
            this.pic_Level.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_Level_MouseMove);
            this.pic_Level.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_Level_MouseUp);
            // 
            // tabLvlProperties
            // 
            this.tabLvlProperties.Controls.Add(this.tabGlobalInfo);
            this.tabLvlProperties.Controls.Add(this.tabPieces);
            this.tabLvlProperties.Controls.Add(this.tabSkills);
            this.tabLvlProperties.Controls.Add(this.tabMisc);
            this.tabLvlProperties.Location = new System.Drawing.Point(9, 42);
            this.tabLvlProperties.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabLvlProperties.Name = "tabLvlProperties";
            this.tabLvlProperties.SelectedIndex = 0;
            this.tabLvlProperties.Size = new System.Drawing.Size(396, 820);
            this.tabLvlProperties.TabIndex = 1;
            this.tabLvlProperties.TabStop = false;
            this.tabLvlProperties.Click += new System.EventHandler(this.tabLvlProperties_Click);
            // 
            // tabGlobalInfo
            // 
            this.tabGlobalInfo.Controls.Add(this.chk_Lvl_AutoStart);
            this.tabGlobalInfo.Controls.Add(this.lbl_Global_Version);
            this.tabGlobalInfo.Controls.Add(this.but_RandomID);
            this.tabGlobalInfo.Controls.Add(this.txt_LevelID);
            this.tabGlobalInfo.Controls.Add(this.lbl_Global_ID);
            this.tabGlobalInfo.Controls.Add(this.lbStartY);
            this.tabGlobalInfo.Controls.Add(this.lbStartX);
            this.tabGlobalInfo.Controls.Add(this.lbSizeH);
            this.tabGlobalInfo.Controls.Add(this.lbSizeW);
            this.tabGlobalInfo.Controls.Add(this.check_Lvl_InfTime);
            this.tabGlobalInfo.Controls.Add(this.combo_Music);
            this.tabGlobalInfo.Controls.Add(this.num_Lvl_TimeSec);
            this.tabGlobalInfo.Controls.Add(this.num_Lvl_TimeMin);
            this.tabGlobalInfo.Controls.Add(this.lbl_Global_TimeLimit);
            this.tabGlobalInfo.Controls.Add(this.num_Lvl_RR);
            this.tabGlobalInfo.Controls.Add(this.lbl_Global_SR);
            this.tabGlobalInfo.Controls.Add(this.num_Lvl_Rescue);
            this.tabGlobalInfo.Controls.Add(this.lbl_Global_Rescue);
            this.tabGlobalInfo.Controls.Add(this.num_Lvl_Lems);
            this.tabGlobalInfo.Controls.Add(this.lbl_Global_Lemmings);
            this.tabGlobalInfo.Controls.Add(this.num_Lvl_StartY);
            this.tabGlobalInfo.Controls.Add(this.num_Lvl_StartX);
            this.tabGlobalInfo.Controls.Add(this.num_Lvl_SizeY);
            this.tabGlobalInfo.Controls.Add(this.num_Lvl_SizeX);
            this.tabGlobalInfo.Controls.Add(this.lbl_Global_Music);
            this.tabGlobalInfo.Controls.Add(this.txt_LevelAuthor);
            this.tabGlobalInfo.Controls.Add(this.lbl_Global_Author);
            this.tabGlobalInfo.Controls.Add(this.txt_LevelTitle);
            this.tabGlobalInfo.Controls.Add(this.lbl_Global_Title);
            this.tabGlobalInfo.Controls.Add(this.num_Lvl_SI);
            this.tabGlobalInfo.Location = new System.Drawing.Point(4, 29);
            this.tabGlobalInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabGlobalInfo.Name = "tabGlobalInfo";
            this.tabGlobalInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabGlobalInfo.Size = new System.Drawing.Size(388, 787);
            this.tabGlobalInfo.TabIndex = 0;
            this.tabGlobalInfo.Text = "Globals";
            this.tabGlobalInfo.UseVisualStyleBackColor = true;
            // 
            // chk_Lvl_AutoStart
            // 
            this.chk_Lvl_AutoStart.AutoSize = true;
            this.chk_Lvl_AutoStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_Lvl_AutoStart.Location = new System.Drawing.Point(111, 234);
            this.chk_Lvl_AutoStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chk_Lvl_AutoStart.Name = "chk_Lvl_AutoStart";
            this.chk_Lvl_AutoStart.Size = new System.Drawing.Size(163, 24);
            this.chk_Lvl_AutoStart.TabIndex = 12;
            this.chk_Lvl_AutoStart.Text = "Auto Screen Start";
            this.chk_Lvl_AutoStart.UseVisualStyleBackColor = true;
            this.chk_Lvl_AutoStart.CheckedChanged += new System.EventHandler(this.chk_Lvl_AutoStart_Leave);
            // 
            // lbl_Global_Version
            // 
            this.lbl_Global_Version.AutoSize = true;
            this.lbl_Global_Version.Location = new System.Drawing.Point(79, 737);
            this.lbl_Global_Version.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Global_Version.Name = "lbl_Global_Version";
            this.lbl_Global_Version.Size = new System.Drawing.Size(215, 20);
            this.lbl_Global_Version.TabIndex = 31;
            this.lbl_Global_Version.Text = "Version: 0000000000000000";
            this.lbl_Global_Version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_RandomID
            // 
            this.but_RandomID.Location = new System.Drawing.Point(68, 686);
            this.but_RandomID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_RandomID.Name = "but_RandomID";
            this.but_RandomID.Size = new System.Drawing.Size(238, 35);
            this.but_RandomID.TabIndex = 30;
            this.but_RandomID.Text = "Random ID";
            this.but_RandomID.UseVisualStyleBackColor = true;
            this.but_RandomID.Click += new System.EventHandler(this.but_RandomID_Click);
            // 
            // txt_LevelID
            // 
            this.txt_LevelID.Location = new System.Drawing.Point(122, 649);
            this.txt_LevelID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_LevelID.MaxLength = 40;
            this.txt_LevelID.Name = "txt_LevelID";
            this.txt_LevelID.Size = new System.Drawing.Size(199, 26);
            this.txt_LevelID.TabIndex = 29;
            this.txt_LevelID.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // lbl_Global_ID
            // 
            this.lbl_Global_ID.Location = new System.Drawing.Point(13, 649);
            this.lbl_Global_ID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Global_ID.Name = "lbl_Global_ID";
            this.lbl_Global_ID.Size = new System.Drawing.Size(101, 23);
            this.lbl_Global_ID.TabIndex = 28;
            this.lbl_Global_ID.Text = "Level ID";
            this.lbl_Global_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbStartY
            // 
            this.lbStartY.AutoSize = true;
            this.lbStartY.Location = new System.Drawing.Point(274, 268);
            this.lbStartY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStartY.Name = "lbStartY";
            this.lbStartY.Size = new System.Drawing.Size(59, 20);
            this.lbStartY.TabIndex = 16;
            this.lbStartY.Text = "Start Y";
            this.lbStartY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbStartX
            // 
            this.lbStartX.AutoSize = true;
            this.lbStartX.Location = new System.Drawing.Point(55, 268);
            this.lbStartX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStartX.Name = "lbStartX";
            this.lbStartX.Size = new System.Drawing.Size(59, 20);
            this.lbStartX.TabIndex = 13;
            this.lbStartX.Text = "Start X";
            this.lbStartX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSizeH
            // 
            this.lbSizeH.AutoSize = true;
            this.lbSizeH.Location = new System.Drawing.Point(274, 191);
            this.lbSizeH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSizeH.Name = "lbSizeH";
            this.lbSizeH.Size = new System.Drawing.Size(56, 20);
            this.lbSizeH.TabIndex = 11;
            this.lbSizeH.Text = "Height";
            this.lbSizeH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSizeW
            // 
            this.lbSizeW.AutoSize = true;
            this.lbSizeW.Location = new System.Drawing.Point(64, 192);
            this.lbSizeW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSizeW.Name = "lbSizeW";
            this.lbSizeW.Size = new System.Drawing.Size(50, 20);
            this.lbSizeW.TabIndex = 8;
            this.lbSizeW.Text = "Width";
            this.lbSizeW.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // check_Lvl_InfTime
            // 
            this.check_Lvl_InfTime.AutoSize = true;
            this.check_Lvl_InfTime.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.check_Lvl_InfTime.Checked = true;
            this.check_Lvl_InfTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Lvl_InfTime.Location = new System.Drawing.Point(130, 545);
            this.check_Lvl_InfTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.check_Lvl_InfTime.Name = "check_Lvl_InfTime";
            this.check_Lvl_InfTime.Size = new System.Drawing.Size(121, 24);
            this.check_Lvl_InfTime.TabIndex = 24;
            this.check_Lvl_InfTime.Text = "Infinite Time";
            this.check_Lvl_InfTime.UseVisualStyleBackColor = true;
            this.check_Lvl_InfTime.CheckedChanged += new System.EventHandler(this.textbox_Leave);
            // 
            // combo_Music
            // 
            this.combo_Music.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Music.FormattingEnabled = true;
            this.combo_Music.Location = new System.Drawing.Point(68, 88);
            this.combo_Music.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.combo_Music.Name = "combo_Music";
            this.combo_Music.Size = new System.Drawing.Size(302, 28);
            this.combo_Music.TabIndex = 5;
            this.combo_Music.DropDownClosed += new System.EventHandler(this.ComboDropDownClosed);
            this.combo_Music.Leave += new System.EventHandler(this.textbox_Leave);
            this.combo_Music.MouseEnter += new System.EventHandler(this.ComboMouseEnter);
            this.combo_Music.MouseLeave += new System.EventHandler(this.ComboMouseLeave);
            // 
            // num_Lvl_TimeSec
            // 
            this.num_Lvl_TimeSec.Location = new System.Drawing.Point(226, 575);
            this.num_Lvl_TimeSec.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Lvl_TimeSec.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.num_Lvl_TimeSec.Name = "num_Lvl_TimeSec";
            this.num_Lvl_TimeSec.Size = new System.Drawing.Size(70, 26);
            this.num_Lvl_TimeSec.TabIndex = 27;
            this.num_Lvl_TimeSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Lvl_TimeSec.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // num_Lvl_TimeMin
            // 
            this.num_Lvl_TimeMin.Location = new System.Drawing.Point(148, 575);
            this.num_Lvl_TimeMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Lvl_TimeMin.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.num_Lvl_TimeMin.Name = "num_Lvl_TimeMin";
            this.num_Lvl_TimeMin.Size = new System.Drawing.Size(70, 26);
            this.num_Lvl_TimeMin.TabIndex = 26;
            this.num_Lvl_TimeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Lvl_TimeMin.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // lbl_Global_TimeLimit
            // 
            this.lbl_Global_TimeLimit.Location = new System.Drawing.Point(37, 576);
            this.lbl_Global_TimeLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Global_TimeLimit.Name = "lbl_Global_TimeLimit";
            this.lbl_Global_TimeLimit.Size = new System.Drawing.Size(103, 23);
            this.lbl_Global_TimeLimit.TabIndex = 25;
            this.lbl_Global_TimeLimit.Text = "Time Limit";
            this.lbl_Global_TimeLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_Lvl_RR
            // 
            this.num_Lvl_RR.Location = new System.Drawing.Point(213, 483);
            this.num_Lvl_RR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Lvl_RR.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.num_Lvl_RR.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Lvl_RR.Name = "num_Lvl_RR";
            this.num_Lvl_RR.Size = new System.Drawing.Size(70, 26);
            this.num_Lvl_RR.TabIndex = 24;
            this.num_Lvl_RR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Lvl_RR.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.num_Lvl_RR.ValueChanged += new System.EventHandler(this.HandleSpawnIntervalNumerics);
            this.num_Lvl_RR.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // lbl_Global_SR
            // 
            this.lbl_Global_SR.Location = new System.Drawing.Point(68, 482);
            this.lbl_Global_SR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Global_SR.Name = "lbl_Global_SR";
            this.lbl_Global_SR.Size = new System.Drawing.Size(138, 26);
            this.lbl_Global_SR.TabIndex = 23;
            this.lbl_Global_SR.Text = "Release Rate";
            this.lbl_Global_SR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_Lvl_Rescue
            // 
            this.num_Lvl_Rescue.Location = new System.Drawing.Point(235, 395);
            this.num_Lvl_Rescue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Lvl_Rescue.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.num_Lvl_Rescue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Lvl_Rescue.Name = "num_Lvl_Rescue";
            this.num_Lvl_Rescue.Size = new System.Drawing.Size(70, 26);
            this.num_Lvl_Rescue.TabIndex = 21;
            this.num_Lvl_Rescue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Lvl_Rescue.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.num_Lvl_Rescue.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // lbl_Global_Rescue
            // 
            this.lbl_Global_Rescue.Location = new System.Drawing.Point(66, 393);
            this.lbl_Global_Rescue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Global_Rescue.Name = "lbl_Global_Rescue";
            this.lbl_Global_Rescue.Size = new System.Drawing.Size(162, 28);
            this.lbl_Global_Rescue.TabIndex = 20;
            this.lbl_Global_Rescue.Text = "Save Requirement";
            this.lbl_Global_Rescue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_Lvl_Lems
            // 
            this.num_Lvl_Lems.Location = new System.Drawing.Point(235, 360);
            this.num_Lvl_Lems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Lvl_Lems.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.num_Lvl_Lems.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Lvl_Lems.Name = "num_Lvl_Lems";
            this.num_Lvl_Lems.Size = new System.Drawing.Size(70, 26);
            this.num_Lvl_Lems.TabIndex = 18;
            this.num_Lvl_Lems.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Lvl_Lems.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.num_Lvl_Lems.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // lbl_Global_Lemmings
            // 
            this.lbl_Global_Lemmings.Location = new System.Drawing.Point(70, 358);
            this.lbl_Global_Lemmings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Global_Lemmings.Name = "lbl_Global_Lemmings";
            this.lbl_Global_Lemmings.Size = new System.Drawing.Size(158, 29);
            this.lbl_Global_Lemmings.TabIndex = 17;
            this.lbl_Global_Lemmings.Text = "Total Lemmings";
            this.lbl_Global_Lemmings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_Lvl_StartY
            // 
            this.num_Lvl_StartY.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.num_Lvl_StartY.Location = new System.Drawing.Point(196, 265);
            this.num_Lvl_StartY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Lvl_StartY.Maximum = new decimal(new int[] {
            159,
            0,
            0,
            0});
            this.num_Lvl_StartY.Name = "num_Lvl_StartY";
            this.num_Lvl_StartY.Size = new System.Drawing.Size(70, 26);
            this.num_Lvl_StartY.TabIndex = 15;
            this.num_Lvl_StartY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Lvl_StartY.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.num_Lvl_StartY.ValueChanged += new System.EventHandler(this.num_Lvl_StartY_ValueChanged);
            this.num_Lvl_StartY.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // num_Lvl_StartX
            // 
            this.num_Lvl_StartX.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.num_Lvl_StartX.Location = new System.Drawing.Point(122, 265);
            this.num_Lvl_StartX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Lvl_StartX.Maximum = new decimal(new int[] {
            319,
            0,
            0,
            0});
            this.num_Lvl_StartX.Name = "num_Lvl_StartX";
            this.num_Lvl_StartX.Size = new System.Drawing.Size(70, 26);
            this.num_Lvl_StartX.TabIndex = 14;
            this.num_Lvl_StartX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Lvl_StartX.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.num_Lvl_StartX.ValueChanged += new System.EventHandler(this.num_Lvl_StartX_ValueChanged);
            this.num_Lvl_StartX.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // num_Lvl_SizeY
            // 
            this.num_Lvl_SizeY.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.num_Lvl_SizeY.Location = new System.Drawing.Point(196, 189);
            this.num_Lvl_SizeY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Lvl_SizeY.Maximum = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            this.num_Lvl_SizeY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Lvl_SizeY.Name = "num_Lvl_SizeY";
            this.num_Lvl_SizeY.Size = new System.Drawing.Size(70, 26);
            this.num_Lvl_SizeY.TabIndex = 10;
            this.num_Lvl_SizeY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Lvl_SizeY.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.num_Lvl_SizeY.ValueChanged += new System.EventHandler(this.num_Lvl_SizeY_ValueChanged);
            this.num_Lvl_SizeY.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // num_Lvl_SizeX
            // 
            this.num_Lvl_SizeX.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.num_Lvl_SizeX.Location = new System.Drawing.Point(122, 189);
            this.num_Lvl_SizeX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Lvl_SizeX.Maximum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.num_Lvl_SizeX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Lvl_SizeX.Name = "num_Lvl_SizeX";
            this.num_Lvl_SizeX.Size = new System.Drawing.Size(70, 26);
            this.num_Lvl_SizeX.TabIndex = 9;
            this.num_Lvl_SizeX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Lvl_SizeX.Value = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.num_Lvl_SizeX.ValueChanged += new System.EventHandler(this.num_Lvl_SizeX_ValueChanged);
            this.num_Lvl_SizeX.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // lbl_Global_Music
            // 
            this.lbl_Global_Music.Location = new System.Drawing.Point(9, 90);
            this.lbl_Global_Music.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Global_Music.Name = "lbl_Global_Music";
            this.lbl_Global_Music.Size = new System.Drawing.Size(69, 23);
            this.lbl_Global_Music.TabIndex = 4;
            this.lbl_Global_Music.Text = "Music";
            this.lbl_Global_Music.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_LevelAuthor
            // 
            this.txt_LevelAuthor.Location = new System.Drawing.Point(67, 51);
            this.txt_LevelAuthor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_LevelAuthor.MaxLength = 54;
            this.txt_LevelAuthor.Name = "txt_LevelAuthor";
            this.txt_LevelAuthor.Size = new System.Drawing.Size(302, 26);
            this.txt_LevelAuthor.TabIndex = 3;
            this.txt_LevelAuthor.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // lbl_Global_Author
            // 
            this.lbl_Global_Author.Location = new System.Drawing.Point(9, 53);
            this.lbl_Global_Author.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Global_Author.Name = "lbl_Global_Author";
            this.lbl_Global_Author.Size = new System.Drawing.Size(66, 23);
            this.lbl_Global_Author.TabIndex = 2;
            this.lbl_Global_Author.Text = "Author";
            this.lbl_Global_Author.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_LevelTitle
            // 
            this.txt_LevelTitle.Location = new System.Drawing.Point(67, 11);
            this.txt_LevelTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_LevelTitle.MaxLength = 54;
            this.txt_LevelTitle.Name = "txt_LevelTitle";
            this.txt_LevelTitle.Size = new System.Drawing.Size(302, 26);
            this.txt_LevelTitle.TabIndex = 1;
            this.txt_LevelTitle.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // lbl_Global_Title
            // 
            this.lbl_Global_Title.Location = new System.Drawing.Point(9, 13);
            this.lbl_Global_Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Global_Title.Name = "lbl_Global_Title";
            this.lbl_Global_Title.Size = new System.Drawing.Size(69, 23);
            this.lbl_Global_Title.TabIndex = 0;
            this.lbl_Global_Title.Text = "Title";
            this.lbl_Global_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // num_Lvl_SI
            // 
            this.num_Lvl_SI.Location = new System.Drawing.Point(212, 483);
            this.num_Lvl_SI.Maximum = new decimal(new int[] {
            102,
            0,
            0,
            0});
            this.num_Lvl_SI.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.num_Lvl_SI.Name = "num_Lvl_SI";
            this.num_Lvl_SI.Size = new System.Drawing.Size(70, 26);
            this.num_Lvl_SI.TabIndex = 32;
            this.num_Lvl_SI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Lvl_SI.Value = new decimal(new int[] {
            53,
            0,
            0,
            0});
            this.num_Lvl_SI.ValueChanged += new System.EventHandler(this.HandleSpawnIntervalNumerics);
            // 
            // tabPieces
            // 
            this.tabPieces.Controls.Add(this.gbPieceMetaData);
            this.tabPieces.Controls.Add(this.but_UngroupSelection);
            this.tabPieces.Controls.Add(this.but_GroupSelection);
            this.tabPieces.Controls.Add(this.check_Pieces_OneWay);
            this.tabPieces.Controls.Add(this.check_Pieces_OnlyOnTerrain);
            this.tabPieces.Controls.Add(this.check_Pieces_NoOv);
            this.tabPieces.Controls.Add(this.check_Pieces_Erase);
            this.tabPieces.Controls.Add(this.but_MoveBackOne);
            this.tabPieces.Controls.Add(this.but_MoveFrontOne);
            this.tabPieces.Controls.Add(this.but_MoveBack);
            this.tabPieces.Controls.Add(this.but_MoveFront);
            this.tabPieces.Controls.Add(this.but_FlipPieces);
            this.tabPieces.Controls.Add(this.but_InvertPieces);
            this.tabPieces.Controls.Add(this.but_RotatePieces);
            this.tabPieces.Location = new System.Drawing.Point(4, 29);
            this.tabPieces.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPieces.Name = "tabPieces";
            this.tabPieces.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPieces.Size = new System.Drawing.Size(388, 787);
            this.tabPieces.TabIndex = 1;
            this.tabPieces.Text = "Pieces";
            this.tabPieces.UseVisualStyleBackColor = true;
            // 
            // gbPieceMetaData
            // 
            this.gbPieceMetaData.Controls.Add(this.lblPieceSize);
            this.gbPieceMetaData.Controls.Add(this.lblSize);
            this.gbPieceMetaData.Controls.Add(this.but_LoadStyle);
            this.gbPieceMetaData.Controls.Add(this.lblName);
            this.gbPieceMetaData.Controls.Add(this.lblPieceType);
            this.gbPieceMetaData.Controls.Add(this.lblStyle);
            this.gbPieceMetaData.Controls.Add(this.lblPieceStyle);
            this.gbPieceMetaData.Controls.Add(this.lblType);
            this.gbPieceMetaData.Controls.Add(this.lblPieceName);
            this.gbPieceMetaData.Location = new System.Drawing.Point(8, 338);
            this.gbPieceMetaData.Name = "gbPieceMetaData";
            this.gbPieceMetaData.Size = new System.Drawing.Size(373, 186);
            this.gbPieceMetaData.TabIndex = 58;
            this.gbPieceMetaData.TabStop = false;
            this.gbPieceMetaData.Text = " Piece Data";
            // 
            // lblPieceSize
            // 
            this.lblPieceSize.AutoSize = true;
            this.lblPieceSize.Location = new System.Drawing.Point(75, 86);
            this.lblPieceSize.Name = "lblPieceSize";
            this.lblPieceSize.Size = new System.Drawing.Size(84, 20);
            this.lblPieceSize.TabIndex = 8;
            this.lblPieceSize.Text = "piece_size";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(12, 86);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(49, 20);
            this.lblSize.TabIndex = 7;
            this.lblSize.Text = "Size:";
            // 
            // but_LoadStyle
            // 
            this.but_LoadStyle.Location = new System.Drawing.Point(13, 128);
            this.but_LoadStyle.Name = "but_LoadStyle";
            this.but_LoadStyle.Size = new System.Drawing.Size(346, 45);
            this.but_LoadStyle.TabIndex = 6;
            this.but_LoadStyle.Text = "Load Style";
            this.but_LoadStyle.UseVisualStyleBackColor = true;
            this.but_LoadStyle.Visible = false;
            this.but_LoadStyle.Click += new System.EventHandler(this.but_LoadStyle_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 26);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // lblPieceType
            // 
            this.lblPieceType.AutoSize = true;
            this.lblPieceType.Location = new System.Drawing.Point(75, 66);
            this.lblPieceType.Name = "lblPieceType";
            this.lblPieceType.Size = new System.Drawing.Size(86, 20);
            this.lblPieceType.TabIndex = 5;
            this.lblPieceType.Text = "piece_type";
            // 
            // lblStyle
            // 
            this.lblStyle.AutoSize = true;
            this.lblStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStyle.Location = new System.Drawing.Point(12, 46);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(54, 20);
            this.lblStyle.TabIndex = 1;
            this.lblStyle.Text = "Style:";
            // 
            // lblPieceStyle
            // 
            this.lblPieceStyle.AutoSize = true;
            this.lblPieceStyle.Location = new System.Drawing.Point(75, 46);
            this.lblPieceStyle.Name = "lblPieceStyle";
            this.lblPieceStyle.Size = new System.Drawing.Size(88, 20);
            this.lblPieceStyle.TabIndex = 4;
            this.lblPieceStyle.Text = "piece_style";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(12, 66);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(52, 20);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type:";
            // 
            // lblPieceName
            // 
            this.lblPieceName.AutoSize = true;
            this.lblPieceName.Location = new System.Drawing.Point(75, 26);
            this.lblPieceName.Name = "lblPieceName";
            this.lblPieceName.Size = new System.Drawing.Size(96, 20);
            this.lblPieceName.TabIndex = 3;
            this.lblPieceName.Text = "piece_name";
            // 
            // but_UngroupSelection
            // 
            this.but_UngroupSelection.Location = new System.Drawing.Point(183, 136);
            this.but_UngroupSelection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_UngroupSelection.Name = "but_UngroupSelection";
            this.but_UngroupSelection.Size = new System.Drawing.Size(189, 47);
            this.but_UngroupSelection.TabIndex = 8;
            this.but_UngroupSelection.Text = "Ungroup";
            this.but_UngroupSelection.UseVisualStyleBackColor = true;
            this.but_UngroupSelection.Click += new System.EventHandler(this.but_UngroupSelection_Click);
            // 
            // but_GroupSelection
            // 
            this.but_GroupSelection.Location = new System.Drawing.Point(13, 136);
            this.but_GroupSelection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_GroupSelection.Name = "but_GroupSelection";
            this.but_GroupSelection.Size = new System.Drawing.Size(166, 47);
            this.but_GroupSelection.TabIndex = 7;
            this.but_GroupSelection.Text = "Group";
            this.but_GroupSelection.UseVisualStyleBackColor = true;
            this.but_GroupSelection.Click += new System.EventHandler(this.but_GroupSelection_Click);
            // 
            // check_Pieces_OneWay
            // 
            this.check_Pieces_OneWay.Location = new System.Drawing.Point(21, 272);
            this.check_Pieces_OneWay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.check_Pieces_OneWay.Name = "check_Pieces_OneWay";
            this.check_Pieces_OneWay.Size = new System.Drawing.Size(154, 26);
            this.check_Pieces_OneWay.TabIndex = 12;
            this.check_Pieces_OneWay.Text = "Allow One-Way";
            this.check_Pieces_OneWay.UseVisualStyleBackColor = true;
            this.check_Pieces_OneWay.CheckedChanged += new System.EventHandler(this.check_Pieces_OneWay_CheckedChanged);
            // 
            // check_Pieces_OnlyOnTerrain
            // 
            this.check_Pieces_OnlyOnTerrain.Location = new System.Drawing.Point(21, 246);
            this.check_Pieces_OnlyOnTerrain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.check_Pieces_OnlyOnTerrain.Name = "check_Pieces_OnlyOnTerrain";
            this.check_Pieces_OnlyOnTerrain.Size = new System.Drawing.Size(154, 26);
            this.check_Pieces_OnlyOnTerrain.TabIndex = 11;
            this.check_Pieces_OnlyOnTerrain.Text = "Only On Terrain";
            this.check_Pieces_OnlyOnTerrain.UseVisualStyleBackColor = true;
            this.check_Pieces_OnlyOnTerrain.CheckedChanged += new System.EventHandler(this.check_Pieces_OnlyOnTerrain_CheckedChanged);
            // 
            // check_Pieces_NoOv
            // 
            this.check_Pieces_NoOv.Location = new System.Drawing.Point(21, 220);
            this.check_Pieces_NoOv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.check_Pieces_NoOv.Name = "check_Pieces_NoOv";
            this.check_Pieces_NoOv.Size = new System.Drawing.Size(154, 26);
            this.check_Pieces_NoOv.TabIndex = 10;
            this.check_Pieces_NoOv.Text = "No Overwrite";
            this.check_Pieces_NoOv.UseVisualStyleBackColor = true;
            this.check_Pieces_NoOv.CheckedChanged += new System.EventHandler(this.check_Pieces_NoOv_CheckedChanged);
            // 
            // check_Pieces_Erase
            // 
            this.check_Pieces_Erase.Location = new System.Drawing.Point(21, 193);
            this.check_Pieces_Erase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.check_Pieces_Erase.Name = "check_Pieces_Erase";
            this.check_Pieces_Erase.Size = new System.Drawing.Size(154, 26);
            this.check_Pieces_Erase.TabIndex = 9;
            this.check_Pieces_Erase.Text = "Erase Terrain";
            this.check_Pieces_Erase.UseVisualStyleBackColor = true;
            this.check_Pieces_Erase.CheckedChanged += new System.EventHandler(this.check_Pieces_Erase_CheckedChanged);
            // 
            // but_MoveBackOne
            // 
            this.but_MoveBackOne.Location = new System.Drawing.Point(183, 73);
            this.but_MoveBackOne.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_MoveBackOne.Name = "but_MoveBackOne";
            this.but_MoveBackOne.NoPaddingText = "Draw Sooner";
            this.but_MoveBackOne.Size = new System.Drawing.Size(100, 53);
            this.but_MoveBackOne.TabIndex = 5;
            this.but_MoveBackOne.UseVisualStyleBackColor = true;
            this.but_MoveBackOne.Click += new System.EventHandler(this.but_MoveBackOne_Click);
            this.but_MoveBackOne.MouseUp += new System.Windows.Forms.MouseEventHandler(this.but_MoveBackOne_MouseUp);
            // 
            // but_MoveFrontOne
            // 
            this.but_MoveFrontOne.Location = new System.Drawing.Point(95, 73);
            this.but_MoveFrontOne.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_MoveFrontOne.Name = "but_MoveFrontOne";
            this.but_MoveFrontOne.NoPaddingText = "Draw Later";
            this.but_MoveFrontOne.Size = new System.Drawing.Size(84, 53);
            this.but_MoveFrontOne.TabIndex = 4;
            this.but_MoveFrontOne.UseVisualStyleBackColor = true;
            this.but_MoveFrontOne.Click += new System.EventHandler(this.but_MoveFrontOne_Click);
            this.but_MoveFrontOne.MouseUp += new System.Windows.Forms.MouseEventHandler(this.but_MoveFrontOne_MouseUp);
            // 
            // but_MoveBack
            // 
            this.but_MoveBack.Location = new System.Drawing.Point(293, 73);
            this.but_MoveBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_MoveBack.Name = "but_MoveBack";
            this.but_MoveBack.NoPaddingText = "Draw First";
            this.but_MoveBack.Size = new System.Drawing.Size(80, 53);
            this.but_MoveBack.TabIndex = 6;
            this.but_MoveBack.UseVisualStyleBackColor = true;
            this.but_MoveBack.Click += new System.EventHandler(this.but_MoveBack_Click);
            // 
            // but_MoveFront
            // 
            this.but_MoveFront.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_MoveFront.Location = new System.Drawing.Point(13, 73);
            this.but_MoveFront.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_MoveFront.Name = "but_MoveFront";
            this.but_MoveFront.NoPaddingText = "Draw Last";
            this.but_MoveFront.Size = new System.Drawing.Size(74, 53);
            this.but_MoveFront.TabIndex = 3;
            this.but_MoveFront.UseVisualStyleBackColor = true;
            this.but_MoveFront.Click += new System.EventHandler(this.but_MoveFront_Click);
            // 
            // but_FlipPieces
            // 
            this.but_FlipPieces.Location = new System.Drawing.Point(255, 13);
            this.but_FlipPieces.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_FlipPieces.Name = "but_FlipPieces";
            this.but_FlipPieces.NoPaddingText = null;
            this.but_FlipPieces.Size = new System.Drawing.Size(117, 50);
            this.but_FlipPieces.TabIndex = 2;
            this.but_FlipPieces.Text = "Flip";
            this.but_FlipPieces.UseVisualStyleBackColor = true;
            this.but_FlipPieces.Click += new System.EventHandler(this.but_FlipPieces_Click);
            this.but_FlipPieces.MouseUp += new System.Windows.Forms.MouseEventHandler(this.but_FlipPieces_MouseUp);
            // 
            // but_InvertPieces
            // 
            this.but_InvertPieces.Location = new System.Drawing.Point(128, 13);
            this.but_InvertPieces.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_InvertPieces.Name = "but_InvertPieces";
            this.but_InvertPieces.NoPaddingText = null;
            this.but_InvertPieces.Size = new System.Drawing.Size(120, 50);
            this.but_InvertPieces.TabIndex = 1;
            this.but_InvertPieces.Text = "Invert";
            this.but_InvertPieces.UseVisualStyleBackColor = true;
            this.but_InvertPieces.Click += new System.EventHandler(this.but_InvertPieces_Click);
            this.but_InvertPieces.MouseUp += new System.Windows.Forms.MouseEventHandler(this.but_InvertPieces_MouseUp);
            // 
            // but_RotatePieces
            // 
            this.but_RotatePieces.Location = new System.Drawing.Point(11, 13);
            this.but_RotatePieces.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_RotatePieces.Name = "but_RotatePieces";
            this.but_RotatePieces.NoPaddingText = null;
            this.but_RotatePieces.Size = new System.Drawing.Size(110, 50);
            this.but_RotatePieces.TabIndex = 0;
            this.but_RotatePieces.Text = "Rotate";
            this.but_RotatePieces.UseVisualStyleBackColor = true;
            this.but_RotatePieces.Click += new System.EventHandler(this.but_RotatePieces_Click);
            this.but_RotatePieces.MouseUp += new System.Windows.Forms.MouseEventHandler(this.but_RotatePieces_MouseUp);
            // 
            // tabSkills
            // 
            this.tabSkills.Controls.Add(this.num_AllNonZeroSkillsToN);
            this.tabSkills.Controls.Add(this.btnAllNonZeroSkillsToN);
            this.tabSkills.Controls.Add(this.lbl_Skill_Digger);
            this.tabSkills.Controls.Add(this.lbl_Skill_Miner);
            this.tabSkills.Controls.Add(this.lbl_Skill_Basher);
            this.tabSkills.Controls.Add(this.lbl_Skill_Builder);
            this.tabSkills.Controls.Add(this.lbl_Skill_Bomber);
            this.tabSkills.Controls.Add(this.lbl_Skill_Blocker);
            this.tabSkills.Controls.Add(this.lbl_Skill_Floater);
            this.tabSkills.Controls.Add(this.lbl_Skill_Climber);
            this.tabSkills.Controls.Add(this.gbRandomSkillset);
            this.tabSkills.Controls.Add(this.gbCustomSkillset);
            this.tabSkills.Controls.Add(this.num_Ski_Digger);
            this.tabSkills.Controls.Add(this.num_Ski_Miner);
            this.tabSkills.Controls.Add(this.num_Ski_Basher);
            this.tabSkills.Controls.Add(this.num_Ski_Builder);
            this.tabSkills.Controls.Add(this.num_Ski_Bomber);
            this.tabSkills.Controls.Add(this.num_Ski_Blocker);
            this.tabSkills.Controls.Add(this.num_Ski_Floater);
            this.tabSkills.Controls.Add(this.num_Ski_Climber);
            this.tabSkills.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabSkills.Location = new System.Drawing.Point(4, 29);
            this.tabSkills.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabSkills.Name = "tabSkills";
            this.tabSkills.Size = new System.Drawing.Size(388, 787);
            this.tabSkills.TabIndex = 2;
            this.tabSkills.Text = "Skills";
            this.tabSkills.UseVisualStyleBackColor = true;
            // 
            // num_AllNonZeroSkillsToN
            // 
            this.num_AllNonZeroSkillsToN.Location = new System.Drawing.Point(274, 693);
            this.num_AllNonZeroSkillsToN.Name = "num_AllNonZeroSkillsToN";
            this.num_AllNonZeroSkillsToN.Size = new System.Drawing.Size(64, 26);
            this.num_AllNonZeroSkillsToN.TabIndex = 53;
            this.num_AllNonZeroSkillsToN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAllNonZeroSkillsToN
            // 
            this.btnAllNonZeroSkillsToN.Location = new System.Drawing.Point(55, 692);
            this.btnAllNonZeroSkillsToN.Name = "btnAllNonZeroSkillsToN";
            this.btnAllNonZeroSkillsToN.Size = new System.Drawing.Size(212, 34);
            this.btnAllNonZeroSkillsToN.TabIndex = 42;
            this.btnAllNonZeroSkillsToN.Text = "Set All Non-Zero Skills To";
            this.btnAllNonZeroSkillsToN.UseVisualStyleBackColor = true;
            this.btnAllNonZeroSkillsToN.Click += new System.EventHandler(this.btnAllNonZeroSkillsToN_Click);
            this.btnAllNonZeroSkillsToN.MouseLeave += new System.EventHandler(this.textbox_Leave);
            // 
            // lbl_Skill_Digger
            // 
            this.lbl_Skill_Digger.Location = new System.Drawing.Point(24, 295);
            this.lbl_Skill_Digger.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Skill_Digger.Name = "lbl_Skill_Digger";
            this.lbl_Skill_Digger.Size = new System.Drawing.Size(88, 26);
            this.lbl_Skill_Digger.TabIndex = 7;
            this.lbl_Skill_Digger.Text = "Digger";
            // 
            // lbl_Skill_Miner
            // 
            this.lbl_Skill_Miner.Location = new System.Drawing.Point(24, 259);
            this.lbl_Skill_Miner.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Skill_Miner.Name = "lbl_Skill_Miner";
            this.lbl_Skill_Miner.Size = new System.Drawing.Size(88, 26);
            this.lbl_Skill_Miner.TabIndex = 6;
            this.lbl_Skill_Miner.Text = "Miner";
            // 
            // lbl_Skill_Basher
            // 
            this.lbl_Skill_Basher.Location = new System.Drawing.Point(24, 212);
            this.lbl_Skill_Basher.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Skill_Basher.Name = "lbl_Skill_Basher";
            this.lbl_Skill_Basher.Size = new System.Drawing.Size(88, 26);
            this.lbl_Skill_Basher.TabIndex = 5;
            this.lbl_Skill_Basher.Text = "Basher";
            // 
            // lbl_Skill_Builder
            // 
            this.lbl_Skill_Builder.Location = new System.Drawing.Point(24, 167);
            this.lbl_Skill_Builder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Skill_Builder.Name = "lbl_Skill_Builder";
            this.lbl_Skill_Builder.Size = new System.Drawing.Size(88, 26);
            this.lbl_Skill_Builder.TabIndex = 4;
            this.lbl_Skill_Builder.Text = "Builder";
            // 
            // lbl_Skill_Bomber
            // 
            this.lbl_Skill_Bomber.Location = new System.Drawing.Point(16, 95);
            this.lbl_Skill_Bomber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Skill_Bomber.Name = "lbl_Skill_Bomber";
            this.lbl_Skill_Bomber.Size = new System.Drawing.Size(98, 26);
            this.lbl_Skill_Bomber.TabIndex = 3;
            this.lbl_Skill_Bomber.Text = "Bomber";
            // 
            // lbl_Skill_Blocker
            // 
            this.lbl_Skill_Blocker.Location = new System.Drawing.Point(16, 128);
            this.lbl_Skill_Blocker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Skill_Blocker.Name = "lbl_Skill_Blocker";
            this.lbl_Skill_Blocker.Size = new System.Drawing.Size(88, 26);
            this.lbl_Skill_Blocker.TabIndex = 2;
            this.lbl_Skill_Blocker.Text = "Blocker";
            // 
            // lbl_Skill_Floater
            // 
            this.lbl_Skill_Floater.Location = new System.Drawing.Point(16, 59);
            this.lbl_Skill_Floater.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Skill_Floater.Name = "lbl_Skill_Floater";
            this.lbl_Skill_Floater.Size = new System.Drawing.Size(98, 26);
            this.lbl_Skill_Floater.TabIndex = 1;
            this.lbl_Skill_Floater.Text = "Floater";
            // 
            // lbl_Skill_Climber
            // 
            this.lbl_Skill_Climber.Location = new System.Drawing.Point(16, 22);
            this.lbl_Skill_Climber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Skill_Climber.Name = "lbl_Skill_Climber";
            this.lbl_Skill_Climber.Size = new System.Drawing.Size(98, 26);
            this.lbl_Skill_Climber.TabIndex = 0;
            this.lbl_Skill_Climber.Text = "Climber";
            // 
            // gbRandomSkillset
            // 
            this.gbRandomSkillset.Controls.Add(this.btnRandomSkillset);
            this.gbRandomSkillset.Controls.Add(this.num_RandomMaxLimit);
            this.gbRandomSkillset.Controls.Add(this.lblRandomMinLimit);
            this.gbRandomSkillset.Controls.Add(this.num_RandomMinLimit);
            this.gbRandomSkillset.Controls.Add(this.lblRandomMaxLimit);
            this.gbRandomSkillset.Location = new System.Drawing.Point(55, 553);
            this.gbRandomSkillset.Name = "gbRandomSkillset";
            this.gbRandomSkillset.Size = new System.Drawing.Size(283, 107);
            this.gbRandomSkillset.TabIndex = 50;
            this.gbRandomSkillset.TabStop = false;
            // 
            // btnRandomSkillset
            // 
            this.btnRandomSkillset.Location = new System.Drawing.Point(23, 23);
            this.btnRandomSkillset.Name = "btnRandomSkillset";
            this.btnRandomSkillset.Size = new System.Drawing.Size(238, 34);
            this.btnRandomSkillset.TabIndex = 47;
            this.btnRandomSkillset.Text = "Random Skillset";
            this.btnRandomSkillset.UseVisualStyleBackColor = true;
            // 
            // num_RandomMaxLimit
            // 
            this.num_RandomMaxLimit.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.num_RandomMaxLimit.Location = new System.Drawing.Point(197, 65);
            this.num_RandomMaxLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_RandomMaxLimit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_RandomMaxLimit.Name = "num_RandomMaxLimit";
            this.num_RandomMaxLimit.Size = new System.Drawing.Size(64, 26);
            this.num_RandomMaxLimit.TabIndex = 46;
            this.num_RandomMaxLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_RandomMaxLimit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_RandomMaxLimit.ValueChanged += new System.EventHandler(this.num_RandomLimit_ValueChanged);
            // 
            // lblRandomMinLimit
            // 
            this.lblRandomMinLimit.Location = new System.Drawing.Point(19, 67);
            this.lblRandomMinLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRandomMinLimit.Name = "lblRandomMinLimit";
            this.lblRandomMinLimit.Size = new System.Drawing.Size(50, 26);
            this.lblRandomMinLimit.TabIndex = 43;
            this.lblRandomMinLimit.Text = "From";
            // 
            // num_RandomMinLimit
            // 
            this.num_RandomMinLimit.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.num_RandomMinLimit.Location = new System.Drawing.Point(75, 65);
            this.num_RandomMinLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_RandomMinLimit.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.num_RandomMinLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_RandomMinLimit.Name = "num_RandomMinLimit";
            this.num_RandomMinLimit.Size = new System.Drawing.Size(64, 26);
            this.num_RandomMinLimit.TabIndex = 45;
            this.num_RandomMinLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_RandomMinLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_RandomMinLimit.ValueChanged += new System.EventHandler(this.num_RandomLimit_ValueChanged);
            // 
            // lblRandomMaxLimit
            // 
            this.lblRandomMaxLimit.Location = new System.Drawing.Point(159, 67);
            this.lblRandomMaxLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRandomMaxLimit.Name = "lblRandomMaxLimit";
            this.lblRandomMaxLimit.Size = new System.Drawing.Size(32, 26);
            this.lblRandomMaxLimit.TabIndex = 44;
            this.lblRandomMaxLimit.Text = "To";
            // 
            // gbCustomSkillset
            // 
            this.gbCustomSkillset.Controls.Add(this.btnSaveAsCustomSkillset);
            this.gbCustomSkillset.Controls.Add(this.combo_CustomSkillset);
            this.gbCustomSkillset.Controls.Add(this.btnCustomSkillset);
            this.gbCustomSkillset.Location = new System.Drawing.Point(55, 375);
            this.gbCustomSkillset.Name = "gbCustomSkillset";
            this.gbCustomSkillset.Size = new System.Drawing.Size(283, 155);
            this.gbCustomSkillset.TabIndex = 52;
            this.gbCustomSkillset.TabStop = false;
            // 
            // btnSaveAsCustomSkillset
            // 
            this.btnSaveAsCustomSkillset.Location = new System.Drawing.Point(23, 19);
            this.btnSaveAsCustomSkillset.Name = "btnSaveAsCustomSkillset";
            this.btnSaveAsCustomSkillset.Size = new System.Drawing.Size(238, 34);
            this.btnSaveAsCustomSkillset.TabIndex = 55;
            this.btnSaveAsCustomSkillset.Text = "Save As Custom Skillset";
            this.btnSaveAsCustomSkillset.UseVisualStyleBackColor = true;
            // 
            // combo_CustomSkillset
            // 
            this.combo_CustomSkillset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_CustomSkillset.FormattingEnabled = true;
            this.combo_CustomSkillset.Location = new System.Drawing.Point(23, 111);
            this.combo_CustomSkillset.Name = "combo_CustomSkillset";
            this.combo_CustomSkillset.Size = new System.Drawing.Size(238, 28);
            this.combo_CustomSkillset.TabIndex = 0;
            // 
            // btnCustomSkillset
            // 
            this.btnCustomSkillset.Location = new System.Drawing.Point(23, 71);
            this.btnCustomSkillset.Name = "btnCustomSkillset";
            this.btnCustomSkillset.Size = new System.Drawing.Size(238, 34);
            this.btnCustomSkillset.TabIndex = 51;
            this.btnCustomSkillset.Text = "Apply Custom Skillset";
            this.btnCustomSkillset.UseVisualStyleBackColor = true;
            this.btnCustomSkillset.Click += new System.EventHandler(this.btnCustomSkillset_Click);
            // 
            // num_Ski_Digger
            // 
            this.num_Ski_Digger.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.num_Ski_Digger.Location = new System.Drawing.Point(114, 293);
            this.num_Ski_Digger.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Ski_Digger.Name = "num_Ski_Digger";
            this.num_Ski_Digger.Size = new System.Drawing.Size(64, 26);
            this.num_Ski_Digger.TabIndex = 25;
            this.num_Ski_Digger.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Ski_Digger.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.num_Ski_Digger.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.num_Ski_Digger.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // num_Ski_Miner
            // 
            this.num_Ski_Miner.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.num_Ski_Miner.Location = new System.Drawing.Point(114, 258);
            this.num_Ski_Miner.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Ski_Miner.Name = "num_Ski_Miner";
            this.num_Ski_Miner.Size = new System.Drawing.Size(64, 26);
            this.num_Ski_Miner.TabIndex = 24;
            this.num_Ski_Miner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Ski_Miner.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.num_Ski_Miner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.num_Ski_Miner.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // num_Ski_Basher
            // 
            this.num_Ski_Basher.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.num_Ski_Basher.Location = new System.Drawing.Point(114, 210);
            this.num_Ski_Basher.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Ski_Basher.Name = "num_Ski_Basher";
            this.num_Ski_Basher.Size = new System.Drawing.Size(64, 26);
            this.num_Ski_Basher.TabIndex = 22;
            this.num_Ski_Basher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Ski_Basher.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.num_Ski_Basher.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.num_Ski_Basher.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // num_Ski_Builder
            // 
            this.num_Ski_Builder.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.num_Ski_Builder.Location = new System.Drawing.Point(114, 162);
            this.num_Ski_Builder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Ski_Builder.Name = "num_Ski_Builder";
            this.num_Ski_Builder.Size = new System.Drawing.Size(64, 26);
            this.num_Ski_Builder.TabIndex = 17;
            this.num_Ski_Builder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Ski_Builder.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.num_Ski_Builder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.num_Ski_Builder.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // num_Ski_Bomber
            // 
            this.num_Ski_Bomber.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.num_Ski_Bomber.Location = new System.Drawing.Point(114, 93);
            this.num_Ski_Bomber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Ski_Bomber.Name = "num_Ski_Bomber";
            this.num_Ski_Bomber.Size = new System.Drawing.Size(64, 26);
            this.num_Ski_Bomber.TabIndex = 12;
            this.num_Ski_Bomber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Ski_Bomber.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.num_Ski_Bomber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.num_Ski_Bomber.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // num_Ski_Blocker
            // 
            this.num_Ski_Blocker.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.num_Ski_Blocker.Location = new System.Drawing.Point(114, 126);
            this.num_Ski_Blocker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Ski_Blocker.Name = "num_Ski_Blocker";
            this.num_Ski_Blocker.Size = new System.Drawing.Size(64, 26);
            this.num_Ski_Blocker.TabIndex = 14;
            this.num_Ski_Blocker.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Ski_Blocker.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.num_Ski_Blocker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.num_Ski_Blocker.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // num_Ski_Floater
            // 
            this.num_Ski_Floater.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.num_Ski_Floater.Location = new System.Drawing.Point(114, 57);
            this.num_Ski_Floater.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Ski_Floater.Name = "num_Ski_Floater";
            this.num_Ski_Floater.Size = new System.Drawing.Size(64, 26);
            this.num_Ski_Floater.TabIndex = 8;
            this.num_Ski_Floater.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Ski_Floater.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.num_Ski_Floater.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.num_Ski_Floater.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // num_Ski_Climber
            // 
            this.num_Ski_Climber.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.num_Ski_Climber.Location = new System.Drawing.Point(114, 20);
            this.num_Ski_Climber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_Ski_Climber.Name = "num_Ski_Climber";
            this.num_Ski_Climber.Size = new System.Drawing.Size(64, 26);
            this.num_Ski_Climber.TabIndex = 6;
            this.num_Ski_Climber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Ski_Climber.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.num_Ski_Climber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.num_Ski_Climber.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // tabMisc
            // 
            this.tabMisc.Controls.Add(this.check_Lvl_Superlemming);
            this.tabMisc.Controls.Add(this.btnEditPostview);
            this.tabMisc.Controls.Add(this.btnEditPreview);
            this.tabMisc.Location = new System.Drawing.Point(4, 29);
            this.tabMisc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMisc.Name = "tabMisc";
            this.tabMisc.Size = new System.Drawing.Size(388, 787);
            this.tabMisc.TabIndex = 3;
            this.tabMisc.Text = "Misc.";
            this.tabMisc.UseVisualStyleBackColor = true;
            // 
            // check_Lvl_Superlemming
            // 
            this.check_Lvl_Superlemming.AutoSize = true;
            this.check_Lvl_Superlemming.Location = new System.Drawing.Point(75, 186);
            this.check_Lvl_Superlemming.Name = "check_Lvl_Superlemming";
            this.check_Lvl_Superlemming.Size = new System.Drawing.Size(242, 24);
            this.check_Lvl_Superlemming.TabIndex = 9;
            this.check_Lvl_Superlemming.Text = "Activate Superlemming Mode";
            this.check_Lvl_Superlemming.UseVisualStyleBackColor = true;
            this.check_Lvl_Superlemming.CheckedChanged += new System.EventHandler(this.textbox_Leave);
            // 
            // btnEditPostview
            // 
            this.btnEditPostview.Location = new System.Drawing.Point(101, 106);
            this.btnEditPostview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditPostview.Name = "btnEditPostview";
            this.btnEditPostview.Size = new System.Drawing.Size(188, 45);
            this.btnEditPostview.TabIndex = 8;
            this.btnEditPostview.Text = "Edit Postview Text";
            this.btnEditPostview.UseVisualStyleBackColor = true;
            this.btnEditPostview.Click += new System.EventHandler(this.btnEditPostview_Click);
            // 
            // btnEditPreview
            // 
            this.btnEditPreview.Location = new System.Drawing.Point(101, 53);
            this.btnEditPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditPreview.Name = "btnEditPreview";
            this.btnEditPreview.Size = new System.Drawing.Size(188, 45);
            this.btnEditPreview.TabIndex = 7;
            this.btnEditPreview.Text = "Edit Preview Text";
            this.btnEditPreview.UseVisualStyleBackColor = true;
            this.btnEditPreview.Click += new System.EventHandler(this.btnEditPreview_Click);
            // 
            // scrollPicLevelHoriz
            // 
            this.scrollPicLevelHoriz.LargeChange = 2;
            this.scrollPicLevelHoriz.Location = new System.Drawing.Point(409, 826);
            this.scrollPicLevelHoriz.Maximum = 1;
            this.scrollPicLevelHoriz.Name = "scrollPicLevelHoriz";
            this.scrollPicLevelHoriz.Size = new System.Drawing.Size(900, 24);
            this.scrollPicLevelHoriz.TabIndex = 40;
            this.scrollPicLevelHoriz.Visible = false;
            this.scrollPicLevelHoriz.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollPicLevelHoriz_Scroll);
            // 
            // scrollPicLevelVert
            // 
            this.scrollPicLevelVert.LargeChange = 2;
            this.scrollPicLevelVert.Location = new System.Drawing.Point(1300, 42);
            this.scrollPicLevelVert.Maximum = 1;
            this.scrollPicLevelVert.Name = "scrollPicLevelVert";
            this.scrollPicLevelVert.Size = new System.Drawing.Size(24, 689);
            this.scrollPicLevelVert.TabIndex = 41;
            this.scrollPicLevelVert.Visible = false;
            this.scrollPicLevelVert.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollPicLevelVert_Scroll);
            // 
            // toolTipButton
            // 
            this.toolTipButton.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTipButton_Popup);
            // 
            // but_PieceRight
            // 
            this.but_PieceRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_PieceRight.Location = new System.Drawing.Point(1274, 40);
            this.but_PieceRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_PieceRight.Name = "but_PieceRight";
            this.but_PieceRight.NoPaddingText = null;
            this.but_PieceRight.Size = new System.Drawing.Size(48, 129);
            this.but_PieceRight.TabIndex = 80;
            this.but_PieceRight.Text = "⇨";
            this.toolTipButton.SetToolTip(this.but_PieceRight, "Right-click for faster scrolling");
            this.but_PieceRight.UseVisualStyleBackColor = true;
            this.but_PieceRight.Click += new System.EventHandler(this.but_PieceRight_Click);
            this.but_PieceRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.but_PieceRight_MouseUp);
            // 
            // but_PieceLeft
            // 
            this.but_PieceLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_PieceLeft.Location = new System.Drawing.Point(3, 40);
            this.but_PieceLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_PieceLeft.Name = "but_PieceLeft";
            this.but_PieceLeft.NoPaddingText = null;
            this.but_PieceLeft.Size = new System.Drawing.Size(48, 129);
            this.but_PieceLeft.TabIndex = 79;
            this.but_PieceLeft.Text = "⇦";
            this.toolTipButton.SetToolTip(this.but_PieceLeft, "Right-click for faster scrolling");
            this.but_PieceLeft.UseVisualStyleBackColor = true;
            this.but_PieceLeft.Click += new System.EventHandler(this.but_PieceLeft_Click);
            this.but_PieceLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.but_PieceLeft_MouseUp);
            // 
            // timerAutosave
            // 
            this.timerAutosave.Interval = 60000;
            this.timerAutosave.Tick += new System.EventHandler(this.timerAutosave_Tick);
            // 
            // statusBar
            // 
            this.statusBar.AutoSize = false;
            this.statusBar.Dock = System.Windows.Forms.DockStyle.None;
            this.statusBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarLabel1,
            this.statusBarLabel2,
            this.statusBarButton1});
            this.statusBar.Location = new System.Drawing.Point(403, 7);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusBar.Size = new System.Drawing.Size(1997, 32);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusBar";
            this.statusBar.Visible = false;
            // 
            // statusBarLabel1
            // 
            this.statusBarLabel1.BackColor = System.Drawing.SystemColors.Info;
            this.statusBarLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.statusBarLabel1.ForeColor = System.Drawing.Color.Red;
            this.statusBarLabel1.Name = "statusBarLabel1";
            this.statusBarLabel1.Size = new System.Drawing.Size(147, 25);
            this.statusBarLabel1.Text = "statusBarLabel1";
            this.statusBarLabel1.Click += new System.EventHandler(this.statusBarLabel1_Click);
            this.statusBarLabel1.MouseEnter += new System.EventHandler(this.toolStripLabel1_MouseEnter);
            this.statusBarLabel1.MouseLeave += new System.EventHandler(this.toolStripLabel1_MouseLeave);
            // 
            // statusBarLabel2
            // 
            this.statusBarLabel2.BackColor = System.Drawing.SystemColors.Info;
            this.statusBarLabel2.Name = "statusBarLabel2";
            this.statusBarLabel2.Size = new System.Drawing.Size(135, 25);
            this.statusBarLabel2.Text = "statusBarLabel2";
            // 
            // statusBarButton1
            // 
            this.statusBarButton1.AutoSize = false;
            this.statusBarButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.statusBarButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMissingPiecesStatusBarMenuItem,
            this.oKStatusBarMenuItem,
            this.deleteMissingPiecesToolStripMenuItem});
            this.statusBarButton1.Image = global::NLEditor.Properties.Resources.LemButton;
            this.statusBarButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusBarButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.statusBarButton1.Name = "statusBarButton1";
            this.statusBarButton1.Size = new System.Drawing.Size(34, 29);
            this.statusBarButton1.Text = "statusBarButton1";
            // 
            // showMissingPiecesStatusBarMenuItem
            // 
            this.showMissingPiecesStatusBarMenuItem.Name = "showMissingPiecesStatusBarMenuItem";
            this.showMissingPiecesStatusBarMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.showMissingPiecesStatusBarMenuItem.Size = new System.Drawing.Size(284, 34);
            this.showMissingPiecesStatusBarMenuItem.Text = "Show missing pieces";
            this.showMissingPiecesStatusBarMenuItem.Click += new System.EventHandler(this.showMissingPiecesStatusBarMenuItem_Click);
            // 
            // oKStatusBarMenuItem
            // 
            this.oKStatusBarMenuItem.Name = "oKStatusBarMenuItem";
            this.oKStatusBarMenuItem.Size = new System.Drawing.Size(284, 34);
            this.oKStatusBarMenuItem.Text = "Keep missing pieces";
            this.oKStatusBarMenuItem.Click += new System.EventHandler(this.oKStatusBarMenuItem_Click);
            // 
            // deleteMissingPiecesToolStripMenuItem
            // 
            this.deleteMissingPiecesToolStripMenuItem.Name = "deleteMissingPiecesToolStripMenuItem";
            this.deleteMissingPiecesToolStripMenuItem.Size = new System.Drawing.Size(284, 34);
            this.deleteMissingPiecesToolStripMenuItem.Text = "Delete missing pieces";
            this.deleteMissingPiecesToolStripMenuItem.Click += new System.EventHandler(this.deleteMissingPiecesToolStripMenuItem_Click);
            // 
            // tabLvlPieces
            // 
            this.tabLvlPieces.Location = new System.Drawing.Point(412, 42);
            this.tabLvlPieces.Name = "tabLvlPieces";
            this.tabLvlPieces.SelectedIndex = 0;
            this.tabLvlPieces.Size = new System.Drawing.Size(200, 100);
            this.tabLvlPieces.TabIndex = 63;
            this.tabLvlPieces.Visible = false;
            // 
            // tabLvlSkills
            // 
            this.tabLvlSkills.Location = new System.Drawing.Point(618, 42);
            this.tabLvlSkills.Name = "tabLvlSkills";
            this.tabLvlSkills.SelectedIndex = 0;
            this.tabLvlSkills.Size = new System.Drawing.Size(200, 100);
            this.tabLvlSkills.TabIndex = 64;
            this.tabLvlSkills.Visible = false;
            // 
            // tabLvlMisc
            // 
            this.tabLvlMisc.Location = new System.Drawing.Point(824, 42);
            this.tabLvlMisc.Name = "tabLvlMisc";
            this.tabLvlMisc.SelectedIndex = 0;
            this.tabLvlMisc.Size = new System.Drawing.Size(200, 100);
            this.tabLvlMisc.TabIndex = 65;
            this.tabLvlMisc.Visible = false;
            // 
            // panelPieceBrowser
            // 
            this.panelPieceBrowser.BackColor = System.Drawing.Color.Transparent;
            this.panelPieceBrowser.Controls.Add(this.picPiece7);
            this.panelPieceBrowser.Controls.Add(this.but_PieceSteel);
            this.panelPieceBrowser.Controls.Add(this.but_SearchPieces);
            this.panelPieceBrowser.Controls.Add(this.but_PieceTerr);
            this.panelPieceBrowser.Controls.Add(this.but_PieceObj);
            this.panelPieceBrowser.Controls.Add(this.but_PieceSketches);
            this.panelPieceBrowser.Controls.Add(this.but_PieceBackground);
            this.panelPieceBrowser.Controls.Add(this.but_ClearBackground);
            this.panelPieceBrowser.Controls.Add(this.picPiece6);
            this.panelPieceBrowser.Controls.Add(this.picPiece5);
            this.panelPieceBrowser.Controls.Add(this.picPiece4);
            this.panelPieceBrowser.Controls.Add(this.picPiece3);
            this.panelPieceBrowser.Controls.Add(this.but_PieceRight);
            this.panelPieceBrowser.Controls.Add(this.picPiece2);
            this.panelPieceBrowser.Controls.Add(this.picPiece1);
            this.panelPieceBrowser.Controls.Add(this.but_PieceLeft);
            this.panelPieceBrowser.Controls.Add(this.picPiece0);
            this.panelPieceBrowser.Controls.Add(this.combo_PieceStyle);
            this.panelPieceBrowser.Controls.Add(this.txt_FocusPieceBrowser);
            this.panelPieceBrowser.Location = new System.Drawing.Point(0, 871);
            this.panelPieceBrowser.Name = "panelPieceBrowser";
            this.panelPieceBrowser.Size = new System.Drawing.Size(1454, 176);
            this.panelPieceBrowser.TabIndex = 67;
            // 
            // picPiece7
            // 
            this.picPiece7.BackColor = System.Drawing.SystemColors.Control;
            this.picPiece7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPiece7.Location = new System.Drawing.Point(1001, 40);
            this.picPiece7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picPiece7.Name = "picPiece7";
            this.picPiece7.Size = new System.Drawing.Size(124, 127);
            this.picPiece7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPiece7.TabIndex = 85;
            this.picPiece7.TabStop = false;
            this.picPiece7.Click += new System.EventHandler(this.picPieces_Click);
            this.picPiece7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPieces_MouseDown);
            this.picPiece7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_Level_MouseUp);
            // 
            // but_PieceSteel
            // 
            this.but_PieceSteel.Location = new System.Drawing.Point(586, 2);
            this.but_PieceSteel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_PieceSteel.Name = "but_PieceSteel";
            this.but_PieceSteel.Size = new System.Drawing.Size(116, 32);
            this.but_PieceSteel.TabIndex = 84;
            this.but_PieceSteel.Text = "Steel";
            this.but_PieceSteel.UseVisualStyleBackColor = true;
            this.but_PieceSteel.Click += new System.EventHandler(this.but_PieceSteel_Click);
            // 
            // but_SearchPieces
            // 
            this.but_SearchPieces.Location = new System.Drawing.Point(1307, 1);
            this.but_SearchPieces.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_SearchPieces.Name = "but_SearchPieces";
            this.but_SearchPieces.Size = new System.Drawing.Size(145, 32);
            this.but_SearchPieces.TabIndex = 83;
            this.but_SearchPieces.Text = "Search Pieces";
            this.but_SearchPieces.UseVisualStyleBackColor = true;
            this.but_SearchPieces.Click += new System.EventHandler(this.but_SearchPieces_Click);
            // 
            // but_PieceTerr
            // 
            this.but_PieceTerr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_PieceTerr.Location = new System.Drawing.Point(462, 2);
            this.but_PieceTerr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_PieceTerr.Name = "but_PieceTerr";
            this.but_PieceTerr.Size = new System.Drawing.Size(116, 32);
            this.but_PieceTerr.TabIndex = 82;
            this.but_PieceTerr.Text = "Terrain";
            this.but_PieceTerr.UseVisualStyleBackColor = true;
            this.but_PieceTerr.Click += new System.EventHandler(this.but_PieceTerr_Click);
            // 
            // but_PieceObj
            // 
            this.but_PieceObj.Location = new System.Drawing.Point(710, 2);
            this.but_PieceObj.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_PieceObj.Name = "but_PieceObj";
            this.but_PieceObj.Size = new System.Drawing.Size(119, 32);
            this.but_PieceObj.TabIndex = 81;
            this.but_PieceObj.Text = "Objects";
            this.but_PieceObj.UseVisualStyleBackColor = true;
            this.but_PieceObj.Click += new System.EventHandler(this.but_PieceObj_Click);
            // 
            // but_PieceSketches
            // 
            this.but_PieceSketches.Location = new System.Drawing.Point(837, 2);
            this.but_PieceSketches.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_PieceSketches.Name = "but_PieceSketches";
            this.but_PieceSketches.Size = new System.Drawing.Size(122, 32);
            this.but_PieceSketches.TabIndex = 78;
            this.but_PieceSketches.Text = "Sketches";
            this.but_PieceSketches.UseVisualStyleBackColor = true;
            this.but_PieceSketches.Click += new System.EventHandler(this.but_PieceSketch_Click);
            // 
            // but_PieceBackground
            // 
            this.but_PieceBackground.Location = new System.Drawing.Point(967, 2);
            this.but_PieceBackground.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_PieceBackground.Name = "but_PieceBackground";
            this.but_PieceBackground.Size = new System.Drawing.Size(145, 32);
            this.but_PieceBackground.TabIndex = 76;
            this.but_PieceBackground.Text = "Backgrounds";
            this.but_PieceBackground.UseVisualStyleBackColor = true;
            this.but_PieceBackground.Click += new System.EventHandler(this.but_PieceBackground_Click);
            // 
            // but_ClearBackground
            // 
            this.but_ClearBackground.Location = new System.Drawing.Point(1133, 2);
            this.but_ClearBackground.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_ClearBackground.Name = "but_ClearBackground";
            this.but_ClearBackground.Size = new System.Drawing.Size(166, 32);
            this.but_ClearBackground.TabIndex = 77;
            this.but_ClearBackground.Text = "Clear Background";
            this.but_ClearBackground.UseVisualStyleBackColor = true;
            this.but_ClearBackground.Click += new System.EventHandler(this.but_ClearBackground_Click);
            // 
            // picPiece6
            // 
            this.picPiece6.BackColor = System.Drawing.SystemColors.Control;
            this.picPiece6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPiece6.Location = new System.Drawing.Point(867, 40);
            this.picPiece6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picPiece6.Name = "picPiece6";
            this.picPiece6.Size = new System.Drawing.Size(124, 127);
            this.picPiece6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPiece6.TabIndex = 73;
            this.picPiece6.TabStop = false;
            this.picPiece6.Click += new System.EventHandler(this.picPieces_Click);
            this.picPiece6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPieces_MouseDown);
            this.picPiece6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_Level_MouseUp);
            // 
            // picPiece5
            // 
            this.picPiece5.BackColor = System.Drawing.SystemColors.Control;
            this.picPiece5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPiece5.Location = new System.Drawing.Point(732, 40);
            this.picPiece5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picPiece5.Name = "picPiece5";
            this.picPiece5.Size = new System.Drawing.Size(124, 127);
            this.picPiece5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPiece5.TabIndex = 72;
            this.picPiece5.TabStop = false;
            this.picPiece5.Click += new System.EventHandler(this.picPieces_Click);
            this.picPiece5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPieces_MouseDown);
            this.picPiece5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_Level_MouseUp);
            // 
            // picPiece4
            // 
            this.picPiece4.BackColor = System.Drawing.SystemColors.Control;
            this.picPiece4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPiece4.Location = new System.Drawing.Point(597, 40);
            this.picPiece4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picPiece4.Name = "picPiece4";
            this.picPiece4.Size = new System.Drawing.Size(124, 127);
            this.picPiece4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPiece4.TabIndex = 71;
            this.picPiece4.TabStop = false;
            this.picPiece4.Click += new System.EventHandler(this.picPieces_Click);
            this.picPiece4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPieces_MouseDown);
            this.picPiece4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_Level_MouseUp);
            // 
            // picPiece3
            // 
            this.picPiece3.BackColor = System.Drawing.SystemColors.Control;
            this.picPiece3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPiece3.Location = new System.Drawing.Point(462, 40);
            this.picPiece3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picPiece3.Name = "picPiece3";
            this.picPiece3.Size = new System.Drawing.Size(124, 127);
            this.picPiece3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPiece3.TabIndex = 70;
            this.picPiece3.TabStop = false;
            this.picPiece3.Click += new System.EventHandler(this.picPieces_Click);
            this.picPiece3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPieces_MouseDown);
            this.picPiece3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_Level_MouseUp);
            // 
            // picPiece2
            // 
            this.picPiece2.BackColor = System.Drawing.SystemColors.Control;
            this.picPiece2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPiece2.Location = new System.Drawing.Point(327, 40);
            this.picPiece2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picPiece2.Name = "picPiece2";
            this.picPiece2.Size = new System.Drawing.Size(124, 127);
            this.picPiece2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPiece2.TabIndex = 69;
            this.picPiece2.TabStop = false;
            this.picPiece2.Click += new System.EventHandler(this.picPieces_Click);
            this.picPiece2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPieces_MouseDown);
            this.picPiece2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_Level_MouseUp);
            // 
            // picPiece1
            // 
            this.picPiece1.BackColor = System.Drawing.SystemColors.Control;
            this.picPiece1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPiece1.Location = new System.Drawing.Point(192, 40);
            this.picPiece1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picPiece1.Name = "picPiece1";
            this.picPiece1.Size = new System.Drawing.Size(124, 127);
            this.picPiece1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPiece1.TabIndex = 68;
            this.picPiece1.TabStop = false;
            this.picPiece1.Click += new System.EventHandler(this.picPieces_Click);
            this.picPiece1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPieces_MouseDown);
            this.picPiece1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_Level_MouseUp);
            // 
            // picPiece0
            // 
            this.picPiece0.BackColor = System.Drawing.SystemColors.Control;
            this.picPiece0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPiece0.Location = new System.Drawing.Point(57, 40);
            this.picPiece0.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picPiece0.Name = "picPiece0";
            this.picPiece0.Size = new System.Drawing.Size(124, 127);
            this.picPiece0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPiece0.TabIndex = 67;
            this.picPiece0.TabStop = false;
            this.picPiece0.Click += new System.EventHandler(this.picPieces_Click);
            this.picPiece0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPieces_MouseDown);
            this.picPiece0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_Level_MouseUp);
            // 
            // combo_PieceStyle
            // 
            this.combo_PieceStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_PieceStyle.FormattingEnabled = true;
            this.combo_PieceStyle.Location = new System.Drawing.Point(9, 2);
            this.combo_PieceStyle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.combo_PieceStyle.Name = "combo_PieceStyle";
            this.combo_PieceStyle.Size = new System.Drawing.Size(442, 28);
            this.combo_PieceStyle.TabIndex = 75;
            this.combo_PieceStyle.SelectedIndexChanged += new System.EventHandler(this.combo_PieceStyle_TextChanged);
            this.combo_PieceStyle.DropDownClosed += new System.EventHandler(this.ComboDropDownClosed);
            this.combo_PieceStyle.TextChanged += new System.EventHandler(this.combo_PieceStyle_TextChanged);
            this.combo_PieceStyle.Leave += new System.EventHandler(this.combo_PieceStyle_Leave);
            this.combo_PieceStyle.MouseEnter += new System.EventHandler(this.ComboMouseEnter);
            this.combo_PieceStyle.MouseLeave += new System.EventHandler(this.ComboMouseLeave);
            // 
            // txt_FocusPieceBrowser
            // 
            this.txt_FocusPieceBrowser.BackColor = System.Drawing.SystemColors.Control;
            this.txt_FocusPieceBrowser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_FocusPieceBrowser.Location = new System.Drawing.Point(-150, 2);
            this.txt_FocusPieceBrowser.Name = "txt_FocusPieceBrowser";
            this.txt_FocusPieceBrowser.Size = new System.Drawing.Size(57, 19);
            this.txt_FocusPieceBrowser.TabIndex = 86;
            this.txt_FocusPieceBrowser.Text = "asdf";
            // 
            // pic_DragNewPiece
            // 
            this.pic_DragNewPiece.BackColor = System.Drawing.Color.Black;
            this.pic_DragNewPiece.Location = new System.Drawing.Point(1422, 826);
            this.pic_DragNewPiece.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pic_DragNewPiece.Name = "pic_DragNewPiece";
            this.pic_DragNewPiece.Size = new System.Drawing.Size(30, 31);
            this.pic_DragNewPiece.TabIndex = 87;
            this.pic_DragNewPiece.TabStop = false;
            this.pic_DragNewPiece.Visible = false;
            // 
            // txt_Focus
            // 
            this.txt_Focus.Location = new System.Drawing.Point(-150, 2);
            this.txt_Focus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Focus.Name = "txt_Focus";
            this.txt_Focus.Size = new System.Drawing.Size(58, 26);
            this.txt_Focus.TabIndex = 37;
            this.txt_Focus.TabStop = false;
            this.txt_Focus.Text = "asdf";
            // 
            // NLEditForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1478, 1049);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.pic_DragNewPiece);
            this.Controls.Add(this.tabLvlMisc);
            this.Controls.Add(this.tabLvlSkills);
            this.Controls.Add(this.tabLvlPieces);
            this.Controls.Add(this.tabLvlProperties);
            this.Controls.Add(this.scrollPicLevelVert);
            this.Controls.Add(this.scrollPicLevelHoriz);
            this.Controls.Add(this.txt_Focus);
            this.Controls.Add(this.pic_Level);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panelPieceBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1300, 700);
            this.Name = "NLEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  RetroLemmini Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.NLEditForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NLEditForm_FormClosing);
            this.Shown += new System.EventHandler(this.NLEditForm_Shown);
            this.Click += new System.EventHandler(this.NLEditForm_Click);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.NLEditForm_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.NLEditForm_DragOver);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NLEditForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NLEditForm_KeyUp);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.NLEditForm_MouseWheel);
            this.Resize += new System.EventHandler(this.NLEditForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Level)).EndInit();
            this.tabLvlProperties.ResumeLayout(false);
            this.tabGlobalInfo.ResumeLayout(false);
            this.tabGlobalInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_TimeSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_TimeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_RR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_Rescue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_Lems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_StartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_StartX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_SizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_SizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Lvl_SI)).EndInit();
            this.tabPieces.ResumeLayout(false);
            this.gbPieceMetaData.ResumeLayout(false);
            this.gbPieceMetaData.PerformLayout();
            this.tabSkills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_AllNonZeroSkillsToN)).EndInit();
            this.gbRandomSkillset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_RandomMaxLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_RandomMinLimit)).EndInit();
            this.gbCustomSkillset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Digger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Miner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Basher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Builder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Bomber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Blocker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Floater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ski_Climber)).EndInit();
            this.tabMisc.ResumeLayout(false);
            this.tabMisc.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.panelPieceBrowser.ResumeLayout(false);
            this.panelPieceBrowser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPiece0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DragNewPiece)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearPhysicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terrainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triggerAreasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deprecatedPiecesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screenStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.TabPage tabGlobalInfo;
        private System.Windows.Forms.TabPage tabPieces;
        private System.Windows.Forms.TabPage tabSkills;
        private System.Windows.Forms.Label lbl_Skill_Digger;
        private System.Windows.Forms.Label lbl_Skill_Miner;
        private System.Windows.Forms.Label lbl_Skill_Basher;
        private System.Windows.Forms.Label lbl_Skill_Builder;
        private System.Windows.Forms.Label lbl_Skill_Bomber;
        private System.Windows.Forms.Label lbl_Skill_Blocker;
        private System.Windows.Forms.Label lbl_Skill_Floater;
        private System.Windows.Forms.Label lbl_Skill_Climber;
        private NLEditor.NumUpDownOverwrite num_Ski_Digger;
        private NLEditor.NumUpDownOverwrite num_Ski_Miner;
        private NLEditor.NumUpDownOverwrite num_Ski_Basher;
        private NLEditor.NumUpDownOverwrite num_Ski_Builder;
        private NLEditor.NumUpDownOverwrite num_Ski_Bomber;
        private NLEditor.NumUpDownOverwrite num_Ski_Blocker;
        private NLEditor.NumUpDownOverwrite num_Ski_Floater;
        private NLEditor.NumUpDownOverwrite num_Ski_Climber;
        private NLEditor.NumUpDownOverwrite num_Lvl_Rescue;
        private System.Windows.Forms.Label lbl_Global_Rescue;
        private NLEditor.NumUpDownOverwrite num_Lvl_Lems;
        private System.Windows.Forms.Label lbl_Global_Lemmings;
        private NLEditor.NumUpDownOverwrite num_Lvl_StartY;
        private NLEditor.NumUpDownOverwrite num_Lvl_StartX;
        private NLEditor.NumUpDownOverwrite num_Lvl_SizeY;
        private NLEditor.NumUpDownOverwrite num_Lvl_SizeX;
        private System.Windows.Forms.Label lbl_Global_Music;
        private System.Windows.Forms.TextBox txt_LevelAuthor;
        private System.Windows.Forms.Label lbl_Global_Author;
        private System.Windows.Forms.TextBox txt_LevelTitle;
        private System.Windows.Forms.Label lbl_Global_Title;
        private NLEditor.NumUpDownOverwrite num_Lvl_TimeSec;
        private NLEditor.NumUpDownOverwrite num_Lvl_TimeMin;
        private System.Windows.Forms.Label lbl_Global_TimeLimit;
        private NLEditor.NumUpDownOverwrite num_Lvl_RR;
        private System.Windows.Forms.Label lbl_Global_SR;
        private System.Windows.Forms.ComboBox combo_Music;
        private System.Windows.Forms.CheckBox check_Lvl_InfTime;
        private System.Windows.Forms.PictureBox pic_Level;
        private System.Windows.Forms.TabControl tabLvlProperties;
        private NLEditor.FocusTextBox txt_Focus;
        private NLEditor.RepeatButton but_FlipPieces;
        private NLEditor.RepeatButton but_InvertPieces;
        private NLEditor.RepeatButton but_RotatePieces;
        private System.Windows.Forms.CheckBox check_Pieces_OneWay;
        private System.Windows.Forms.CheckBox check_Pieces_OnlyOnTerrain;
        private System.Windows.Forms.CheckBox check_Pieces_NoOv;
        private System.Windows.Forms.CheckBox check_Pieces_Erase;
        private NLEditor.RepeatButton but_MoveBackOne;
        private NLEditor.RepeatButton but_MoveFrontOne;
        private NLEditor.NoPaddingButton but_MoveBack;
        private NLEditor.NoPaddingButton but_MoveFront;
        private System.Windows.Forms.ToolStripMenuItem hotkeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipPieces;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.HScrollBar scrollPicLevelHoriz;
        private System.Windows.Forms.VScrollBar scrollPicLevelVert;
        private System.Windows.Forms.Button but_UngroupSelection;
        private System.Windows.Forms.Button but_GroupSelection;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ungroupToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipButton;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.TabPage tabMisc;
        private System.Windows.Forms.Button btnEditPostview;
        private System.Windows.Forms.Button btnEditPreview;
        private System.Windows.Forms.Label lbStartY;
        private System.Windows.Forms.Label lbStartX;
        private System.Windows.Forms.Label lbSizeH;
        private System.Windows.Forms.Label lbSizeW;
        private System.Windows.Forms.TextBox txt_LevelID;
        private System.Windows.Forms.Label lbl_Global_ID;
        private System.Windows.Forms.Button but_RandomID;
        private System.Windows.Forms.ToolStripMenuItem pasteInPlaceToolStripMenuItem;
        private System.Windows.Forms.Timer timerAutosave;
        private System.Windows.Forms.Label lbl_Global_Version;
        private System.Windows.Forms.ToolStripMenuItem snapToGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem playLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.CheckBox chk_Lvl_AutoStart;
        private System.Windows.Forms.CheckBox check_Lvl_Superlemming;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel2;
        private System.Windows.Forms.ToolStripDropDownButton statusBarButton1;
        private System.Windows.Forms.ToolStripMenuItem oKStatusBarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMissingPiecesStatusBarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMissingPiecesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanseLevelsToolStripMenuItem;
        private System.Windows.Forms.Button btnAllNonZeroSkillsToN;
        private NumUpDownOverwrite num_RandomMaxLimit;
        private NumUpDownOverwrite num_RandomMinLimit;
        private System.Windows.Forms.Label lblRandomMaxLimit;
        private System.Windows.Forms.Label lblRandomMinLimit;
        private System.Windows.Forms.ToolStripMenuItem searchPiecesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPieceType;
        private System.Windows.Forms.Label lblPieceStyle;
        private System.Windows.Forms.Label lblPieceName;
        private System.Windows.Forms.Button but_LoadStyle;
        private System.Windows.Forms.GroupBox gbPieceMetaData;
        private System.Windows.Forms.GroupBox gbRandomSkillset;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLevelWindowToolStripMenuItem;
        private System.Windows.Forms.TabControl tabLvlPieces;
        private System.Windows.Forms.TabControl tabLvlSkills;
        private System.Windows.Forms.TabControl tabLvlMisc;
        private System.Windows.Forms.ToolStripMenuItem expandAllTabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Label lblPieceSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.ToolStripMenuItem highlightEraserPiecesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highlightGroupedPiecesToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbCustomSkillset;
        private System.Windows.Forms.Button btnCustomSkillset;
        private System.Windows.Forms.ComboBox combo_CustomSkillset;
        private System.Windows.Forms.Panel panelPieceBrowser;
        private System.Windows.Forms.PictureBox picPiece7;
        private System.Windows.Forms.Button but_PieceSteel;
        private System.Windows.Forms.Button but_SearchPieces;
        private System.Windows.Forms.Button but_PieceTerr;
        private System.Windows.Forms.Button but_PieceObj;
        private System.Windows.Forms.Button but_PieceSketches;
        private System.Windows.Forms.Button but_PieceBackground;
        private System.Windows.Forms.Button but_ClearBackground;
        private System.Windows.Forms.PictureBox picPiece6;
        private System.Windows.Forms.PictureBox picPiece5;
        private System.Windows.Forms.PictureBox picPiece4;
        private System.Windows.Forms.PictureBox picPiece3;
        private RepeatButton but_PieceRight;
        private System.Windows.Forms.PictureBox picPiece2;
        private System.Windows.Forms.PictureBox picPiece1;
        private RepeatButton but_PieceLeft;
        private System.Windows.Forms.PictureBox picPiece0;
        private System.Windows.Forms.ComboBox combo_PieceStyle;
        private System.Windows.Forms.PictureBox pic_DragNewPiece;
        private System.Windows.Forms.ToolStripMenuItem openPieceBrowserWindowToolStripMenuItem;
        private NumUpDownOverwrite num_AllNonZeroSkillsToN;
        private System.Windows.Forms.Button btnSaveAsCustomSkillset;
        private System.Windows.Forms.Button btnRandomSkillset;
        private FocusTextBox txt_FocusPieceBrowser;
        private System.Windows.Forms.ToolStripMenuItem refreshStylesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMissingPiecesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem styleManagerToolStripMenuItem;
        private NumUpDownOverwrite num_Lvl_SI;
        private System.Windows.Forms.ToolStripMenuItem exportAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToINIToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    }
}

