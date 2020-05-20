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
using System.Xml.Serialization;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace TestProject
{
    [Serializable]
    [DataContract(Name = "Node", Namespace = "TestProject", IsReference = true)]
    public class Node
    {
        //  public Node searchRet;
        [DataMember]
        public virtual List<Node> Nodes { get; set; }
        [DisplayName("Name")]
        [DataMember]
        public string sNode { get; set; }
        public Node()
        {
              
        }
        public Node(string label)
        {
            this.Nodes = new List<Node>();
            this.sNode = label;

        }
        public virtual void AddNode(Node n)
        {
            if (n.GetClass() == "Signal") return;
            Nodes.Add(n);
        }
        public virtual void RemoveNode(Node n)
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
        public virtual bool containsNode(string s)
        {
            if (this.sNode.ToLower().Contains(s.ToLower()))
            {
                return true;
            }
            return false;
        }
      
    }
}
