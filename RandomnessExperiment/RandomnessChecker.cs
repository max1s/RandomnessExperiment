using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomnessExperiment
{
    
    class RandomnessChecker
    {
        public Graph myGraph;
        double randomnessThreshhold;
        Vertex v;

        public RandomnessChecker(Graph g, int constant)
        {
            myGraph = g;
            randomnessThreshhold = constant*Math.Ceiling(Math.Log(myGraph.myNumberOfVertices, 2.0d));
            v = myGraph.myVertices[rdm.Next(myGraph.myNumberOfVertices)];
            
        }

        public bool CheckGraph()
        {
            //find c . log n need to ask stefan about this

            bool b;
            Random rdm = new Random();


            //Check a vertex V at Random.. Since this is only an approximation doesnt really matter which
            

            //foreach(Vertex v in myGraph.myVertices)
            //{
            b = CheckNeighbourList(v);

            if (!b)
                return false;
            else
                return true;
               
            //}
            
        }

        public bool CheckNeighbourList(Vertex v)
        {
            List<Vertex> myNeighbourList = new List<Vertex>();
            int counter = 0;
         

            //you need some sort of selection process.
            myNeighbourList.Add(v);
            
            while (myNeighbourList.Count < myGraph.myNumberOfVertices)
            {
                
                  
                if (counter < randomnessThreshhold)
                {
                    List<Vertex> staticCopy = new List<Vertex>();
                    staticCopy = myNeighbourList.ToList();
                    foreach (Vertex vertex in staticCopy)
                    {
                        foreach (Edge e in vertex.myEdges)
                        {
                            if (!myNeighbourList.Contains(myGraph.myVertices[e.mySecondVertex]))
                            {
                                myNeighbourList.Add(myGraph.myVertices[e.mySecondVertex]);

                            }
                        }
                    }
                    counter++;
                    //for (int x = 0; x < myGraph.myOrder; x++)
                    //{
                        
                    //    if (!myNeighbourList.Contains(myGraph.myVertices[myGraph.myVertices[i].myEdges[x].mySecondVertex]))
                    //    {
                    //        myNeighbourList.Add(myGraph.myVertices[myGraph.myVertices[i].myEdges[x].mySecondVertex]);
                            
                    //    }
                        
                    //}
                    //Console.Write("[");
                    //foreach (Vertex vertex in myNeighbourList)
                    //{
                    //    Console.Write(vertex + ",");
                    //}
                    //Console.Write("]");
                    //Console.WriteLine();
                }
                else
                    return false;

                
            }
            return true;
        }

        
        
       
    }
}
