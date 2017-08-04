using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.RL.Stochastic
{
    /*State class, is a simple class. 
     * it would initially contain a state number and features of a state if required. 
     * States can be implied states based on observations of an environment */
    class State
    {
        private readonly int _stateID;
        private readonly string _stateName;
        private readonly int[] _stateFeatures;

        public int ID { get { return _stateID; } }
        public string Name { get { return _stateName; } }
        public int[] Features { get { return _stateFeatures; } }

        public State(int ID) : this (ID,null,null)
        {
            
        }

        public State(int ID, string name) : this(ID,name,null)
        {
            
        }

        public State(int ID, string name, int[] features)
        {
            _stateID = ID;
            _stateName = name;
            _stateFeatures = features;
        }

        

        public int GetFeature(int idx)
        {
            try
            {
                return _stateFeatures[idx];
            }
            catch(Exception)
            {
                return 0;
            }
        }
    }
}
