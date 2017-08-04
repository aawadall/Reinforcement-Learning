using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.RL.Stochastic
{
    /* A Signal is a collection of reward and new state */
    class Signal
    {
        private readonly State _currentState;
        private readonly State _previousState;
        private readonly double _reward;
        private readonly int _action;

        public int Action
        {
            get { return _action; }
        } 


        public Signal(State state, double reward) : this(state,null,reward,0)
        {
            
        }

        public Signal(State newState, State oldState, double reward,int action)
        {
            _currentState = newState;
            _reward = reward; 
            _previousState = oldState;
            _action = action;
        }

      
        public double Reward { get { return _reward; } }
        public State CurrentState { get { return _currentState; } }
        public State PrevioustState { get { return _previousState; } }
    }
}
