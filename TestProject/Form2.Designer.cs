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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.lblParent = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblParentTxt = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.cboxType = new System.Windows.Forms.CheckedListBox();
            this.IO = new System.Windows.Forms.CheckBox();
            this.treeView_lib_f2 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_list = new System.Windows.Forms.Label();
            this.txtFilter_f2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            this.cboxType.FormattingEnabled = true;
            this.cboxType.Items.AddRange(new object[] {
            resources.GetString("cboxType.Items"),
            resources.GetString("cboxType.Items1"),
            resources.GetString("cboxType.Items2")});
            resources.ApplyResources(this.cboxType, "cboxType");
            this.cboxType.Name = "cboxType";
            // 
            // IO
            // 
            resources.ApplyResources(this.IO, "IO");
            this.IO.Name = "IO";
            this.IO.UseVisualStyleBackColor = true;
            // 
            // treeView_lib_f2
            // 
            this.treeView_lib_f2.AllowDrop = true;
            resources.ApplyResources(this.treeView_lib_f2, "treeView_lib_f2");
            this.treeView_lib_f2.Name = "treeView_lib_f2";
            this.treeView_lib_f2.DoubleClick += new System.EventHandler(this.treeView_lib_f2_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IO);
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
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFilter_f2);
            this.Controls.Add(this.lbl_list);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeView_lib_f2);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.lblParentTxt);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.CheckBox IO;
        public System.Windows.Forms.TreeView treeView_lib_f2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_list;
        private System.Windows.Forms.TextBox txtFilter_f2;
        private System.Windows.Forms.Button button1;
    }
}