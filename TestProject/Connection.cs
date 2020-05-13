using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class Connection
    {
        public Signal s1;
        public Signal s2;
        public Connection()
        {

        }
        public Connection(Signal si1, Signal si2)
        {
            s1 = si1;
            s2 = si2;
        }
    }
}
