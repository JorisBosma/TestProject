using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace TestProject
{
    public partial class PropertyForm : Form
    {
        public MyTreeNode pNode;
        public PropertyForm(MyTreeNode p)
        {
            this.pNode = p;
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
        }
        private void PropertyForm_Load(object sender, EventArgs e)
        {
            propGridSignal.SelectedObject = pNode.nNode;
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
            //RELOAD PROJ TREEVIEW
            Form1 f1 = new Form1();
            MyTreeNode Treeroot = (MyTreeNode)f1.treeView_proj.Nodes[0];
            Node root = Treeroot.nNode;
            DataContractSerializer xs2 = new DataContractSerializer(typeof(Node), "Node", "Building", new Type[] { typeof(Device), typeof(Signal) });
            FileStream txtWriter2 = new FileStream("temp.xml", FileMode.Create);

            xs2.WriteObject(txtWriter2, root);

            txtWriter2.Close();
            f1.CreateFromXML("temp.xml", f1.treeView_proj);

            System.IO.File.Delete("temp.xml");

            //RELOAD LIB TREEVIEW
            Form2 f2 = new Form2((MyTreeNode)f1.treeView_proj.Nodes[0]);
            Treeroot = (MyTreeNode)f2.treeView_lib_f2.Nodes[0];
            root = Treeroot.nNode;
            DataContractSerializer xs = new DataContractSerializer(typeof(Node), "Node", "Building", new Type[] { typeof(Device), typeof(Signal) });
            FileStream txtWriter = new FileStream("temp.xml", FileMode.Create);

            xs.WriteObject(txtWriter, root);

            txtWriter.Close();

            f1.CreateFromXML("temp.xml", f2.treeView_lib_f2);
            System.IO.File.Delete("temp.xml");
        }
    }
}
