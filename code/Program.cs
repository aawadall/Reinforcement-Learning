using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.RL.Stochastic
{
    class Program
    {
      

        static void Main(string[] args)
        {
            int nActions = 15;
            int nStates = 12;
            int nAgents = 10;
            int nSteps = 100000;
            WorldDynamics WD = new WorldDynamics(nStates, nActions);
            Environment env = new Environment(nStates, nActions,nAgents,WD);
            

            Random rnd = new Random();
            for (int i = 0; i < nSteps;i++ )
            {
                env.Simulate();
         
            }
           
            env.Print();
            Console.ReadLine();
        }
    }
}
