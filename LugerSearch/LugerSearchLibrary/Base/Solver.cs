namespace LugerSearchLibrary.Base
{
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;

    public abstract class Solver : ISolver
    {
        #region Private Properties

        private HashSet<IState> closed;
        
        #endregion

        #region Constructor(s)

        public Solver()
        {
            closed = new HashSet<IState>();
        }

        #endregion

        #region Private Methods

        private List<IState> FindPath(IState solution)
        {
            LinkedList<IState> path = new LinkedList<IState>();

            while (solution != null)
            {
                path.AddFirst(solution);
                solution = solution.GetParent();
            }

            return path.ToList();
        }

        #endregion

        #region Public Methods

        public List<IState> Solve(IState initialState)
        {
            closed.Clear();

            ClearOpen();

            AddState(initialState);

            while (HasElements())
            {
                IState state = NextState();

                if (state.IsSolution())
                {
                    return FindPath(state);
                }

                closed.Add(state);

                foreach (var move in state.GetPossibleMoves())
                {
                    if (!closed.Contains(move))
                    {
                        AddState(move);
                    }
                }
            }

            return null;
        }

        public int GetVisitedStateCount()
        {
            return closed.Count();
        }

        #endregion

        #region Protected Abstract Methods

        protected abstract bool HasElements();

        protected abstract IState NextState();

        protected abstract void AddState(IState state);

        protected abstract void ClearOpen();

        #endregion
    }
}
