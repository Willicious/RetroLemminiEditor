namespace RLEditor
{
    partial class RLEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RLEditForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.templatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.playLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.cleanseLevelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteInPlaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLevelWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPieceBrowserWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandAllTabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.highlightEraserPiecesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.clearPhysicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.terrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.steelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triggerAreasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.steelAreasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMissingPiecesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepMissingPieces = new System.Windows.Forms.ToolStripSeparator();
            this.refreshStylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.snapToGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.levelPackCompilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picLevel = new System.Windows.Forms.PictureBox();
            this.toolTipPieces = new System.Windows.Forms.ToolTip(this.components);
            this.scrollPicLevelHoriz = new System.Windows.Forms.HScrollBar();
            this.scrollPicLevelVert = new System.Windows.Forms.VScrollBar();
            this.toolTipButton = new System.Windows.Forms.ToolTip(this.components);
            this.btnRulers = new System.Windows.Forms.Button();
            this.btnPieceRight = new RLEditor.RepeatButton();
            this.btnPieceLeft = new RLEditor.RepeatButton();
            this.timerAutosave = new System.Windows.Forms.Timer(this.components);
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusBarSteelAreasLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarMissingPiecesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarGenericLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarButtonMissingPieces = new System.Windows.Forms.ToolStripDropDownButton();
            this.showMissingPiecesStatusBarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oKStatusBarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMissingPiecesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarButtonSteelAreas = new System.Windows.Forms.ToolStripDropDownButton();
            this.gotItThanksStatusBarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dontShowAgainStatusBarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPiecesExp = new System.Windows.Forms.TabControl();
            this.tabSkillsExp = new System.Windows.Forms.TabControl();
            this.tabExtrasExp = new System.Windows.Forms.TabControl();
            this.panelPieceBrowser = new System.Windows.Forms.Panel();
            this.btnStyleRandom = new System.Windows.Forms.Button();
            this.btnAddSteelArea = new System.Windows.Forms.Button();
            this.picPiece7 = new System.Windows.Forms.PictureBox();
            this.btnSteel = new System.Windows.Forms.Button();
            this.btnTerrain = new System.Windows.Forms.Button();
            this.btnObjects = new System.Windows.Forms.Button();
            this.picPiece6 = new System.Windows.Forms.PictureBox();
            this.picPiece5 = new System.Windows.Forms.PictureBox();
            this.picPiece4 = new System.Windows.Forms.PictureBox();
            this.picPiece3 = new System.Windows.Forms.PictureBox();
            this.picPiece2 = new System.Windows.Forms.PictureBox();
            this.picPiece1 = new System.Windows.Forms.PictureBox();
            this.picPiece0 = new System.Windows.Forms.PictureBox();
            this.comboPieceStyle = new System.Windows.Forms.ComboBox();
            this.txtFocusPieceBrowser = new RLEditor.FocusTextBox();
            this.picDragNewPiece = new System.Windows.Forms.PictureBox();
            this.tabSkills = new System.Windows.Forms.TabPage();
            this.lblInfinityDigger = new System.Windows.Forms.Label();
            this.lblInfinityMiner = new System.Windows.Forms.Label();
            this.lblInfinityBasher = new System.Windows.Forms.Label();
            this.lblInfinityBuilder = new System.Windows.Forms.Label();
            this.lblInfinityBlocker = new System.Windows.Forms.Label();
            this.lblInfinityBomber = new System.Windows.Forms.Label();
            this.lblInfinityFloater = new System.Windows.Forms.Label();
            this.lblInfinityClimber = new System.Windows.Forms.Label();
            this.btnClearAllSkills = new System.Windows.Forms.Button();
            this.btnRandomSkillset = new System.Windows.Forms.Button();
            this.lblRandomMinLimit = new System.Windows.Forms.Label();
            this.lblRandomMaxLimit = new System.Windows.Forms.Label();
            this.btnSaveAsCustomSkillset = new System.Windows.Forms.Button();
            this.comboCustomSkillset = new System.Windows.Forms.ComboBox();
            this.btnAllSkillsToN = new System.Windows.Forms.Button();
            this.lblDigger = new System.Windows.Forms.Label();
            this.lblMiner = new System.Windows.Forms.Label();
            this.lblBasher = new System.Windows.Forms.Label();
            this.lblBuilder = new System.Windows.Forms.Label();
            this.lblBomber = new System.Windows.Forms.Label();
            this.lblBlocker = new System.Windows.Forms.Label();
            this.lblFloater = new System.Windows.Forms.Label();
            this.lblClimber = new System.Windows.Forms.Label();
            this.numRandomMaxLimit = new RLEditor.NumUpDownOverwrite();
            this.numRandomMinLimit = new RLEditor.NumUpDownOverwrite();
            this.numAllSkillsToN = new RLEditor.NumUpDownOverwrite();
            this.numDigger = new RLEditor.NumUpDownOverwrite();
            this.numMiner = new RLEditor.NumUpDownOverwrite();
            this.numBasher = new RLEditor.NumUpDownOverwrite();
            this.numBuilder = new RLEditor.NumUpDownOverwrite();
            this.numBomber = new RLEditor.NumUpDownOverwrite();
            this.numBlocker = new RLEditor.NumUpDownOverwrite();
            this.numFloater = new RLEditor.NumUpDownOverwrite();
            this.numClimber = new RLEditor.NumUpDownOverwrite();
            this.tabPieces = new System.Windows.Forms.TabPage();
            this.btnFlipSpawnDirection = new System.Windows.Forms.Button();
            this.btnLoadStyle = new System.Windows.Forms.Button();
            this.checkNegativeSteel = new System.Windows.Forms.CheckBox();
            this.lblRulerHeight = new System.Windows.Forms.Label();
            this.lblRulerWidth = new System.Windows.Forms.Label();
            this.lblSteelAreaHeight = new System.Windows.Forms.Label();
            this.lblSteelAreaWidth = new System.Windows.Forms.Label();
            this.checkFake = new System.Windows.Forms.CheckBox();
            this.checkInvisible = new System.Windows.Forms.CheckBox();
            this.lblPieceSize = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPieceType = new System.Windows.Forms.Label();
            this.lblStyle = new System.Windows.Forms.Label();
            this.lblPieceStyle = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblPieceName = new System.Windows.Forms.Label();
            this.checkAllowOneWay = new System.Windows.Forms.CheckBox();
            this.checkOnlyOnTerrain = new System.Windows.Forms.CheckBox();
            this.checkNoOverwrite = new System.Windows.Forms.CheckBox();
            this.checkErase = new System.Windows.Forms.CheckBox();
            this.numRulerHeight = new RLEditor.NumUpDownOverwrite();
            this.numRulerWidth = new RLEditor.NumUpDownOverwrite();
            this.numSteelAreaHeight = new RLEditor.NumUpDownOverwrite();
            this.numSteelAreaWidth = new RLEditor.NumUpDownOverwrite();
            this.btnDrawSooner = new RLEditor.RepeatButton();
            this.btnDrawLater = new RLEditor.RepeatButton();
            this.btnDrawFirst = new RLEditor.NoPaddingButton();
            this.btnDrawLast = new RLEditor.NoPaddingButton();
            this.btnFlip = new RLEditor.RepeatButton();
            this.btnInvert = new RLEditor.RepeatButton();
            this.btnRotate = new RLEditor.RepeatButton();
            this.tabGlobals = new System.Windows.Forms.TabPage();
            this.btnCancelCrop = new System.Windows.Forms.Button();
            this.btnApplyCrop = new System.Windows.Forms.Button();
            this.btnCropLevel = new System.Windows.Forms.Button();
            this.numReleaseRateMax = new RLEditor.NumUpDownOverwrite();
            this.lblReleaseRateMax = new System.Windows.Forms.Label();
            this.lblReleaseRateMin = new System.Windows.Forms.Label();
            this.comboMainStyle = new System.Windows.Forms.ComboBox();
            this.lblMainStyle = new System.Windows.Forms.Label();
            this.checkAutoSteel = new System.Windows.Forms.CheckBox();
            this.comboSteelMode = new System.Windows.Forms.ComboBox();
            this.lblSteelMode = new System.Windows.Forms.Label();
            this.checkTimeLimit = new System.Windows.Forms.CheckBox();
            this.checkLockReleaseRate = new System.Windows.Forms.CheckBox();
            this.checkAutoStart = new System.Windows.Forms.CheckBox();
            this.lblLevelVersion = new System.Windows.Forms.Label();
            this.txtLevelAuthor = new System.Windows.Forms.TextBox();
            this.txtLevelTitle = new System.Windows.Forms.TextBox();
            this.lblStartY = new System.Windows.Forms.Label();
            this.lblStartX = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.comboMusic = new System.Windows.Forms.ComboBox();
            this.numTimeSecs = new RLEditor.NumUpDownOverwrite();
            this.numTimeMins = new RLEditor.NumUpDownOverwrite();
            this.numReleaseRateMin = new RLEditor.NumUpDownOverwrite();
            this.numRescue = new RLEditor.NumUpDownOverwrite();
            this.lblRescue = new System.Windows.Forms.Label();
            this.numLemmings = new RLEditor.NumUpDownOverwrite();
            this.lblLemmings = new System.Windows.Forms.Label();
            this.numStartY = new RLEditor.NumUpDownOverwrite();
            this.numStartX = new RLEditor.NumUpDownOverwrite();
            this.numHeight = new RLEditor.NumUpDownOverwrite();
            this.numWidth = new RLEditor.NumUpDownOverwrite();
            this.lblMusic = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.tabProperties = new System.Windows.Forms.TabControl();
            this.tabExtras = new System.Windows.Forms.TabPage();
            this.checkDirectDrop = new System.Windows.Forms.CheckBox();
            this.btnLevelPackCompiler = new System.Windows.Forms.Button();
            this.btnModsHelp = new System.Windows.Forms.Button();
            this.comboMods = new System.Windows.Forms.ComboBox();
            this.lblMods = new System.Windows.Forms.Label();
            this.btnHints = new System.Windows.Forms.Button();
            this.lblMaxFallDistance = new System.Windows.Forms.Label();
            this.checkForceNormalTimerSpeed = new System.Windows.Forms.CheckBox();
            this.checkSuperlemming = new System.Windows.Forms.CheckBox();
            this.numMaxFallDistance = new RLEditor.NumUpDownOverwrite();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblUpdatingLPC = new System.Windows.Forms.Label();
            this.txtFocus = new RLEditor.FocusTextBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLevel)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.picDragNewPiece)).BeginInit();
            this.tabSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRandomMaxLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRandomMinLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAllSkillsToN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDigger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMiner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBuilder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBomber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlocker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClimber)).BeginInit();
            this.tabPieces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRulerHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRulerWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSteelAreaHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSteelAreaWidth)).BeginInit();
            this.tabGlobals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReleaseRateMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeSecs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeMins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReleaseRateMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRescue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLemmings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            this.tabProperties.SuspendLayout();
            this.tabExtras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxFallDistance)).BeginInit();
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
            this.saveAsImageToolStripMenuItem,
            this.toolStripSeparator10,
            this.templatesToolStripMenuItem,
            this.toolStripSeparator1,
            this.playLevelToolStripMenuItem,
            this.validateLevelToolStripMenuItem,
            this.toolStripSeparator9,
            this.cleanseLevelsToolStripMenuItem,
            this.toolStripSeparator11,
            this.exitToolStripMenuItem});
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
            // saveAsImageToolStripMenuItem
            // 
            this.saveAsImageToolStripMenuItem.Name = "saveAsImageToolStripMenuItem";
            this.saveAsImageToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Alt+S";
            this.saveAsImageToolStripMenuItem.Size = new System.Drawing.Size(354, 34);
            this.saveAsImageToolStripMenuItem.Text = "Save As Image";
            this.saveAsImageToolStripMenuItem.Click += new System.EventHandler(this.saveAsImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(351, 6);
            // 
            // templatesToolStripMenuItem
            // 
            this.templatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTemplateToolStripMenuItem,
            this.saveAsTemplateToolStripMenuItem});
            this.templatesToolStripMenuItem.Name = "templatesToolStripMenuItem";
            this.templatesToolStripMenuItem.Size = new System.Drawing.Size(354, 34);
            this.templatesToolStripMenuItem.Text = "Templates";
            // 
            // openTemplateToolStripMenuItem
            // 
            this.openTemplateToolStripMenuItem.Name = "openTemplateToolStripMenuItem";
            this.openTemplateToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.openTemplateToolStripMenuItem.Text = "Open Templates Loader";
            this.openTemplateToolStripMenuItem.Click += new System.EventHandler(this.openTemplateToolStripMenuItem_Click);
            // 
            // saveAsTemplateToolStripMenuItem
            // 
            this.saveAsTemplateToolStripMenuItem.Name = "saveAsTemplateToolStripMenuItem";
            this.saveAsTemplateToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.saveAsTemplateToolStripMenuItem.Text = "Save Level As Template";
            this.saveAsTemplateToolStripMenuItem.Click += new System.EventHandler(this.saveAsTemplateToolStripMenuItem_Click);
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
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(351, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(354, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            this.duplicateToolStripMenuItem});
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
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLevelWindowToolStripMenuItem,
            this.openPieceBrowserWindowToolStripMenuItem,
            this.expandAllTabsToolStripMenuItem,
            this.toolStripSeparator6,
            this.highlightEraserPiecesToolStripMenuItem,
            this.toolStripSeparator7,
            this.clearPhysicsToolStripMenuItem,
            this.toolStripSeparator8,
            this.terrainToolStripMenuItem,
            this.steelToolStripMenuItem,
            this.objectToolStripMenuItem,
            this.triggerAreasToolStripMenuItem,
            this.screenStartToolStripMenuItem,
            this.steelAreasToolStripMenuItem,
            this.rulersToolStripMenuItem});
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
            // steelToolStripMenuItem
            // 
            this.steelToolStripMenuItem.Checked = true;
            this.steelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.steelToolStripMenuItem.Name = "steelToolStripMenuItem";
            this.steelToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F2";
            this.steelToolStripMenuItem.Size = new System.Drawing.Size(460, 34);
            this.steelToolStripMenuItem.Text = "Show/Hide Steel";
            this.steelToolStripMenuItem.Click += new System.EventHandler(this.steelToolStripMenuItem_Click);
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
            this.triggerAreasToolStripMenuItem.Checked = true;
            this.triggerAreasToolStripMenuItem.CheckOnClick = true;
            this.triggerAreasToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
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
            // steelAreasToolStripMenuItem
            // 
            this.steelAreasToolStripMenuItem.Checked = true;
            this.steelAreasToolStripMenuItem.CheckOnClick = true;
            this.steelAreasToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.steelAreasToolStripMenuItem.Name = "steelAreasToolStripMenuItem";
            this.steelAreasToolStripMenuItem.ShortcutKeyDisplayString = "F6";
            this.steelAreasToolStripMenuItem.Size = new System.Drawing.Size(460, 34);
            this.steelAreasToolStripMenuItem.Text = "Show/Hide Steel Areas";
            this.steelAreasToolStripMenuItem.Click += new System.EventHandler(this.steelAreasToolStripMenuItem_Click);
            // 
            // rulersToolStripMenuItem
            // 
            this.rulersToolStripMenuItem.Checked = true;
            this.rulersToolStripMenuItem.CheckOnClick = true;
            this.rulersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rulersToolStripMenuItem.Name = "rulersToolStripMenuItem";
            this.rulersToolStripMenuItem.ShortcutKeyDisplayString = "F7";
            this.rulersToolStripMenuItem.Size = new System.Drawing.Size(460, 34);
            this.rulersToolStripMenuItem.Text = "Show/Hide Rulers";
            this.rulersToolStripMenuItem.Click += new System.EventHandler(this.rulersToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMissingPiecesToolStripMenuItem,
            this.sepMissingPieces,
            this.refreshStylesToolStripMenuItem,
            this.styleManagerToolStripMenuItem,
            this.toolStripSeparator13,
            this.snapToGridToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.hotkeysToolStripMenuItem,
            this.toolStripSeparator5,
            this.levelPackCompilerToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.optionsToolStripMenuItem.Text = "Tools";
            // 
            // showMissingPiecesToolStripMenuItem
            // 
            this.showMissingPiecesToolStripMenuItem.Name = "showMissingPiecesToolStripMenuItem";
            this.showMissingPiecesToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F8";
            this.showMissingPiecesToolStripMenuItem.Size = new System.Drawing.Size(410, 34);
            this.showMissingPiecesToolStripMenuItem.Text = "Show Missing Pieces";
            this.showMissingPiecesToolStripMenuItem.Click += new System.EventHandler(this.showMissingPiecesToolStripMenuItem_Click);
            // 
            // sepMissingPieces
            // 
            this.sepMissingPieces.Name = "sepMissingPieces";
            this.sepMissingPieces.Size = new System.Drawing.Size(407, 6);
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
            this.styleManagerToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Alt+F8";
            this.styleManagerToolStripMenuItem.Size = new System.Drawing.Size(410, 34);
            this.styleManagerToolStripMenuItem.Text = "Style Manager";
            this.styleManagerToolStripMenuItem.Click += new System.EventHandler(this.styleManagerToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(407, 6);
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
            // levelPackCompilerToolStripMenuItem
            // 
            this.levelPackCompilerToolStripMenuItem.Name = "levelPackCompilerToolStripMenuItem";
            this.levelPackCompilerToolStripMenuItem.Size = new System.Drawing.Size(410, 34);
            this.levelPackCompilerToolStripMenuItem.Text = "Level Pack Compiler";
            this.levelPackCompilerToolStripMenuItem.Click += new System.EventHandler(this.levelPackCompilerToolStripMenuItem_Click);
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
            // picLevel
            // 
            this.picLevel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.picLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picLevel.Location = new System.Drawing.Point(386, 42);
            this.picLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picLevel.Name = "picLevel";
            this.picLevel.Size = new System.Drawing.Size(1002, 820);
            this.picLevel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLevel.TabIndex = 36;
            this.picLevel.TabStop = false;
            this.picLevel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_Level_MouseDown);
            this.picLevel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_Level_MouseMove);
            this.picLevel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_Level_MouseUp);
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
            // btnRulers
            // 
            this.btnRulers.Location = new System.Drawing.Point(783, 2);
            this.btnRulers.Name = "btnRulers";
            this.btnRulers.Size = new System.Drawing.Size(116, 32);
            this.btnRulers.TabIndex = 89;
            this.btnRulers.Tag = "Show Rulers (these can be used to fine-tune your level, and will not appear when " +
    "the level is played in RetroLemmini)";
            this.btnRulers.Text = "Rulers";
            this.toolTipButton.SetToolTip(this.btnRulers, "Select from various helper rulers");
            this.btnRulers.UseVisualStyleBackColor = true;
            this.btnRulers.Click += new System.EventHandler(this.btnPieceRulers_Click);
            // 
            // btnPieceRight
            // 
            this.btnPieceRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPieceRight.Location = new System.Drawing.Point(1274, 40);
            this.btnPieceRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPieceRight.Name = "btnPieceRight";
            this.btnPieceRight.NoPaddingText = null;
            this.btnPieceRight.Size = new System.Drawing.Size(48, 129);
            this.btnPieceRight.TabIndex = 80;
            this.btnPieceRight.Text = "⇨";
            this.toolTipButton.SetToolTip(this.btnPieceRight, "Right-click for faster scrolling");
            this.btnPieceRight.UseVisualStyleBackColor = true;
            this.btnPieceRight.Click += new System.EventHandler(this.btnPieceRight_Click);
            this.btnPieceRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPieceRight_MouseUp);
            // 
            // btnPieceLeft
            // 
            this.btnPieceLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPieceLeft.Location = new System.Drawing.Point(3, 40);
            this.btnPieceLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPieceLeft.Name = "btnPieceLeft";
            this.btnPieceLeft.NoPaddingText = null;
            this.btnPieceLeft.Size = new System.Drawing.Size(48, 129);
            this.btnPieceLeft.TabIndex = 79;
            this.btnPieceLeft.Text = "⇦";
            this.toolTipButton.SetToolTip(this.btnPieceLeft, "Right-click for faster scrolling");
            this.btnPieceLeft.UseVisualStyleBackColor = true;
            this.btnPieceLeft.Click += new System.EventHandler(this.btnPieceLeft_Click);
            this.btnPieceLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPieceLeft_MouseUp);
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
            this.statusBarSteelAreasLabel,
            this.statusBarMissingPiecesLabel,
            this.statusBarGenericLabel,
            this.statusBarButtonMissingPieces,
            this.statusBarButtonSteelAreas});
            this.statusBar.Location = new System.Drawing.Point(403, 7);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusBar.Size = new System.Drawing.Size(1997, 32);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusBar";
            this.statusBar.Visible = false;
            // 
            // statusBarSteelAreasLabel
            // 
            this.statusBarSteelAreasLabel.ActiveLinkColor = System.Drawing.Color.SteelBlue;
            this.statusBarSteelAreasLabel.BackColor = System.Drawing.SystemColors.Info;
            this.statusBarSteelAreasLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.statusBarSteelAreasLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.statusBarSteelAreasLabel.Name = "statusBarSteelAreasLabel";
            this.statusBarSteelAreasLabel.Size = new System.Drawing.Size(145, 25);
            this.statusBarSteelAreasLabel.Text = "steelAreasLabel";
            this.statusBarSteelAreasLabel.Click += new System.EventHandler(this.statusBarLabel1_Click);
            this.statusBarSteelAreasLabel.MouseEnter += new System.EventHandler(this.statusBarLabel_MouseEnter);
            this.statusBarSteelAreasLabel.MouseLeave += new System.EventHandler(this.statusBarLabel_MouseLeave);
            // 
            // statusBarMissingPiecesLabel
            // 
            this.statusBarMissingPiecesLabel.BackColor = System.Drawing.SystemColors.Info;
            this.statusBarMissingPiecesLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.statusBarMissingPiecesLabel.ForeColor = System.Drawing.Color.Red;
            this.statusBarMissingPiecesLabel.Name = "statusBarMissingPiecesLabel";
            this.statusBarMissingPiecesLabel.Size = new System.Drawing.Size(174, 25);
            this.statusBarMissingPiecesLabel.Text = "missingPiecesLabel";
            this.statusBarMissingPiecesLabel.Click += new System.EventHandler(this.statusBarLabel2_Click);
            this.statusBarMissingPiecesLabel.MouseEnter += new System.EventHandler(this.statusBarLabel_MouseEnter);
            this.statusBarMissingPiecesLabel.MouseLeave += new System.EventHandler(this.statusBarLabel_MouseLeave);
            // 
            // statusBarGenericLabel
            // 
            this.statusBarGenericLabel.BackColor = System.Drawing.SystemColors.Info;
            this.statusBarGenericLabel.Name = "statusBarGenericLabel";
            this.statusBarGenericLabel.Size = new System.Drawing.Size(110, 25);
            this.statusBarGenericLabel.Text = "genericLabel";
            // 
            // statusBarButtonMissingPieces
            // 
            this.statusBarButtonMissingPieces.AutoSize = false;
            this.statusBarButtonMissingPieces.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.statusBarButtonMissingPieces.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMissingPiecesStatusBarMenuItem,
            this.oKStatusBarMenuItem,
            this.deleteMissingPiecesToolStripMenuItem});
            this.statusBarButtonMissingPieces.Image = global::RLEditor.Properties.Resources.LemButton;
            this.statusBarButtonMissingPieces.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusBarButtonMissingPieces.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.statusBarButtonMissingPieces.Name = "statusBarButtonMissingPieces";
            this.statusBarButtonMissingPieces.Size = new System.Drawing.Size(34, 29);
            this.statusBarButtonMissingPieces.Text = "statusBarButton1";
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
            // statusBarButtonSteelAreas
            // 
            this.statusBarButtonSteelAreas.AutoSize = false;
            this.statusBarButtonSteelAreas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.statusBarButtonSteelAreas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotItThanksStatusBarMenuItem,
            this.dontShowAgainStatusBarMenuItem});
            this.statusBarButtonSteelAreas.Image = global::RLEditor.Properties.Resources.LemButton;
            this.statusBarButtonSteelAreas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusBarButtonSteelAreas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.statusBarButtonSteelAreas.Name = "statusBarButtonSteelAreas";
            this.statusBarButtonSteelAreas.Size = new System.Drawing.Size(34, 29);
            this.statusBarButtonSteelAreas.Text = "statusBarButton1";
            // 
            // gotItThanksStatusBarMenuItem
            // 
            this.gotItThanksStatusBarMenuItem.Name = "gotItThanksStatusBarMenuItem";
            this.gotItThanksStatusBarMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gotItThanksStatusBarMenuItem.Size = new System.Drawing.Size(361, 34);
            this.gotItThanksStatusBarMenuItem.Text = "Got it, thanks";
            this.gotItThanksStatusBarMenuItem.Click += new System.EventHandler(this.gotItThanksStatusBarMenuItem_Click);
            // 
            // dontShowAgainStatusBarMenuItem
            // 
            this.dontShowAgainStatusBarMenuItem.Name = "dontShowAgainStatusBarMenuItem";
            this.dontShowAgainStatusBarMenuItem.Size = new System.Drawing.Size(361, 34);
            this.dontShowAgainStatusBarMenuItem.Text = "Don\'t show this message again";
            this.dontShowAgainStatusBarMenuItem.Click += new System.EventHandler(this.dontShowAgainStatusBarMenuItem_Click);
            // 
            // tabPiecesExp
            // 
            this.tabPiecesExp.Location = new System.Drawing.Point(412, 42);
            this.tabPiecesExp.Name = "tabPiecesExp";
            this.tabPiecesExp.SelectedIndex = 0;
            this.tabPiecesExp.Size = new System.Drawing.Size(200, 100);
            this.tabPiecesExp.TabIndex = 63;
            this.tabPiecesExp.Visible = false;
            // 
            // tabSkillsExp
            // 
            this.tabSkillsExp.Location = new System.Drawing.Point(618, 42);
            this.tabSkillsExp.Name = "tabSkillsExp";
            this.tabSkillsExp.SelectedIndex = 0;
            this.tabSkillsExp.Size = new System.Drawing.Size(200, 100);
            this.tabSkillsExp.TabIndex = 64;
            this.tabSkillsExp.Visible = false;
            // 
            // tabExtrasExp
            // 
            this.tabExtrasExp.Location = new System.Drawing.Point(824, 42);
            this.tabExtrasExp.Name = "tabExtrasExp";
            this.tabExtrasExp.SelectedIndex = 0;
            this.tabExtrasExp.Size = new System.Drawing.Size(200, 100);
            this.tabExtrasExp.TabIndex = 65;
            this.tabExtrasExp.Visible = false;
            // 
            // panelPieceBrowser
            // 
            this.panelPieceBrowser.BackColor = System.Drawing.Color.Transparent;
            this.panelPieceBrowser.Controls.Add(this.btnStyleRandom);
            this.panelPieceBrowser.Controls.Add(this.btnRulers);
            this.panelPieceBrowser.Controls.Add(this.btnAddSteelArea);
            this.panelPieceBrowser.Controls.Add(this.picPiece7);
            this.panelPieceBrowser.Controls.Add(this.btnSteel);
            this.panelPieceBrowser.Controls.Add(this.btnTerrain);
            this.panelPieceBrowser.Controls.Add(this.btnObjects);
            this.panelPieceBrowser.Controls.Add(this.picPiece6);
            this.panelPieceBrowser.Controls.Add(this.picPiece5);
            this.panelPieceBrowser.Controls.Add(this.picPiece4);
            this.panelPieceBrowser.Controls.Add(this.picPiece3);
            this.panelPieceBrowser.Controls.Add(this.btnPieceRight);
            this.panelPieceBrowser.Controls.Add(this.picPiece2);
            this.panelPieceBrowser.Controls.Add(this.picPiece1);
            this.panelPieceBrowser.Controls.Add(this.btnPieceLeft);
            this.panelPieceBrowser.Controls.Add(this.picPiece0);
            this.panelPieceBrowser.Controls.Add(this.comboPieceStyle);
            this.panelPieceBrowser.Controls.Add(this.txtFocusPieceBrowser);
            this.panelPieceBrowser.Location = new System.Drawing.Point(0, 871);
            this.panelPieceBrowser.Name = "panelPieceBrowser";
            this.panelPieceBrowser.Size = new System.Drawing.Size(1454, 176);
            this.panelPieceBrowser.TabIndex = 67;
            // 
            // btnStyleRandom
            // 
            this.btnStyleRandom.Location = new System.Drawing.Point(13, 2);
            this.btnStyleRandom.Name = "btnStyleRandom";
            this.btnStyleRandom.Size = new System.Drawing.Size(100, 32);
            this.btnStyleRandom.TabIndex = 90;
            this.btnStyleRandom.Tag = "Open a random style in the Piece Browser (you can add styles to the randomizer in" +
    " Style Manager)";
            this.btnStyleRandom.Text = "Random";
            this.btnStyleRandom.UseVisualStyleBackColor = true;
            this.btnStyleRandom.Click += new System.EventHandler(this.btnStyleRandom_Click);
            // 
            // btnAddSteelArea
            // 
            this.btnAddSteelArea.Location = new System.Drawing.Point(1132, 2);
            this.btnAddSteelArea.Name = "btnAddSteelArea";
            this.btnAddSteelArea.Size = new System.Drawing.Size(188, 32);
            this.btnAddSteelArea.TabIndex = 88;
            this.btnAddSteelArea.Tag = "Add a manual steel area (clicking this when a piece isselected will automatically" +
    " apply a steel area to that piece)";
            this.btnAddSteelArea.Text = "Add Steel Area";
            this.btnAddSteelArea.UseVisualStyleBackColor = true;
            this.btnAddSteelArea.Click += new System.EventHandler(this.btnAddSteelArea_Click);
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
            // btnSteel
            // 
            this.btnSteel.Location = new System.Drawing.Point(536, 2);
            this.btnSteel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSteel.Name = "btnSteel";
            this.btnSteel.Size = new System.Drawing.Size(116, 32);
            this.btnSteel.TabIndex = 84;
            this.btnSteel.Tag = "Show Steel pieces";
            this.btnSteel.Text = "Steel";
            this.btnSteel.UseVisualStyleBackColor = true;
            this.btnSteel.Click += new System.EventHandler(this.btnPieceSteel_Click);
            // 
            // btnTerrain
            // 
            this.btnTerrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerrain.Location = new System.Drawing.Point(412, 2);
            this.btnTerrain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTerrain.Name = "btnTerrain";
            this.btnTerrain.Size = new System.Drawing.Size(116, 32);
            this.btnTerrain.TabIndex = 82;
            this.btnTerrain.Tag = "Show Terrain pieces";
            this.btnTerrain.Text = "Terrain";
            this.btnTerrain.UseVisualStyleBackColor = true;
            this.btnTerrain.Click += new System.EventHandler(this.btnPieceTerr_Click);
            // 
            // btnObjects
            // 
            this.btnObjects.Location = new System.Drawing.Point(660, 2);
            this.btnObjects.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnObjects.Name = "btnObjects";
            this.btnObjects.Size = new System.Drawing.Size(116, 32);
            this.btnObjects.TabIndex = 81;
            this.btnObjects.Tag = "Show Objects";
            this.btnObjects.Text = "Objects";
            this.btnObjects.UseVisualStyleBackColor = true;
            this.btnObjects.Click += new System.EventHandler(this.btnPieceObj_Click);
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
            // comboPieceStyle
            // 
            this.comboPieceStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPieceStyle.FormattingEnabled = true;
            this.comboPieceStyle.Location = new System.Drawing.Point(127, 2);
            this.comboPieceStyle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboPieceStyle.MaxDropDownItems = 40;
            this.comboPieceStyle.Name = "comboPieceStyle";
            this.comboPieceStyle.Size = new System.Drawing.Size(274, 28);
            this.comboPieceStyle.TabIndex = 75;
            this.comboPieceStyle.SelectedIndexChanged += new System.EventHandler(this.combo_PieceStyle_TextChanged);
            this.comboPieceStyle.DropDownClosed += new System.EventHandler(this.ComboDropDownClosed);
            this.comboPieceStyle.TextChanged += new System.EventHandler(this.combo_PieceStyle_TextChanged);
            this.comboPieceStyle.Leave += new System.EventHandler(this.combo_PieceStyle_Leave);
            this.comboPieceStyle.MouseEnter += new System.EventHandler(this.ComboMouseEnter);
            this.comboPieceStyle.MouseLeave += new System.EventHandler(this.ComboMouseLeave);
            // 
            // txtFocusPieceBrowser
            // 
            this.txtFocusPieceBrowser.BackColor = System.Drawing.SystemColors.Control;
            this.txtFocusPieceBrowser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFocusPieceBrowser.Location = new System.Drawing.Point(-150, 2);
            this.txtFocusPieceBrowser.Name = "txtFocusPieceBrowser";
            this.txtFocusPieceBrowser.Size = new System.Drawing.Size(57, 19);
            this.txtFocusPieceBrowser.TabIndex = 86;
            this.txtFocusPieceBrowser.Text = "asdf";
            // 
            // picDragNewPiece
            // 
            this.picDragNewPiece.BackColor = System.Drawing.Color.Black;
            this.picDragNewPiece.Location = new System.Drawing.Point(1422, 826);
            this.picDragNewPiece.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picDragNewPiece.Name = "picDragNewPiece";
            this.picDragNewPiece.Size = new System.Drawing.Size(30, 31);
            this.picDragNewPiece.TabIndex = 87;
            this.picDragNewPiece.TabStop = false;
            this.picDragNewPiece.Visible = false;
            // 
            // tabSkills
            // 
            this.tabSkills.Controls.Add(this.lblInfinityDigger);
            this.tabSkills.Controls.Add(this.lblInfinityMiner);
            this.tabSkills.Controls.Add(this.lblInfinityBasher);
            this.tabSkills.Controls.Add(this.lblInfinityBuilder);
            this.tabSkills.Controls.Add(this.lblInfinityBlocker);
            this.tabSkills.Controls.Add(this.lblInfinityBomber);
            this.tabSkills.Controls.Add(this.lblInfinityFloater);
            this.tabSkills.Controls.Add(this.lblInfinityClimber);
            this.tabSkills.Controls.Add(this.btnClearAllSkills);
            this.tabSkills.Controls.Add(this.btnRandomSkillset);
            this.tabSkills.Controls.Add(this.lblRandomMinLimit);
            this.tabSkills.Controls.Add(this.lblRandomMaxLimit);
            this.tabSkills.Controls.Add(this.btnSaveAsCustomSkillset);
            this.tabSkills.Controls.Add(this.comboCustomSkillset);
            this.tabSkills.Controls.Add(this.btnAllSkillsToN);
            this.tabSkills.Controls.Add(this.lblDigger);
            this.tabSkills.Controls.Add(this.lblMiner);
            this.tabSkills.Controls.Add(this.lblBasher);
            this.tabSkills.Controls.Add(this.lblBuilder);
            this.tabSkills.Controls.Add(this.lblBomber);
            this.tabSkills.Controls.Add(this.lblBlocker);
            this.tabSkills.Controls.Add(this.lblFloater);
            this.tabSkills.Controls.Add(this.lblClimber);
            this.tabSkills.Controls.Add(this.numRandomMaxLimit);
            this.tabSkills.Controls.Add(this.numRandomMinLimit);
            this.tabSkills.Controls.Add(this.numAllSkillsToN);
            this.tabSkills.Controls.Add(this.numDigger);
            this.tabSkills.Controls.Add(this.numMiner);
            this.tabSkills.Controls.Add(this.numBasher);
            this.tabSkills.Controls.Add(this.numBuilder);
            this.tabSkills.Controls.Add(this.numBomber);
            this.tabSkills.Controls.Add(this.numBlocker);
            this.tabSkills.Controls.Add(this.numFloater);
            this.tabSkills.Controls.Add(this.numClimber);
            this.tabSkills.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabSkills.Location = new System.Drawing.Point(4, 29);
            this.tabSkills.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabSkills.Name = "tabSkills";
            this.tabSkills.Size = new System.Drawing.Size(388, 787);
            this.tabSkills.TabIndex = 2;
            this.tabSkills.Text = "Skills";
            this.tabSkills.UseVisualStyleBackColor = true;
            // 
            // lblInfinityDigger
            // 
            this.lblInfinityDigger.AutoSize = true;
            this.lblInfinityDigger.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblInfinityDigger.Location = new System.Drawing.Point(221, 325);
            this.lblInfinityDigger.Name = "lblInfinityDigger";
            this.lblInfinityDigger.Size = new System.Drawing.Size(74, 20);
            this.lblInfinityDigger.TabIndex = 72;
            this.lblInfinityDigger.Text = "- (Infinity)";
            this.lblInfinityDigger.Visible = false;
            // 
            // lblInfinityMiner
            // 
            this.lblInfinityMiner.AutoSize = true;
            this.lblInfinityMiner.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblInfinityMiner.Location = new System.Drawing.Point(221, 285);
            this.lblInfinityMiner.Name = "lblInfinityMiner";
            this.lblInfinityMiner.Size = new System.Drawing.Size(74, 20);
            this.lblInfinityMiner.TabIndex = 71;
            this.lblInfinityMiner.Text = "- (Infinity)";
            this.lblInfinityMiner.Visible = false;
            // 
            // lblInfinityBasher
            // 
            this.lblInfinityBasher.AutoSize = true;
            this.lblInfinityBasher.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblInfinityBasher.Location = new System.Drawing.Point(221, 245);
            this.lblInfinityBasher.Name = "lblInfinityBasher";
            this.lblInfinityBasher.Size = new System.Drawing.Size(74, 20);
            this.lblInfinityBasher.TabIndex = 70;
            this.lblInfinityBasher.Text = "- (Infinity)";
            this.lblInfinityBasher.Visible = false;
            // 
            // lblInfinityBuilder
            // 
            this.lblInfinityBuilder.AutoSize = true;
            this.lblInfinityBuilder.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblInfinityBuilder.Location = new System.Drawing.Point(221, 205);
            this.lblInfinityBuilder.Name = "lblInfinityBuilder";
            this.lblInfinityBuilder.Size = new System.Drawing.Size(74, 20);
            this.lblInfinityBuilder.TabIndex = 69;
            this.lblInfinityBuilder.Text = "- (Infinity)";
            this.lblInfinityBuilder.Visible = false;
            // 
            // lblInfinityBlocker
            // 
            this.lblInfinityBlocker.AutoSize = true;
            this.lblInfinityBlocker.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblInfinityBlocker.Location = new System.Drawing.Point(221, 165);
            this.lblInfinityBlocker.Name = "lblInfinityBlocker";
            this.lblInfinityBlocker.Size = new System.Drawing.Size(74, 20);
            this.lblInfinityBlocker.TabIndex = 68;
            this.lblInfinityBlocker.Text = "- (Infinity)";
            this.lblInfinityBlocker.Visible = false;
            // 
            // lblInfinityBomber
            // 
            this.lblInfinityBomber.AutoSize = true;
            this.lblInfinityBomber.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblInfinityBomber.Location = new System.Drawing.Point(221, 125);
            this.lblInfinityBomber.Name = "lblInfinityBomber";
            this.lblInfinityBomber.Size = new System.Drawing.Size(74, 20);
            this.lblInfinityBomber.TabIndex = 67;
            this.lblInfinityBomber.Text = "- (Infinity)";
            this.lblInfinityBomber.Visible = false;
            // 
            // lblInfinityFloater
            // 
            this.lblInfinityFloater.AutoSize = true;
            this.lblInfinityFloater.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblInfinityFloater.Location = new System.Drawing.Point(221, 85);
            this.lblInfinityFloater.Name = "lblInfinityFloater";
            this.lblInfinityFloater.Size = new System.Drawing.Size(74, 20);
            this.lblInfinityFloater.TabIndex = 66;
            this.lblInfinityFloater.Text = "- (Infinity)";
            this.lblInfinityFloater.Visible = false;
            // 
            // lblInfinityClimber
            // 
            this.lblInfinityClimber.AutoSize = true;
            this.lblInfinityClimber.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblInfinityClimber.Location = new System.Drawing.Point(221, 45);
            this.lblInfinityClimber.Name = "lblInfinityClimber";
            this.lblInfinityClimber.Size = new System.Drawing.Size(74, 20);
            this.lblInfinityClimber.TabIndex = 65;
            this.lblInfinityClimber.Text = "- (Infinity)";
            this.lblInfinityClimber.Visible = false;
            // 
            // btnClearAllSkills
            // 
            this.btnClearAllSkills.Location = new System.Drawing.Point(62, 734);
            this.btnClearAllSkills.Name = "btnClearAllSkills";
            this.btnClearAllSkills.Size = new System.Drawing.Size(261, 40);
            this.btnClearAllSkills.TabIndex = 64;
            this.btnClearAllSkills.Text = "Clear Skillset";
            this.btnClearAllSkills.UseVisualStyleBackColor = true;
            this.btnClearAllSkills.Click += new System.EventHandler(this.btnClearAllSkills_Click);
            // 
            // btnRandomSkillset
            // 
            this.btnRandomSkillset.Location = new System.Drawing.Point(62, 521);
            this.btnRandomSkillset.Name = "btnRandomSkillset";
            this.btnRandomSkillset.Size = new System.Drawing.Size(261, 40);
            this.btnRandomSkillset.TabIndex = 47;
            this.btnRandomSkillset.Text = "Random Skillset";
            this.btnRandomSkillset.UseVisualStyleBackColor = true;
            this.btnRandomSkillset.Click += new System.EventHandler(this.btnRandomSkillset_Click);
            // 
            // lblRandomMinLimit
            // 
            this.lblRandomMinLimit.Location = new System.Drawing.Point(68, 573);
            this.lblRandomMinLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRandomMinLimit.Name = "lblRandomMinLimit";
            this.lblRandomMinLimit.Size = new System.Drawing.Size(50, 26);
            this.lblRandomMinLimit.TabIndex = 43;
            this.lblRandomMinLimit.Text = "From";
            // 
            // lblRandomMaxLimit
            // 
            this.lblRandomMaxLimit.Location = new System.Drawing.Point(215, 571);
            this.lblRandomMaxLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRandomMaxLimit.Name = "lblRandomMaxLimit";
            this.lblRandomMaxLimit.Size = new System.Drawing.Size(32, 26);
            this.lblRandomMaxLimit.TabIndex = 44;
            this.lblRandomMaxLimit.Text = "To";
            // 
            // btnSaveAsCustomSkillset
            // 
            this.btnSaveAsCustomSkillset.Location = new System.Drawing.Point(62, 402);
            this.btnSaveAsCustomSkillset.Name = "btnSaveAsCustomSkillset";
            this.btnSaveAsCustomSkillset.Size = new System.Drawing.Size(261, 40);
            this.btnSaveAsCustomSkillset.TabIndex = 55;
            this.btnSaveAsCustomSkillset.Text = "Save As Custom Skillset";
            this.btnSaveAsCustomSkillset.UseVisualStyleBackColor = true;
            this.btnSaveAsCustomSkillset.Click += new System.EventHandler(this.btnSaveAsCustomSkillset_Click);
            // 
            // comboCustomSkillset
            // 
            this.comboCustomSkillset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCustomSkillset.FormattingEnabled = true;
            this.comboCustomSkillset.Location = new System.Drawing.Point(62, 448);
            this.comboCustomSkillset.Name = "comboCustomSkillset";
            this.comboCustomSkillset.Size = new System.Drawing.Size(261, 28);
            this.comboCustomSkillset.TabIndex = 0;
            this.comboCustomSkillset.SelectedIndexChanged += new System.EventHandler(this.combo_CustomSkillset_SelectedIndexChanged);
            // 
            // btnAllSkillsToN
            // 
            this.btnAllSkillsToN.Location = new System.Drawing.Point(62, 656);
            this.btnAllSkillsToN.Name = "btnAllSkillsToN";
            this.btnAllSkillsToN.Size = new System.Drawing.Size(191, 40);
            this.btnAllSkillsToN.TabIndex = 42;
            this.btnAllSkillsToN.Text = "Set All Skills To";
            this.btnAllSkillsToN.UseVisualStyleBackColor = true;
            this.btnAllSkillsToN.Click += new System.EventHandler(this.btnAllSkillsToN_Click);
            this.btnAllSkillsToN.MouseLeave += new System.EventHandler(this.textbox_Leave);
            // 
            // lblDigger
            // 
            this.lblDigger.AutoSize = true;
            this.lblDigger.Location = new System.Drawing.Point(58, 325);
            this.lblDigger.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDigger.Name = "lblDigger";
            this.lblDigger.Size = new System.Drawing.Size(56, 20);
            this.lblDigger.TabIndex = 7;
            this.lblDigger.Text = "Digger";
            // 
            // lblMiner
            // 
            this.lblMiner.AutoSize = true;
            this.lblMiner.Location = new System.Drawing.Point(58, 285);
            this.lblMiner.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMiner.Name = "lblMiner";
            this.lblMiner.Size = new System.Drawing.Size(48, 20);
            this.lblMiner.TabIndex = 6;
            this.lblMiner.Text = "Miner";
            // 
            // lblBasher
            // 
            this.lblBasher.AutoSize = true;
            this.lblBasher.Location = new System.Drawing.Point(58, 245);
            this.lblBasher.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBasher.Name = "lblBasher";
            this.lblBasher.Size = new System.Drawing.Size(60, 20);
            this.lblBasher.TabIndex = 5;
            this.lblBasher.Text = "Basher";
            // 
            // lblBuilder
            // 
            this.lblBuilder.AutoSize = true;
            this.lblBuilder.Location = new System.Drawing.Point(58, 205);
            this.lblBuilder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuilder.Name = "lblBuilder";
            this.lblBuilder.Size = new System.Drawing.Size(58, 20);
            this.lblBuilder.TabIndex = 4;
            this.lblBuilder.Text = "Builder";
            // 
            // lblBomber
            // 
            this.lblBomber.AutoSize = true;
            this.lblBomber.Location = new System.Drawing.Point(58, 125);
            this.lblBomber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBomber.Name = "lblBomber";
            this.lblBomber.Size = new System.Drawing.Size(65, 20);
            this.lblBomber.TabIndex = 3;
            this.lblBomber.Text = "Bomber";
            // 
            // lblBlocker
            // 
            this.lblBlocker.AutoSize = true;
            this.lblBlocker.Location = new System.Drawing.Point(58, 165);
            this.lblBlocker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlocker.Name = "lblBlocker";
            this.lblBlocker.Size = new System.Drawing.Size(62, 20);
            this.lblBlocker.TabIndex = 2;
            this.lblBlocker.Text = "Blocker";
            // 
            // lblFloater
            // 
            this.lblFloater.AutoSize = true;
            this.lblFloater.Location = new System.Drawing.Point(58, 85);
            this.lblFloater.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFloater.Name = "lblFloater";
            this.lblFloater.Size = new System.Drawing.Size(59, 20);
            this.lblFloater.TabIndex = 1;
            this.lblFloater.Text = "Floater";
            // 
            // lblClimber
            // 
            this.lblClimber.AutoSize = true;
            this.lblClimber.Location = new System.Drawing.Point(58, 45);
            this.lblClimber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClimber.Name = "lblClimber";
            this.lblClimber.Size = new System.Drawing.Size(62, 20);
            this.lblClimber.TabIndex = 0;
            this.lblClimber.Text = "Climber";
            // 
            // numRandomMaxLimit
            // 
            this.numRandomMaxLimit.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.numRandomMaxLimit.Location = new System.Drawing.Point(259, 569);
            this.numRandomMaxLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numRandomMaxLimit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numRandomMaxLimit.Name = "numRandomMaxLimit";
            this.numRandomMaxLimit.Size = new System.Drawing.Size(64, 26);
            this.numRandomMaxLimit.TabIndex = 62;
            this.numRandomMaxLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRandomMaxLimit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numRandomMaxLimit.ValueChanged += new System.EventHandler(this.num_RandomLimit_ValueChanged);
            // 
            // numRandomMinLimit
            // 
            this.numRandomMinLimit.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.numRandomMinLimit.Location = new System.Drawing.Point(131, 569);
            this.numRandomMinLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numRandomMinLimit.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numRandomMinLimit.Name = "numRandomMinLimit";
            this.numRandomMinLimit.Size = new System.Drawing.Size(64, 26);
            this.numRandomMinLimit.TabIndex = 61;
            this.numRandomMinLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRandomMinLimit.ValueChanged += new System.EventHandler(this.num_RandomLimit_ValueChanged);
            // 
            // numAllSkillsToN
            // 
            this.numAllSkillsToN.Location = new System.Drawing.Point(259, 660);
            this.numAllSkillsToN.Name = "numAllSkillsToN";
            this.numAllSkillsToN.Size = new System.Drawing.Size(64, 26);
            this.numAllSkillsToN.TabIndex = 53;
            this.numAllSkillsToN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numDigger
            // 
            this.numDigger.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.numDigger.Location = new System.Drawing.Point(152, 323);
            this.numDigger.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numDigger.Name = "numDigger";
            this.numDigger.Size = new System.Drawing.Size(64, 26);
            this.numDigger.TabIndex = 25;
            this.numDigger.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numDigger.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.numDigger.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.numDigger.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // numMiner
            // 
            this.numMiner.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.numMiner.Location = new System.Drawing.Point(152, 283);
            this.numMiner.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numMiner.Name = "numMiner";
            this.numMiner.Size = new System.Drawing.Size(64, 26);
            this.numMiner.TabIndex = 24;
            this.numMiner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMiner.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.numMiner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.numMiner.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // numBasher
            // 
            this.numBasher.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.numBasher.Location = new System.Drawing.Point(152, 243);
            this.numBasher.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numBasher.Name = "numBasher";
            this.numBasher.Size = new System.Drawing.Size(64, 26);
            this.numBasher.TabIndex = 22;
            this.numBasher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numBasher.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.numBasher.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.numBasher.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // numBuilder
            // 
            this.numBuilder.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.numBuilder.Location = new System.Drawing.Point(152, 203);
            this.numBuilder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numBuilder.Name = "numBuilder";
            this.numBuilder.Size = new System.Drawing.Size(64, 26);
            this.numBuilder.TabIndex = 17;
            this.numBuilder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numBuilder.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.numBuilder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.numBuilder.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // numBomber
            // 
            this.numBomber.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.numBomber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBomber.Location = new System.Drawing.Point(152, 123);
            this.numBomber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numBomber.Name = "numBomber";
            this.numBomber.Size = new System.Drawing.Size(64, 26);
            this.numBomber.TabIndex = 12;
            this.numBomber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numBomber.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.numBomber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.numBomber.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // numBlocker
            // 
            this.numBlocker.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.numBlocker.Location = new System.Drawing.Point(152, 163);
            this.numBlocker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numBlocker.Name = "numBlocker";
            this.numBlocker.Size = new System.Drawing.Size(64, 26);
            this.numBlocker.TabIndex = 14;
            this.numBlocker.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numBlocker.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.numBlocker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.numBlocker.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // numFloater
            // 
            this.numFloater.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.numFloater.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numFloater.Location = new System.Drawing.Point(152, 83);
            this.numFloater.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numFloater.Name = "numFloater";
            this.numFloater.Size = new System.Drawing.Size(64, 26);
            this.numFloater.TabIndex = 8;
            this.numFloater.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numFloater.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.numFloater.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.numFloater.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // numClimber
            // 
            this.numClimber.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.numClimber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numClimber.Location = new System.Drawing.Point(152, 43);
            this.numClimber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numClimber.Name = "numClimber";
            this.numClimber.Size = new System.Drawing.Size(64, 26);
            this.numClimber.TabIndex = 6;
            this.numClimber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numClimber.ValueChanged += new System.EventHandler(this.num_Skill_ValueChanged);
            this.numClimber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_Skill_KeyDown);
            this.numClimber.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // tabPieces
            // 
            this.tabPieces.Controls.Add(this.btnFlipSpawnDirection);
            this.tabPieces.Controls.Add(this.btnLoadStyle);
            this.tabPieces.Controls.Add(this.checkNegativeSteel);
            this.tabPieces.Controls.Add(this.lblRulerHeight);
            this.tabPieces.Controls.Add(this.lblRulerWidth);
            this.tabPieces.Controls.Add(this.lblSteelAreaHeight);
            this.tabPieces.Controls.Add(this.lblSteelAreaWidth);
            this.tabPieces.Controls.Add(this.checkFake);
            this.tabPieces.Controls.Add(this.checkInvisible);
            this.tabPieces.Controls.Add(this.lblPieceSize);
            this.tabPieces.Controls.Add(this.lblSize);
            this.tabPieces.Controls.Add(this.lblName);
            this.tabPieces.Controls.Add(this.lblPieceType);
            this.tabPieces.Controls.Add(this.lblStyle);
            this.tabPieces.Controls.Add(this.lblPieceStyle);
            this.tabPieces.Controls.Add(this.lblType);
            this.tabPieces.Controls.Add(this.lblPieceName);
            this.tabPieces.Controls.Add(this.checkAllowOneWay);
            this.tabPieces.Controls.Add(this.checkOnlyOnTerrain);
            this.tabPieces.Controls.Add(this.checkNoOverwrite);
            this.tabPieces.Controls.Add(this.checkErase);
            this.tabPieces.Controls.Add(this.numRulerHeight);
            this.tabPieces.Controls.Add(this.numRulerWidth);
            this.tabPieces.Controls.Add(this.numSteelAreaHeight);
            this.tabPieces.Controls.Add(this.numSteelAreaWidth);
            this.tabPieces.Controls.Add(this.btnDrawSooner);
            this.tabPieces.Controls.Add(this.btnDrawLater);
            this.tabPieces.Controls.Add(this.btnDrawFirst);
            this.tabPieces.Controls.Add(this.btnDrawLast);
            this.tabPieces.Controls.Add(this.btnFlip);
            this.tabPieces.Controls.Add(this.btnInvert);
            this.tabPieces.Controls.Add(this.btnRotate);
            this.tabPieces.Location = new System.Drawing.Point(4, 29);
            this.tabPieces.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPieces.Name = "tabPieces";
            this.tabPieces.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPieces.Size = new System.Drawing.Size(388, 787);
            this.tabPieces.TabIndex = 1;
            this.tabPieces.Text = "Pieces";
            this.tabPieces.UseVisualStyleBackColor = true;
            // 
            // btnFlipSpawnDirection
            // 
            this.btnFlipSpawnDirection.Location = new System.Drawing.Point(11, 139);
            this.btnFlipSpawnDirection.Name = "btnFlipSpawnDirection";
            this.btnFlipSpawnDirection.Size = new System.Drawing.Size(361, 50);
            this.btnFlipSpawnDirection.TabIndex = 81;
            this.btnFlipSpawnDirection.Text = "←   Flip Spawn Direction   →";
            this.btnFlipSpawnDirection.UseVisualStyleBackColor = true;
            this.btnFlipSpawnDirection.Click += new System.EventHandler(this.btnFlipSpawnDirection_Click);
            // 
            // btnLoadStyle
            // 
            this.btnLoadStyle.Location = new System.Drawing.Point(21, 732);
            this.btnLoadStyle.Name = "btnLoadStyle";
            this.btnLoadStyle.Size = new System.Drawing.Size(345, 47);
            this.btnLoadStyle.TabIndex = 80;
            this.btnLoadStyle.Text = "Load Style of Selected Piece";
            this.btnLoadStyle.UseVisualStyleBackColor = true;
            this.btnLoadStyle.Click += new System.EventHandler(this.btnLoadStyle_Click);
            // 
            // checkNegativeSteel
            // 
            this.checkNegativeSteel.AutoSize = true;
            this.checkNegativeSteel.Location = new System.Drawing.Point(196, 542);
            this.checkNegativeSteel.Name = "checkNegativeSteel";
            this.checkNegativeSteel.Size = new System.Drawing.Size(138, 24);
            this.checkNegativeSteel.TabIndex = 79;
            this.checkNegativeSteel.Text = "Negative Steel";
            this.checkNegativeSteel.UseVisualStyleBackColor = true;
            this.checkNegativeSteel.Visible = false;
            this.checkNegativeSteel.CheckedChanged += new System.EventHandler(this.check_Pieces_NegativeSteel_CheckedChanged);
            // 
            // lblRulerHeight
            // 
            this.lblRulerHeight.AutoSize = true;
            this.lblRulerHeight.Location = new System.Drawing.Point(17, 688);
            this.lblRulerHeight.Name = "lblRulerHeight";
            this.lblRulerHeight.Size = new System.Drawing.Size(56, 20);
            this.lblRulerHeight.TabIndex = 76;
            this.lblRulerHeight.Text = "Height";
            this.lblRulerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRulerHeight.Visible = false;
            // 
            // lblRulerWidth
            // 
            this.lblRulerWidth.AutoSize = true;
            this.lblRulerWidth.Location = new System.Drawing.Point(17, 649);
            this.lblRulerWidth.Name = "lblRulerWidth";
            this.lblRulerWidth.Size = new System.Drawing.Size(50, 20);
            this.lblRulerWidth.TabIndex = 75;
            this.lblRulerWidth.Text = "Width";
            this.lblRulerWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRulerWidth.Visible = false;
            // 
            // lblSteelAreaHeight
            // 
            this.lblSteelAreaHeight.AutoSize = true;
            this.lblSteelAreaHeight.Location = new System.Drawing.Point(17, 582);
            this.lblSteelAreaHeight.Name = "lblSteelAreaHeight";
            this.lblSteelAreaHeight.Size = new System.Drawing.Size(56, 20);
            this.lblSteelAreaHeight.TabIndex = 72;
            this.lblSteelAreaHeight.Text = "Height";
            this.lblSteelAreaHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSteelAreaHeight.Visible = false;
            // 
            // lblSteelAreaWidth
            // 
            this.lblSteelAreaWidth.AutoSize = true;
            this.lblSteelAreaWidth.Location = new System.Drawing.Point(17, 543);
            this.lblSteelAreaWidth.Name = "lblSteelAreaWidth";
            this.lblSteelAreaWidth.Size = new System.Drawing.Size(50, 20);
            this.lblSteelAreaWidth.TabIndex = 71;
            this.lblSteelAreaWidth.Text = "Width";
            this.lblSteelAreaWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSteelAreaWidth.Visible = false;
            // 
            // checkFake
            // 
            this.checkFake.AutoSize = true;
            this.checkFake.Location = new System.Drawing.Point(21, 368);
            this.checkFake.Name = "checkFake";
            this.checkFake.Size = new System.Drawing.Size(71, 24);
            this.checkFake.TabIndex = 68;
            this.checkFake.Text = "Fake";
            this.checkFake.UseVisualStyleBackColor = true;
            this.checkFake.CheckedChanged += new System.EventHandler(this.check_Pieces_Fake_CheckedChanged);
            // 
            // checkInvisible
            // 
            this.checkInvisible.AutoSize = true;
            this.checkInvisible.Location = new System.Drawing.Point(21, 342);
            this.checkInvisible.Name = "checkInvisible";
            this.checkInvisible.Size = new System.Drawing.Size(91, 24);
            this.checkInvisible.TabIndex = 67;
            this.checkInvisible.Text = "Invisible";
            this.checkInvisible.UseVisualStyleBackColor = true;
            this.checkInvisible.CheckedChanged += new System.EventHandler(this.check_Pieces_Invisible_CheckedChanged);
            // 
            // lblPieceSize
            // 
            this.lblPieceSize.AutoSize = true;
            this.lblPieceSize.Location = new System.Drawing.Point(80, 494);
            this.lblPieceSize.Name = "lblPieceSize";
            this.lblPieceSize.Size = new System.Drawing.Size(84, 20);
            this.lblPieceSize.TabIndex = 66;
            this.lblPieceSize.Text = "piece_size";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(17, 494);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(44, 20);
            this.lblSize.TabIndex = 65;
            this.lblSize.Text = "Size:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(17, 422);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 20);
            this.lblName.TabIndex = 59;
            this.lblName.Text = "Name:";
            // 
            // lblPieceType
            // 
            this.lblPieceType.AutoSize = true;
            this.lblPieceType.Location = new System.Drawing.Point(80, 470);
            this.lblPieceType.Name = "lblPieceType";
            this.lblPieceType.Size = new System.Drawing.Size(86, 20);
            this.lblPieceType.TabIndex = 64;
            this.lblPieceType.Text = "piece_type";
            // 
            // lblStyle
            // 
            this.lblStyle.AutoSize = true;
            this.lblStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStyle.Location = new System.Drawing.Point(17, 446);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(48, 20);
            this.lblStyle.TabIndex = 60;
            this.lblStyle.Text = "Style:";
            // 
            // lblPieceStyle
            // 
            this.lblPieceStyle.AutoSize = true;
            this.lblPieceStyle.Location = new System.Drawing.Point(80, 446);
            this.lblPieceStyle.Name = "lblPieceStyle";
            this.lblPieceStyle.Size = new System.Drawing.Size(88, 20);
            this.lblPieceStyle.TabIndex = 63;
            this.lblPieceStyle.Text = "piece_style";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(17, 470);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(47, 20);
            this.lblType.TabIndex = 61;
            this.lblType.Text = "Type:";
            // 
            // lblPieceName
            // 
            this.lblPieceName.AutoSize = true;
            this.lblPieceName.Location = new System.Drawing.Point(80, 422);
            this.lblPieceName.Name = "lblPieceName";
            this.lblPieceName.Size = new System.Drawing.Size(96, 20);
            this.lblPieceName.TabIndex = 62;
            this.lblPieceName.Text = "piece_name";
            // 
            // checkAllowOneWay
            // 
            this.checkAllowOneWay.Location = new System.Drawing.Point(21, 285);
            this.checkAllowOneWay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkAllowOneWay.Name = "checkAllowOneWay";
            this.checkAllowOneWay.Size = new System.Drawing.Size(154, 26);
            this.checkAllowOneWay.TabIndex = 12;
            this.checkAllowOneWay.Text = "Allow One-Way";
            this.checkAllowOneWay.UseVisualStyleBackColor = true;
            this.checkAllowOneWay.CheckedChanged += new System.EventHandler(this.check_Pieces_OneWay_CheckedChanged);
            // 
            // checkOnlyOnTerrain
            // 
            this.checkOnlyOnTerrain.Location = new System.Drawing.Point(21, 259);
            this.checkOnlyOnTerrain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkOnlyOnTerrain.Name = "checkOnlyOnTerrain";
            this.checkOnlyOnTerrain.Size = new System.Drawing.Size(154, 26);
            this.checkOnlyOnTerrain.TabIndex = 11;
            this.checkOnlyOnTerrain.Text = "Only On Terrain";
            this.checkOnlyOnTerrain.UseVisualStyleBackColor = true;
            this.checkOnlyOnTerrain.CheckedChanged += new System.EventHandler(this.check_Pieces_OnlyOnTerrain_CheckedChanged);
            // 
            // checkNoOverwrite
            // 
            this.checkNoOverwrite.Location = new System.Drawing.Point(21, 233);
            this.checkNoOverwrite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkNoOverwrite.Name = "checkNoOverwrite";
            this.checkNoOverwrite.Size = new System.Drawing.Size(154, 26);
            this.checkNoOverwrite.TabIndex = 10;
            this.checkNoOverwrite.Text = "No Overwrite";
            this.checkNoOverwrite.UseVisualStyleBackColor = true;
            this.checkNoOverwrite.CheckedChanged += new System.EventHandler(this.check_Pieces_NoOv_CheckedChanged);
            // 
            // checkErase
            // 
            this.checkErase.Location = new System.Drawing.Point(21, 206);
            this.checkErase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkErase.Name = "checkErase";
            this.checkErase.Size = new System.Drawing.Size(154, 26);
            this.checkErase.TabIndex = 9;
            this.checkErase.Text = "Erase Terrain";
            this.checkErase.UseVisualStyleBackColor = true;
            this.checkErase.CheckedChanged += new System.EventHandler(this.check_Pieces_Erase_CheckedChanged);
            // 
            // numRulerHeight
            // 
            this.numRulerHeight.Location = new System.Drawing.Point(85, 686);
            this.numRulerHeight.Maximum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.numRulerHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRulerHeight.Name = "numRulerHeight";
            this.numRulerHeight.Size = new System.Drawing.Size(82, 26);
            this.numRulerHeight.TabIndex = 78;
            this.numRulerHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRulerHeight.Value = new decimal(new int[] {
            126,
            0,
            0,
            0});
            this.numRulerHeight.Visible = false;
            this.numRulerHeight.ValueChanged += new System.EventHandler(this.num_RulerHeight_ValueChanged);
            this.numRulerHeight.Click += new System.EventHandler(this.num_RulerHeight_ValueChanged);
            this.numRulerHeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.num_RulerHeight_KeyUp);
            // 
            // numRulerWidth
            // 
            this.numRulerWidth.Location = new System.Drawing.Point(85, 647);
            this.numRulerWidth.Maximum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.numRulerWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRulerWidth.Name = "numRulerWidth";
            this.numRulerWidth.Size = new System.Drawing.Size(82, 26);
            this.numRulerWidth.TabIndex = 77;
            this.numRulerWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRulerWidth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numRulerWidth.Visible = false;
            this.numRulerWidth.ValueChanged += new System.EventHandler(this.num_RulerWidth_ValueChanged);
            this.numRulerWidth.Click += new System.EventHandler(this.num_RulerWidth_ValueChanged);
            this.numRulerWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.num_RulerWidth_KeyUp);
            // 
            // numSteelAreaHeight
            // 
            this.numSteelAreaHeight.Location = new System.Drawing.Point(85, 580);
            this.numSteelAreaHeight.Maximum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.numSteelAreaHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSteelAreaHeight.Name = "numSteelAreaHeight";
            this.numSteelAreaHeight.Size = new System.Drawing.Size(82, 26);
            this.numSteelAreaHeight.TabIndex = 74;
            this.numSteelAreaHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSteelAreaHeight.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numSteelAreaHeight.Visible = false;
            this.numSteelAreaHeight.ValueChanged += new System.EventHandler(this.num_SteelAreaHeight_ValueChanged);
            this.numSteelAreaHeight.Click += new System.EventHandler(this.num_SteelAreaHeight_ValueChanged);
            this.numSteelAreaHeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.num_SteelAreaHeight_KeyUp);
            // 
            // numSteelAreaWidth
            // 
            this.numSteelAreaWidth.Location = new System.Drawing.Point(85, 541);
            this.numSteelAreaWidth.Maximum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.numSteelAreaWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSteelAreaWidth.Name = "numSteelAreaWidth";
            this.numSteelAreaWidth.Size = new System.Drawing.Size(82, 26);
            this.numSteelAreaWidth.TabIndex = 73;
            this.numSteelAreaWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSteelAreaWidth.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numSteelAreaWidth.Visible = false;
            this.numSteelAreaWidth.ValueChanged += new System.EventHandler(this.num_SteelAreaWidth_ValueChanged);
            this.numSteelAreaWidth.Click += new System.EventHandler(this.num_SteelAreaWidth_ValueChanged);
            this.numSteelAreaWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.num_SteelAreaHeight_KeyUp);
            // 
            // btnDrawSooner
            // 
            this.btnDrawSooner.Location = new System.Drawing.Point(183, 73);
            this.btnDrawSooner.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDrawSooner.Name = "btnDrawSooner";
            this.btnDrawSooner.NoPaddingText = "Draw Sooner";
            this.btnDrawSooner.Size = new System.Drawing.Size(100, 53);
            this.btnDrawSooner.TabIndex = 5;
            this.btnDrawSooner.UseVisualStyleBackColor = true;
            this.btnDrawSooner.Click += new System.EventHandler(this.btnMoveBackOne_Click);
            this.btnDrawSooner.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMoveBackOne_MouseUp);
            // 
            // btnDrawLater
            // 
            this.btnDrawLater.Location = new System.Drawing.Point(95, 73);
            this.btnDrawLater.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDrawLater.Name = "btnDrawLater";
            this.btnDrawLater.NoPaddingText = "Draw Later";
            this.btnDrawLater.Size = new System.Drawing.Size(84, 53);
            this.btnDrawLater.TabIndex = 4;
            this.btnDrawLater.UseVisualStyleBackColor = true;
            this.btnDrawLater.Click += new System.EventHandler(this.btnMoveFrontOne_Click);
            this.btnDrawLater.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMoveFrontOne_MouseUp);
            // 
            // btnDrawFirst
            // 
            this.btnDrawFirst.Location = new System.Drawing.Point(292, 73);
            this.btnDrawFirst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDrawFirst.Name = "btnDrawFirst";
            this.btnDrawFirst.NoPaddingText = "Draw First";
            this.btnDrawFirst.Size = new System.Drawing.Size(80, 53);
            this.btnDrawFirst.TabIndex = 6;
            this.btnDrawFirst.UseVisualStyleBackColor = true;
            this.btnDrawFirst.Click += new System.EventHandler(this.btnMoveBack_Click);
            // 
            // btnDrawLast
            // 
            this.btnDrawLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrawLast.Location = new System.Drawing.Point(11, 73);
            this.btnDrawLast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDrawLast.Name = "btnDrawLast";
            this.btnDrawLast.NoPaddingText = "Draw Last";
            this.btnDrawLast.Size = new System.Drawing.Size(74, 53);
            this.btnDrawLast.TabIndex = 3;
            this.btnDrawLast.UseVisualStyleBackColor = true;
            this.btnDrawLast.Click += new System.EventHandler(this.btnMoveFront_Click);
            // 
            // btnFlip
            // 
            this.btnFlip.Location = new System.Drawing.Point(255, 13);
            this.btnFlip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFlip.Name = "btnFlip";
            this.btnFlip.NoPaddingText = null;
            this.btnFlip.Size = new System.Drawing.Size(117, 50);
            this.btnFlip.TabIndex = 2;
            this.btnFlip.Text = "Flip";
            this.btnFlip.UseVisualStyleBackColor = true;
            this.btnFlip.Click += new System.EventHandler(this.btnFlipPieces_Click);
            this.btnFlip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnFlipPieces_MouseUp);
            // 
            // btnInvert
            // 
            this.btnInvert.Location = new System.Drawing.Point(128, 13);
            this.btnInvert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.NoPaddingText = null;
            this.btnInvert.Size = new System.Drawing.Size(120, 50);
            this.btnInvert.TabIndex = 1;
            this.btnInvert.Text = "Invert";
            this.btnInvert.UseVisualStyleBackColor = true;
            this.btnInvert.Click += new System.EventHandler(this.btnInvertPieces_Click);
            this.btnInvert.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnInvertPieces_MouseUp);
            // 
            // btnRotate
            // 
            this.btnRotate.Location = new System.Drawing.Point(11, 13);
            this.btnRotate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.NoPaddingText = null;
            this.btnRotate.Size = new System.Drawing.Size(110, 50);
            this.btnRotate.TabIndex = 0;
            this.btnRotate.Text = "Rotate";
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.Click += new System.EventHandler(this.btnRotatePieces_Click);
            this.btnRotate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRotatePieces_MouseUp);
            // 
            // tabGlobals
            // 
            this.tabGlobals.Controls.Add(this.btnCancelCrop);
            this.tabGlobals.Controls.Add(this.btnApplyCrop);
            this.tabGlobals.Controls.Add(this.btnCropLevel);
            this.tabGlobals.Controls.Add(this.numReleaseRateMax);
            this.tabGlobals.Controls.Add(this.lblReleaseRateMax);
            this.tabGlobals.Controls.Add(this.lblReleaseRateMin);
            this.tabGlobals.Controls.Add(this.comboMainStyle);
            this.tabGlobals.Controls.Add(this.lblMainStyle);
            this.tabGlobals.Controls.Add(this.checkAutoSteel);
            this.tabGlobals.Controls.Add(this.comboSteelMode);
            this.tabGlobals.Controls.Add(this.lblSteelMode);
            this.tabGlobals.Controls.Add(this.checkTimeLimit);
            this.tabGlobals.Controls.Add(this.checkLockReleaseRate);
            this.tabGlobals.Controls.Add(this.checkAutoStart);
            this.tabGlobals.Controls.Add(this.lblLevelVersion);
            this.tabGlobals.Controls.Add(this.txtLevelAuthor);
            this.tabGlobals.Controls.Add(this.txtLevelTitle);
            this.tabGlobals.Controls.Add(this.lblStartY);
            this.tabGlobals.Controls.Add(this.lblStartX);
            this.tabGlobals.Controls.Add(this.lblHeight);
            this.tabGlobals.Controls.Add(this.comboMusic);
            this.tabGlobals.Controls.Add(this.numTimeSecs);
            this.tabGlobals.Controls.Add(this.numTimeMins);
            this.tabGlobals.Controls.Add(this.numReleaseRateMin);
            this.tabGlobals.Controls.Add(this.numRescue);
            this.tabGlobals.Controls.Add(this.lblRescue);
            this.tabGlobals.Controls.Add(this.numLemmings);
            this.tabGlobals.Controls.Add(this.lblLemmings);
            this.tabGlobals.Controls.Add(this.numStartY);
            this.tabGlobals.Controls.Add(this.numStartX);
            this.tabGlobals.Controls.Add(this.numHeight);
            this.tabGlobals.Controls.Add(this.numWidth);
            this.tabGlobals.Controls.Add(this.lblMusic);
            this.tabGlobals.Controls.Add(this.lblAuthor);
            this.tabGlobals.Controls.Add(this.lblTitle);
            this.tabGlobals.Controls.Add(this.lblWidth);
            this.tabGlobals.Location = new System.Drawing.Point(4, 29);
            this.tabGlobals.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabGlobals.Name = "tabGlobals";
            this.tabGlobals.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabGlobals.Size = new System.Drawing.Size(388, 787);
            this.tabGlobals.TabIndex = 0;
            this.tabGlobals.Text = "Globals";
            this.tabGlobals.UseVisualStyleBackColor = true;
            // 
            // btnCancelCrop
            // 
            this.btnCancelCrop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelCrop.Location = new System.Drawing.Point(249, 250);
            this.btnCancelCrop.Name = "btnCancelCrop";
            this.btnCancelCrop.Size = new System.Drawing.Size(100, 32);
            this.btnCancelCrop.TabIndex = 105;
            this.btnCancelCrop.Tag = "Cancel crop and close the rectangle";
            this.btnCancelCrop.Text = "Cancel";
            this.btnCancelCrop.UseVisualStyleBackColor = true;
            this.btnCancelCrop.Visible = false;
            this.btnCancelCrop.Click += new System.EventHandler(this.btnCancelCrop_Click);
            // 
            // btnApplyCrop
            // 
            this.btnApplyCrop.ForeColor = System.Drawing.Color.Blue;
            this.btnApplyCrop.Location = new System.Drawing.Point(140, 250);
            this.btnApplyCrop.Name = "btnApplyCrop";
            this.btnApplyCrop.Size = new System.Drawing.Size(100, 32);
            this.btnApplyCrop.TabIndex = 104;
            this.btnApplyCrop.Tag = "Apply crop rectangle as new width and height";
            this.btnApplyCrop.Text = "Apply";
            this.btnApplyCrop.UseVisualStyleBackColor = true;
            this.btnApplyCrop.Visible = false;
            this.btnApplyCrop.Click += new System.EventHandler(this.btnApplyCrop_Click);
            // 
            // btnCropLevel
            // 
            this.btnCropLevel.Location = new System.Drawing.Point(28, 250);
            this.btnCropLevel.Name = "btnCropLevel";
            this.btnCropLevel.Size = new System.Drawing.Size(100, 32);
            this.btnCropLevel.TabIndex = 103;
            this.btnCropLevel.Tag = "Activate crop rectangle to easily change the width and height of the level";
            this.btnCropLevel.Text = "Crop";
            this.btnCropLevel.UseVisualStyleBackColor = true;
            this.btnCropLevel.Click += new System.EventHandler(this.btnCropLevel_Click);
            this.btnCropLevel.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnCropLevel.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            // 
            // numReleaseRateMax
            // 
            this.numReleaseRateMax.Location = new System.Drawing.Point(279, 483);
            this.numReleaseRateMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numReleaseRateMax.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numReleaseRateMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numReleaseRateMax.Name = "numReleaseRateMax";
            this.numReleaseRateMax.Size = new System.Drawing.Size(70, 26);
            this.numReleaseRateMax.TabIndex = 102;
            this.numReleaseRateMax.Tag = "Set the maximum release rate";
            this.numReleaseRateMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numReleaseRateMax.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numReleaseRateMax.ValueChanged += new System.EventHandler(this.num_Lvl_RRMax_ValueChanged);
            this.numReleaseRateMax.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // lblReleaseRateMax
            // 
            this.lblReleaseRateMax.AutoSize = true;
            this.lblReleaseRateMax.Location = new System.Drawing.Point(209, 485);
            this.lblReleaseRateMax.Name = "lblReleaseRateMax";
            this.lblReleaseRateMax.Size = new System.Drawing.Size(66, 20);
            this.lblReleaseRateMax.TabIndex = 101;
            this.lblReleaseRateMax.Text = "Max RR";
            // 
            // lblReleaseRateMin
            // 
            this.lblReleaseRateMin.AutoSize = true;
            this.lblReleaseRateMin.Location = new System.Drawing.Point(24, 485);
            this.lblReleaseRateMin.Name = "lblReleaseRateMin";
            this.lblReleaseRateMin.Size = new System.Drawing.Size(62, 20);
            this.lblReleaseRateMin.TabIndex = 100;
            this.lblReleaseRateMin.Text = "Min RR";
            // 
            // comboMainStyle
            // 
            this.comboMainStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMainStyle.FormattingEnabled = true;
            this.comboMainStyle.ItemHeight = 20;
            this.comboMainStyle.Location = new System.Drawing.Point(68, 156);
            this.comboMainStyle.MaxDropDownItems = 30;
            this.comboMainStyle.Name = "comboMainStyle";
            this.comboMainStyle.Size = new System.Drawing.Size(301, 28);
            this.comboMainStyle.TabIndex = 94;
            this.comboMainStyle.Tag = "Choose a main style for your level";
            this.comboMainStyle.SelectedIndexChanged += new System.EventHandler(this.combo_MainStyle_TextChanged);
            this.comboMainStyle.DropDownClosed += new System.EventHandler(this.ComboDropDownClosed);
            this.comboMainStyle.TextChanged += new System.EventHandler(this.combo_MainStyle_TextChanged);
            this.comboMainStyle.Leave += new System.EventHandler(this.textbox_Leave);
            this.comboMainStyle.MouseEnter += new System.EventHandler(this.ComboMouseEnter);
            this.comboMainStyle.MouseLeave += new System.EventHandler(this.ComboMouseLeave);
            // 
            // lblMainStyle
            // 
            this.lblMainStyle.Location = new System.Drawing.Point(9, 161);
            this.lblMainStyle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMainStyle.Name = "lblMainStyle";
            this.lblMainStyle.Size = new System.Drawing.Size(69, 23);
            this.lblMainStyle.TabIndex = 93;
            this.lblMainStyle.Text = "Style";
            this.lblMainStyle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkAutoSteel
            // 
            this.checkAutoSteel.AutoSize = true;
            this.checkAutoSteel.Location = new System.Drawing.Point(28, 653);
            this.checkAutoSteel.Name = "checkAutoSteel";
            this.checkAutoSteel.Size = new System.Drawing.Size(148, 24);
            this.checkAutoSteel.TabIndex = 91;
            this.checkAutoSteel.Tag = "With automatic steel checked, steel pieces do not require a manually-applied stee" +
    "l area";
            this.checkAutoSteel.Text = "Automatic Steel";
            this.checkAutoSteel.UseVisualStyleBackColor = true;
            this.checkAutoSteel.CheckedChanged += new System.EventHandler(this.textbox_Leave);
            // 
            // comboSteelMode
            // 
            this.comboSteelMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSteelMode.Enabled = false;
            this.comboSteelMode.FormattingEnabled = true;
            this.comboSteelMode.Items.AddRange(new object[] {
            "Auto (Fit to Shape)",
            "Auto (Visible Pixels Only)",
            "Manual"});
            this.comboSteelMode.Location = new System.Drawing.Point(297, 651);
            this.comboSteelMode.Name = "comboSteelMode";
            this.comboSteelMode.Size = new System.Drawing.Size(52, 28);
            this.comboSteelMode.TabIndex = 90;
            this.comboSteelMode.Visible = false;
            this.comboSteelMode.DropDownClosed += new System.EventHandler(this.ComboDropDownClosed);
            this.comboSteelMode.Leave += new System.EventHandler(this.textbox_Leave);
            this.comboSteelMode.MouseEnter += new System.EventHandler(this.ComboMouseEnter);
            this.comboSteelMode.MouseLeave += new System.EventHandler(this.ComboMouseLeave);
            // 
            // lblSteelMode
            // 
            this.lblSteelMode.AutoSize = true;
            this.lblSteelMode.Enabled = false;
            this.lblSteelMode.Location = new System.Drawing.Point(201, 654);
            this.lblSteelMode.Name = "lblSteelMode";
            this.lblSteelMode.Size = new System.Drawing.Size(90, 20);
            this.lblSteelMode.TabIndex = 89;
            this.lblSteelMode.Text = "Steel Mode";
            this.lblSteelMode.Visible = false;
            // 
            // checkTimeLimit
            // 
            this.checkTimeLimit.AutoSize = true;
            this.checkTimeLimit.Location = new System.Drawing.Point(28, 586);
            this.checkTimeLimit.Name = "checkTimeLimit";
            this.checkTimeLimit.Size = new System.Drawing.Size(106, 24);
            this.checkTimeLimit.TabIndex = 32;
            this.checkTimeLimit.Tag = "Apply a time limit, or leave this unchecked for infinite time";
            this.checkTimeLimit.Text = "Time Limit";
            this.checkTimeLimit.UseVisualStyleBackColor = true;
            this.checkTimeLimit.CheckedChanged += new System.EventHandler(this.textbox_Leave);
            // 
            // checkLockReleaseRate
            // 
            this.checkLockReleaseRate.AutoSize = true;
            this.checkLockReleaseRate.Location = new System.Drawing.Point(28, 521);
            this.checkLockReleaseRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkLockReleaseRate.Name = "checkLockReleaseRate";
            this.checkLockReleaseRate.Size = new System.Drawing.Size(171, 24);
            this.checkLockReleaseRate.TabIndex = 22;
            this.checkLockReleaseRate.Tag = "Lock the release rate (prevents it from being changed in-game)";
            this.checkLockReleaseRate.Text = "Lock Release Rate";
            this.checkLockReleaseRate.UseVisualStyleBackColor = true;
            this.checkLockReleaseRate.CheckedChanged += new System.EventHandler(this.check_Lvl_LockSR_CheckedChanged);
            // 
            // checkAutoStart
            // 
            this.checkAutoStart.AutoSize = true;
            this.checkAutoStart.Location = new System.Drawing.Point(28, 349);
            this.checkAutoStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkAutoStart.Name = "checkAutoStart";
            this.checkAutoStart.Size = new System.Drawing.Size(163, 24);
            this.checkAutoStart.TabIndex = 12;
            this.checkAutoStart.Tag = "Automatically set the start position";
            this.checkAutoStart.Text = "Auto Screen Start";
            this.checkAutoStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkAutoStart.UseVisualStyleBackColor = true;
            this.checkAutoStart.CheckedChanged += new System.EventHandler(this.chk_Lvl_AutoStart_Leave);
            // 
            // lblLevelVersion
            // 
            this.lblLevelVersion.AutoSize = true;
            this.lblLevelVersion.Location = new System.Drawing.Point(24, 717);
            this.lblLevelVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLevelVersion.Name = "lblLevelVersion";
            this.lblLevelVersion.Size = new System.Drawing.Size(117, 20);
            this.lblLevelVersion.TabIndex = 31;
            this.lblLevelVersion.Text = "Level Version 0";
            this.lblLevelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLevelAuthor
            // 
            this.txtLevelAuthor.Location = new System.Drawing.Point(67, 63);
            this.txtLevelAuthor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLevelAuthor.MaxLength = 54;
            this.txtLevelAuthor.Name = "txtLevelAuthor";
            this.txtLevelAuthor.Size = new System.Drawing.Size(302, 26);
            this.txtLevelAuthor.TabIndex = 3;
            this.txtLevelAuthor.Tag = "Enter an author name";
            this.txtLevelAuthor.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // txtLevelTitle
            // 
            this.txtLevelTitle.Location = new System.Drawing.Point(67, 15);
            this.txtLevelTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLevelTitle.MaxLength = 54;
            this.txtLevelTitle.Name = "txtLevelTitle";
            this.txtLevelTitle.Size = new System.Drawing.Size(302, 26);
            this.txtLevelTitle.TabIndex = 1;
            this.txtLevelTitle.Tag = "Enter a title for your level";
            this.txtLevelTitle.TextChanged += new System.EventHandler(this.txtLevelTitle_TextChanged);
            this.txtLevelTitle.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // lblStartY
            // 
            this.lblStartY.AutoSize = true;
            this.lblStartY.Location = new System.Drawing.Point(209, 313);
            this.lblStartY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartY.Name = "lblStartY";
            this.lblStartY.Size = new System.Drawing.Size(59, 20);
            this.lblStartY.TabIndex = 16;
            this.lblStartY.Text = "Start Y";
            this.lblStartY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartX
            // 
            this.lblStartX.AutoSize = true;
            this.lblStartX.Location = new System.Drawing.Point(24, 313);
            this.lblStartX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartX.Name = "lblStartX";
            this.lblStartX.Size = new System.Drawing.Size(59, 20);
            this.lblStartX.TabIndex = 13;
            this.lblStartX.Text = "Start X";
            this.lblStartX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(209, 218);
            this.lblHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(56, 20);
            this.lblHeight.TabIndex = 11;
            this.lblHeight.Text = "Height";
            this.lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboMusic
            // 
            this.comboMusic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMusic.FormattingEnabled = true;
            this.comboMusic.Location = new System.Drawing.Point(68, 108);
            this.comboMusic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboMusic.Name = "comboMusic";
            this.comboMusic.Size = new System.Drawing.Size(302, 28);
            this.comboMusic.TabIndex = 5;
            this.comboMusic.Tag = "Choose a music track for your level (note that you can also set music for a full " +
    "pack of levels using the Level Pack Compiler)";
            this.comboMusic.DropDownClosed += new System.EventHandler(this.ComboDropDownClosed);
            this.comboMusic.Leave += new System.EventHandler(this.textbox_Leave);
            this.comboMusic.MouseEnter += new System.EventHandler(this.ComboMouseEnter);
            this.comboMusic.MouseLeave += new System.EventHandler(this.ComboMouseLeave);
            // 
            // numTimeSecs
            // 
            this.numTimeSecs.Location = new System.Drawing.Point(279, 585);
            this.numTimeSecs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numTimeSecs.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numTimeSecs.Name = "numTimeSecs";
            this.numTimeSecs.Size = new System.Drawing.Size(70, 26);
            this.numTimeSecs.TabIndex = 27;
            this.numTimeSecs.Tag = "Set the numbr of seconds for the time limit";
            this.numTimeSecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTimeSecs.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // numTimeMins
            // 
            this.numTimeMins.Location = new System.Drawing.Point(192, 585);
            this.numTimeMins.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numTimeMins.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numTimeMins.Name = "numTimeMins";
            this.numTimeMins.Size = new System.Drawing.Size(70, 26);
            this.numTimeMins.TabIndex = 26;
            this.numTimeMins.Tag = "Set the number of minutes for the time limit";
            this.numTimeMins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTimeMins.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // numReleaseRateMin
            // 
            this.numReleaseRateMin.Location = new System.Drawing.Point(114, 483);
            this.numReleaseRateMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numReleaseRateMin.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numReleaseRateMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numReleaseRateMin.Name = "numReleaseRateMin";
            this.numReleaseRateMin.Size = new System.Drawing.Size(70, 26);
            this.numReleaseRateMin.TabIndex = 24;
            this.numReleaseRateMin.Tag = "Set the minimum release rate";
            this.numReleaseRateMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numReleaseRateMin.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numReleaseRateMin.ValueChanged += new System.EventHandler(this.num_Lvl_RRMin_ValueChanged);
            this.numReleaseRateMin.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // numRescue
            // 
            this.numRescue.Location = new System.Drawing.Point(279, 410);
            this.numRescue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numRescue.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numRescue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRescue.Name = "numRescue";
            this.numRescue.Size = new System.Drawing.Size(70, 26);
            this.numRescue.TabIndex = 21;
            this.numRescue.Tag = "Set the amount of lemmings to be saved";
            this.numRescue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRescue.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numRescue.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // lblRescue
            // 
            this.lblRescue.AutoSize = true;
            this.lblRescue.Location = new System.Drawing.Point(209, 412);
            this.lblRescue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRescue.Name = "lblRescue";
            this.lblRescue.Size = new System.Drawing.Size(45, 20);
            this.lblRescue.TabIndex = 20;
            this.lblRescue.Text = "Save";
            this.lblRescue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numLemmings
            // 
            this.numLemmings.Location = new System.Drawing.Point(114, 410);
            this.numLemmings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numLemmings.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numLemmings.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLemmings.Name = "numLemmings";
            this.numLemmings.Size = new System.Drawing.Size(70, 26);
            this.numLemmings.TabIndex = 18;
            this.numLemmings.Tag = "Set the total number of lemmings";
            this.numLemmings.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLemmings.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numLemmings.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // lblLemmings
            // 
            this.lblLemmings.AutoSize = true;
            this.lblLemmings.Location = new System.Drawing.Point(24, 412);
            this.lblLemmings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLemmings.Name = "lblLemmings";
            this.lblLemmings.Size = new System.Drawing.Size(82, 20);
            this.lblLemmings.TabIndex = 17;
            this.lblLemmings.Text = "Lemmings";
            this.lblLemmings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numStartY
            // 
            this.numStartY.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numStartY.Location = new System.Drawing.Point(279, 311);
            this.numStartY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numStartY.Maximum = new decimal(new int[] {
            319,
            0,
            0,
            0});
            this.numStartY.Name = "numStartY";
            this.numStartY.Size = new System.Drawing.Size(70, 26);
            this.numStartY.TabIndex = 15;
            this.numStartY.Tag = "Set the vertical start position";
            this.numStartY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numStartY.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.numStartY.ValueChanged += new System.EventHandler(this.num_Lvl_StartY_ValueChanged);
            this.numStartY.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // numStartX
            // 
            this.numStartX.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numStartX.Location = new System.Drawing.Point(114, 311);
            this.numStartX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numStartX.Maximum = new decimal(new int[] {
            639,
            0,
            0,
            0});
            this.numStartX.Name = "numStartX";
            this.numStartX.Size = new System.Drawing.Size(70, 26);
            this.numStartX.TabIndex = 14;
            this.numStartX.Tag = "Set the horizontal start position";
            this.numStartX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numStartX.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numStartX.ValueChanged += new System.EventHandler(this.num_Lvl_StartX_ValueChanged);
            this.numStartX.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // numHeight
            // 
            this.numHeight.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numHeight.Location = new System.Drawing.Point(279, 216);
            this.numHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numHeight.Maximum = new decimal(new int[] {
            6400,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(70, 26);
            this.numHeight.TabIndex = 10;
            this.numHeight.Tag = "Set the level height";
            this.numHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numHeight.Value = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.numHeight.ValueChanged += new System.EventHandler(this.num_Lvl_SizeY_ValueChanged);
            this.numHeight.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // numWidth
            // 
            this.numWidth.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numWidth.Location = new System.Drawing.Point(114, 216);
            this.numWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numWidth.Maximum = new decimal(new int[] {
            6400,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(70, 26);
            this.numWidth.TabIndex = 9;
            this.numWidth.Tag = "Set the level width";
            this.numWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numWidth.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numWidth.ValueChanged += new System.EventHandler(this.num_Lvl_SizeX_ValueChanged);
            this.numWidth.Leave += new System.EventHandler(this.textbox_Leave);
            // 
            // lblMusic
            // 
            this.lblMusic.Location = new System.Drawing.Point(9, 113);
            this.lblMusic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMusic.Name = "lblMusic";
            this.lblMusic.Size = new System.Drawing.Size(69, 23);
            this.lblMusic.TabIndex = 4;
            this.lblMusic.Text = "Music";
            this.lblMusic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAuthor
            // 
            this.lblAuthor.Location = new System.Drawing.Point(9, 65);
            this.lblAuthor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(66, 23);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Author";
            this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(9, 17);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(69, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(24, 218);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(50, 20);
            this.lblWidth.TabIndex = 8;
            this.lblWidth.Tag = "";
            this.lblWidth.Text = "Width";
            this.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabProperties
            // 
            this.tabProperties.Controls.Add(this.tabGlobals);
            this.tabProperties.Controls.Add(this.tabPieces);
            this.tabProperties.Controls.Add(this.tabSkills);
            this.tabProperties.Controls.Add(this.tabExtras);
            this.tabProperties.Location = new System.Drawing.Point(9, 42);
            this.tabProperties.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.SelectedIndex = 0;
            this.tabProperties.Size = new System.Drawing.Size(396, 820);
            this.tabProperties.TabIndex = 1;
            this.tabProperties.TabStop = false;
            this.tabProperties.Click += new System.EventHandler(this.tabLvlProperties_Click);
            // 
            // tabExtras
            // 
            this.tabExtras.Controls.Add(this.checkDirectDrop);
            this.tabExtras.Controls.Add(this.btnLevelPackCompiler);
            this.tabExtras.Controls.Add(this.btnModsHelp);
            this.tabExtras.Controls.Add(this.comboMods);
            this.tabExtras.Controls.Add(this.lblMods);
            this.tabExtras.Controls.Add(this.btnHints);
            this.tabExtras.Controls.Add(this.lblMaxFallDistance);
            this.tabExtras.Controls.Add(this.checkForceNormalTimerSpeed);
            this.tabExtras.Controls.Add(this.checkSuperlemming);
            this.tabExtras.Controls.Add(this.numMaxFallDistance);
            this.tabExtras.Location = new System.Drawing.Point(4, 29);
            this.tabExtras.Name = "tabExtras";
            this.tabExtras.Size = new System.Drawing.Size(388, 787);
            this.tabExtras.TabIndex = 3;
            this.tabExtras.Text = "Extras";
            this.tabExtras.UseVisualStyleBackColor = true;
            // 
            // checkDirectDrop
            // 
            this.checkDirectDrop.AutoSize = true;
            this.checkDirectDrop.Location = new System.Drawing.Point(33, 215);
            this.checkDirectDrop.Name = "checkDirectDrop";
            this.checkDirectDrop.Size = new System.Drawing.Size(177, 24);
            this.checkDirectDrop.TabIndex = 109;
            this.checkDirectDrop.Text = "Activate Direct Drop";
            this.checkDirectDrop.UseVisualStyleBackColor = true;
            this.checkDirectDrop.CheckedChanged += new System.EventHandler(this.textbox_Leave);
            // 
            // btnLevelPackCompiler
            // 
            this.btnLevelPackCompiler.Location = new System.Drawing.Point(33, 25);
            this.btnLevelPackCompiler.Name = "btnLevelPackCompiler";
            this.btnLevelPackCompiler.Size = new System.Drawing.Size(321, 50);
            this.btnLevelPackCompiler.TabIndex = 108;
            this.btnLevelPackCompiler.Text = "Level Pack Compiler";
            this.btnLevelPackCompiler.UseVisualStyleBackColor = true;
            this.btnLevelPackCompiler.Click += new System.EventHandler(this.btnLevelPackCompiler_Click);
            // 
            // btnModsHelp
            // 
            this.btnModsHelp.Location = new System.Drawing.Point(298, 119);
            this.btnModsHelp.Name = "btnModsHelp";
            this.btnModsHelp.Size = new System.Drawing.Size(56, 50);
            this.btnModsHelp.TabIndex = 107;
            this.btnModsHelp.Text = "?";
            this.btnModsHelp.UseVisualStyleBackColor = true;
            this.btnModsHelp.Click += new System.EventHandler(this.btnModsHelp_Click);
            // 
            // comboMods
            // 
            this.comboMods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMods.FormattingEnabled = true;
            this.comboMods.Location = new System.Drawing.Point(83, 127);
            this.comboMods.Name = "comboMods";
            this.comboMods.Size = new System.Drawing.Size(209, 28);
            this.comboMods.TabIndex = 106;
            this.comboMods.DropDownClosed += new System.EventHandler(this.combo_Mods_DropDownClosed);
            this.comboMods.Leave += new System.EventHandler(this.textbox_Leave);
            this.comboMods.MouseEnter += new System.EventHandler(this.ComboMouseEnter);
            this.comboMods.MouseLeave += new System.EventHandler(this.ComboMouseLeave);
            // 
            // lblMods
            // 
            this.lblMods.AutoSize = true;
            this.lblMods.Location = new System.Drawing.Point(29, 135);
            this.lblMods.Name = "lblMods";
            this.lblMods.Size = new System.Drawing.Size(48, 20);
            this.lblMods.TabIndex = 105;
            this.lblMods.Text = "Mods";
            // 
            // btnHints
            // 
            this.btnHints.Location = new System.Drawing.Point(33, 480);
            this.btnHints.Name = "btnHints";
            this.btnHints.Size = new System.Drawing.Size(321, 50);
            this.btnHints.TabIndex = 104;
            this.btnHints.Text = "Level Solution Hints";
            this.btnHints.UseVisualStyleBackColor = true;
            this.btnHints.Click += new System.EventHandler(this.btnHints_Click);
            // 
            // lblMaxFallDistance
            // 
            this.lblMaxFallDistance.AutoSize = true;
            this.lblMaxFallDistance.Location = new System.Drawing.Point(29, 396);
            this.lblMaxFallDistance.Name = "lblMaxFallDistance";
            this.lblMaxFallDistance.Size = new System.Drawing.Size(134, 20);
            this.lblMaxFallDistance.TabIndex = 100;
            this.lblMaxFallDistance.Text = "Max Fall Distance";
            // 
            // checkForceNormalTimerSpeed
            // 
            this.checkForceNormalTimerSpeed.AutoSize = true;
            this.checkForceNormalTimerSpeed.Checked = true;
            this.checkForceNormalTimerSpeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkForceNormalTimerSpeed.Enabled = false;
            this.checkForceNormalTimerSpeed.Location = new System.Drawing.Point(33, 322);
            this.checkForceNormalTimerSpeed.Name = "checkForceNormalTimerSpeed";
            this.checkForceNormalTimerSpeed.Size = new System.Drawing.Size(212, 24);
            this.checkForceNormalTimerSpeed.TabIndex = 97;
            this.checkForceNormalTimerSpeed.Text = "Use Normal Timer Speed";
            this.checkForceNormalTimerSpeed.UseVisualStyleBackColor = true;
            this.checkForceNormalTimerSpeed.CheckedChanged += new System.EventHandler(this.textbox_Leave);
            // 
            // checkSuperlemming
            // 
            this.checkSuperlemming.AutoSize = true;
            this.checkSuperlemming.Location = new System.Drawing.Point(33, 292);
            this.checkSuperlemming.Name = "checkSuperlemming";
            this.checkSuperlemming.Size = new System.Drawing.Size(242, 24);
            this.checkSuperlemming.TabIndex = 93;
            this.checkSuperlemming.Text = "Activate Superlemming Mode";
            this.checkSuperlemming.UseVisualStyleBackColor = true;
            this.checkSuperlemming.CheckedChanged += new System.EventHandler(this.check_Lvl_Superlemming_CheckedChanged);
            // 
            // numMaxFallDistance
            // 
            this.numMaxFallDistance.Location = new System.Drawing.Point(196, 394);
            this.numMaxFallDistance.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numMaxFallDistance.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numMaxFallDistance.Name = "numMaxFallDistance";
            this.numMaxFallDistance.Size = new System.Drawing.Size(68, 26);
            this.numMaxFallDistance.TabIndex = 101;
            this.numMaxFallDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMaxFallDistance.Value = new decimal(new int[] {
            126,
            0,
            0,
            0});
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblHint.Location = new System.Drawing.Point(405, 13);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(300, 20);
            this.lblHint.TabIndex = 88;
            this.lblHint.Text = "Shows hints when hovering over a control";
            this.lblHint.Visible = false;
            // 
            // lblUpdatingLPC
            // 
            this.lblUpdatingLPC.AutoSize = true;
            this.lblUpdatingLPC.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblUpdatingLPC.Location = new System.Drawing.Point(728, 13);
            this.lblUpdatingLPC.Name = "lblUpdatingLPC";
            this.lblUpdatingLPC.Size = new System.Drawing.Size(232, 20);
            this.lblUpdatingLPC.TabIndex = 89;
            this.lblUpdatingLPC.Text = "Updating Level Pack Compiler...";
            this.lblUpdatingLPC.Visible = false;
            this.lblUpdatingLPC.Click += new System.EventHandler(this.lblUpdatingLPC_Click);
            this.lblUpdatingLPC.MouseEnter += new System.EventHandler(this.lblUpdatingLPC_MouseEnter);
            this.lblUpdatingLPC.MouseLeave += new System.EventHandler(this.lblUpdatingLPC_MouseLeave);
            // 
            // txtFocus
            // 
            this.txtFocus.Location = new System.Drawing.Point(-150, 2);
            this.txtFocus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFocus.Name = "txtFocus";
            this.txtFocus.Size = new System.Drawing.Size(58, 26);
            this.txtFocus.TabIndex = 37;
            this.txtFocus.TabStop = false;
            this.txtFocus.Text = "asdf";
            // 
            // RLEditForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1478, 1049);
            this.Controls.Add(this.lblUpdatingLPC);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.picDragNewPiece);
            this.Controls.Add(this.tabExtrasExp);
            this.Controls.Add(this.tabSkillsExp);
            this.Controls.Add(this.tabPiecesExp);
            this.Controls.Add(this.tabProperties);
            this.Controls.Add(this.scrollPicLevelVert);
            this.Controls.Add(this.scrollPicLevelHoriz);
            this.Controls.Add(this.txtFocus);
            this.Controls.Add(this.picLevel);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panelPieceBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1300, 700);
            this.Name = "RLEditForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.picLevel)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.picDragNewPiece)).EndInit();
            this.tabSkills.ResumeLayout(false);
            this.tabSkills.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRandomMaxLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRandomMinLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAllSkillsToN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDigger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMiner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBuilder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBomber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlocker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClimber)).EndInit();
            this.tabPieces.ResumeLayout(false);
            this.tabPieces.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRulerHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRulerWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSteelAreaHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSteelAreaWidth)).EndInit();
            this.tabGlobals.ResumeLayout(false);
            this.tabGlobals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReleaseRateMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeSecs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeMins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReleaseRateMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRescue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLemmings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            this.tabProperties.ResumeLayout(false);
            this.tabExtras.ResumeLayout(false);
            this.tabExtras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxFallDistance)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem screenStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.PictureBox picLevel;
        private RLEditor.FocusTextBox txtFocus;
        private System.Windows.Forms.ToolStripMenuItem hotkeysToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipPieces;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.HScrollBar scrollPicLevelHoriz;
        private System.Windows.Forms.VScrollBar scrollPicLevelVert;
        private System.Windows.Forms.ToolTip toolTipButton;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteInPlaceToolStripMenuItem;
        private System.Windows.Forms.Timer timerAutosave;
        private System.Windows.Forms.ToolStripMenuItem snapToGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem playLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusBarMissingPiecesLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusBarGenericLabel;
        private System.Windows.Forms.ToolStripDropDownButton statusBarButtonMissingPieces;
        private System.Windows.Forms.ToolStripMenuItem oKStatusBarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMissingPiecesStatusBarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMissingPiecesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanseLevelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLevelWindowToolStripMenuItem;
        private System.Windows.Forms.TabControl tabPiecesExp;
        private System.Windows.Forms.TabControl tabSkillsExp;
        private System.Windows.Forms.TabControl tabExtrasExp;
        private System.Windows.Forms.ToolStripMenuItem expandAllTabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem highlightEraserPiecesToolStripMenuItem;
        private System.Windows.Forms.Panel panelPieceBrowser;
        private System.Windows.Forms.PictureBox picPiece7;
        private System.Windows.Forms.Button btnSteel;
        private System.Windows.Forms.Button btnTerrain;
        private System.Windows.Forms.Button btnObjects;
        private System.Windows.Forms.PictureBox picPiece6;
        private System.Windows.Forms.PictureBox picPiece5;
        private System.Windows.Forms.PictureBox picPiece4;
        private System.Windows.Forms.PictureBox picPiece3;
        private RepeatButton btnPieceRight;
        private System.Windows.Forms.PictureBox picPiece2;
        private System.Windows.Forms.PictureBox picPiece1;
        private RepeatButton btnPieceLeft;
        private System.Windows.Forms.PictureBox picPiece0;
        private System.Windows.Forms.ComboBox comboPieceStyle;
        private System.Windows.Forms.PictureBox picDragNewPiece;
        private System.Windows.Forms.ToolStripMenuItem openPieceBrowserWindowToolStripMenuItem;
        private FocusTextBox txtFocusPieceBrowser;
        private System.Windows.Forms.ToolStripMenuItem refreshStylesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMissingPiecesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem styleManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem saveAsImageToolStripMenuItem;
        private System.Windows.Forms.Button btnAddSteelArea;
        private System.Windows.Forms.TabPage tabSkills;
        private System.Windows.Forms.Button btnClearAllSkills;
        private System.Windows.Forms.Button btnRandomSkillset;
        private System.Windows.Forms.Label lblRandomMinLimit;
        private System.Windows.Forms.Label lblRandomMaxLimit;
        private System.Windows.Forms.Button btnSaveAsCustomSkillset;
        private System.Windows.Forms.ComboBox comboCustomSkillset;
        private System.Windows.Forms.Button btnAllSkillsToN;
        private System.Windows.Forms.Label lblDigger;
        private System.Windows.Forms.Label lblMiner;
        private System.Windows.Forms.Label lblBasher;
        private System.Windows.Forms.Label lblBuilder;
        private System.Windows.Forms.Label lblBomber;
        private System.Windows.Forms.Label lblBlocker;
        private System.Windows.Forms.Label lblFloater;
        private System.Windows.Forms.Label lblClimber;
        private NumUpDownOverwrite numRandomMaxLimit;
        private NumUpDownOverwrite numRandomMinLimit;
        private NumUpDownOverwrite numAllSkillsToN;
        private NumUpDownOverwrite numDigger;
        private NumUpDownOverwrite numMiner;
        private NumUpDownOverwrite numBasher;
        private NumUpDownOverwrite numBuilder;
        private NumUpDownOverwrite numBomber;
        private NumUpDownOverwrite numBlocker;
        private NumUpDownOverwrite numFloater;
        private NumUpDownOverwrite numClimber;
        private System.Windows.Forms.TabPage tabPieces;
        private System.Windows.Forms.CheckBox checkNegativeSteel;
        private System.Windows.Forms.Label lblRulerHeight;
        private System.Windows.Forms.Label lblRulerWidth;
        private System.Windows.Forms.Label lblSteelAreaHeight;
        private System.Windows.Forms.Label lblSteelAreaWidth;
        private System.Windows.Forms.CheckBox checkFake;
        private System.Windows.Forms.CheckBox checkInvisible;
        private System.Windows.Forms.Label lblPieceSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPieceType;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.Label lblPieceStyle;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblPieceName;
        private System.Windows.Forms.CheckBox checkAllowOneWay;
        private System.Windows.Forms.CheckBox checkOnlyOnTerrain;
        private System.Windows.Forms.CheckBox checkNoOverwrite;
        private System.Windows.Forms.CheckBox checkErase;
        private NumUpDownOverwrite numRulerHeight;
        private NumUpDownOverwrite numRulerWidth;
        private NumUpDownOverwrite numSteelAreaHeight;
        private NumUpDownOverwrite numSteelAreaWidth;
        private RepeatButton btnDrawSooner;
        private RepeatButton btnDrawLater;
        private NoPaddingButton btnDrawFirst;
        private NoPaddingButton btnDrawLast;
        private RepeatButton btnFlip;
        private RepeatButton btnInvert;
        private RepeatButton btnRotate;
        private System.Windows.Forms.TabPage tabGlobals;
        private System.Windows.Forms.CheckBox checkAutoSteel;
        private System.Windows.Forms.ComboBox comboSteelMode;
        private System.Windows.Forms.Label lblSteelMode;
        private System.Windows.Forms.CheckBox checkTimeLimit;
        private System.Windows.Forms.CheckBox checkLockReleaseRate;
        public System.Windows.Forms.CheckBox checkAutoStart;
        private System.Windows.Forms.Label lblLevelVersion;
        private System.Windows.Forms.TextBox txtLevelAuthor;
        private System.Windows.Forms.TextBox txtLevelTitle;
        private System.Windows.Forms.Label lblStartY;
        private System.Windows.Forms.Label lblStartX;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.ComboBox comboMusic;
        private NumUpDownOverwrite numTimeSecs;
        private NumUpDownOverwrite numTimeMins;
        private NumUpDownOverwrite numReleaseRateMin;
        private NumUpDownOverwrite numRescue;
        private System.Windows.Forms.Label lblRescue;
        private NumUpDownOverwrite numLemmings;
        private System.Windows.Forms.Label lblLemmings;
        private NumUpDownOverwrite numStartY;
        private NumUpDownOverwrite numStartX;
        private NumUpDownOverwrite numHeight;
        private NumUpDownOverwrite numWidth;
        private System.Windows.Forms.Label lblMusic;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabProperties;
        private System.Windows.Forms.ComboBox comboMainStyle;
        private System.Windows.Forms.Label lblMainStyle;
        private System.Windows.Forms.ToolStripMenuItem steelAreasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulersToolStripMenuItem;
        private System.Windows.Forms.Button btnRulers;
        private System.Windows.Forms.Label lblReleaseRateMax;
        private System.Windows.Forms.Label lblReleaseRateMin;
        private NumUpDownOverwrite numReleaseRateMax;
        private System.Windows.Forms.ToolStripDropDownButton statusBarButtonSteelAreas;
        private System.Windows.Forms.ToolStripMenuItem gotItThanksStatusBarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dontShowAgainStatusBarMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusBarSteelAreasLabel;
        private System.Windows.Forms.ToolStripMenuItem levelPackCompilerToolStripMenuItem;
        private System.Windows.Forms.TabPage tabExtras;
        private System.Windows.Forms.CheckBox checkSuperlemming;
        private System.Windows.Forms.Button btnHints;
        private NumUpDownOverwrite numMaxFallDistance;
        private System.Windows.Forms.Label lblMaxFallDistance;
        private System.Windows.Forms.CheckBox checkForceNormalTimerSpeed;
        private System.Windows.Forms.ComboBox comboMods;
        private System.Windows.Forms.Label lblMods;
        private System.Windows.Forms.Button btnModsHelp;
        private System.Windows.Forms.Button btnLevelPackCompiler;
        private System.Windows.Forms.Button btnLoadStyle;
        private System.Windows.Forms.Button btnFlipSpawnDirection;
        private System.Windows.Forms.Button btnStyleRandom;
        private System.Windows.Forms.Button btnCropLevel;
        private System.Windows.Forms.Button btnCancelCrop;
        private System.Windows.Forms.Button btnApplyCrop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem templatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.CheckBox checkDirectDrop;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.ToolStripSeparator sepMissingPieces;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.Label lblUpdatingLPC;
        private System.Windows.Forms.Label lblInfinityClimber;
        private System.Windows.Forms.Label lblInfinityBomber;
        private System.Windows.Forms.Label lblInfinityFloater;
        private System.Windows.Forms.Label lblInfinityDigger;
        private System.Windows.Forms.Label lblInfinityMiner;
        private System.Windows.Forms.Label lblInfinityBasher;
        private System.Windows.Forms.Label lblInfinityBuilder;
        private System.Windows.Forms.Label lblInfinityBlocker;
        private System.Windows.Forms.ToolStripMenuItem steelToolStripMenuItem;
    }
}

