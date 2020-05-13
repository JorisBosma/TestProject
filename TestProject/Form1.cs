﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;



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

            //INIT for sig_treeview
            treeView_sig.ItemDrag += new ItemDragEventHandler(treeView_ItemDrag);
            treeView_sig.DragEnter += new DragEventHandler(treeView_DragEnter);
            treeView_sig.DragOver += new DragEventHandler(treeView_DragOver);
            treeView_sig.DragDrop += new DragEventHandler(treeView_DragDrop);
            treeView_sig.KeyDown += new KeyEventHandler(treeview_Shift);

            
        }
        //----------------MAIN-----------------------------------------------------------------------------------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            
            CreateFromXML("proj.xml", treeView_proj);
            CreateFromXML("lib.xml", treeView_lib);
            // CreateFromXML("proj.xml", treeView_sig);
            MyTreeNode libTreeRoot = (MyTreeNode)treeView_lib.Nodes[0];
            Node libRoot = libTreeRoot.nNode;
            MyTreeNode treeRoot = (MyTreeNode)treeView_proj.Nodes[0];
            Node root = treeRoot.nNode;
            PopulateSigTree(root);

            

            //SERIALIZER
            /*XmlRootAttribute xRoot = new XmlRootAttribute();
            XmlSerializer xs = new XmlSerializer(typeof(Node), null, new Type[] { typeof(Device), typeof(Signal)}, xRoot, xRoot.Namespace);
            const string path = @"C:\Users\Joris.Bosma.KG\source\repos\TestProject\TestProject\bin\Debug\Serializing.xml";
            TextWriter txtWriter = new StreamWriter(path);

            xs.Serialize(txtWriter, libRoot);

            txtWriter.Close();
            // Console.WriteLine(s.IO);

            //DESERIALIZER
            //XmlRootAttribute xRoot = new XmlRootAttribute();
            XmlSerializer xs2 = new XmlSerializer(typeof(Node), null, new Type[] { typeof(Device), typeof(Signal) }, xRoot, xRoot.Namespace);
            Node root2;
            using (Stream reader = new FileStream("Serializing.xml", FileMode.Open))
                root2 = (Node)xs2.Deserialize(reader);
            Console.WriteLine(root2.sNode);*/
        }
        public void PopulateTree(MyTreeNode MyTreeRoot, TreeView treeView)
        {
            MyTreeRoot.Text = MyTreeRoot.nNode.sNode;
            treeView.Nodes.Clear();
            treeView.Nodes.Add(MyTreeRoot);
            MyTreeRoot.getTreeNodes();
        }
       
        public void PopulateSigTree(Node myRoot)
        {
            
           foreach(Node n in myRoot.Nodes)
           {
                PopulateSigTree(n);
                if(n.GetClass() == "Device")
                {
                    Device d = (Device)n;
                    MyTreeNode tDev = new MyTreeNode(d);
                    foreach (Signal s in d.Signals)
                    {
                        if (s.ConnectedSignal == null)
                        {
                            MyTreeNode tSig = new MyTreeNode(s);
                            tSig.Text = tSig.nNode.sNode;
                            tDev.Nodes.Add(tSig);
                        }
                    }
                    tDev.Text = tDev.nNode.sNode;
                    treeView_sig.Nodes.Add(tDev);
                    
                }

           }
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
                        if(targetNode.nNode.GetClass() == "Signal" && draggedNode.nNode.GetClass() == "Signal")
                        {
                            Signal sTarget = (Signal)targetNode.nNode;
                            Signal sDragged = (Signal)draggedNode.nNode;
                            sTarget.Connect(sDragged);

                            MyTreeNode t = (MyTreeNode)targetNode.Parent;
                            Device parentD = (Device)t.nNode;
                            parentD.BuildConnections();
                            //System.Console.WriteLine("Connected: "+sTarget.ConnectedSignal.sNode + sDragged.ConnectedSignal.sNode);
                            targetNode.ForeColor = System.Drawing.Color.Green;
                            draggedNode.ForeColor = System.Drawing.Color.Green;
                            //refresh tree
                            MyTreeNode treeRoot = (MyTreeNode)treeView_proj.Nodes[0];
                            Node root = treeRoot.nNode;
                            treeView_sig.Nodes.Clear();
                            PopulateSigTree(root);
                            //sTarget.Disconnnect(sDragged);
                            //System.Console.WriteLine("Connected: " + sTarget.ConnectedSignal.sNode + sDragged.ConnectedSignal.sNode);
                        }
                         
                        if ((targetNode.nNode.GetClass() == "Device" && draggedNode.nNode.GetClass() != "Signal") || (targetNode.nNode.GetClass() == "Node" && draggedNode.nNode.GetClass() == "Signal") || (targetNode.nNode.GetClass() == "Signal"))
                        {
                            return;
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
            if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.NumPad3)
            {
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
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                string search = txtFilter.Text;
                if (search.Count() < 3) return;
                MyTreeNode startNode = (MyTreeNode)treeView_lib.Nodes[0];
                
                MyTreeNode SelectedNode = SearchNode(search, startNode);
                if (SelectedNode != null)
                {
                    treeView_lib.SelectedNode = SelectedNode;
                    this.treeView_lib.Select();
                }
          
            }
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e) 
        {  
            string Path = "Test.xml";
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
                Path = saveFileDialog.FileName;
            }
            HTMLwriter ht = new HTMLwriter();
            
            MyTreeNode treeRoot = (MyTreeNode)treeView_proj.Nodes[0];
            Node root = treeRoot.nNode;
            XmlRootAttribute xRoot = new XmlRootAttribute();
            XmlSerializer xs = new XmlSerializer(typeof(Node), null, new Type[] { typeof(Device), typeof(Signal) }, xRoot, xRoot.Namespace);
            TextWriter txtWriter = new StreamWriter(Path);

            xs.Serialize(txtWriter, root);

            txtWriter.Close();
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
            string Path = "Test.xml";
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
                Path = saveFileDialog.FileName;
            }
            HTMLwriter ht = new HTMLwriter();

            MyTreeNode treeRoot = (MyTreeNode)treeView_lib.Nodes[0];
            Node root = treeRoot.nNode;
            XmlRootAttribute xRoot = new XmlRootAttribute();
            XmlSerializer xs = new XmlSerializer(typeof(Node), null, new Type[] { typeof(Device), typeof(Signal) }, xRoot, xRoot.Namespace);
            TextWriter txtWriter = new StreamWriter(Path);

            xs.Serialize(txtWriter, root);

            txtWriter.Close();

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

        public void CreateFromXML(string File, TreeView treeView)
        {
            //DESERIALIZER
            XmlRootAttribute xRoot = new XmlRootAttribute();
            XmlSerializer xs2 = new XmlSerializer(typeof(Node), null, new Type[] { typeof(Device), typeof(Signal), typeof(Connection) }, xRoot, xRoot.Namespace);
            Node root;
            using (Stream reader = new FileStream(File, FileMode.Open))
                root = (Node)xs2.Deserialize(reader);
            Console.WriteLine(root.sNode);
            MyTreeNode myTreeRoot = new MyTreeNode(root);
            PopulateTree(myTreeRoot, treeView);
        }
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set sender as toolstrip item to make properties accessable
            ToolStripItem button = sender as ToolStripItem;
            //then ask for the parent and put it in pbutton
            ContextMenuStrip pbutton = (ContextMenuStrip)button.GetCurrentParent();
            //then put the parent's tag into treeview
            TreeView treeView = (TreeView)pbutton.Tag;
            MyTreeNode selectedNode = (MyTreeNode)treeView.SelectedNode;
            //Open new form and give the (new) parent node 
            Form propForm = new PropertyForm(selectedNode, this);
            propForm.Show();
        }

        private void disconnectSignalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set sender as toolstrip item to make properties accessable
            ToolStripItem button = sender as ToolStripItem;
            //then ask for the parent and put it in pbutton
            ContextMenuStrip pbutton = (ContextMenuStrip)button.GetCurrentParent();
            //then put the parent's tag into treeview
            TreeView treeView = (TreeView)pbutton.Tag;
            MyTreeNode selectedNode = (MyTreeNode)treeView.SelectedNode;
            Signal SelectedSig = (Signal)selectedNode.nNode;
            SelectedSig.Disconnnect();
            MyTreeNode treeRoot = (MyTreeNode)treeView_proj.Nodes[0];
            Node root = treeRoot.nNode;
            treeView_sig.Nodes.Clear();
            PopulateSigTree(root);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyTreeNode t = (MyTreeNode)treeView_proj.Nodes[0];
            ConnectSignals(t.nNode);
        }
        private void ConnectSignals(Node myRoot)
        {
            foreach (Node n in myRoot.Nodes)
            {
                ConnectSignals(n);
                if (n.GetClass() == "Device")
                {
                    Device d = (Device)n;
                    d.BuildConnectionsInSig();

                }

            }
        }
    } 
}
    