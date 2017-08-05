using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.RL.Stochastic
{
    /*
     * Main player in this simulator, an intellegent AI agent using a policy assigned 
     */
    class Agent
    {
        private Policy _policy;// Should have a policy 
        // should learn
        private double _return;// Should keep track of Return Value 
        private int _id;

        public int ID
        {
            get { return _id; }
            //set { _id = value; }
        }

        public double Return
        {
            get { return _return; }
           // set { _return = value; }
        }

        public Agent(int nStates, int nActions, int id)
        {
            _return = 0;
            _id = id;
            _policy = new Policy(nStates, nActions);
        }

        public Signal Play(Action action, Environment env)
        {
            // Should learn later 
            Signal sig = env.React(action,this);
            _return = _policy.GetReturn(sig, _return);
            _policy.Learn( sig);
            return sig;
        }

        public Signal Play(Environment env)
        {
            return Play(env.GetAction(_policy.GetBestMove(env.CurrentState.ID)), env);
        }
        public void Print()
        {
            Console.WriteLine("Agent[" + _id + "] Statistics");
            _policy.Print();
            Console.WriteLine("Accumilated Return = " + _return);
        }

        public double Alpha { get { return _policy.Alpha; } }
        public double Gamma { get { return _policy.Gamma; } }
    }
}
