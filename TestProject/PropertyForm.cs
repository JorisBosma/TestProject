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
    public partial class PropertyForm : Form
    {
        public MyTreeNode pNode;
        Form1 form1;
        public PropertyForm(MyTreeNode p, Form1 form1)
        {
            this.pNode = p;
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.form1 = form1;
        }
        private void PropertyForm_Load(object sender, EventArgs e)
        {
            propGridSignal.SelectedObject = pNode.nNode;
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
            //RELOAD LIB TREEVIEW
            MyTreeNode Treeroot = (MyTreeNode)form1.treeView_lib.Nodes[0];
            Node root = Treeroot.nNode;
            DataContractSerializer xs = new DataContractSerializer(typeof(Node), "Node", "Building", new Type[] { typeof(Device), typeof(Signal) });
            FileStream txtWriter = new FileStream("temp.xml", FileMode.Create);

            xs.WriteObject(txtWriter, root);

            txtWriter.Close();

            form1.CreateFromXML("temp.xml", form1.treeView_lib);
            System.IO.File.Delete("temp.xml");

            //RELOAD PROJ TREEVIEW
            Treeroot = (MyTreeNode)form1.treeView_proj.Nodes[0];
            root = Treeroot.nNode;
            DataContractSerializer xs2 = new DataContractSerializer(typeof(Node), "Node", "Building", new Type[] { typeof(Device), typeof(Signal) });
            FileStream txtWriter2 = new FileStream("temp.xml", FileMode.Create);

            xs2.WriteObject(txtWriter2, root);

            txtWriter2.Close();
            form1.CreateFromXML("temp.xml", form1.treeView_proj);

            System.IO.File.Delete("temp.xml"); 
        }
    }
}
