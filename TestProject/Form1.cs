using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TestProject
{
    public partial class Form1 : Form
    {
        // public event System.Windows.Forms.ItemDragEventHandler ItemDrag;
        public Form1()
        {
            InitializeComponent();
            treeView_proj.ItemDrag += new ItemDragEventHandler(treeView_ItemDrag);
            treeView_proj.DragEnter += new DragEventHandler(treeView_DragEnter);
            treeView_proj.DragOver += new DragEventHandler(treeView_DragOver);
            treeView_proj.DragDrop += new DragEventHandler(treeView_DragDrop);
            treeView_proj.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView_MouseDown);
            treeView_proj.KeyDown += new KeyEventHandler(treeview_Shift);

            //INIT for lib_treeview
            treeView_lib.ItemDrag += new ItemDragEventHandler(treeView_ItemDrag);
            treeView_lib.DragEnter += new DragEventHandler(treeView_DragEnter);
            treeView_lib.DragOver += new DragEventHandler(treeView_DragOver);
            treeView_lib.DragDrop += new DragEventHandler(treeView_DragDrop);
            treeView_lib.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView_MouseDown);
            treeView_lib.KeyDown += new KeyEventHandler(treeview_Shift);



        }

        private void Form1_Load(object sender, EventArgs e)
        //----------------MAIN------------------------------------------------
        {

            Node root = new Node("RootNode");
            Node node1 = new Node("node1");
            Node node1a = new Node("node1a");
            Node node1b = new Node("node1b");
            Node node1c = new Node("node1c");
            Node node2 = new Node("node2");
            Node node2a = new Node("node2a");
            Device Dev1 = new Device("Dev1");
            Signal Sig1 = new Signal("Sig1");
            Signal Sig2 = new Signal("Sig2");

            Node lroot = new Node("LRoot node");
            Node lnode1 = new Node("Lnode1");
            Node lnode1a = new Node("Lnode1a");
            Node lnode1b = new Node("Lnode1b");
            Node lnode1c = new Node("Lnode1c");
            Node lnode2 = new Node("Lnode2");
            Node lnode2a = new Node("Lnode2a");
            Device lDev1 = new Device("LDev1");
            Signal lSig1 = new Signal("LSig1");
            Signal lSig2 = new Signal("LSig2");

            //  Node root;
            //  root = NodeFactory.readXML();

            //Make a tree root node, and give it the original root node-------------
            MyTreeNode MyTreeRoot = new MyTreeNode(root);
            //There is always one original root (right?)
            MyTreeNode MyTreeRoot2 = new MyTreeNode(lroot); // This root is used for the library

            root.AddNode(node1);
            root.AddNode(node2);
            root.AddNode(Dev1);

            node1.AddNode(node1a);
            node1.AddNode(node1b);
            node1.AddNode(node1c);
            node2.AddNode(node2a);
            Dev1.AddSignal(Sig1);
            Dev1.AddSignal(Sig2);

            lroot.AddNode(lnode1);
            lroot.AddNode(lnode2);
            lroot.AddNode(lDev1);

            lnode1.AddNode(lnode1a);
            lnode1.AddNode(lnode1b);
            lnode1.AddNode(lnode1c);
            lnode2.AddNode(lnode2a);
            lDev1.AddSignal(lSig1);
            lDev1.AddSignal(lSig2);

            Dev1.GetSignals(Dev1.Signals);
            PopulateTree(MyTreeRoot, treeView_proj);
            PopulateTree(MyTreeRoot2, treeView_lib);

        }
        public void PopulateTree(MyTreeNode MyTreeRoot, TreeView treeView)
        {
            MyTreeRoot.Text = MyTreeRoot.nNode.sNode;
            treeView.Nodes.Clear();
            treeView.Nodes.Add(MyTreeRoot);
            MyTreeRoot.getTreeNodes();
        }

        public void treeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            TreeView treeView = sender as TreeView;

            ContextMenuStrip contextMenu = rightClickMenu;
            //set the tag of the contextmenu as the current treeview, this is for later use in the button
            contextMenu.Tag = treeView;
            MyTreeNode selected_Node = (MyTreeNode)treeView.GetNodeAt(e.X, e.Y);
            if (selected_Node == null) return;
            treeView.SelectedNode = selected_Node;
            selected_Node.ContextMenuStrip = contextMenu;
            selected_Node.ContextMenuStrip.Show(treeView, new Point(e.X, e.Y));
        }
        private void btnVerwijderen_Click(object sender, EventArgs e)
        {
            //set sender as toolstrip item to make properties accessable
            ToolStripItem button = sender as ToolStripItem;
            //then ask for the parent and put it in pbutton
            ContextMenuStrip pbutton = (ContextMenuStrip)button.GetCurrentParent();
            //then put the parent's tag into treeview
            TreeView treeView = (TreeView)pbutton.Tag;
            MyTreeNode selectedNode = (MyTreeNode)treeView.SelectedNode;
            MyTreeNode pNode = (MyTreeNode)selectedNode.Parent;
            pNode.nNode.RemoveNode(selectedNode.nNode);
            selectedNode.Remove();
        }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            //set sender as toolstrip item to make properties accessable
            ToolStripItem button = sender as ToolStripItem;
            //then ask for the parent and put it in pbutton
            ContextMenuStrip pbutton = (ContextMenuStrip)button.GetCurrentParent();
            //then put the parent's tag into treeview
            TreeView treeView = (TreeView)pbutton.Tag;
            MyTreeNode selectedNode = (MyTreeNode)treeView.SelectedNode;

            //Open new form and give the (new) parent node 
            Form form2 = new Form2(selectedNode);
            form2.Show();


        }
        public void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.

            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        public void treeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        public void treeView_DragOver(object sender, DragEventArgs e)
        {
            TreeView treeView = sender as TreeView;

            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = treeView.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            treeView.SelectedNode = treeView.GetNodeAt(targetPoint);
        }

        public void treeView_DragDrop(object sender, DragEventArgs e)
        {
            TreeView treeView = sender as TreeView;

            // Retrieve the client coordinates of the drop location.
            Point targetPoint = treeView.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            MyTreeNode targetNode = (MyTreeNode)treeView.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            MyTreeNode draggedNode = (MyTreeNode)e.Data.GetData(typeof(MyTreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (targetNode == null) targetNode = (MyTreeNode)treeView.Nodes[0]; //als jij niet op een node sleept, targetNode wordt rootnode
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    if (draggedNode.TreeView == treeView_lib && targetNode.TreeView == treeView_proj)
                    {
                        MyTreeNode cNode = new MyTreeNode(draggedNode.nNode);
                        cNode.Text = draggedNode.nNode.sNode;
                        cNode.getTreeNodes();
                        targetNode.nNode.AddNode(cNode.nNode);
                        targetNode.Nodes.Add(cNode);
                    }
                    else
                    {
                        //Remove and Add node in Data
                        MyTreeNode parentNode = (MyTreeNode)draggedNode.Parent;
                        // MyTreeNode cloneNode = (MyTreeNode)draggedNode.Clone();
                        if (parentNode == null) return;
                        parentNode.nNode.RemoveNode(draggedNode.nNode);
                        targetNode.nNode.AddNode(draggedNode.nNode);

                        //Remove and Add node in the tree
                        //Always do this after manipulating the data, otherwise the parentNode is not accurate                    
                        draggedNode.Remove();
                        targetNode.Nodes.Add(draggedNode); //Put dragged node on top (bottom is default)
                    }
                }
                // Expand the node at the location 
                // to show the dropped node.
                targetNode.Expand();
            }
        }
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.            
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;
            // Also gotta figure out what this does exactly?!?!?!
            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }


        private void treeview_Shift(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.NumPad9 || e.KeyCode != Keys.NumPad3) return;
            TreeView treeView = sender as TreeView;

            MyTreeNode selectedNode = (MyTreeNode)treeView.SelectedNode;
            MyTreeNode cNode = selectedNode; 
            MyTreeNode pNode = (MyTreeNode)selectedNode.Parent;
            int i = selectedNode.Index;

            //change index based on which key is pressed
            if (e.KeyCode == Keys.NumPad9) i--;
            if (e.KeyCode == Keys.NumPad3) i++;

            //Remove old node from tree & data
            selectedNode.Remove();
            pNode.nNode.RemoveNode(selectedNode.nNode);

            //Add the copy to parent with new index
            pNode.Nodes.Insert(i, cNode);
            pNode.nNode.InsertNode(i, cNode.nNode);
            treeView.SelectedNode = cNode;
        }

        private void btnDoXML_Click(object sender, EventArgs e)
        {
            MyTreeNode root = (MyTreeNode)treeView_proj.Nodes[0];

            //start writing all nodes to overarching element
            string rs = root.nNode.GenerateXML();
            Console.WriteLine(rs);
            System.IO.File.WriteAllText("Test.xml", rs);
        }

        private void btnGetXML_Click(object sender, EventArgs e)
        {
            string rs = System.IO.File.ReadAllText("Test.xml");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(rs);
            XmlElement root = doc.DocumentElement;
            Node nroot = new Node("GETTREETHING");
            nroot.parseXML(root);
            MyTreeNode myTreeRoot = new MyTreeNode(nroot.Nodes[0]);
            PopulateTree(myTreeRoot, treeView_proj);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string search = txtFilter.Text;
            if(search.Count() <= 3) return;
            MyTreeNode n = (MyTreeNode)treeView_lib.Nodes[0];
            n.searchTree(search);
            treeView_lib.SelectedNode = n;

        }
    }

    //---------------------------CLASS DEFINITIONS------------------------------------
    public class MyTreeNode : TreeNode
    {
        public Node nNode;

        public MyTreeNode(Node n)
        {
            this.nNode = n;
        }


        public void getTreeNodes()
        {
            foreach (Node n in this.nNode.Nodes)
            {
                MyTreeNode a = new MyTreeNode(n);
                //a.nNode = n;
                a.getTreeNodes();
                a.Text = a.nNode.sNode;
                this.Nodes.Add(a);
            }
        }

        public void searchTree(string s)
        {
            
            
        }
    }

    public class Node
    {
        public List<Node> Nodes;
        public string sNode;

        public Node(string label)
        {
            this.Nodes = new List<Node>();
            this.sNode = label;
        }

        public void AddNode(Node n)
        {
            Nodes.Add(n);
        }
        public void RemoveNode(Node n)
        {
            Nodes.Remove(n);
        }
        public void InsertNode(Int32 i, Node n)
        {
            if (i < 0) return;
            if (i > Nodes.Count()) return;
            Nodes.Insert(i, n);
        }

        public virtual string GenerateXML()
        {
            String result;
            result = "<Node name='" + this.sNode + "'>\n";
            foreach (Node n in this.Nodes)
            {
                result = result + n.GenerateXML();
            }
            result = result + "</Node>\n";
            return result;
        }
        public void parseXML(XmlElement e)
        {
            string s = e.GetAttribute("name");
            XmlElement t;
            Node newNode = new Node(s);
            this.Nodes.Add(newNode);
            if (e.HasChildNodes == true)
            {
                t = (XmlElement)e.ChildNodes[0];
                newNode.parseXML(t);
            }
            t = (XmlElement)e.NextSibling;
            if(t != null)
            {
                this.parseXML(t);
            }
        }
    }


    public class Device : Node
    {
        public List<Signal> Signals;
        public Device(string sNode) : base(sNode)
        {
            this.Signals = new List<Signal>();
        }

        public void AddSignal(Signal s)
        {
            Signals.Add(s);
        }
        public void GetSignals(List<Signal> Signals)
        {
            int i = 0;
            Signals.ForEach(delegate (Signal ss)
            {
                i++;
            });
        }
        public override string GenerateXML()
        {
            String result;
            result = "<Device name='" + this.sNode + "'>\n";
            foreach (Node n in this.Nodes)
            {
                result = result + n.GenerateXML();
            }
            result = result + "</Device>\n";
            return result;
        }
        
    }
    public class Signal
    {
        public List<SignalType> signalTypes;
        public string sSignal;
        public Signal(string label)
        {
            this.sSignal = label;
        }
        public void parseXML()
        {

        }
    }

    public class SignalType 
    {
        
    }
}