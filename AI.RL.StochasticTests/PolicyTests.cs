using Xunit;
using AI.RL.Stochastic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.RL.Stochastic.Tests
{
    public class PolicyTests
    {
# region Test Constructors 
        [Fact()]
        public void PolicyTestConstructor_Policy_parameters()
        {
            var alpha = 0.1;
            var gamma = 0.9;
            var lambda = 1;
            var epsilon = 0.001;

            var par = new Parameters(alpha, gamma, lambda, epsilon);
            var target = new Policy(2, 2, par);

            Assert.True(target.Alpha == alpha &&
                        target.Gamma == gamma &&
                        target.Lambda == lambda &&
                        target.Epsilon == epsilon,
                        "Policy with explicitly specified parameters"
                );
        }

        [Fact()]
        public void PolicyTestConstructor_Policy_rnd_parameters()
        {
            
            var target = new Policy(2, 2);

            Assert.True(target.Alpha >= 0 &&
                        target.Gamma >= 0 &&
                        target.Lambda >= 0 &&
                        target.Epsilon >= 0 &&
                        target.Alpha <= 1 &&
                        target.Gamma <= 1 &&
                        target.Lambda <= 1 &&
                        target.Epsilon <= 1,
                        "Policy with explicitly specified parameters in range 0 to 1"
                );
        }
#endregion
        [Fact()]
        public void BestActionTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void PrintTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetReturnTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void LearnTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetBestMoveTest()
        {
            Assert.True(false, "This test needs an implementation");
        }
    }
}