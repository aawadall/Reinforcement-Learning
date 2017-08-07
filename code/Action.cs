using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.RL.Stochastic
{
    public class Action 
    {
        private readonly int _actionID;
        private readonly string _actionName;

        public int ID { get { return _actionID; } }
        public string Name { get { return _actionName; } }

        public Action(int ID)
        {
            _actionID = ID;
        }

        public Action(int ID, string name)
        {
            new Action(ID);
            _actionName = name;
            
        }
    }
}
