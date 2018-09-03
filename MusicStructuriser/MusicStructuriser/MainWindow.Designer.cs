namespace MusicStructuriser
{
    partial class MainWindow
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
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Knoten3");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Knoten2", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Knoten0", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Knoten4");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Knoten5");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Knoten6");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Knoten7");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Knoten1", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            this.tabBox = new System.Windows.Forms.TabControl();
            this.pageStructure = new System.Windows.Forms.TabPage();
            this.pageMeta = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.grpTracklist = new System.Windows.Forms.GroupBox();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.pagePath = new System.Windows.Forms.TabPage();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbArtist = new System.Windows.Forms.Label();
            this.lbAlbum = new System.Windows.Forms.Label();
            this.lbYear = new System.Windows.Forms.Label();
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.txtAlbum = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lbTrack = new System.Windows.Forms.Label();
            this.lbGenre = new System.Windows.Forms.Label();
            this.lbAlbumArtist = new System.Windows.Forms.Label();
            this.lbComposer = new System.Windows.Forms.Label();
            this.lbCDNum = new System.Windows.Forms.Label();
            this.txtTrack = new System.Windows.Forms.TextBox();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.txtAlbumArtist = new System.Windows.Forms.TextBox();
            this.txtComposer = new System.Windows.Forms.TextBox();
            this.txtDiscNum = new System.Windows.Forms.TextBox();
            this.tabBox.SuspendLayout();
            this.pageMeta.SuspendLayout();
            this.grpTracklist.SuspendLayout();
            this.grpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabBox
            // 
            this.tabBox.Controls.Add(this.pageStructure);
            this.tabBox.Controls.Add(this.pageMeta);
            this.tabBox.Controls.Add(this.pagePath);
            this.tabBox.Location = new System.Drawing.Point(6, 19);
            this.tabBox.Name = "tabBox";
            this.tabBox.SelectedIndex = 0;
            this.tabBox.Size = new System.Drawing.Size(955, 725);
            this.tabBox.TabIndex = 1;
            // 
            // pageStructure
            // 
            this.pageStructure.Location = new System.Drawing.Point(4, 22);
            this.pageStructure.Name = "pageStructure";
            this.pageStructure.Padding = new System.Windows.Forms.Padding(3);
            this.pageStructure.Size = new System.Drawing.Size(947, 699);
            this.pageStructure.TabIndex = 0;
            this.pageStructure.Text = "Structure";
            this.pageStructure.UseVisualStyleBackColor = true;
            // 
            // pageMeta
            // 
            this.pageMeta.Controls.Add(this.txtDiscNum);
            this.pageMeta.Controls.Add(this.txtComposer);
            this.pageMeta.Controls.Add(this.txtAlbumArtist);
            this.pageMeta.Controls.Add(this.txtGenre);
            this.pageMeta.Controls.Add(this.txtTrack);
            this.pageMeta.Controls.Add(this.lbCDNum);
            this.pageMeta.Controls.Add(this.lbComposer);
            this.pageMeta.Controls.Add(this.lbAlbumArtist);
            this.pageMeta.Controls.Add(this.lbGenre);
            this.pageMeta.Controls.Add(this.lbTrack);
            this.pageMeta.Controls.Add(this.txtYear);
            this.pageMeta.Controls.Add(this.txtAlbum);
            this.pageMeta.Controls.Add(this.txtArtist);
            this.pageMeta.Controls.Add(this.lbYear);
            this.pageMeta.Controls.Add(this.lbAlbum);
            this.pageMeta.Controls.Add(this.lbArtist);
            this.pageMeta.Controls.Add(this.lbTitle);
            this.pageMeta.Controls.Add(this.txtTitle);
            this.pageMeta.Controls.Add(this.button1);
            this.pageMeta.Location = new System.Drawing.Point(4, 22);
            this.pageMeta.Name = "pageMeta";
            this.pageMeta.Padding = new System.Windows.Forms.Padding(3);
            this.pageMeta.Size = new System.Drawing.Size(947, 699);
            this.pageMeta.TabIndex = 1;
            this.pageMeta.Text = "Meta Data";
            this.pageMeta.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Location = new System.Drawing.Point(6, 19);
            this.treeView1.Name = "treeView1";
            treeNode9.Name = "Knoten3";
            treeNode9.Text = "Knoten3";
            treeNode10.Name = "Knoten2";
            treeNode10.Text = "Knoten2";
            treeNode11.Name = "Knoten0";
            treeNode11.Text = "Knoten0";
            treeNode12.Name = "Knoten4";
            treeNode12.Text = "Knoten4";
            treeNode13.Name = "Knoten5";
            treeNode13.Text = "Knoten5";
            treeNode14.Name = "Knoten6";
            treeNode14.Text = "Knoten6";
            treeNode15.Name = "Knoten7";
            treeNode15.Text = "Knoten7";
            treeNode16.Name = "Knoten1";
            treeNode16.Text = "Knoten1";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode16});
            this.treeView1.Size = new System.Drawing.Size(188, 725);
            this.treeView1.TabIndex = 2;
            // 
            // grpTracklist
            // 
            this.grpTracklist.Controls.Add(this.treeView1);
            this.grpTracklist.Location = new System.Drawing.Point(12, 12);
            this.grpTracklist.Name = "grpTracklist";
            this.grpTracklist.Size = new System.Drawing.Size(200, 750);
            this.grpTracklist.TabIndex = 3;
            this.grpTracklist.TabStop = false;
            this.grpTracklist.Text = "Tracklist";
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.tabBox);
            this.grpSettings.Location = new System.Drawing.Point(219, 12);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(967, 750);
            this.grpSettings.TabIndex = 4;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // pagePath
            // 
            this.pagePath.Location = new System.Drawing.Point(4, 22);
            this.pagePath.Name = "pagePath";
            this.pagePath.Padding = new System.Windows.Forms.Padding(3);
            this.pagePath.Size = new System.Drawing.Size(947, 699);
            this.pagePath.TabIndex = 2;
            this.pagePath.Text = "Folder Paths";
            this.pagePath.UseVisualStyleBackColor = true;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(46, 63);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(204, 20);
            this.txtTitle.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(460, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(6, 66);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(30, 13);
            this.lbTitle.TabIndex = 4;
            this.lbTitle.Text = "Title:";
            // 
            // lbArtist
            // 
            this.lbArtist.AutoSize = true;
            this.lbArtist.Location = new System.Drawing.Point(6, 107);
            this.lbArtist.Name = "lbArtist";
            this.lbArtist.Size = new System.Drawing.Size(33, 13);
            this.lbArtist.TabIndex = 5;
            this.lbArtist.Text = "Artist:";
            // 
            // lbAlbum
            // 
            this.lbAlbum.AutoSize = true;
            this.lbAlbum.Location = new System.Drawing.Point(6, 158);
            this.lbAlbum.Name = "lbAlbum";
            this.lbAlbum.Size = new System.Drawing.Size(39, 13);
            this.lbAlbum.TabIndex = 6;
            this.lbAlbum.Text = "Album:";
            // 
            // lbYear
            // 
            this.lbYear.AutoSize = true;
            this.lbYear.Location = new System.Drawing.Point(265, 158);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(32, 13);
            this.lbYear.TabIndex = 7;
            this.lbYear.Text = "Year:";
            // 
            // txtArtist
            // 
            this.txtArtist.Location = new System.Drawing.Point(46, 104);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(204, 20);
            this.txtArtist.TabIndex = 8;
            // 
            // txtAlbum
            // 
            this.txtAlbum.Location = new System.Drawing.Point(46, 155);
            this.txtAlbum.Name = "txtAlbum";
            this.txtAlbum.Size = new System.Drawing.Size(204, 20);
            this.txtAlbum.TabIndex = 9;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(303, 155);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(204, 20);
            this.txtYear.TabIndex = 10;
            // 
            // lbTrack
            // 
            this.lbTrack.AutoSize = true;
            this.lbTrack.Location = new System.Drawing.Point(6, 201);
            this.lbTrack.Name = "lbTrack";
            this.lbTrack.Size = new System.Drawing.Size(38, 13);
            this.lbTrack.TabIndex = 11;
            this.lbTrack.Text = "Track:";
            // 
            // lbGenre
            // 
            this.lbGenre.AutoSize = true;
            this.lbGenre.Location = new System.Drawing.Point(6, 244);
            this.lbGenre.Name = "lbGenre";
            this.lbGenre.Size = new System.Drawing.Size(39, 13);
            this.lbGenre.TabIndex = 12;
            this.lbGenre.Text = "Genre:";
            // 
            // lbAlbumArtist
            // 
            this.lbAlbumArtist.AutoSize = true;
            this.lbAlbumArtist.Location = new System.Drawing.Point(6, 294);
            this.lbAlbumArtist.Name = "lbAlbumArtist";
            this.lbAlbumArtist.Size = new System.Drawing.Size(65, 13);
            this.lbAlbumArtist.TabIndex = 13;
            this.lbAlbumArtist.Text = "Album Artist:";
            // 
            // lbComposer
            // 
            this.lbComposer.AutoSize = true;
            this.lbComposer.Location = new System.Drawing.Point(6, 353);
            this.lbComposer.Name = "lbComposer";
            this.lbComposer.Size = new System.Drawing.Size(57, 13);
            this.lbComposer.TabIndex = 14;
            this.lbComposer.Text = "Composer:";
            // 
            // lbCDNum
            // 
            this.lbCDNum.AutoSize = true;
            this.lbCDNum.Location = new System.Drawing.Point(6, 403);
            this.lbCDNum.Name = "lbCDNum";
            this.lbCDNum.Size = new System.Drawing.Size(71, 13);
            this.lbCDNum.TabIndex = 15;
            this.lbCDNum.Text = "Disc Number:";
            // 
            // txtTrack
            // 
            this.txtTrack.Location = new System.Drawing.Point(46, 198);
            this.txtTrack.Name = "txtTrack";
            this.txtTrack.Size = new System.Drawing.Size(204, 20);
            this.txtTrack.TabIndex = 16;
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(46, 241);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(204, 20);
            this.txtGenre.TabIndex = 17;
            // 
            // txtAlbumArtist
            // 
            this.txtAlbumArtist.Location = new System.Drawing.Point(77, 291);
            this.txtAlbumArtist.Name = "txtAlbumArtist";
            this.txtAlbumArtist.Size = new System.Drawing.Size(204, 20);
            this.txtAlbumArtist.TabIndex = 18;
            // 
            // txtComposer
            // 
            this.txtComposer.Location = new System.Drawing.Point(69, 350);
            this.txtComposer.Name = "txtComposer";
            this.txtComposer.Size = new System.Drawing.Size(204, 20);
            this.txtComposer.TabIndex = 19;
            // 
            // txtDiscNum
            // 
            this.txtDiscNum.Location = new System.Drawing.Point(83, 400);
            this.txtDiscNum.Name = "txtDiscNum";
            this.txtDiscNum.Size = new System.Drawing.Size(204, 20);
            this.txtDiscNum.TabIndex = 20;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 774);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.grpTracklist);
            this.Name = "MainWindow";
            this.Text = "Music Structuriser";
            this.tabBox.ResumeLayout(false);
            this.pageMeta.ResumeLayout(false);
            this.pageMeta.PerformLayout();
            this.grpTracklist.ResumeLayout(false);
            this.grpSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabBox;
        private System.Windows.Forms.TabPage pageStructure;
        private System.Windows.Forms.TabPage pageMeta;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox grpTracklist;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.TabPage pagePath;
        private System.Windows.Forms.Label lbCDNum;
        private System.Windows.Forms.Label lbComposer;
        private System.Windows.Forms.Label lbAlbumArtist;
        private System.Windows.Forms.Label lbGenre;
        private System.Windows.Forms.Label lbTrack;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtAlbum;
        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.Label lbYear;
        private System.Windows.Forms.Label lbAlbum;
        private System.Windows.Forms.Label lbArtist;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.TextBox txtTrack;
        private System.Windows.Forms.TextBox txtDiscNum;
        private System.Windows.Forms.TextBox txtComposer;
        private System.Windows.Forms.TextBox txtAlbumArtist;
    }
}