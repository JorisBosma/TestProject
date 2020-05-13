﻿using System;
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
    public class Signal : Node
    {
        public int ID;
        public bool IO { get; set; }
        public string type { get; set; }
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
     /*   public override string GenerateXML()
        {
            string conSig;
            if(this.ConnectedSignal != null)
            {
                 conSig = Convert.ToString(this.ConnectedSignal.ID);
            }
            else
            {
                 conSig = "";
            }
            string result;
            result = "<Signal ID='" + this.ID + "' name='" + this.sNode + "' IO='" + this.IO + "' type='" + this.type + "' ConnectedSig='" + conSig + "'>\n</Signal>\n";
            return result;
        }*/
        public void Connect(Signal s)
        {
            if (this.ID == s.ID) return;
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
