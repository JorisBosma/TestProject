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
            CreateFromXML("proj.xml", treeView_proj);
            CreateFromXML("lib.xml", treeView_lib);
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

        private MyTreeNode SearchNode(string SearchText, MyTreeNode StartNode)
        {
            MyTreeNode node = null;
            while (StartNode != null)
            {
                if (StartNode.nNode.sNode.ToLower().Contains(SearchText.ToLower()))
                {
                    node = StartNode;
                    break;
                };
                if (StartNode.Nodes.Count != 0)
                {
                    node = SearchNode(SearchText, (MyTreeNode)StartNode.Nodes[0]);//Recursive Search
                    if (node != null) break;
                }
                StartNode = (MyTreeNode)StartNode.NextNode;
            }
            return node;
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                string search = txtFilter.Text;
                if (search.Count() < 3) return;
                MyTreeNode SelectedNode = SearchNode(search, (MyTreeNode)treeView_lib.Nodes[0]);
                if (SelectedNode != null)
                {
                    treeView_lib.SelectedNode = SelectedNode;
                    this.treeView_lib.Select();
                }
            }
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyTreeNode root = (MyTreeNode)treeView_proj.Nodes[0];

            //start writing all nodes to overarching element
            string rs = "<?xml version='1.0' encoding='UTF-8'?>\n<XML>\n<project projectnr='" + txtProjNr.Text + "'></project>\n<LastEdit Editor='" + Environment.UserName + "'></LastEdit>\n";
            rs = rs + root.nNode.GenerateXML() + "</XML>";
            //Console.WriteLine(rs);
            string File = "Test.xml";
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"C:\Users\Joris.Bosma.KG\source\repos\TestProject\TestProject\bin\Debug",
                Title = "Browse XML Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true,
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File = saveFileDialog.FileName;
            }
            System.IO.File.WriteAllText(File, rs);
        }

        private void openProjectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string File = "Test.xml";
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\Joris.Bosma.KG\source\repos\TestProject\TestProject\bin\Debug",
                Title = "Browse XML Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                File = openFileDialog.FileName;
            }
            CreateFromXML(File, treeView_proj);
        }

        private void saveLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyTreeNode root = (MyTreeNode)treeView_proj.Nodes[0];
            //start writing all nodes to overarching element
            string rs = "<?xml version='1.0' encoding='UTF-8'?>\n<XML>\n<LastEdit Editor='" + Environment.UserName + "'></LastEdit>\n";
            rs = rs + root.nNode.GenerateXML() + "</XML>";
            //Console.WriteLine(rs);
            string File = "Test.xml";
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"C:\Users\Joris.Bosma.KG\source\repos\TestProject\TestProject\bin\Debug",
                Title = "Browse XML Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true,
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File = saveFileDialog.FileName;
            }
            System.IO.File.WriteAllText(File, rs);
        }

        private void openLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string File = "Test.xml";
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\Joris.Bosma.KG\source\repos\TestProject\TestProject\bin\Debug",
                Title = "Browse XML Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                File = openFileDialog.FileName;
            }
            CreateFromXML(File, treeView_lib);
        }

        private void CreateFromXML(string File, TreeView treeView)
        {
            string rs = System.IO.File.ReadAllText(File);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(rs);
            XmlElement root = doc.DocumentElement;
            Node nroot = new Node("TempTreeRoot");
            nroot.parseXML(root);
            MyTreeNode myTreeRoot = new MyTreeNode(nroot.Nodes[0]);
            PopulateTree(myTreeRoot, treeView);
        }
    }

    //---------------------------CLASSES----------------------------------------------------------------------------------------------------------------------
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
        public virtual string GetClass()
        {
            return "Node";
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
        public virtual void parseXML(XmlElement e)
        {
            XmlElement t = null;
            if (e.Name == "Node")
            {
                string s = e.GetAttribute("name");
                Node newNode = new Node(s);
                this.Nodes.Add(newNode);
                if (e.HasChildNodes == true)
                {
                    t = (XmlElement)e.ChildNodes[0];
                    newNode.parseXML(t);
                }
                t = (XmlElement)e.NextSibling;
                if (t != null)
                {
                    this.parseXML(t);
                }
            }
            else if (e.Name == "Device")
            {
                string s = e.GetAttribute("name");
                Device newNode = new Device(s);
                this.Nodes.Add(newNode);
                if (e.HasChildNodes == true)
                {
                    t = (XmlElement)e.ChildNodes[0];
                    newNode.parseXML(t);
                }
                t = (XmlElement)e.NextSibling;
                if (t != null)
                {
                    this.parseXML(t);
                }
            }
            else if (e.Name == "Signal")
            {
                string s = e.GetAttribute("name");
                Signal newNode = new Signal(s);
                this.Nodes.Add(newNode);
                if (e.HasChildNodes == true)
                {
                    t = (XmlElement)e.ChildNodes[0];
                    newNode.parseXML(t);
                }
                t = (XmlElement)e.NextSibling;
                if (t != null)
                {
                    this.parseXML(t);
                }
            }
            else if (t == null)
            {
                t = (XmlElement)e.NextSibling;
                if (t != null)
                {
                    this.parseXML(t);
                }
                else if (e.HasChildNodes)
                {
                    t = (XmlElement)e.ChildNodes[0];
                    this.parseXML(t);
                }
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
        public Signal GetSignals()
        {

            return null;
        }
        public override string GenerateXML()
        {
            String result;
            result = "<Device name='" + this.sNode + "'>\n";
            foreach (Node n in this.Nodes)
            {
                result = result + n.GenerateXML();
            }
            foreach (Signal s in this.Signals)
            {
                result = result + s.GenerateXML();
            }
            result = result + "</Device>\n";
            return result;
        }
        public override string GetClass()
        {
            return "Device";
        }
    }
    public class Signal : Node
    {
        public SignalType signalType;
        public Signal(string sNode) : base(sNode)
        {
            this.signalType = new SignalType("");
        }

        public override string GenerateXML()
        {
            String result;
            result = "<Signal name='" + this.sNode + "'>\n</Signal>\n";
            return result;
        }
        public override string GetClass()
        {
            return "Signal";
        }
    }

    public class SignalType
    {
        public string Type;
        public SignalType(string sType)
        {
            this.Type = sType;
        }
    }
}