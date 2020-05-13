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
        public List<Connection> connections { get; set; }
        public string Merk { get; set; }
        public string Soort { get; set; }
        public string Omschrijving { get; set; }                 //Omschrijving
        public string Type { get; set; }                         //STC100, STP100-50, Magna3 etc.
        
        [Browsable(false)]
        public override List<Node> Nodes { get; set; }

        public Device()
        {

        }
        public Device(string sNode) : base(sNode)
        {
            this.Signals = new List<Signal>();
            this.connections = new List<Connection>();
            this.BuildConnections();
            this.BuildConnectionsInSig();
        }
        public override void AddNode(Node s)
        {
            if (s.GetClass() != "Signal") return;                //Only signals can be added to a device (This is only in the data)
            Signals.Add((Signal)s);
        }
        public void BuildConnections()
        {
            this.connections.Clear();
            foreach(Signal s in this.Signals)
            {
                if (s.ConnectedSignal == null) ;
                else
                {
                    Connection c = new Connection(s, s.ConnectedSignal);
                    this.connections.Add(c);
                }
            }
        }
        public void BuildConnectionsInSig()
        {
            foreach(Connection c in connections)
            {
                foreach(Signal s in Signals)
                {
                    if(s == c.s1 )
                    {
                        s.Connect(c.s1);
                    }
                    else if (s== c.s2)
                    {
                        s.Connect(c.s2);
                    }
                }
            }
        }
        public override void RemoveNode(Node s)
        {
            if (s.GetClass() != "Signal") return;
            Signals.Remove((Signal)s);
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

      
    }
}
