using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightPigs.Main.Model
{
    public class pigsEventArgs
    {
        public readonly bool stepsOver;
        public readonly Queue<Keys> redSteps;
        public readonly Queue<Keys> blueSteps;
        public readonly int whoWon;

        public pigsEventArgs(bool stepsOver, Queue<Keys> redSteps, Queue<Keys> blueSteps, int whoWon)
        { 
            this.stepsOver = stepsOver;
            this.redSteps = redSteps;
            this.blueSteps = blueSteps;
            this.whoWon = whoWon;
        }   
    }
}
