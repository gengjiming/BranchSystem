using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration.Json;
namespace BranchSystem
{
    class Program
    {

        static void Main(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                .AddJsonFile("appsettings.json", optional: true)
                                                .Build();
            int depth;
            if (!int.TryParse(configuration["Depth"], out depth))
            {
                Console.WriteLine("Please provide a valid depth config");
                return;
            }

            if (depth == 0)
            {
                Console.WriteLine("Please provide a valid depth config");
                return;
            }
            Console.WriteLine("Depth parameter: "+depth);
            var branchSystem = new BranchSystem(depth);            
            var predictEmptyContainerName = branchSystem.PredictEmptyContainer();
            branchSystem.RunBalls();
            var emptyContainerName = branchSystem.GetEmptyContainer();
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
