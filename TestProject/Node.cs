using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestProject
{
    public class Node
    {
        public Node searchRet;
        public virtual List<Node> Nodes { get; set; }
        public string sNode { get; set; }

        public Node(string label)
        {
            this.Nodes = new List<Node>();
            this.sNode = label;
        }
        public virtual void AddNode(Node n)
        {
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
        public virtual bool containsNode(string s)
        {
            if (this.sNode.ToLower().Contains(s.ToLower()))
            {
                return true;
            }
            return false;
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
                string merk = e.GetAttribute("merk");
                string soort = e.GetAttribute("soort");
                string type = e.GetAttribute("type");
                string omschrijving = e.GetAttribute("omschrijving");
                Device newNode = new Device(s);
                newNode.Merk = merk;
                newNode.Soort = soort;
                newNode.Type = type;
                newNode.Omschrijving = omschrijving;
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
                Signal newNode = new Signal(s, "testType");
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
}
