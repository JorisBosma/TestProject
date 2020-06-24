namespace TestProject
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.lblParent = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblParentTxt = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.cboxType = new System.Windows.Forms.CheckedListBox();
            this.treeView_lib_f2 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl_list = new System.Windows.Forms.Label();
            this.txtFilter_f2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.libraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toevoegenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVerwijderen = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.rightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblParent
            // 
            resources.ApplyResources(this.lblParent, "lblParent");
            this.lblParent.Name = "lblParent";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblParentTxt
            // 
            resources.ApplyResources(this.lblParentTxt, "lblParentTxt");
            this.lblParentTxt.Name = "lblParentTxt";
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // cboxType
            // 
            this.cboxType.CheckOnClick = true;
            this.cboxType.FormattingEnabled = true;
            this.cboxType.Items.AddRange(new object[] {
            resources.GetString("cboxType.Items"),
            resources.GetString("cboxType.Items1"),
            resources.GetString("cboxType.Items2")});
            resources.ApplyResources(this.cboxType, "cboxType");
            this.cboxType.Name = "cboxType";
            // 
            // treeView_lib_f2
            // 
            this.treeView_lib_f2.AllowDrop = true;
            resources.ApplyResources(this.treeView_lib_f2, "treeView_lib_f2");
            this.treeView_lib_f2.Name = "treeView_lib_f2";
            this.treeView_lib_f2.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_lib_f2_DragDrop);
            this.treeView_lib_f2.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_lib_f2_DragEnter);
            this.treeView_lib_f2.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView_lib_f2_DragOver);
            this.treeView_lib_f2.DoubleClick += new System.EventHandler(this.treeView_lib_f2_DoubleClick);
            this.treeView_lib_f2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView_lib_f2_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.cboxType);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.btnAdd);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl_list
            // 
            resources.ApplyResources(this.lbl_list, "lbl_list");
            this.lbl_list.Name = "lbl_list";
            // 
            // txtFilter_f2
            // 
            resources.ApplyResources(this.txtFilter_f2, "txtFilter_f2");
            this.txtFilter_f2.Name = "txtFilter_f2";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.libraryToolStripMenuItem,
            this.refreshToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // libraryToolStripMenuItem
            // 
            this.libraryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveToolStripMenuItem1});
            this.libraryToolStripMenuItem.Name = "libraryToolStripMenuItem";
            resources.ApplyResources(this.libraryToolStripMenuItem, "libraryToolStripMenuItem");
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            resources.ApplyResources(this.saveToolStripMenuItem1, "saveToolStripMenuItem1");
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toevoegenToolStripMenuItem,
            this.btnVerwijderen,
            this.propertiesToolStripMenuItem});
            this.rightClickMenu.Name = "rightClickMenu";
            resources.ApplyResources(this.rightClickMenu, "rightClickMenu");
            // 
            // toevoegenToolStripMenuItem
            // 
            this.toevoegenToolStripMenuItem.Name = "toevoegenToolStripMenuItem";
            resources.ApplyResources(this.toevoegenToolStripMenuItem, "toevoegenToolStripMenuItem");
            // 
            // btnVerwijderen
            // 
            this.btnVerwijderen.Name = "btnVerwijderen";
            resources.ApplyResources(this.btnVerwijderen, "btnVerwijderen");
            this.btnVerwijderen.Click += new System.EventHandler(this.btnVerwijderen_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            resources.ApplyResources(this.propertiesToolStripMenuItem, "propertiesToolStripMenuItem");
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // clBox
            // 
            this.clBox.CheckOnClick = true;
            this.clBox.FormattingEnabled = true;
            resources.ApplyResources(this.clBox, "clBox");
            this.clBox.Name = "clBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            resources.ApplyResources(this.refreshToolStripMenuItem, "refreshToolStripMenuItem");
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFilter_f2);
            this.Controls.Add(this.lbl_list);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeView_lib_f2);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.lblParentTxt);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.rightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblParentTxt;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.CheckedListBox cboxType;
        public System.Windows.Forms.TreeView treeView_lib_f2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_list;
        private System.Windows.Forms.TextBox txtFilter_f2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem libraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip rightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem btnVerwijderen;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toevoegenToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox clBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}