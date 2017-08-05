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
            int nAgents = 10;

            WorldDynamics WD = new WorldDynamics(nStates, nActions);
            Environment env = new Environment(nStates, nActions,nAgents,WD);
            
            
         
            Signal sig;
            int idx = 0;
            Random rnd = new Random();
            for (int i = 0; i < 10000;i++ )
            {
                idx += idx<nAgents-1?1:1-nAgents;
                //idx = GetNextAgent(nAgents, idx); 
                foreach(Agent agent in env.AllAgents)
                {
                    //Console.WriteLine("Agent ["+agent.ID+"] Playing");
                    if(agent.ID == idx)
                    {
                        sig=agent.Play(true, env);
                    }
                    else
                    {
                        sig=agent.Play(false, env);
                    }
                }
      
                sig = env.ActiveAgent.Interact(env);

            }
           
            /*
            for (int i = 0;i < nAgents ; i++)
            {
                env.GetAgent(i).Print();
            }
             */
            env.Print();
            Console.ReadLine();
        }
    }
}
