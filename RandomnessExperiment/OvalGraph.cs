using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomnessExperiment
{
    class OvalGraph : Graph
    {
        public OvalGraph(int noOfVertices)
        {
            myOrder = 2;
            myNumberOfVertices = noOfVertices;
            myVertices = new List<Vertex>(noOfVertices);

            PopulateGraph();
            ConstructGraph();
            Console.WriteLine("Graph Constructed!");
        }

        public void ConstructGraph()
        {
            foreach (Vertex v in myVertices)
            {
                v.myEdges.Add(new Edge(v.myID, Chain(v.myID - 1 ,myNumberOfVertices)));
                v.myEdges.Add(new Edge(v.myID, Chain(v.myID + 1, myNumberOfVertices)));

            }
        }

        public int Chain(int a, int upper)
        {
            if (a < 0)
                return  upper + a;
            if (a > upper -1)
                return -upper + a;
            else
                return a;
        }
    }
}
