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
{
    public partial class Form2 : Form
    {
        public MyTreeNode pNode;
        public Form2(MyTreeNode p)
        {
            this.pNode = p;
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            Node newNode = new Node(Name);
            if (Name == null) return;
            if(radioButton1.Checked == true)
            {
                newNode = new Device(Name);
            }
            else if(radioButton2.Checked == true)
            {
                string type = cboxType.SelectedItem.ToString();
                newNode = new Signal(Name, type);
            }
            MyTreeNode newTreeNode = new MyTreeNode(newNode);
            newTreeNode.Text = newNode.sNode;
            pNode.nNode.AddNode(newNode);
            pNode.Nodes.Add(newTreeNode);
            pNode.Expand();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            lblParent.Text = pNode.nNode.sNode;
            cboxType.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                cboxType.Show();
            }
        }
    }
}
