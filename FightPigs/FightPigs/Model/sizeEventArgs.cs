using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FightPigs.Main.Model
{
    public class sizeEventArgs
    {
        public size setSize;
        public sizeEventArgs(size x) 
        {
            this.setSize = x;
        }
    }
}
