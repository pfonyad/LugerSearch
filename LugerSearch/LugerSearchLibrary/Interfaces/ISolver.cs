namespace LugerSearchLibrary.Interfaces
{
    using System.Collections.Generic;

    public interface ISolver
    {
        List<IState> Solve(IState initialState);
    }
}
