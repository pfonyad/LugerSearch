namespace LugerSearchLibrary.Interfaces
{
    using System.Collections.Generic;

    interface ISolver<T> where T : class
    {
        List<T> Solve(T initialState);
    }
}
