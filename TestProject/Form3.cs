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
    public partial class Form3 : Form
    {
        MyTreeNode TreeNode;
        public Form3()
        {
            InitializeComponent();

        }
        public Form3(MyTreeNode myTreeNode)
        {
            TreeNode = myTreeNode;
            InitializeComponent();
        }

        public void Form3_Load(object sender, EventArgs e)
        {
            Device d = (Device)TreeNode.nNode;
            foreach(Signal s in d.Signals)
            {
                clBox.Items.Add(s.sNode);
            }         
        }
    }
}
