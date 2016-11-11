namespace LugerSearchLibrary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Base;
    using Interfaces;

    public class BestFirstSolver : Solver
    {
        #region Private Properties

        public Queue<IState> queue;

        #endregion

        #region Constructor(s)

        public BestFirstSolver()
        {
            queue = new Queue<IState>();
        }

        #endregion

        protected override void AddState(IState state)
        {
            if (!queue.Contains(state))
            {
                queue.Enqueue(state);
                queue.OrderBy(st => st.GetDistance() + st.GetHeuristic());
            }
        }

        protected override void ClearOpen()
        {
            queue.Clear();
        }

        protected override bool HasElements()
        {
            return queue.Count > 0;
        }

        protected override IState NextState()
        {
            return queue.Dequeue();
        }
    }
}