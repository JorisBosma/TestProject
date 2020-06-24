using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
namespace TestProject
{
    public partial class Form2 : Form
    {
        public MyTreeNode pNode; //this is the node on which you clicked
        public MyTreeNode addedNode;
        
        List<Signal> l = new List<Signal>();
        public Form2(MyTreeNode p)
        {
            this.pNode = p;
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            treeView_lib_f2.ItemDrag += new ItemDragEventHandler(treeView_lib_f2_ItemDrag);
        }
        public Form2()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Adds from the "new" section to the project
            string Name = txtName.Text;
            Node newNode = new Node(Name);
            if (Name == null) return;
            if (radioButton1.Checked == true)
            {
                newNode = new Device(Name);
            }
            else if (radioButton2.Checked == true)
            {
                string type = cboxType.SelectedItem.ToString();
                newNode = new Signal(Name, type);
            }
            MyTreeNode newTreeNode = new MyTreeNode(newNode);
            newTreeNode.Text = newNode.sNode;
            pNode.nNode.AddNode(newNode);
            if ((pNode.nNode.GetClass() == "Device" && newNode.GetClass() != "Signal") || (pNode.nNode.GetClass() == "Node" && newNode.GetClass() == "Signal") || (pNode.nNode.GetClass() == "Signal"))
            {
                return;
            }
            else
            {
                pNode.Nodes.Add(newTreeNode);
            }
            pNode.Expand();
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
            if (radioButton2.Checked == true)
            {
                cboxType.Show();
            }
        }
        private void treeView_lib_f2_DoubleClick(object sender, EventArgs e)
        {
            //Sets node as selected node, after this you can also select signals from a device
            //In the future, want to add it to a list instead of just 1 node at a time
            TreeView treeView = sender as TreeView;
            MyTreeNode selected_Node = (MyTreeNode)treeView.SelectedNode;
            lbl_list.Text ="SELECTED: \n" + selected_Node.nNode.sNode;
            MyTreeNode newNode = new MyTreeNode(selected_Node.nNode);
            newNode.Text = newNode.nNode.sNode;
            newNode = (MyTreeNode)selected_Node.Clone();
            if ((pNode.nNode.GetClass() == "Device" && newNode.nNode.GetClass() != "Signal") || (pNode.nNode.GetClass() == "Node" && newNode.nNode.GetClass() == "Signal") || (pNode.nNode.GetClass() == "Signal"))
            {
                return;
            }
            if (newNode.nNode.GetClass() == "Device")
            {
                Device d = (Device)newNode.nNode;
                clBox.Items.Clear();
                foreach (Signal s in d.Signals)
                {
                    l.Add(s);
                    clBox.Items.Add(s.sNode);
                }
                
                d.Signals.Clear();
                newNode.nNode = d;
                newNode.Nodes.Clear();
            }
            addedNode = newNode;
        }
        private MyTreeNode SearchNode(string SearchText, MyTreeNode StartNode)
        {
            MyTreeNode treeNode = new MyTreeNode(StartNode.nNode);
            treeNode.Text = treeNode.nNode.sNode;
            if (StartNode == null) return treeNode;
            foreach(MyTreeNode n in StartNode.Nodes)
            {
                SearchNode(SearchText, n);
                if (n.Text.ToLower().Contains(SearchText.ToLower()))
                {
                    MyTreeNode cl = (MyTreeNode)n.Clone();
                    treeNode.Nodes.Add(cl);
                }
            }
            return treeNode;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //ZOEKEN
            Form1 f1 = new Form1();
            f1.CreateFromXML("lib.xml", treeView_lib_f2);
            string search = txtFilter_f2.Text;
            if (search.Count() < 3) return;
            MyTreeNode startNode = (MyTreeNode)treeView_lib_f2.Nodes[0];

            MyTreeNode SelectedNode = SearchNode(search, startNode);
            if (SelectedNode != null)
            {
                treeView_lib_f2.Nodes.Clear();
                treeView_lib_f2.Nodes.Add(SelectedNode);
                treeView_lib_f2.Nodes[0].Expand();
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OPEN
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
            Form1 f1 = new Form1();
            f1.CreateFromXML(File, treeView_lib_f2);

        }
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //SAVE
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

            MyTreeNode treeRoot = (MyTreeNode)treeView_lib_f2.Nodes[0];
            Node root = treeRoot.nNode;
            DataContractSerializer xs = new DataContractSerializer(typeof(Node), "Node", "Building", new Type[] { typeof(Device), typeof(Signal) });
            FileStream txtWriter = new FileStream(Path, FileMode.Create);

            xs.WriteObject(txtWriter, root);

            txtWriter.Close();
        }
        private void treeView_lib_f2_MouseClick(object sender, MouseEventArgs e)
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
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PROPERTIES FOR LIBRARY
            //set sender as toolstrip item to make properties accessable
            ToolStripItem button = sender as ToolStripItem;
            //then ask for the parent and put it in pbutton
            ContextMenuStrip pbutton = (ContextMenuStrip)button.GetCurrentParent();
            //then put the parent's tag into treeview
            TreeView treeView = (TreeView)pbutton.Tag;
            MyTreeNode selectedNode = (MyTreeNode)treeView.SelectedNode;
            //Open new form and give the (new) parent node 
            Form propForm = new PropertyForm(selectedNode);
            propForm.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //ADD TO LIBRARY
            //pNode becomes the selectedNode from the lib
            MyTreeNode SelectedNode = (MyTreeNode)treeView_lib_f2.SelectedNode;
            string Name = txtName.Text;
            Node newNode = new Node(Name);
            if (Name == null) return;
            if (radioButton1.Checked == true)
            {
                newNode = new Device(Name);
            }
            else if (radioButton2.Checked == true)
            {
                string type = cboxType.SelectedItem.ToString();
                newNode = new Signal(Name, type);
            }
            MyTreeNode newTreeNode = new MyTreeNode(newNode);
            newTreeNode.Text = newNode.sNode;
            SelectedNode.nNode.AddNode(newNode);
            //pNode.nNode.AddNode(newNode);
            if ((SelectedNode.nNode.GetClass() == "Device" && newNode.GetClass() != "Signal") || (SelectedNode.nNode.GetClass() == "Node" && newNode.GetClass() == "Signal") || (SelectedNode.nNode.GetClass() == "Signal"))
            {
                return;
            }
            else
            {
                SelectedNode.Nodes.Add(newTreeNode);
            }
            SelectedNode.Expand();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //This button adds the selected Node(, device or signal) to the project 
            //In the future I want to make this a list instead of just 1 node
            if (addedNode == null) return;
            if(addedNode.nNode.GetClass() == "Device")
            {
                Device d = (Device)addedNode.nNode;
                
                foreach (Object o in clBox.CheckedItems)
                {
                    foreach(Signal s1 in l)
                    {
                        if(o.ToString() == s1.sNode)
                        {
                            d.Signals.Add(s1);
                            MyTreeNode s1t = new MyTreeNode(s1);
                            s1t.Text = s1t.nNode.sNode;
                            addedNode.Nodes.Add(s1t);
                        }
                    }   
                }
                addedNode.nNode = d;
            }
            addNodes(addedNode);
            lbl_list.Text = "SELECTED: \n";

        }
        public void addNodes(MyTreeNode newNode)
        {
            pNode.Nodes.Add(newNode);
            pNode.nNode.AddNode(newNode.nNode);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.CreateFromXML("lib.xml", treeView_lib_f2);
        }

        private void treeView_lib_f2_DragDrop(object sender, DragEventArgs e)
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
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                }

                // If it is a copy operation, clone the dragged node 
                // and add it to the node at the drop location.
                else if (e.Effect == DragDropEffects.Copy)
                {
                    targetNode.Nodes.Add((MyTreeNode)draggedNode.Clone());
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
            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }

        private void treeView_lib_f2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void treeView_lib_f2_DragOver(object sender, DragEventArgs e)
        {
            TreeView treeView = sender as TreeView;

            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = treeView.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            treeView.SelectedNode = treeView.GetNodeAt(targetPoint);
        }
        private void treeView_lib_f2_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Path = "temp.xml";
            //WRITE DATA TO TEMP FILE
            MyTreeNode treeRoot = (MyTreeNode)treeView_lib_f2.Nodes[0];
            Node root = treeRoot.nNode;
            DataContractSerializer xs = new DataContractSerializer(typeof(Node), "Node", "Building", new Type[] { typeof(Device), typeof(Signal) });
            FileStream txtWriter = new FileStream(Path, FileMode.Create);
            xs.WriteObject(txtWriter, root);

            txtWriter.Close();

            //READ THAT DATA FROM TEMP
            DataContractSerializer xs2 = new DataContractSerializer(typeof(Node), "Node", "Building", new Type[] { typeof(Device), typeof(Signal) });

            using (Stream reader = new FileStream(Path, FileMode.Open))
                root = (Node)xs2.ReadObject(reader);

            //Console.WriteLine(root.sNode);
            MyTreeNode myTreeRoot = new MyTreeNode(root);

            Form1 f1 = new Form1();
            f1.CreateFromXML("temp.xml", treeView_lib_f2);
        }
    }
}
