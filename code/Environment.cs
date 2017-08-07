using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.RL.Stochastic
{
    /*
     * A Collection of Agents and States 
     * and a single World Dynamics object 
     */
    public class Environment
    {
    #region Initilizations 
        private WorldDynamics _WD;

        private int _currentState;
        public int ActiveAgentID{get;set;}

        private Action[] _actions;
        private State[] _states;
        private Agent[] _agents;

        private Signal _sig; // This signal object will be used for observations
       
        public Environment(int nStates, int nActions, int nAgents, WorldDynamics WD)
        {
            ConstructActions(nActions);
            ConstructStates(nStates);
            ConstructAgents(nAgents);
            _WD = WD;
            _sig = new Signal(_states[0],_states[0],-100,_actions[0],_agents[0]);
        }

        private void ConstructStates(int nStates)
        {
            // Build random states using passed argument 
            _states = new State[nStates];
            for (int i = 0; i < nStates; i++)
            {
                _states[i] = new State(i);
            }
        }

        private void ConstructAgents(int nAgents)
        {
            // Build random states using passed argument 
            _agents = new Agent[nAgents];
            for (int i = 0; i < nAgents; i++)
            {
                _agents[i] = new Agent(_states.Length, _actions.Length, i);
            }
        }

        private void ConstructActions(int nActions)
        {
            // Build random states using passed argument 
            _actions = new Action[nActions];
            for (int i = 0; i < nActions; i++)
            {
                _actions[i] = new Action(i);
            }
        }
        #endregion

        #region Simulation
        // Simulation 
        public Signal Interact(Action action, Agent actor)
        {
            /* Change the logic of interaction to pulling request.
             * i.e. make a call to a selected agent and ask for their move. */ 
            Console.WriteLine("Interacting with Agent: " + actor.ID);
            _sig = _WD.Interact(action, actor, this);
            _currentState = _sig.CurrentState.ID;
            return _sig;
        }

        public Signal Interact(Agent agent)
        {
            return Interact( _actions[agent.GetBestMove(_currentState)] ,agent);
        }

        public Signal Observe => _sig; /* Observing current state of the environment 
                                        * without altering the current state */
        
        private void WhosTurn()
        {
            // Identify who's turn is it
            // Cycle over ActiveAgent 
            ActiveAgentID += ActiveAgentID < nAgents - 1 ? 1 : 1 - nAgents;
            
        }
        public void Simulate()
        {
            Console.WriteLine("Simulation");
            // Find who's turn 
            WhosTurn();
            Console.WriteLine("Chosen Agent is " + ActiveAgentID);
            // Make them play
            ActiveAgent.Interact(this);
            ActiveAgent.ObserveMyMove(_sig);
            // Update environment 
            foreach(Agent agent in _agents)
            {
                // Make others see
                if(agent.ID != ActiveAgentID)
                {
                    agent.Observe(this);
                }
            }

        }
        #endregion 
        // States    

        public int nStates { get { return _states.Length; } }
        public State CurrentState { get { return _states[_currentState]; } }
        public State GetState(int index)
        {
            return _states[index];
        }
        // Actions 
        
        public int nActions { get { return _actions.Length; } }
        public Action GetAction(int idx) 
        { 
            return _actions[idx];  
        }
        // Agents 
       
        public int nAgents =>  _agents.Length; 
        public Agent ActiveAgent => _agents[ActiveAgentID]; 
        public Agent GetAgent(int idx)
        {
            return _agents[idx];
        }
        public Agent[] AllAgents => _agents;


        
        public void Print()
        {
            // Side by side 
            // 1 list agents
            //Console.WriteLine();
            Console.Write("Agent\t");
            for (int i=0;i<nAgents;i++)
            { Console.Write("\t"+i);}
            Console.WriteLine();
            // alpha 
            //Console.WriteLine();
            Console.Write("Alpha\t");
            for (int i = 0; i < nAgents; i++)
            { Console.Write("\t" + string.Format("{0:0.00}",_agents[i].Alpha)); }
            Console.WriteLine();
            // gamma
            //Console.WriteLine();
            Console.Write("Gamma\t");
            for (int i = 0; i < nAgents; i++)
            { Console.Write("\t" + string.Format("{0:0.00}", _agents[i].Gamma)); }
            Console.WriteLine();
            // return 
            //Console.WriteLine();
            Console.Write("Return\t");
            for (int i = 0; i < nAgents; i++)
            { Console.Write("\t" + string.Format("{0:n0}", _agents[i].Return)); }
            Console.WriteLine();
        }
    }

    
}
