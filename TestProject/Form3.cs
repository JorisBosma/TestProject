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
        public MyTreeNode pNode;
        MyTreeNode TreeNode;
        Device d;
        public Form3()//The string is there to differentiate the constructors
        {
            
            InitializeComponent();

        }
        public Form3(MyTreeNode myTreeNode, MyTreeNode p)
        {
            TreeNode = myTreeNode;
            pNode = p;
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
            /*Device temp = d;
            Device temp2 = new Device(d.sNode);
            
            // d.Signals.Clear();
            int i = 0;
            foreach (object o in clBox.CheckedItems)
            {
                if(o.ToString() == temp.Signals[0].sNode)
                {
                    temp2.Signals.Add(temp.Signals[0]);
                }
                i++;
            }
            MyTreeNode newNode = new MyTreeNode(temp2);
            newNode.Text = newNode.nNode.sNode;
            Form2 f2 = new Form2(pNode);
            f2.addNodes(newNode);*/ //THIS DOESNT ADD TO FORM1 (probably has to do with the parent)
            







            this.Close();
        }
    }
}
