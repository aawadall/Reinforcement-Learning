using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.RL.Stochastic
{
    class Program
    {
        public static int GetNextAgent(int nAgents, int current)
        {
            return (current < (nAgents - 1) )? current + 1 : 0;
        }
        static void Main(string[] args)
        {
            int nActions = 15;
            int nStates = 12;
            int nAgents = 20;
            WorldDynamics WD = new WorldDynamics(nStates, nActions);
            Environment env = new Environment(nStates, nActions,nAgents,WD);
            
            
         
            Signal sig;
            int idx = 0;
            Random rnd = new Random();
            for (int i = 0; i < 1000000;i++ )
            {
                idx = GetNextAgent(nAgents, idx); ;
                env.ActiveAgentID = idx;
                //Console.WriteLine("Active Agent : "+env.ActiveAgentID);
                sig = env.ActiveAgent.Play(env);
                    //React(action[idx]);
                
                //Console.WriteLine("Action:"+sig.Action+" Moved From State " + sig.PrevioustState.ID + "->" + sig.CurrentState.ID + " Yielded " + sig.Reward);
                //Console.WriteLine("Played by Agent["+env.ActiveAgent.ID+"], Current Return : "+env.ActiveAgent.Return);
            }
           
            /*
            for (int i = 0;i < nAgents ; i++)
            {
                env.GetAgent(i).Print();
            }
             */
            env.Print();
        }
    }
}
