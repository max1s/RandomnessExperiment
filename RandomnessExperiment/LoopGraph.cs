using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomnessExperiment
{
    class LoopGraph : Graph
    {
        public int myRadius;

        public LoopGraph(int noOfVertices)
        {
            myOrder = 3;
            myNumberOfVertices = noOfVertices*2;
            myRadius = noOfVertices;
            myVertices = new List<Vertex>(myNumberOfVertices);

            PopulateGraph();
            ConstructGraph();
        }

        public void ConstructGraph()
        {
            foreach (Vertex v in myVertices)
            {
                if (v.myID < myRadius)
                {
                    v.myEdges.Add(new Edge(v.myID, v.myID + myRadius));
                    v.myEdges.Add(new Edge(v.myID, Wrap(v.myID - 1, 0, myRadius)));
                    v.myEdges.Add(new Edge(v.myID, Wrap(v.myID + 1, 0, myRadius)));
                }
                else
                {
                    v.myEdges.Add(new Edge(v.myID, v.myID - myRadius));
                    v.myEdges.Add(new Edge(v.myID, Wrap(v.myID - 1, myRadius, myRadius*2)));
                    v.myEdges.Add(new Edge(v.myID, Wrap(v.myID + 1, myRadius, myRadius*2)));
                }


            }
        }

        public int Wrap(int a, int lower, int upper)
        {
            if (a < lower)
                return upper - 1;
            if (a > upper - 1)
                return lower;
            else
                return a;


        }

       


    }
}
