using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace TestProject
{
    public partial class PropertyForm : Form
    {
        public MyTreeNode pNode;
        public PropertyForm(MyTreeNode p)
        {
            this.pNode = p;
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
        }
        private void PropertyForm_Load(object sender, EventArgs e)
        {
            propGridSignal.SelectedObject = pNode.nNode;
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
