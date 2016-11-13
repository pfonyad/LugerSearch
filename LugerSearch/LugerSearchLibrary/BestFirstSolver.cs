namespace LugerSearchLibrary
{
    using System.Collections.Generic;
    using System.Linq;

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

        #region Private Methods

        private void OrderQueue()
        {
            var dct = new Dictionary<IState, double>();

            foreach (var oneState in queue)
            {
                dct.Add(oneState, oneState.GetDistance() + oneState.GetHeuristic());
            }

            queue.Clear();

            foreach (var oneState in dct.OrderBy(st => st.Value))
            {
                queue.Enqueue(oneState.Key);
            }
        }

        #endregion

        #region Protected Override Methods

        protected override void AddState(IState state)
        {
            if (!queue.Contains(state))
            {
                queue.Enqueue(state);

                OrderQueue();
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

        #endregion
    }
}