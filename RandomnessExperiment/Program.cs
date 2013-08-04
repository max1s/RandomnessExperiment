using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RandomnessExperiment
{
    class Program
    {
        //static String typeOfGraph;
        //static String sizeOfGraph;
        //static String orderOfGraph;

        static void Main(string[] args)
        {

            int sizeOfGraph;
            int randomnessConstant = 3;
            int orderOfGraph;
            List<String> experiment = new List<string>();

            for (sizeOfGraph = 10; sizeOfGraph < 30; sizeOfGraph = sizeOfGraph + 2)
            {
                Console.WriteLine(sizeOfGraph);

                OvalGraph og = new OvalGraph(sizeOfGraph);
                RandomnessChecker rc = new RandomnessChecker(og, randomnessConstant);
                int t = 0;
                while (!rc.CheckGraph())
                {
                    t++;
                    og.NeighbourSwapVertices(2);
                }
                experiment.Add(sizeOfGraph + " " + t);
                    
                
            }
            

            File.WriteAllLines("C:\\Users\\max\\Dropbox\\Second Year CS\\experiment5.txt", experiment.ToArray());
           
            

            //OvalGraph og = new OvalGraph(3000);
            //RandomnessChecker rc = new RandomnessChecker(og);
            //int changesInParralel = 1;
         

            ////Console.WriteLine("Initially this graph is " + rc.CheckGraph() + " In terms of randomness");
            //for (int i = 0; i < 200000000; i++)
            //{
            //    //foreach(Vertex v in og.myVertices)
            //    //{
            //    //    Console.Write( "Vertex " + v.myID + " : ");
            //    //    foreach (Edge e in v.myEdges)
            //    //    {
            //    //        Console.Write(e.mySecondVertex + " ");
            //    //    }
            //    //    Console.WriteLine();
            //    //}
                
            //    //Console.WriteLine("Passover with: " + changesInParralel + " changes in parralel ");
            //    og.NeighbourSwapVertices(1);
            //    if (rc.CheckGraph())
            //        Console.WriteLine("true");
            //    //Console.WriteLine("Time " + (i + 1) + " : " + rc.CheckGraph());

            //}
            //for (sizeOfGraph = 10; sizeOfGraph < 500; sizeOfGraph = sizeOfGraph + 2)
            //{
            //    Console.WriteLine(sizeOfGraph);
            //    for (randomnessConstant = 2; randomnessConstant < 20; randomnessConstant++)
            //    {

            //        RandomnessChecker rc = new RandomnessChecker(new RandomSeedGraph(sizeOfGraph, orderOfGraph), randomnessConstant);
            //        bool b = rc.CheckGraph();
            //        experiment.Add(sizeOfGraph + " " + randomnessConstant + " " + b);
            //    }
            //}

            //Console.Write(rc.CheckGraph());
            //Console.Read();

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
