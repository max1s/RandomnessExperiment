using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomnessExperiment
{
    class Graph
    {
        public int myNumberOfVertices;
        public int myOrder;
        public List<Vertex> myVertices;

        public Graph(int noOfVertices, int order)
        {
            myNumberOfVertices = noOfVertices;
            myOrder = order;
            myVertices = new List<Vertex>(noOfVertices);
            ConstructGraph();
        }

        public void ConstructGraph()
        {
            
        }
    }
}
