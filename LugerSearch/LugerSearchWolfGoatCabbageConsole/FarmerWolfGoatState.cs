namespace LugerSearchWolfGoatCabbageConsole
{
    using System.Collections.Generic;

    using LugerSearchLibrary.Base;
    using LugerSearchLibrary.Interfaces;

    #region Extensions

    using static FarmerWolfGoatState;

    public static class Extensions
    {
        public static FarmerWolfGoatSide GetOpposite(this FarmerWolfGoatSide side)
        {
            return side == FarmerWolfGoatSide.East ? FarmerWolfGoatSide.West : FarmerWolfGoatSide.East;
        }
    }

    #endregion

    public class FarmerWolfGoatState : State
    {
        #region Private Properties

        private FarmerWolfGoatSide farmer;
        private FarmerWolfGoatSide wolf;
        private FarmerWolfGoatSide goat;
        private FarmerWolfGoatSide cabbage;

        #endregion

        #region Public Properties

        public enum FarmerWolfGoatSide
        {
            East,
            West
        }

        #endregion

        #region Constructor(s)

        public FarmerWolfGoatState()
        {
            farmer = wolf = goat = cabbage = FarmerWolfGoatSide.East;
        }

        public FarmerWolfGoatState(FarmerWolfGoatState parent, FarmerWolfGoatSide farmer, FarmerWolfGoatSide wolf, FarmerWolfGoatSide goat, FarmerWolfGoatSide cabbage) : base(parent)
        {
            this.farmer = farmer;
            this.wolf = wolf;
            this.goat = goat;
            this.cabbage = cabbage;
        }

        #endregion

        #region Private Methods

        private void AddIfSafe(HashSet<State> moves)
        {
            bool unSafe = (farmer != wolf && farmer != goat) || (farmer != goat && farmer != cabbage);
            if (!unSafe)
            {
                moves.Add(this);
            }
        }

        #endregion

        #region Public Override Methods

        public override double GetHeuristic()
        {
            int sum = 0;

            if (farmer == FarmerWolfGoatSide.East)
            {
                sum++;
            }
            if (wolf == FarmerWolfGoatSide.East)
            {
                sum++;
            }
            if (cabbage == FarmerWolfGoatSide.East)
            {
                sum++;
            }
            if (goat == FarmerWolfGoatSide.East)
            {
                sum++;
            }

            return sum;
        }

        public override IEnumerable<IState> GetPossibleMoves()
        {
            var moves = new HashSet<State>();
            // Move wolf
            if (farmer == wolf)
            {
                new FarmerWolfGoatState(this, farmer.GetOpposite(), wolf.GetOpposite(), goat, cabbage).AddIfSafe(moves);
            }
            // Move goat
            if (farmer == goat)
            {
                new FarmerWolfGoatState(this, farmer.GetOpposite(), wolf, goat.GetOpposite(), cabbage).AddIfSafe(moves);
            }
            // Move cabbage
            if (farmer == cabbage)
            {
                new FarmerWolfGoatState(this, farmer.GetOpposite(), wolf, goat, cabbage.GetOpposite()).AddIfSafe(moves);
            }
            // Move just farmer
            new FarmerWolfGoatState(this, farmer.GetOpposite(), wolf, goat, cabbage).AddIfSafe(moves);

            return moves;
        }

        public override bool IsSolution()
        {
            return farmer == FarmerWolfGoatSide.West && wolf == FarmerWolfGoatSide.West && goat == FarmerWolfGoatSide.West && cabbage == FarmerWolfGoatSide.West;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(FarmerWolfGoatState))
            {
                return false;
            }

            var fwgs = obj as FarmerWolfGoatState;

            return farmer == fwgs.farmer && wolf == fwgs.wolf && cabbage == fwgs.cabbage && goat == fwgs.goat;
        }

        public override int GetHashCode()
        {
            return (farmer == FarmerWolfGoatSide.East ? 1 : 0) +
                   (wolf == FarmerWolfGoatSide.East ? 2 : 0) +
                   (cabbage == FarmerWolfGoatSide.East ? 4 : 0) +
                   (goat == FarmerWolfGoatSide.East ? 8 : 0);
        }

        public override string ToString()
        {
            return (farmer == FarmerWolfGoatSide.East ? "F" : " ") +
                   (wolf == FarmerWolfGoatSide.East ? "W" : " ") +
                   (cabbage == FarmerWolfGoatSide.East ? "C" : " ") +
                   (goat == FarmerWolfGoatSide.East ? "G" : " ") +
                                    " | ~~~~~ | " +
                   (farmer == FarmerWolfGoatSide.West ? "F" : " ") +
                   (wolf == FarmerWolfGoatSide.West ? "W" : " ") +
                   (cabbage == FarmerWolfGoatSide.West ? "C" : " ") +
                   (goat == FarmerWolfGoatSide.West ? "G" : " ") +
                   " (heuristic: " + GetHeuristic() + ")" + "\n";
        }

        #endregion
    }
}