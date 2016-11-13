using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LugerSearchLibrary;
using LugerSearchLibrary.Interfaces;

namespace LugerSearchWolfGoatCabbageConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var farmerWolfGoatState = new FarmerWolfGoatState(
                null,
                FarmerWolfGoatState.FarmerWolfGoatSide.East,
                FarmerWolfGoatState.FarmerWolfGoatSide.East,
                FarmerWolfGoatState.FarmerWolfGoatSide.East,
                FarmerWolfGoatState.FarmerWolfGoatSide.East
                );

            object[] solvers = { new BestFirstSolver(), new BreadthFirstSolver(), new DepthFirstSolver() };

            for (int i = 0; i < solvers.Length; i++)
            {
                Console.WriteLine("Solver: {0}\n", solvers[i].GetType().Name);

                foreach (var oneSolve in (solvers[i] as ISolver).Solve(farmerWolfGoatState))
                {
                    Console.WriteLine(oneSolve);
                }

                Console.WriteLine("****** END ******\n\n");
            }

            Console.ReadKey();
        }
    }
}
