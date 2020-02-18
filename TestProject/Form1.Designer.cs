namespace TestProject
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
            this.treeView_lib = new System.Windows.Forms.TreeView();
            this.btnDoXML = new System.Windows.Forms.Button();
            this.btnGetXML = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.rightClickMenu.SuspendLayout();
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
            this.btnVerwijderen});
            this.rightClickMenu.Name = "rightClickMenu";
            this.rightClickMenu.Size = new System.Drawing.Size(136, 48);
            // 
            // btnToevoegen
            // 
            this.btnToevoegen.Name = "btnToevoegen";
            this.btnToevoegen.Size = new System.Drawing.Size(135, 22);
            this.btnToevoegen.Text = "Toevoegen";
            this.btnToevoegen.Click += new System.EventHandler(this.btnToevoegen_Click);
            // 
            // btnVerwijderen
            // 
            this.btnVerwijderen.Name = "btnVerwijderen";
            this.btnVerwijderen.Size = new System.Drawing.Size(135, 22);
            this.btnVerwijderen.Text = "Verwijderen";
            this.btnVerwijderen.Click += new System.EventHandler(this.btnVerwijderen_Click);
            // 
            // treeView_lib
            // 
            this.treeView_lib.AllowDrop = true;
            this.treeView_lib.Location = new System.Drawing.Point(402, 92);
            this.treeView_lib.Name = "treeView_lib";
            this.treeView_lib.Size = new System.Drawing.Size(269, 405);
            this.treeView_lib.TabIndex = 2;
            // 
            // btnDoXML
            // 
            this.btnDoXML.Location = new System.Drawing.Point(42, 519);
            this.btnDoXML.Name = "btnDoXML";
            this.btnDoXML.Size = new System.Drawing.Size(85, 23);
            this.btnDoXML.TabIndex = 3;
            this.btnDoXML.Text = "Generate XML";
            this.btnDoXML.UseVisualStyleBackColor = true;
            this.btnDoXML.Click += new System.EventHandler(this.btnDoXML_Click);
            // 
            // btnGetXML
            // 
            this.btnGetXML.Location = new System.Drawing.Point(229, 519);
            this.btnGetXML.Name = "btnGetXML";
            this.btnGetXML.Size = new System.Drawing.Size(75, 23);
            this.btnGetXML.TabIndex = 5;
            this.btnGetXML.Text = "Get Tree from XML";
            this.btnGetXML.UseVisualStyleBackColor = true;
            this.btnGetXML.Click += new System.EventHandler(this.btnGetXML_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(402, 53);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(269, 20);
            this.txtFilter.TabIndex = 6;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 578);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnGetXML);
            this.Controls.Add(this.btnDoXML);
            this.Controls.Add(this.treeView_lib);
            this.Controls.Add(this.treeView_proj);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.rightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_proj;
        private System.Windows.Forms.ContextMenuStrip rightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem btnToevoegen;
        private System.Windows.Forms.ToolStripMenuItem btnVerwijderen;
        private System.Windows.Forms.TreeView treeView_lib;
        private System.Windows.Forms.Button btnDoXML;
        private System.Windows.Forms.Button btnGetXML;
        private System.Windows.Forms.TextBox txtFilter;
    }
}

