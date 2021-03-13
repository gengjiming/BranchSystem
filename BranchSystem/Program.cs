using System;
using System.Linq;

namespace BranchSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int depth = 4;
            if (args.Any())
            {
                if (!int.TryParse(args[0], out depth))
                {
                    Console.WriteLine("Please provide a valid depth value");
                    return;
                }
            }
            
            if (depth == 0)
            {
                Console.WriteLine("Please provide a valid depth value");
                return;
            }
            Console.WriteLine("Depth parameter: "+depth);
            var branchSystem = new BranchSystem(depth);            
            var predictEmptyContainerName = branchSystem.PredictEmptyContainer();
            var emptyContainerName = branchSystem.RunBalls();
            Console.WriteLine("Predict Empty Container Name: " + predictEmptyContainerName);
            Console.WriteLine("Empty Container Name: " + emptyContainerName);
            if (predictEmptyContainerName == emptyContainerName)
            {
                Console.WriteLine("Predict success");
            }
            else
            {
                Console.WriteLine("Predict failed");
            }
        }
    }
}
