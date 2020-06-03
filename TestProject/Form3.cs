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
        Device d;
        public Form3()
        {
            InitializeComponent();

        }
        public Form3(MyTreeNode myTreeNode)
        {
            TreeNode = myTreeNode;
            InitializeComponent();
            d = (Device)TreeNode.nNode;
        }

        public void Form3_Load(object sender, EventArgs e)
        {
            clBox.Items.Clear();
            foreach(Signal s in d.Signals)
            {
                clBox.Items.Add(s.sNode);
            }         
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Device temp = d;
           // d.Signals.Clear();
            int i = 0;
            foreach (object o in clBox.CheckedItems)
            {
                if(o.ToString() == temp.Signals[0].sNode)
                {
                    d.Signals.Add(temp.Signals[0]);
                }
                i++;
            }
            this.Close();
        }
    }
}
