namespace LugerSearchLibrary.Interfaces
{
    using System.Collections.Generic;

    public interface IState
    {
        IEnumerable<IState> GetPossibleMoves();

        bool IsSolution();

        double GetHeuristic();

        double GetDistance();

        IState GetParent();
    }
}
