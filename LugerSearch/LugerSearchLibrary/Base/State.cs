namespace LugerSearchLibrary.Base
{
    using System.Collections.Generic;

    using Interfaces;

    public abstract class State : IState
    {
        #region Private Properties

        private IState parent;

        private double distance;

        #endregion

        #region Constructor(s)

        public State() : this(null)
        {

        }

        public State(IState parent)
        {
            this.parent = parent;
            distance = parent != null ? parent.GetDistance() + 1 : 0;
        }

        #endregion

        #region Public Methods

        public abstract IEnumerable<IState> GetPossibleMoves();

        public abstract bool IsSolution();

        public abstract double GetHeuristic();

        public double GetDistance()
        {
            return distance;
        }

        public IState GetParent()
        {
            return parent;
        }

        #endregion
    }
}
