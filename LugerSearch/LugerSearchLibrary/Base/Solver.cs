namespace LugerSearchLibrary.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Interfaces;

    public abstract class Solver : ISolver<State>
    {
        private HashSet<State> closed;

        public Solver()
        {
            closed = new HashSet<State>();
        }

        public List<State> Solve(State initialState)
        {
            throw new NotImplementedException();
        }

        private List<State> FindPath(State solution)
        {
            LinkedList<State> path = new LinkedList<State>();
            while (solution != null)
            {
                path.AddFirst(solution);
                solution = solution.GetParent();
            }
            return path.ToList();
        }

        public int GetVisitedStateCount()
        {
            return closed.Count();
        }

        protected abstract bool HasElements();

        protected abstract State NextState();

        protected abstract void AddState(State state);

        protected abstract void ClearOpen();
    }
}
