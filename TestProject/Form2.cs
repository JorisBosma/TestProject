using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
namespace TestProject
{
    public partial class Form2 : Form
    {
        public MyTreeNode pNode; //this is the node on which you clicked
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
            if((pNode.nNode.GetClass() == "Device" && newNode.GetClass() != "Signal") || (pNode.nNode.GetClass() == "Node" && newNode.GetClass() == "Signal") || (pNode.nNode.GetClass() == "Signal"))
            {
                return;
            }
            else
            {
                pNode.Nodes.Add(newTreeNode);
            } 
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
            Form1 f1 = new Form1();
            f1.CreateFromXML("lib.xml", treeView_lib_f2);
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                cboxType.Show();
            }
        }

        private void treeView_lib_f2_DoubleClick(object sender, EventArgs e)
        {
            TreeView treeView = sender as TreeView;
            MyTreeNode selected_Node = (MyTreeNode)treeView.SelectedNode;
            lbl_list.Text = lbl_list.Text + "\n" + selected_Node.nNode.sNode;
            MyTreeNode newNode = new MyTreeNode(selected_Node.nNode);
            newNode.Text = newNode.nNode.sNode;
            pNode.Nodes.Add(newNode);
            pNode.nNode.AddNode(newNode.nNode);
            
        }

        private MyTreeNode SearchNode(string SearchText, MyTreeNode StartNode)
        {
            MyTreeNode treeNode = null;
            while (StartNode != null)
            {
                if (StartNode.nNode.containsNode(SearchText))
                {
                    treeNode = StartNode;
                    break;
                };
                if (StartNode.Nodes.Count != 0)
                {
                    treeNode = SearchNode(SearchText, (MyTreeNode)StartNode.Nodes[0]);//Recursive Search
                    if (treeNode != null) break;
                }
                StartNode = (MyTreeNode)StartNode.NextNode;
            }
            return treeNode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string search = txtFilter_f2.Text;
            if (search.Count() < 3) return;
            MyTreeNode startNode = (MyTreeNode)treeView_lib_f2.Nodes[0];

            MyTreeNode SelectedNode = SearchNode(search, startNode);
            if (SelectedNode != null)
            {
                treeView_lib_f2.SelectedNode = SelectedNode;
                this.treeView_lib_f2.Select();
            }
        }
    }
}
