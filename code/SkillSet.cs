using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.RL.Stochastic
{
    /*
     * Action Collection is made of a set of actions, index and a general Collection Description
     */
    public class SkillSet
    {
        private Action[] _actions;
        private int _nActions;
        private string _collectionName;

        public SkillSet():this("")
        { }

        public SkillSet(string name)
        {
            _collectionName = name;
        }

        public Action[] Actions { get => _actions; }

        public void LearnSkill(Action action)
        {
            Actions[_nActions++] = action;
        }

        public Action GetSkill(int idx)
        {
            try
            {
                return Actions[idx];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void InvokeSkill(int idx, Environment env)
        {
            // when implemented, it would invoke the customized Invoke() method of the idx_th action 
            
        }
    }
}
