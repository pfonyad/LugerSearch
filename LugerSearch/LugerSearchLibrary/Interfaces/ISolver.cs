namespace LugerSearchLibrary.Interfaces
{
    using System.Collections.Generic;

    public interface ISolver
    {
        IEnumerable<IState> Solve(IState initialState);

        IEnumerable<IEnumerable<IState>> GetAllSolve(IState initialState);

        IEnumerable<IEnumerable<IState>> SolveAllMove(IState initialState);
    }
}
