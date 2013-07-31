using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomnessExperiment
{
    class Program
    {
        //static String typeOfGraph;
        //static String sizeOfGraph;
        //static String orderOfGraph;

        static void Main(string[] args)
        {
            OvalGraph og = new OvalGraph(3);
            RandomnessChecker rc = new RandomnessChecker(og);
            Console.Write(rc.CheckGraph());
            Console.Read();

            //while(true)
            //{
            //    Console.WriteLine("=================");
            //    Console.WriteLine("Please enter the type of graph you would like (RS/O):");
            //    typeOfGraph = Console.ReadLine();
            //    Console.WriteLine("Please enter the size of graph you would like (no of vertices):");
            //    sizeOfGraph = Console.ReadLine();
            //    Console.WriteLine("And to what order do you want each vertex? : ");
            //    orderOfGraph = Console.ReadLine();
            //    // Warning Becomes unstable if 2 ^ Order >= Number of Vertices

            //    try
            //    {
            //        if (typeOfGraph.Equals("RS"))
            //        {
            //            RandomSeedGraph myFirstTestGraph = new RandomSeedGraph(12, 3);
            //        }
            //        else
            //        {
            //            throw new NotImplementedException();
            //        }
            //        Console.Read();
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Sorry invalid Inputs!");
            //    }
            //}
        }
    }
}
