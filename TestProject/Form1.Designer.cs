﻿namespace TestProject
{
    partial class Form1
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
            this.treeView_proj = new System.Windows.Forms.TreeView();
            this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnToevoegen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVerwijderen = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectSignalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView_lib = new System.Windows.Forms.TreeView();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.treeView_sig = new System.Windows.Forms.TreeView();
            this.rightClickMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_proj
            // 
            this.treeView_proj.AllowDrop = true;
            this.treeView_proj.Location = new System.Drawing.Point(42, 92);
            this.treeView_proj.Name = "treeView_proj";
            this.treeView_proj.Size = new System.Drawing.Size(262, 405);
            this.treeView_proj.TabIndex = 0;
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnToevoegen,
            this.btnVerwijderen,
            this.propertiesToolStripMenuItem,
            this.disconnectSignalsToolStripMenuItem});
            this.rightClickMenu.Name = "rightClickMenu";
            this.rightClickMenu.Size = new System.Drawing.Size(174, 92);
            // 
            // btnToevoegen
            // 
            this.btnToevoegen.Name = "btnToevoegen";
            this.btnToevoegen.Size = new System.Drawing.Size(173, 22);
            this.btnToevoegen.Text = "Toevoegen";
            this.btnToevoegen.Click += new System.EventHandler(this.btnToevoegen_Click);
            // 
            // btnVerwijderen
            // 
            this.btnVerwijderen.Name = "btnVerwijderen";
            this.btnVerwijderen.Size = new System.Drawing.Size(173, 22);
            this.btnVerwijderen.Text = "Verwijderen";
            this.btnVerwijderen.Click += new System.EventHandler(this.btnVerwijderen_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // disconnectSignalsToolStripMenuItem
            // 
            this.disconnectSignalsToolStripMenuItem.Name = "disconnectSignalsToolStripMenuItem";
            this.disconnectSignalsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.disconnectSignalsToolStripMenuItem.Text = "Disconnect Signals";
            this.disconnectSignalsToolStripMenuItem.Click += new System.EventHandler(this.disconnectSignalsToolStripMenuItem_Click);
            // 
            // treeView_lib
            // 
            this.treeView_lib.AllowDrop = true;
            this.treeView_lib.Location = new System.Drawing.Point(629, 92);
            this.treeView_lib.Name = "treeView_lib";
            this.treeView_lib.Size = new System.Drawing.Size(269, 405);
            this.treeView_lib.TabIndex = 2;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(629, 50);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(269, 20);
            this.txtFilter.TabIndex = 6;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(910, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem1,
            this.saveLibraryToolStripMenuItem,
            this.openLibraryToolStripMenuItem});
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.openProjectToolStripMenuItem.Text = "File";
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem1
            // 
            this.openProjectToolStripMenuItem1.Name = "openProjectToolStripMenuItem1";
            this.openProjectToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.openProjectToolStripMenuItem1.Text = "Open Project";
            this.openProjectToolStripMenuItem1.Click += new System.EventHandler(this.openProjectToolStripMenuItem1_Click);
            // 
            // saveLibraryToolStripMenuItem
            // 
            this.saveLibraryToolStripMenuItem.Name = "saveLibraryToolStripMenuItem";
            this.saveLibraryToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveLibraryToolStripMenuItem.Text = "Save Library";
            this.saveLibraryToolStripMenuItem.Click += new System.EventHandler(this.saveLibraryToolStripMenuItem_Click);
            // 
            // openLibraryToolStripMenuItem
            // 
            this.openLibraryToolStripMenuItem.Name = "openLibraryToolStripMenuItem";
            this.openLibraryToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openLibraryToolStripMenuItem.Text = "Open Library";
            this.openLibraryToolStripMenuItem.Click += new System.EventHandler(this.openLibraryToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(626, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Zoeken:";
            // 
            // treeView_sig
            // 
            this.treeView_sig.Location = new System.Drawing.Point(335, 92);
            this.treeView_sig.Name = "treeView_sig";
            this.treeView_sig.Size = new System.Drawing.Size(262, 405);
            this.treeView_sig.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 556);
            this.Controls.Add(this.treeView_sig);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.treeView_lib);
            this.Controls.Add(this.treeView_proj);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.rightClickMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip rightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem btnToevoegen;
        private System.Windows.Forms.ToolStripMenuItem btnVerwijderen;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLibraryToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        public System.Windows.Forms.TreeView treeView_proj;
        public System.Windows.Forms.TreeView treeView_lib;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem disconnectSignalsToolStripMenuItem;
        public System.Windows.Forms.TreeView treeView_sig;
    }
}

