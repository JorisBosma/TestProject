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
    [DataContract(Name = "Signal", Namespace = "TestProject", IsReference = true)]
    public class Signal : Node
    {
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public Signal ConnectedSignal { get; set; }
        [Browsable(false)]
        public override List<Node> Nodes { get; set; }


        public Signal()
        {

        }
        public Signal(string sNode, string type) : base(sNode)
        {
            this.type = type;
        }
        public override void AddNode(Node s)
        {
            return;
        }
        public void Connect(Signal s)
        {
            if (this.ConnectedSignal != null) return;
            this.ConnectedSignal = s;
            
            //Connect the signal and then make sure the one it's connected to also connects to this one
            //It will always go both ways (same for disconnect)
            if(s.ConnectedSignal != this)
            {
                s.Connect(this);
            }
        }
        public void Disconnnect()
        {
            if (this.ConnectedSignal == null) return;
            Signal s = this.ConnectedSignal;
            this.ConnectedSignal = null;
            if(s.ConnectedSignal == this)
            {
                s.Disconnnect();
            }
        }
        public override bool containsNode(string s)
        {
            if (this.sNode.ToLower().Contains(s.ToLower()))
            {
                return true;
            }
            return false;
        }
        public override string GetClass()
        {
            return "Signal";
        }
    }
}
