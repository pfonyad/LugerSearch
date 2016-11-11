using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LugerSearchLibrary;

namespace LugerSearchWolfGoatCabbageConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FarmerWolfGoatState fwgs = new FarmerWolfGoatState(null, FarmerWolfGoatState.FarmerWolfGoatSide.East, FarmerWolfGoatState.FarmerWolfGoatSide.East, FarmerWolfGoatState.FarmerWolfGoatSide.East, FarmerWolfGoatState.FarmerWolfGoatSide.East);

            BestFirstSolver bfss = new BestFirstSolver();

            //BreadthFirstSolver bfs = new BreadthFirstSolver();

            var solve = bfss.Solve(fwgs);

            foreach (var item in solve)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
