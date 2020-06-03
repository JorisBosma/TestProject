using System;
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
            TreeView treeView = sender as TreeView;
            MyTreeNode selected_Node = (MyTreeNode)treeView.SelectedNode;
            lbl_list.Text = lbl_list.Text + "\n" + selected_Node.nNode.sNode;
            MyTreeNode newNode = new MyTreeNode(selected_Node.nNode);
            newNode.Text = newNode.nNode.sNode;
            newNode = (MyTreeNode)selected_Node.Clone();
            if ((pNode.nNode.GetClass() == "Device" && newNode.nNode.GetClass() != "Signal") || (pNode.nNode.GetClass() == "Node" && newNode.nNode.GetClass() == "Signal") || (pNode.nNode.GetClass() == "Signal"))
            {
                return;
            }
            if (newNode.nNode.GetClass() == "Device")
            {
                Form f3 = new Form3(newNode);
                f3.Show();
            }
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
            //ZOEKEN
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
            // pNode.nNode.AddNode(newNode);
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
    }
}
