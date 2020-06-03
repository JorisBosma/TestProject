using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using System.Runtime.Serialization;
using System.Xml.Schema;

namespace TestProject
{
    [Serializable]
    [DataContract(Name = "Controller", Namespace = "TestProject")]
    class Controller : Device
    {
        [DataMember]
        int UI = 2;
        [DataMember]
        int UO = 2;
        [DataMember]
        int DO = 2;
        [DataMember]
        int Relais = 2;
        [DataMember]
        int V_DC = 2;
        [DataMember]
        int V_AC = 2;

        public Controller()
        {
            
        }
        public Controller(string sNode) : base(sNode)
        {
            this.Signals = new List<Signal>();
        }

        public bool CheckSignals()
        {
            bool chSignals = false;
            Console.WriteLine(chSignals);
            int tcount = 0;
            int uiC = 0;
            int uoC = 0;
            int doC = 0;
            int rC = 0;
            int v_acC = 0;
            int v_dcC = 0;
            int total = UI + UO + DO + Relais + V_AC + V_DC;
            foreach (Signal s in Signals)
            {
                tcount++;
                if (tcount > total) chSignals = true;
                switch (s.type)
                {
                    case "UI":
                        uiC++;
                        break;
                    case "UO":
                        uoC++;
                        break;
                    case "DO":
                        doC++;
                        break;
                    case "Relais":
                        rC++;
                        break;
                    case "V_AC":
                        v_acC++;
                        break;
                    case "V_DC":
                        v_dcC++;
                        break;
                    default:
                        Console.WriteLine("def");
                        break;
                }
                if (uiC > UI || uoC > UO || doC > DO || rC > Relais || v_acC > V_AC || v_dcC > V_DC) chSignals = true;
            }
            Console.WriteLine(chSignals);
            return chSignals;
        }

        public override string GetClass()
        {
            return "Controller";
        }
    }
}
