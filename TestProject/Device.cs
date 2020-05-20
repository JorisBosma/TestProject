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
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace TestProject
{
    [Serializable]
    [DataContract(Name = "Device", Namespace = "TestProject")]
    public class Device : Node
    {
        [DataMember]
        public List<Signal> Signals { get; set; }
        [DataMember]
        public string Merk { get; set; }
        [DataMember]
        public string Soort { get; set; }
        [DataMember]
        public string Omschrijving { get; set; }                 //Omschrijving
        [DataMember]
        public string Type { get; set; }                         //STC100, STP100-50, Magna3 etc.

        [Browsable(false)]
        public override List<Node> Nodes { get; set; }

        public Device()
        {
            
        }
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
