using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomnessExperiment
{
    class RandomSeedGraph : Graph
    {
       
        
        public bool backtrack = false;

        public RandomSeedGraph(int noOfVertices, int order)
        {
            myNumberOfVertices = noOfVertices;
            myOrder = order;
            myVertices = new List<Vertex>(noOfVertices);

            // this is because of a unique case where the graph can stall when being constructed.
            while (!backtrack)
            {
                backtrack = ConstructGraph();
       
            }
        }

        public bool ConstructGraph()
        {
            //Just add all the vertices with no connections
            PopulateGraph();
            

            int stallCount = 0;
            //For non-Complete Graphs. Pick an edge at random and add it as a pair.
            for (int i = 0; i < myNumberOfVertices; i++)
            {
                    
                while (true)
                {
                    if (myVertices[i].myEdges.Count == myOrder)
                        break;


                    int edgeToBe = randomSeed.Next(myNumberOfVertices);
                    if (!myVertices[i].myEdges.Contains(new Edge(i, edgeToBe)) && (myVertices[edgeToBe].myEdges.Count < myOrder)
                        && (edgeToBe != i))
                    {
                        myVertices[i].myEdges.Add(new Edge(i, edgeToBe));
                        myVertices[edgeToBe].myEdges.Add(new Edge(edgeToBe, i));
                        stallCount = 0;
                    }

                    stallCount++;
                    if (stallCount > 100)
                        return false;


                }
                              
            }
            //Console.WriteLine("Graph Constructed!");
            return true;
        }

        
    }
}
