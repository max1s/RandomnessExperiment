using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomnessExperiment
{
    
    class RandomnessChecker
    {
        Graph myGraph;
        double randomnessThreshhold; 

        public RandomnessChecker(Graph g, int constant)
        {
            myGraph = g;
            randomnessThreshhold = constant*Math.Ceiling(Math.Log(myGraph.myNumberOfVertices, 2.0d));
            
        }

        public bool CheckGraph()
        {
            //find c . log n need to ask stefan about this

            bool b;

            foreach(Vertex v in myGraph.myVertices)
            {
               b = CheckNeighbourList(v);
               if (b == false)
                   return false;
            }
            return true;
        }

        public bool CheckNeighbourList(Vertex v)
        {
            List<Vertex> myNeighbourList = new List<Vertex>();
            int counter = 0;
            Vertex lastLink = v;
            int i  = 0;

            //you need some sort of selection process.
            myNeighbourList.Add(v);

            while (myNeighbourList.Count < myGraph.myNumberOfVertices)
            {
                if (!myGraph.myVertices[i].myEdges.Contains(new Edge(i, lastLink.myID)))
                {
                    counter++;
                }
                  
                if (counter < randomnessThreshhold)
                {
                    for (int x = 0; x < myGraph.myOrder; x++)
                    {
                        
                        if (!myNeighbourList.Contains(myGraph.myVertices[myGraph.myVertices[i].myEdges[x].mySecondVertex]))
                        {
                            myNeighbourList.Add(myGraph.myVertices[myGraph.myVertices[i].myEdges[x].mySecondVertex]);
                        }
                    }
                }
                else
                    return false;

                i++;
            }
            return true;
        }

        
        
       
    }
}
