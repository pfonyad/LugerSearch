namespace LugerSearchLibrary.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Interfaces;

    public abstract class State : IState<State>
    {
        #region Private Properties

        private State parent;

        private double distance;

        #endregion

        #region Constructor(s)

        public State()
        {
            parent = null;
            distance = 0;
        }

        public State(State parent)
        {
            this.parent = parent;
            distance = parent.GetDistance() + 1;
        }

        #endregion

        #region Public Methods

        public IEnumerable<State> GetPossibleMoves()
        {
            throw new NotImplementedException();
        }

        public bool IsSolution()
        {
            throw new NotImplementedException();
        }

        public double GetHeuristic()
        {
            throw new NotImplementedException();
        }

        public double GetDistance()
        {
            return distance;
        }

        public State GetParent()
        {
            return parent;
        }

        #endregion
    }
}
