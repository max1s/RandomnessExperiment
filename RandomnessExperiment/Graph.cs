using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomnessExperiment
{
    abstract class Graph
    {
        public int myNumberOfVertices;
        public int myOrder;
        public List<Vertex> myVertices;
        public Random randomSeed = new Random();

        public void PopulateGraph()
        {
            myVertices.Clear();
            for (int i = 0; i < myNumberOfVertices; i++)
            {
                myVertices.Add(new Vertex(myOrder, i));
            }
        }

        public void AllNeighbourSwapVertices(int numberOfSwaps)
        {
        }

        public void NeighbourSwapVertices(int numberOfSwaps)
        {

            //makes sure doesnt process same vertex twice in same operation.
            List<Vertex> usedVertices = new List<Vertex>();
            int passOver = 0;
            //choose initial starting vertex at random
            Vertex vertexToSwap = myVertices[randomSeed.Next(myNumberOfVertices-1)];

            //main loop where vertex is chosen at random and swapping starts.
            while (passOver < numberOfSwaps)
            {
                //this vertex is now used
                usedVertices.Add(vertexToSwap);

                Vertex neighbourToSwapWith = myVertices[vertexToSwap.myEdges[randomSeed.Next(myOrder-1)].mySecondVertex];

                int firstRandom = randomSeed.Next(myOrder-1);
                int secondRandom = randomSeed.Next(myOrder-1);
                
                
                Edge firstEdgetoSwap = vertexToSwap.myEdges[firstRandom];
                Edge secondEdgetoSwap = neighbourToSwapWith.myEdges[secondRandom];

                Console.WriteLine( " First Vertex picked: " + vertexToSwap.myID);
                Console.WriteLine(" Second Vertex picked: " + neighbourToSwapWith.myID);
                Console.WriteLine(" First attempt Edge picked: " + firstEdgetoSwap);
                Console.WriteLine(" First attempt Edge picked: " + secondEdgetoSwap);

                bool errorFromOverChoosing = false;


                //basically if the edges are already in use use other ones.....
                //but if there are simply no edges abort the operation

                if (firstEdgetoSwap.isBeingSwapped || firstEdgetoSwap.mySecondVertex == neighbourToSwapWith.myID)
                {
                    foreach (Edge edge in vertexToSwap.myEdges)
                    {
                        errorFromOverChoosing = false;
                        if (!edge.isBeingSwapped && !(edge.mySecondVertex == neighbourToSwapWith.myID))
                        {
                            firstEdgetoSwap = edge;
                            Console.WriteLine(" first edge now swapped to: " + firstEdgetoSwap);
                            break;
                            
                        }
                        errorFromOverChoosing = true;
                        
                    }
                    
                }

                if (secondEdgetoSwap.isBeingSwapped || secondEdgetoSwap.mySecondVertex == vertexToSwap.myID)
                {
                    foreach (Edge edge in neighbourToSwapWith.myEdges)
                    {
                        errorFromOverChoosing = false;
                        if (!edge.isBeingSwapped && !(edge.mySecondVertex == vertexToSwap.myID))
                        {
                            secondEdgetoSwap = edge;
                            Console.WriteLine(" second edge now swapped to: " + secondEdgetoSwap);
                            break;
                        }
                        errorFromOverChoosing = true;
                        
                    }
                    
                }

                if (errorFromOverChoosing)
                {
                    Console.WriteLine("Error flag raised");
                    while (usedVertices.Contains(vertexToSwap))
                    {
                        vertexToSwap = myVertices[randomSeed.Next(myNumberOfVertices - 1)];
                    }
                    Console.WriteLine("Continuing after error...");
                    continue;
                }
                
                //Swap and change.
                Console.WriteLine("Swapping...");
                Edge temp = secondEdgetoSwap;

                temp.mySecondVertex = firstEdgetoSwap.mySecondVertex;
                firstEdgetoSwap.mySecondVertex = secondEdgetoSwap.mySecondVertex;
                secondEdgetoSwap = temp;

                firstEdgetoSwap.isBeingSwapped = secondEdgetoSwap.isBeingSwapped = true;

                Edge firstReplaceEdge = myVertices[vertexToSwap.myID].myEdges[firstRandom];
                Edge secondReplaceEdge = myVertices[neighbourToSwapWith.myID].myEdges[secondRandom];


                myVertices[firstEdgetoSwap.mySecondVertex].myEdges.Find(x => x.mySecondVertex == firstReplaceEdge.myFirstVertex).mySecondVertex = firstEdgetoSwap.myFirstVertex;// = new Edge(firstEdgetoSwap.mySecondVertex, firstEdgetoSwap.myFirstVertex);
                myVertices[vertexToSwap.myID].myEdges[firstRandom] = firstEdgetoSwap;

                myVertices[secondEdgetoSwap.mySecondVertex].myEdges.Find(x => x.mySecondVertex == secondReplaceEdge.myFirstVertex).mySecondVertex = secondEdgetoSwap.myFirstVertex;
                myVertices[neighbourToSwapWith.myID].myEdges[secondRandom] = secondEdgetoSwap;
                //succesful switch so we can count this as succesful operation
                passOver++;
                //choose next Vertex at Random.

                while(usedVertices.Contains(vertexToSwap))
                {
                    vertexToSwap = myVertices[randomSeed.Next(myNumberOfVertices - 1)];
                }
            }
            //after main loop we need to now turn the flag off for all the recently changed vertices.

            foreach (Vertex v in myVertices)
            {
                foreach (Edge e in v.myEdges)
                {
                    e.isBeingSwapped = false;
                }
            }
        }
    }
}
