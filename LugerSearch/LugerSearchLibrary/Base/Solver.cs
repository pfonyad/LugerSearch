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

        private IEnumerable<IState> FindPath(IState solution)
        {
            var path = new LinkedList<IState>();

            while (solution != null)
            {
                path.AddFirst(solution);
                solution = solution.GetParent();
            }

            return path.ToList();
        }

        #endregion

        #region Public Methods

        public IEnumerable<IState> Solve(IState initialState)
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

        public IEnumerable<IEnumerable<IState>> GetAllSolve(IState initialState)
        {
            var solves = new List<IEnumerable<IState>>();

            closed.Clear();

            ClearOpen();

            AddState(initialState);

            while (HasElements())
            {
                IState state = NextState();

                if (state.IsSolution())
                {
                    solves.Add(FindPath(state));
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

            return solves;
        }

        public IEnumerable<IEnumerable<IState>> SolveAllMove(IState initialState)
        {
            var states = new Queue<IState>();

            var solves = new Dictionary<int, IEnumerable<IState>>();

            var solvedThread = new HashSet<IState>();

            states.Enqueue(initialState);

            while (states.Any())
            {
                var state = states.Dequeue();

                var solve = Solve(state);

                if (solve != null)
                {
                    var hashCode = solve.Sum(s => s.GetHashCode());

                    if (!solves.ContainsKey(hashCode))
                    {
                        solves.Add(hashCode, solve);
                    }
                }

                if (!solvedThread.Contains(state))
                {
                    solvedThread.Add(state);
                }

                foreach (var move in state.GetPossibleMoves())
                {
                    if (!solvedThread.Contains(move))
                    {
                        states.Enqueue(move);
                    }
                }
            }

            return solves.Select(s => s.Value);
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
