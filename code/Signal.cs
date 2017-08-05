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
        private readonly Agent _actor;
        private readonly double _reward;
        private readonly Action _action;

        public Action Action
        {
            get { return _action; }
        } 



        public Signal(State newState, State oldState, double reward,Action action,Agent actor)
        {
            _currentState = newState;
            _reward = reward; 
            _previousState = oldState;
            _action = action;
            _actor = actor;
        }

      
        public double Reward { get { return _reward; } }
        public State CurrentState { get { return _currentState; } }
        public State PrevioustState { get { return _previousState; } }

        internal Agent Actor => _actor;
    }
}
