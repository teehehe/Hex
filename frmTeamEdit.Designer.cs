namespace Hex
{
    partial class frmTeamEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTeamEdit));
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.listTeams = new BrightIdeasSoftware.ObjectListView();
            this.clmTAccount = new BrightIdeasSoftware.OLVColumn();
            this.clmTCharacter = new BrightIdeasSoftware.OLVColumn();
            this.clmTServer = new BrightIdeasSoftware.OLVColumn();
            this.clmTRealm = new BrightIdeasSoftware.OLVColumn();
            this.listCharacters = new BrightIdeasSoftware.ObjectListView();
            this.clmAccount = new BrightIdeasSoftware.OLVColumn();
            this.clmCharacter = new BrightIdeasSoftware.OLVColumn();
            this.clmServer = new BrightIdeasSoftware.OLVColumn();
            this.clmRealm = new BrightIdeasSoftware.OLVColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchTeam = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.listTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listCharacters)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(48, 354);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(683, 55);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save Team";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTeamName
            // 
            this.txtTeamName.BackColor = System.Drawing.Color.DimGray;
            this.txtTeamName.Location = new System.Drawing.Point(486, 6);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.ReadOnly = true;
            this.txtTeamName.Size = new System.Drawing.Size(135, 23);
            this.txtTeamName.TabIndex = 4;
            // 
            // listTeams
            // 
            this.listTeams.AllowDrop = true;
            this.listTeams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.listTeams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmTAccount,
            this.clmTCharacter,
            this.clmTServer,
            this.clmTRealm});
            this.listTeams.Cursor = System.Windows.Forms.Cursors.Default;
            this.listTeams.ForeColor = System.Drawing.Color.LightGray;
            this.listTeams.FullRowSelect = true;
            this.listTeams.LabelWrap = false;
            this.listTeams.Location = new System.Drawing.Point(407, 40);
            this.listTeams.MultiSelect = false;
            this.listTeams.Name = "listTeams";
            this.listTeams.SelectedBackColor = System.Drawing.Color.DimGray;
            this.listTeams.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listTeams.SelectedForeColor = System.Drawing.Color.Black;
            this.listTeams.Size = new System.Drawing.Size(370, 294);
            this.listTeams.TabIndex = 6;
            this.listTeams.UnfocusedSelectedBackColor = System.Drawing.Color.DimGray;
            this.listTeams.UnfocusedSelectedForeColor = System.Drawing.Color.Black;
            this.listTeams.View = System.Windows.Forms.View.Details;
            this.listTeams.DragDrop += new System.Windows.Forms.DragEventHandler(this.listTeams_DragDrop);
            this.listTeams.DragOver += new System.Windows.Forms.DragEventHandler(this.listTeams_DragOver);
            this.listTeams.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listTeams_MouseDown);
            // 
            // clmTAccount
            // 
            this.clmTAccount.AspectName = "TAccount";
            this.clmTAccount.FillsFreeSpace = true;
            this.clmTAccount.Groupable = false;
            this.clmTAccount.Text = "Account";
            this.clmTAccount.Width = 100;
            // 
            // clmTCharacter
            // 
            this.clmTCharacter.AspectName = "TCharacter";
            this.clmTCharacter.FillsFreeSpace = true;
            this.clmTCharacter.Groupable = false;
            this.clmTCharacter.Text = "Character";
            this.clmTCharacter.Width = 100;
            // 
            // clmTServer
            // 
            this.clmTServer.AspectName = "TServer";
            this.clmTServer.Groupable = false;
            this.clmTServer.MaximumWidth = 60;
            this.clmTServer.Text = "Server";
            // 
            // clmTRealm
            // 
            this.clmTRealm.AspectName = "TRealm";
            this.clmTRealm.Groupable = false;
            this.clmTRealm.MaximumWidth = 60;
            this.clmTRealm.Text = "Realm";
            // 
            // listCharacters
            // 
            this.listCharacters.AllowDrop = true;
            this.listCharacters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.listCharacters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmAccount,
            this.clmCharacter,
            this.clmServer,
            this.clmRealm});
            this.listCharacters.Cursor = System.Windows.Forms.Cursors.Default;
            this.listCharacters.ForeColor = System.Drawing.Color.LightGray;
            this.listCharacters.FullRowSelect = true;
            this.listCharacters.LabelWrap = false;
            this.listCharacters.Location = new System.Drawing.Point(9, 40);
            this.listCharacters.MultiSelect = false;
            this.listCharacters.Name = "listCharacters";
            this.listCharacters.SelectedBackColor = System.Drawing.Color.DimGray;
            this.listCharacters.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listCharacters.SelectedForeColor = System.Drawing.Color.Black;
            this.listCharacters.Size = new System.Drawing.Size(370, 294);
            this.listCharacters.TabIndex = 5;
            this.listCharacters.UnfocusedSelectedBackColor = System.Drawing.Color.DimGray;
            this.listCharacters.UnfocusedSelectedForeColor = System.Drawing.Color.Black;
            this.listCharacters.UseFiltering = true;
            this.listCharacters.View = System.Windows.Forms.View.Details;
            this.listCharacters.DragDrop += new System.Windows.Forms.DragEventHandler(this.listCharacters_DragDrop);
            this.listCharacters.DragOver += new System.Windows.Forms.DragEventHandler(this.listCharacters_DragOver);
            this.listCharacters.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listCharacters_MouseDown);
            // 
            // clmAccount
            // 
            this.clmAccount.AspectName = "Account";
            this.clmAccount.FillsFreeSpace = true;
            this.clmAccount.Groupable = false;
            this.clmAccount.IsEditable = false;
            this.clmAccount.Text = "Account";
            this.clmAccount.Width = 100;
            // 
            // clmCharacter
            // 
            this.clmCharacter.AspectName = "Character";
            this.clmCharacter.FillsFreeSpace = true;
            this.clmCharacter.Groupable = false;
            this.clmCharacter.IsEditable = false;
            this.clmCharacter.Text = "Character";
            this.clmCharacter.Width = 100;
            // 
            // clmServer
            // 
            this.clmServer.AspectName = "Server";
            this.clmServer.Groupable = false;
            this.clmServer.IsEditable = false;
            this.clmServer.Text = "Server";
            // 
            // clmRealm
            // 
            this.clmRealm.AspectName = "Realm";
            this.clmRealm.Groupable = false;
            this.clmRealm.IsEditable = false;
            this.clmRealm.Text = "Realm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(407, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Team Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Filter:";
            // 
            // txtSearchTeam
            // 
            this.txtSearchTeam.BackColor = System.Drawing.Color.DimGray;
            this.txtSearchTeam.Location = new System.Drawing.Point(48, 6);
            this.txtSearchTeam.Name = "txtSearchTeam";
            this.txtSearchTeam.Size = new System.Drawing.Size(134, 23);
            this.txtSearchTeam.TabIndex = 10;
            this.txtSearchTeam.TextChanged += new System.EventHandler(this.txtSearchTeam_TextChanged);
            // 
            // frmTeamEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(784, 419);
            this.Controls.Add(this.txtSearchTeam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtTeamName);
            this.Controls.Add(this.listTeams);
            this.Controls.Add(this.listCharacters);
            this.ForeColor = System.Drawing.Color.Silver;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTeamEdit";
            this.Text = "Team Edit";
            ((System.ComponentModel.ISupportInitialize)(this.listTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listCharacters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTeamName;
        private BrightIdeasSoftware.ObjectListView listTeams;
        private BrightIdeasSoftware.ObjectListView listCharacters;
        private BrightIdeasSoftware.OLVColumn clmTAccount;
        private BrightIdeasSoftware.OLVColumn clmTCharacter;
        private BrightIdeasSoftware.OLVColumn clmTServer;
        private BrightIdeasSoftware.OLVColumn clmTRealm;
        private BrightIdeasSoftware.OLVColumn clmAccount;
        private BrightIdeasSoftware.OLVColumn clmCharacter;
        private BrightIdeasSoftware.OLVColumn clmServer;
        private BrightIdeasSoftware.OLVColumn clmRealm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchTeam;
    }
}