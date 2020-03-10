using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{                       //sNode is now the name, i want this to be "name" or something like that to make it more readable
    public partial class PropertyForm : Form
    {
        public MyTreeNode pNode;
        Form1 form1;
        public PropertyForm(MyTreeNode p, Form1 form1)
        {
            this.pNode = p;
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.form1 = form1;
        }

        private void PropertyForm_Load(object sender, EventArgs e)
        {
            propGridSignal.SelectedObject = pNode.nNode;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
            MyTreeNode root = (MyTreeNode)form1.treeView_lib.Nodes[0];
            string rs = "<?xml version='1.0' encoding='UTF-8'?>\n<XML>\n<LastEdit Editor='" + Environment.UserName + "'></LastEdit>\n";
            rs = rs + root.nNode.GenerateXML() + "</XML>";
            System.IO.File.WriteAllText("temp.xml", rs);
            form1.CreateFromXML("temp.xml", form1.treeView_lib);

            root = (MyTreeNode)form1.treeView_proj.Nodes[0];
            rs = "<?xml version='1.0' encoding='UTF-8'?>\n<XML>\n<project projectnr='123546879'></project>\n<LastEdit Editor='" + Environment.UserName + "'></LastEdit>\n";
            rs = rs + root.nNode.GenerateXML() + "</XML>";
            System.IO.File.WriteAllText("temp.xml", rs);
            form1.CreateFromXML("temp.xml", form1.treeView_proj);

            System.IO.File.Delete("temp.xml");
        }
    }
}
