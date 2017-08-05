using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.RL.Stochastic
{
    class Parameters
    {

        private string _algorithm; /* Possible Values :
                                    * - QLEARN = Q-Learning
                                    * - SARSA = SARSA
                                    * - ESARSA = Expected SARSA
                                    * - TD = Temproral Difference
                                    */
        public string Algorithm
        {
          get {return _algorithm; }
          set {algorithm = value; }
        }
        private double _alpha; // learning rate

        public double Alpha
        {
            get { return _alpha; }
            set { _alpha = value; }
        }
        private double _gamma; // discount rate

        public double Gamma
        {
            get { return _gamma; }
            set { _gamma = value; }
        }
        private double _lambda; // for TD(lambda)

        public double Lambda
        {
            get { return _lambda; }
            set { _lambda = value; }
        }
        private double _epsilon; // exploration chance

        public double Epsilon
        {
            get { return _epsilon; }
            set { _epsilon = value; }
        }

        //Function to get random number
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static double RandomNumber()
        {
            lock (syncLock)
            { // synchronize
                return random.NextDouble();
            }
        }
        public Parameters()
        {
            //Random rnd = new Random();
            _alpha = RandomNumber();//rnd.NextDouble();
            _gamma = RandomNumber();//rnd.NextDouble();
            _lambda = RandomNumber(); //rnd.NextDouble();
            _epsilon = RandomNumber(); //rnd.NextDouble();
            Print();
            //Console.ReadLine();

        }
        public Parameters(double alpha, double gamma,  double lambda, double epsilon)
        {
            _alpha = alpha;
            _gamma = gamma;
            _lambda = lambda;
            _epsilon = epsilon;
        }

        public void Print()
        {
            Console.WriteLine("Parameters Report");
            Console.WriteLine("-----------------");
            Console.WriteLine("alpha : \t" + string.Format("{0:0.00}", _alpha));
            Console.WriteLine("gamma : \t" + string.Format("{0:0.00}", _gamma));
            Console.WriteLine("lambda : \t" + string.Format("{0:0.00}", _lambda));
            Console.WriteLine("epsilon : \t" + string.Format("{0:0.00}", _epsilon));

        }
    }
}
