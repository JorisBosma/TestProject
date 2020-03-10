namespace TestProject
{
    partial class PropertyForm
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
            this.propGridSignal = new System.Windows.Forms.PropertyGrid();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // propGridSignal
            // 
            this.propGridSignal.Location = new System.Drawing.Point(12, 12);
            this.propGridSignal.Name = "propGridSignal";
            this.propGridSignal.Size = new System.Drawing.Size(307, 395);
            this.propGridSignal.TabIndex = 0;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(242, 412);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // PropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 447);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.propGridSignal);
            this.Name = "PropertyForm";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.PropertyForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propGridSignal;
        private System.Windows.Forms.Button btn_OK;
    }
}