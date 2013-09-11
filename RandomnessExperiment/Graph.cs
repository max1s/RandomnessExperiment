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


        public int ParallelNeighbourSwap()
        {
            int numberOfSwaps = 0;
            List<Vertex> swapWith = new List<Vertex>();
            List<Vertex> exhausted = new List<Vertex>();
            foreach (Vertex v in myVertices)
            {
                swapWith.Add(myVertices[v.myEdges[randomSeed.Next(myOrder)].mySecondVertex]);

            }
          
            for (int i = 0; i < myNumberOfVertices; i++)
            {
                Vertex vertexToSwap = myVertices[i];
                Vertex neighbourToSwapWith = myVertices[swapWith[i].myID];
                //Console.WriteLine(i + " : " + swapWith[i]);
                //Console.WriteLine(swapWith[i] + " : " + swapWith[swapWith[i].myID]);
                //Console.WriteLine("---------------");

                if (myVertices[i] == swapWith[swapWith[i].myID] && !exhausted.Contains(swapWith[i]))
                {
                    numberOfSwaps++;

                    int firstRandom = randomSeed.Next(myOrder - 1);
                    int secondRandom = randomSeed.Next(myOrder - 1);

                    Edge firstEdgetoSwap = vertexToSwap.myEdges[firstRandom];
                    Edge secondEdgetoSwap = neighbourToSwapWith.myEdges[secondRandom];
                    Edge temp;

                    if (firstEdgetoSwap.mySecondVertex == neighbourToSwapWith.myID)
                    {
                        firstRandom = 0;
                        foreach (Edge edge in vertexToSwap.myEdges)
                        {

                            //!edge.isBeingSwapped && 
                            if (!(edge.mySecondVertex == neighbourToSwapWith.myID))
                            {
                                firstEdgetoSwap = edge;
                                //  Console.WriteLine(" first edge now swapped to: " + firstEdgetoSwap);
                                break;

                            }
                            firstRandom++;
                        }

                    }

                    //secondEdgetoSwap.isBeingSwapped ||
                    if (secondEdgetoSwap.mySecondVertex == vertexToSwap.myID)
                    {
                        secondRandom = 0;
                        foreach (Edge edge in neighbourToSwapWith.myEdges)
                        {                            // !edge.isBeingSwapped &&
                            if (!(edge.mySecondVertex == vertexToSwap.myID))
                            {
                                secondEdgetoSwap = edge;
                                // Console.WriteLine(" second edge now swapped to: " + secondEdgetoSwap);
                                break;
                            }
                            secondRandom++;
                        }

                    }
                    //Console.WriteLine( " First Vertex picked: " + vertexToSwap.myID);
                    //Console.WriteLine(" Second Vertex picked: " + neighbourToSwapWith.myID);
                    //Console.WriteLine(" attempt first Edge picked: " + firstEdgetoSwap);
                    //Console.WriteLine(" attempt second Edge picked: " + secondEdgetoSwap);

                    myVertices[firstEdgetoSwap.mySecondVertex].myEdges.Find(x => x.mySecondVertex == firstEdgetoSwap.myFirstVertex).mySecondVertex = secondEdgetoSwap.myFirstVertex;
                    myVertices[secondEdgetoSwap.mySecondVertex].myEdges.Find(x => x.mySecondVertex == secondEdgetoSwap.myFirstVertex).mySecondVertex = firstEdgetoSwap.myFirstVertex;

                    //

                    temp = new Edge(secondEdgetoSwap.myFirstVertex, secondEdgetoSwap.mySecondVertex);

                    temp.mySecondVertex = firstEdgetoSwap.mySecondVertex;
                    firstEdgetoSwap.mySecondVertex = secondEdgetoSwap.mySecondVertex;
                    secondEdgetoSwap = temp;

                    myVertices[vertexToSwap.myID].myEdges[firstRandom] = firstEdgetoSwap;
                    myVertices[neighbourToSwapWith.myID].myEdges[secondRandom] = secondEdgetoSwap;

                }
                exhausted.Add(vertexToSwap);
                exhausted.Add(neighbourToSwapWith);
            }


            return numberOfSwaps;
        }

        public void SingleNeighbourSwap(int numberOfSwaps)
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
                Edge temp;


               // Console.WriteLine( " First Vertex picked: " + vertexToSwap.myID);
               // Console.WriteLine(" Second Vertex picked: " + neighbourToSwapWith.myID);
               // Console.WriteLine(" attempt first Edge picked: " + firstEdgetoSwap);
               // Console.WriteLine(" attempt second Edge picked: " + secondEdgetoSwap);

                bool errorFromOverChoosing = false;


                //basically if the edges are already in use use other ones.....
                //but if there are simply no edges abort the operation
                //firstEdgetoSwap.isBeingSwapped ||
                if (firstEdgetoSwap.mySecondVertex == neighbourToSwapWith.myID)
                {
                    firstRandom = 0;
                    foreach (Edge edge in vertexToSwap.myEdges)
                    {
                        
                        errorFromOverChoosing = false;
                        //!edge.isBeingSwapped && 
                        if (!(edge.mySecondVertex == neighbourToSwapWith.myID))
                        {
                            firstEdgetoSwap = edge;
                          //  Console.WriteLine(" first edge now swapped to: " + firstEdgetoSwap);
                            break;
                            
                        }
                        errorFromOverChoosing = true;
                        firstRandom++;
                    }
                    
                }

                //secondEdgetoSwap.isBeingSwapped ||
                if (secondEdgetoSwap.mySecondVertex == vertexToSwap.myID)
                {
                    secondRandom = 0;
                    foreach (Edge edge in neighbourToSwapWith.myEdges)
                    {
                        errorFromOverChoosing = false;
                        // !edge.isBeingSwapped &&
                        if (!(edge.mySecondVertex == vertexToSwap.myID))
                        {
                            secondEdgetoSwap = edge;
                           // Console.WriteLine(" second edge now swapped to: " + secondEdgetoSwap);
                            break;
                        }
                        errorFromOverChoosing = true;
                        secondRandom++;
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

               
                myVertices[firstEdgetoSwap.mySecondVertex].myEdges.Find(x => x.mySecondVertex == firstEdgetoSwap.myFirstVertex).mySecondVertex = secondEdgetoSwap.myFirstVertex;
                myVertices[secondEdgetoSwap.mySecondVertex].myEdges.Find(x => x.mySecondVertex == secondEdgetoSwap.myFirstVertex).mySecondVertex = firstEdgetoSwap.myFirstVertex;

                //

                temp = new Edge(secondEdgetoSwap.myFirstVertex, secondEdgetoSwap.mySecondVertex);

                temp.mySecondVertex = firstEdgetoSwap.mySecondVertex;
                firstEdgetoSwap.mySecondVertex = secondEdgetoSwap.mySecondVertex;
                secondEdgetoSwap = temp;


                //firstEdgetoSwap.isBeingSwapped = secondEdgetoSwap.isBeingSwapped = true;

                //


                // = new Edge(firstEdgetoSwap.mySecondVertex, firstEdgetoSwap.myFirstVertex);
                myVertices[vertexToSwap.myID].myEdges[firstRandom] = firstEdgetoSwap;

               
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

            //foreach (Vertex v in myVertices)
            //{
            //    foreach (Edge e in v.myEdges)
            //    {
            //        e.isBeingSwapped = false;
            //    }
            //}
        }
    }
}
