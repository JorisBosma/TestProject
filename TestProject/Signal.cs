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
    public class Signal : Node
    {
        public bool IO { get; set; }
        public string type { get; set; }
        [Browsable(false)]
        public override List<Node> Nodes { get; set; }

        public Signal(string sNode, string type) : base(sNode)
        {
            this.type = type;
        }
        public override void AddNode(Node s)
        {
            return;
        }
        public override string GenerateXML()
        {
            String result;
            result = "<Signal name='" + this.sNode + "' IO='" + this.IO + "' type='" + this.type + "'>\n</Signal>\n";
            return result;
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
