namespace LugerSearchLibrary.Interfaces
{
    using System.Collections.Generic;

    internal interface IState<T> where T : class
    {
        IEnumerable<T> GetPossibleMoves();

        bool IsSolution();

        double GetHeuristic();

        double GetDistance();

        T GetParent();
    }
}
