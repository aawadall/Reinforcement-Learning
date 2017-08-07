using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.RL.Stochastic
{
    /*
     * A Policy is used to learn how an environment behaves
     * and finds the optimal way of interacting with it
     */
    public class Policy
    {
#region Attributes and Constructors 
        private readonly string _algorithm; //Learning Algorithm, future feature  
        private double[,] _q; // State Action Pair , i = state, j = action
        private double[] _v; // State Value

        private Parameters _param;

        private double[] _theta; // used for function approximation

        public double Alpha => _param.Alpha; 
        public double Gamma => _param.Gamma;
        public double Lambda => _param.Lambda;
        public double Epsilon => _param.Epsilon;

        public Policy(int nStates, int nActions, Parameters param)
        {
            _param = param;
            _q = new double[nStates, nActions];
            _v = new double[nStates];
        }

        public Policy(int nStates, int nActions) : this(nStates, nActions, new Parameters())
        { }
#endregion

        public int BestAction(int stateID)
        {
            // Given a state ID, find best Action ID
            try
            {
                double[] val = new double[_q.GetLength(1)];
                for(int i=0;i<val.Length;i++)
                {
                    val[i] = _q[stateID, i];
                }
                return val.ToList().IndexOf(val.Max());
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public void Print()
        {
            Console.WriteLine("Policy Statistics");
            // Print Parameters
            _param.Print();
            // Print Q
            Console.WriteLine("\nState Action pair value");
            Console.Write("   Action\t");
            for (int j = 0; j < _q.GetLength(1); j++) // Actions
            {
                Console.Write("\t"+j+" ");
            }
            Console.WriteLine();
            for(int i=0;i<_q.GetLength(0);i++) // States
            {
                Console.Write("State ["+i+"]\t");
                for (int j=0;j<_q.GetLength(1);j++) // Actions
                {
                    Console.Write(string.Format("\t{0:0.00}", _q[i, j]));
                }
                Console.WriteLine();
            }
            // Print V
            Console.WriteLine("\n State Value");
            for (int i = 0; i < _q.GetLength(0); i++) // States
            {
                Console.Write("State [" + i + "]\t");
                Console.WriteLine(string.Format("\t{0:0.00}", _v[i]));
            }

        }

        public double GetReturn(Signal sig, double ret)
        {
            return ret + _param.Gamma * sig.Reward;
        }

        public void Learn(Signal sig)
        {
            int state = sig.PrevioustState.ID;
            int action = sig.Action.ID;
            double[] qState = new double[_q.GetLength(1)];
            for (int i = 0; i < qState.Length;i++ )
            {
                qState[i] = _q[state, i];
            }
            _v[state] = qState.Max();
            _q[state, action] += _param.Alpha * (sig.Reward + _param.Gamma * _v[state] - _q[state, action]);
          
        }

        public int GetBestMove(int state)
        {
            double[] qState = new double[_q.GetLength(1)];
            for (int i = 0; i < qState.Length; i++)
            {
                qState[i] = _q[state, i];
            }
            return qState.ToList().IndexOf(qState.Max());
        }


    }
}
