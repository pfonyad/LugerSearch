namespace LugerSearchLibrary
{
    using System.Collections.Generic;

    using Base;
    using Interfaces;

    public class BreadthFirstSolver : Solver
    {
        #region Private Properties

        private LinkedList<IState> queue;

        #endregion

        #region Constructor(s)

        public BreadthFirstSolver()
        {
            queue = new LinkedList<IState>();
        }

        #endregion

        #region Protected Override Methods

        protected override void AddState(IState state)
        {
            if (!queue.Contains(state))
            {
                queue.AddLast(state);
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
            var last = queue.Last.Value;
            queue.RemoveLast();
            return last;
        }

        #endregion
    }
}
