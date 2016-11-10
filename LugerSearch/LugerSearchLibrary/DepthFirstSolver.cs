namespace LugerSearchLibrary
{
    using System.Collections.Generic;

    using Base;
    using Interfaces;

    public class DepthFirstSolver : Solver
    {
        #region Private Properties

        private Stack<IState> stack;
        
        #endregion

        #region Constructor(s)

        public DepthFirstSolver()
        {
            stack = new Stack<IState>();
        }

        #endregion

        #region Protected Override Methods

        protected override void AddState(IState state)
        {
            if (!stack.Contains(state))
            {
                stack.Push(state);
            }
        }

        protected override void ClearOpen()
        {
            stack.Clear();
        }

        protected override bool HasElements()
        {
            return stack.Count > 0;
        }

        protected override IState NextState()
        {
            return stack.Pop();
        }

        #endregion
    }
}
