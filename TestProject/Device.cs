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
    public class Device : Node
    {
        public List<Signal> Signals { get; set; }
        public string Merk { get; set; }
        public string Soort { get; set; }
        public string Omschrijving { get; set; }                 //Omschrijving
        public string Type { get; set; }                         //STC100, STP100-50, Magna3 etc.
        public string ToConnnect;
        [Browsable(false)]
        public override List<Node> Nodes { get; set; }

        public Device(string sNode) : base(sNode)
        {
            this.Signals = new List<Signal>();
        }
        public override void AddNode(Node s)
        {
            if (s.GetClass() != "Signal") return;                //Only signals can be added to a device (This is only in the data)
            Signals.Add((Signal)s);
        }
        public override void RemoveNode(Node s)
        {
            if (s.GetClass() != "Signal") return;
            Signals.Remove((Signal)s);
        }
        public override string GenerateXML()
        {
            String result;
            result = "<Device name='" + this.sNode + "' merk='" + this.Merk + "' soort='" + this.Soort + "' omschrijving='" + this.Omschrijving + "' type='" + this.Type + "'>\n";
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
        public override bool containsNode(string s)
        {
            if (this.sNode.ToLower().Contains(s.ToLower())||this.Merk.ToLower().Contains(s.ToLower()) || this.Soort.ToLower().Contains(s.ToLower()) ||  this.Type.ToLower().Contains(s.ToLower()))
            {
                return true;
            }
            return false;
        }
        public override void parseXML(XmlElement e)
        {
            XmlElement t = null;
            if (e.Name == "Signal")
            {
                bool b = bool.Parse(e.GetAttribute("IO"));
                string type = e.GetAttribute("type");
                string s = e.GetAttribute("name");
                Signal newNode = new Signal(s, type);
                

                newNode.IO = b;
                newNode.type = type;
                
                this.Signals.Add(newNode);

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
        }
    }
}
