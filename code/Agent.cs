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
    public class Agent
    {
#region Agent Attributes & Constructors 
        private Policy _policy;// Should have a policy 
        // should learn
        private double _return;// Should keep track of Return Value 
        private int _id;    // Agent ID is used by Environment class 

  

        public int ID => _id; 
        public double Return => _return; 
        public double Epsilon => _policy.Epsilon;

        public Agent(int nStates, int nActions, int id):this(nStates, nActions, id, new Policy(nStates,nActions))
        {
            
        }

        public Agent(int nStates, int nActions, int id, Policy policy)
        {
            _return = 0;
            _id = id;
            _policy = policy;

        }
        public double Alpha { get { return _policy.Alpha; } }
        public double Gamma { get { return _policy.Gamma; } }
        #endregion
#region Learning and Acting 
        public int GetBestMove(int state)
        {
            /* use policy to find best move */
            return _policy.BestAction(state);
        }

        public void ObserveMyMove(Signal sig)
        {
            _return = _policy.GetReturn(sig, _return);
            Observe(sig);
        }

        public void Observe(Signal sig)
        {
            _policy.Learn(sig);
        }

        public Signal Play(Boolean play,Environment env)
        {
            if (play)
            {
                Interact(env);
            }
            
             return Observe(env);
                   
        }
        public Signal Interact(Action action, Environment env)
        {
            
            // Interact with Environment 
            Signal sig = env.Interact(action,this);
            _return = _policy.GetReturn(sig, _return);

            Observe(env); // Observing is learning 
            return sig;
        }

        public Signal Interact(Environment env)
        {
            return Interact(env.GetAction(_policy.GetBestMove(env.CurrentState.ID)), env);
        }



        #endregion
#region Reporting and Stats 
        public void Print()
        {
            Console.WriteLine("Agent[" + _id + "] Statistics");
            _policy.Print();
            Console.WriteLine("Accumilated Return = " + _return);
        }

        public Signal Observe(Environment env)
        {
            // Learn by observing 
            _policy.Learn(env.Observe);
            return env.Observe;
        }
#endregion
    }
}
