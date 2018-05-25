namespace LugerSearchWolfGoatCabbageConsole
{
    using System;

    using LugerSearchLibrary;
    using LugerSearchLibrary.Interfaces;

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

            ISolver[] solvers = { new BestFirstSolver(), new BreadthFirstSolver(), new DepthFirstSolver() };

            foreach (var solver in solvers)
            {
                Console.WriteLine("Solver: {0}\n", solver.GetType().Name);

                foreach (var step in solver.Solve(farmerWolfGoatState))
                {
                    Console.WriteLine(step);
                }

                Console.WriteLine("****** END ******\n\n");
            }

            Console.WriteLine("Get all solve with BestFirstSolver:\n");

            var bestFirstSolver = new BestFirstSolver();
            var allSolve = bestFirstSolver.SolveAllMove(farmerWolfGoatState);

            foreach (var solves in allSolve)
            {
                foreach (var solve in solves)
                {
                    Console.WriteLine(solve);
                }

                Console.WriteLine("\n**********************************\n");
            }

            Console.WriteLine("****** END ******\n\n");

            Console.ReadKey();
        }
    }
}
