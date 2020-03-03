using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public class MyTreeNode : TreeNode
    {
        public Node nNode;
        public MyTreeNode(Node n)
        {
            this.nNode = n;
        }
        public void getTreeNodes()
        {
            if (this.nNode.GetClass() == "Device")
            {
                Device d = (Device)this.nNode;
                foreach (Signal s in d.Signals)
                {
                    MyTreeNode a = new MyTreeNode(s);
                    a.Text = a.nNode.sNode;
                    this.Nodes.Add(a);
                }
            }
            foreach (Node n in this.nNode.Nodes)
            {
                MyTreeNode a = new MyTreeNode(n);
                a.getTreeNodes();
                a.Text = a.nNode.sNode;
                this.Nodes.Add(a);
            }
        }
    }
}
