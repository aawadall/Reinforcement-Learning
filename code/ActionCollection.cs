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
    public class ActionCollection
    {
        private Action[] _actions;
        private int _nActions;
        private string _collectionName;

        public ActionCollection():this("")
        { }

        public ActionCollection(string name)
        {
            _collectionName = name;
        }

        public Action[] Actions { get => _actions; }

        public void AddAction(Action action)
        {
            Actions[_nActions++] = action;
        }

        public Action GetActionAt(int idx)
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
    }
}
