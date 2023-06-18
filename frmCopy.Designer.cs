namespace Hex
{
    partial class frmCopy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopy));
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.rbLiveFrom = new System.Windows.Forms.RadioButton();
            this.rbCelestiusFrom = new System.Windows.Forms.RadioButton();
            this.rbAtlasFrom = new System.Windows.Forms.RadioButton();
            this.lblFrom = new System.Windows.Forms.Label();
            this.listCharToCopy = new BrightIdeasSoftware.ObjectListView();
            this.clmCharToCopy = new BrightIdeasSoftware.OLVColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbLiveTo = new System.Windows.Forms.RadioButton();
            this.rbAtlasTo = new System.Windows.Forms.RadioButton();
            this.rbCelestiusTo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.kryptonManager1 = new Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPalette1 = new Krypton.Toolkit.KryptonPalette(this.components);
            this.kryptonPalette1 = new Krypton.Toolkit.KryptonPalette(this.components);
            this.kryptonListBox1 = new Krypton.Toolkit.KryptonListBox();
            ((System.ComponentModel.ISupportInitialize)(this.listCharToCopy)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.DimGray;
            this.txtName.Location = new System.Drawing.Point(48, 503);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(119, 23);
            this.txtName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(18, 441);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 45);
            this.label4.TabIndex = 13;
            this.label4.Text = "Enter New Characters Name\r\n(DO NOT type the extenstions\r\nlike -5.ini or -41.ini)\r" +
    "\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCopy
            // 
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.ForeColor = System.Drawing.Color.Silver;
            this.btnCopy.Location = new System.Drawing.Point(7, 603);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 36);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.button2_Click);
            // 
            // rbLiveFrom
            // 
            this.rbLiveFrom.AutoSize = true;
            this.rbLiveFrom.ForeColor = System.Drawing.Color.Silver;
            this.rbLiveFrom.Location = new System.Drawing.Point(145, 15);
            this.rbLiveFrom.Name = "rbLiveFrom";
            this.rbLiveFrom.Size = new System.Drawing.Size(46, 19);
            this.rbLiveFrom.TabIndex = 2;
            this.rbLiveFrom.TabStop = true;
            this.rbLiveFrom.Text = "Live";
            this.rbLiveFrom.UseVisualStyleBackColor = true;
            this.rbLiveFrom.CheckedChanged += new System.EventHandler(this.rbLiveFrom_CheckedChanged);
            // 
            // rbCelestiusFrom
            // 
            this.rbCelestiusFrom.AutoSize = true;
            this.rbCelestiusFrom.ForeColor = System.Drawing.Color.Silver;
            this.rbCelestiusFrom.Location = new System.Drawing.Point(65, 15);
            this.rbCelestiusFrom.Name = "rbCelestiusFrom";
            this.rbCelestiusFrom.Size = new System.Drawing.Size(72, 19);
            this.rbCelestiusFrom.TabIndex = 1;
            this.rbCelestiusFrom.TabStop = true;
            this.rbCelestiusFrom.Text = "Celestius";
            this.rbCelestiusFrom.UseVisualStyleBackColor = true;
            this.rbCelestiusFrom.CheckedChanged += new System.EventHandler(this.rbCelestiusFrom_CheckedChanged);
            // 
            // rbAtlasFrom
            // 
            this.rbAtlasFrom.AutoSize = true;
            this.rbAtlasFrom.ForeColor = System.Drawing.Color.Silver;
            this.rbAtlasFrom.Location = new System.Drawing.Point(11, 15);
            this.rbAtlasFrom.Name = "rbAtlasFrom";
            this.rbAtlasFrom.Size = new System.Drawing.Size(51, 19);
            this.rbAtlasFrom.TabIndex = 0;
            this.rbAtlasFrom.TabStop = true;
            this.rbAtlasFrom.Text = "Atlas";
            this.rbAtlasFrom.UseVisualStyleBackColor = true;
            this.rbAtlasFrom.CheckedChanged += new System.EventHandler(this.rbAtlasFrom_CheckedChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.ForeColor = System.Drawing.Color.Silver;
            this.lblFrom.Location = new System.Drawing.Point(29, 9);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(158, 30);
            this.lblFrom.TabIndex = 12;
            this.lblFrom.Text = "Select the server you wish \r\nto copy from to populate list";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // listCharToCopy
            // 
            this.listCharToCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.listCharToCopy.CausesValidation = false;
            this.listCharToCopy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmCharToCopy});
            this.listCharToCopy.EmptyListMsg = "No Items To Display";
            this.listCharToCopy.ForeColor = System.Drawing.Color.Silver;
            this.listCharToCopy.HasCollapsibleGroups = false;
            this.listCharToCopy.LabelWrap = false;
            this.listCharToCopy.Location = new System.Drawing.Point(7, 93);
            this.listCharToCopy.MultiSelect = false;
            this.listCharToCopy.Name = "listCharToCopy";
            this.listCharToCopy.SelectedBackColor = System.Drawing.Color.DimGray;
            this.listCharToCopy.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listCharToCopy.SelectedForeColor = System.Drawing.Color.Black;
            this.listCharToCopy.ShowGroups = false;
            this.listCharToCopy.Size = new System.Drawing.Size(200, 345);
            this.listCharToCopy.TabIndex = 3;
            this.listCharToCopy.View = System.Windows.Forms.View.Details;
            // 
            // clmCharToCopy
            // 
            this.clmCharToCopy.AspectName = "CharToCopy";
            this.clmCharToCopy.FillsFreeSpace = true;
            this.clmCharToCopy.Groupable = false;
            this.clmCharToCopy.HeaderCheckBoxUpdatesRowCheckBoxes = false;
            this.clmCharToCopy.Hideable = false;
            this.clmCharToCopy.IsEditable = false;
            this.clmCharToCopy.Text = "Character Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLiveFrom);
            this.groupBox1.Controls.Add(this.rbAtlasFrom);
            this.groupBox1.Controls.Add(this.rbCelestiusFrom);
            this.groupBox1.Location = new System.Drawing.Point(7, 40);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 40);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbLiveTo);
            this.groupBox2.Controls.Add(this.rbAtlasTo);
            this.groupBox2.Controls.Add(this.rbCelestiusTo);
            this.groupBox2.Location = new System.Drawing.Point(7, 554);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 40);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // rbLiveTo
            // 
            this.rbLiveTo.AutoSize = true;
            this.rbLiveTo.ForeColor = System.Drawing.Color.Silver;
            this.rbLiveTo.Location = new System.Drawing.Point(145, 15);
            this.rbLiveTo.Name = "rbLiveTo";
            this.rbLiveTo.Size = new System.Drawing.Size(46, 19);
            this.rbLiveTo.TabIndex = 2;
            this.rbLiveTo.TabStop = true;
            this.rbLiveTo.Text = "Live";
            this.rbLiveTo.UseVisualStyleBackColor = true;
            this.rbLiveTo.CheckedChanged += new System.EventHandler(this.rbLiveTo_CheckedChanged);
            // 
            // rbAtlasTo
            // 
            this.rbAtlasTo.AutoSize = true;
            this.rbAtlasTo.ForeColor = System.Drawing.Color.Silver;
            this.rbAtlasTo.Location = new System.Drawing.Point(11, 15);
            this.rbAtlasTo.Name = "rbAtlasTo";
            this.rbAtlasTo.Size = new System.Drawing.Size(51, 19);
            this.rbAtlasTo.TabIndex = 0;
            this.rbAtlasTo.TabStop = true;
            this.rbAtlasTo.Text = "Atlas";
            this.rbAtlasTo.UseVisualStyleBackColor = true;
            this.rbAtlasTo.CheckedChanged += new System.EventHandler(this.rbAtlasTo_CheckedChanged);
            // 
            // rbCelestiusTo
            // 
            this.rbCelestiusTo.AutoSize = true;
            this.rbCelestiusTo.ForeColor = System.Drawing.Color.Silver;
            this.rbCelestiusTo.Location = new System.Drawing.Point(65, 15);
            this.rbCelestiusTo.Name = "rbCelestiusTo";
            this.rbCelestiusTo.Size = new System.Drawing.Size(72, 19);
            this.rbCelestiusTo.TabIndex = 1;
            this.rbCelestiusTo.TabStop = true;
            this.rbCelestiusTo.Text = "Celestius";
            this.rbCelestiusTo.UseVisualStyleBackColor = true;
            this.rbCelestiusTo.CheckedChanged += new System.EventHandler(this.rbCelestiusTo_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(7, 538);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Select the server you wish to copy to";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // kryptonManager1
            // 
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.BasePaletteMode = Krypton.Toolkit.PaletteMode.Office365BlackDarkMode;
            this.kryptonPalette1.ButtonStyles.ButtonButtonSpec.StateTracking.Back.Color1 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette1.ButtonStyles.ButtonButtonSpec.StateTracking.Back.Color2 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Border.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideFocus.Content.LongText.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideFocus.Content.LongText.Color2 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Border.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Border.Color2 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StatePressed.Back.Color1 = System.Drawing.Color.DimGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StatePressed.Back.Color2 = System.Drawing.Color.DarkGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StatePressed.Border.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Back.Color1 = System.Drawing.Color.DimGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Back.Color2 = System.Drawing.Color.DimGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Border.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Border.Color2 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.Common.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.Common.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.Common.StateCommon.Border.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.Common.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.Common.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ContextMenu.StateNormal.ItemHighlight.Back.Color1 = System.Drawing.Color.DimGray;
            this.kryptonPalette1.ContextMenu.StateNormal.ItemHighlight.Back.Color2 = System.Drawing.Color.DimGray;
            this.kryptonPalette1.ContextMenu.StateNormal.ItemHighlight.Border.Color1 = System.Drawing.Color.Silver;
            this.kryptonPalette1.ContextMenu.StateNormal.ItemHighlight.Border.Color2 = System.Drawing.Color.Silver;
            this.kryptonPalette1.ContextMenu.StateNormal.ItemHighlight.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormCommon.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCommon.StateActive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Border.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormCommon.StateInactive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCommon.StateInactive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom1.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom1.StateActive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom1.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom1.StateActive.Border.Color2 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.FormStyles.FormCustom1.StateActive.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormCustom1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom1.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom1.StateInactive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom1.StateInactive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom2.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom2.StateActive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom2.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom2.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormMain.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormMain.StateActive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.HeaderStyles.HeaderCommon.StateCommon.Border.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.HeaderStyles.HeaderCommon.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.HeaderStyles.HeaderCommon.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ToolMenuStatus.Button.ButtonSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.kryptonPalette1.ToolMenuStatus.Button.ButtonSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.kryptonPalette1.ToolMenuStatus.Button.ButtonSelectedHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.kryptonPalette1.ToolMenuStatus.Button.ButtonSelectedHighlightBorder = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuBorder = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuItemBorder = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuItemPressedGradientBegin = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuItemPressedGradientEnd = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuItemSelected = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuItemSelectedGradientBegin = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuItemSelectedGradientEnd = System.Drawing.Color.Silver;
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuItemText = System.Drawing.Color.Silver;
            this.kryptonPalette1.ToolMenuStatus.MenuStrip.MenuStripGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.MenuStrip.MenuStripGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.MenuStrip.MenuStripText = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripBorder = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripDropDownBackground = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripPanelGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripPanelGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripText = System.Drawing.Color.LightGray;
            this.kryptonManager1.GlobalPalette = this.kryptonPalette1;
            this.kryptonManager1.GlobalPaletteMode = Krypton.Toolkit.PaletteModeManager.Custom;
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.BasePaletteMode = Krypton.Toolkit.PaletteMode.Office365BlackDarkMode;
            this.kryptonPalette1.ButtonStyles.ButtonButtonSpec.StateTracking.Back.Color1 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette1.ButtonStyles.ButtonButtonSpec.StateTracking.Back.Color2 = System.Drawing.Color.Fuchsia;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Border.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideFocus.Content.LongText.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideFocus.Content.LongText.Color2 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Border.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Border.Color2 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StatePressed.Back.Color1 = System.Drawing.Color.DimGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StatePressed.Back.Color2 = System.Drawing.Color.DarkGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StatePressed.Border.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Back.Color1 = System.Drawing.Color.DimGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Back.Color2 = System.Drawing.Color.DimGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Border.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Border.Color2 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.Common.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.Common.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.Common.StateCommon.Border.Color1 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.Common.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.Common.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ContextMenu.StateNormal.ItemHighlight.Back.Color1 = System.Drawing.Color.DimGray;
            this.kryptonPalette1.ContextMenu.StateNormal.ItemHighlight.Back.Color2 = System.Drawing.Color.DimGray;
            this.kryptonPalette1.ContextMenu.StateNormal.ItemHighlight.Border.Color1 = System.Drawing.Color.Silver;
            this.kryptonPalette1.ContextMenu.StateNormal.ItemHighlight.Border.Color2 = System.Drawing.Color.Silver;
            this.kryptonPalette1.ContextMenu.StateNormal.ItemHighlight.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormCommon.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCommon.StateActive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCommon.StateInactive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCommon.StateInactive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom1.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom1.StateActive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom1.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom1.StateActive.Border.Color2 = System.Drawing.Color.LightGray;
            this.kryptonPalette1.FormStyles.FormCustom1.StateActive.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormCustom1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom1.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom1.StateInactive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom1.StateInactive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom2.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom2.StateActive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom2.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormCustom2.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormMain.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormMain.StateActive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.Button.ButtonSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.kryptonPalette1.ToolMenuStatus.Button.ButtonSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.kryptonPalette1.ToolMenuStatus.Button.ButtonSelectedHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.kryptonPalette1.ToolMenuStatus.Button.ButtonSelectedHighlightBorder = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuBorder = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuItemBorder = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuItemPressedGradientBegin = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuItemPressedGradientEnd = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuItemSelected = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuItemSelectedGradientBegin = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuItemSelectedGradientEnd = System.Drawing.Color.Silver;
            this.kryptonPalette1.ToolMenuStatus.Menu.MenuItemText = System.Drawing.Color.Silver;
            this.kryptonPalette1.ToolMenuStatus.MenuStrip.MenuStripGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.MenuStrip.MenuStripGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.MenuStrip.MenuStripText = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripBorder = System.Drawing.Color.LightGray;
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripContentPanelGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripDropDownBackground = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripPanelGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripPanelGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.kryptonPalette1.ToolMenuStatus.ToolStrip.ToolStripText = System.Drawing.Color.LightGray;
            // 
            // kryptonListBox1
            // 
            this.kryptonListBox1.Items.AddRange(new object[] {
            "Gaheris",
            "Ywain1",
            "Ywain2",
            "Ywain3",
            "Ywain4",
            "Ywain5",
            "Ywain6",
            "Ywain7",
            "Ywain8",
            "Ywain9",
            "Ywain10"});
            this.kryptonListBox1.Location = new System.Drawing.Point(100, 598);
            this.kryptonListBox1.Name = "kryptonListBox1";
            this.kryptonListBox1.Size = new System.Drawing.Size(107, 53);
            this.kryptonListBox1.TabIndex = 16;
            this.kryptonListBox1.Visible = false;
            // 
            // frmCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(215, 651);
            this.Controls.Add(this.kryptonListBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listCharToCopy);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCopy";
            this.PaletteMode = Krypton.Toolkit.PaletteMode.Office365BlackDarkMode;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.StateCommon.Border.Color1 = System.Drawing.Color.LightGray;
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.StateCommon.Header.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.StateCommon.Header.Border.Color2 = System.Drawing.Color.LightGray;
            this.StateCommon.Header.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.Text = "Character Copy";
            ((System.ComponentModel.ISupportInitialize)(this.listCharToCopy)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.RadioButton rbLiveFrom;
        private System.Windows.Forms.RadioButton rbCelestiusFrom;
        private System.Windows.Forms.RadioButton rbAtlasFrom;
        private System.Windows.Forms.Label lblFrom;
        private BrightIdeasSoftware.ObjectListView listCharToCopy;
        private BrightIdeasSoftware.OLVColumn clmCharToCopy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbLiveTo;
        private System.Windows.Forms.RadioButton rbAtlasTo;
        private System.Windows.Forms.RadioButton rbCelestiusTo;
        private System.Windows.Forms.Label label1;
        private Krypton.Toolkit.KryptonManager kryptonManager1;
        private Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private Krypton.Toolkit.KryptonListBox kryptonListBox1;
    }
}