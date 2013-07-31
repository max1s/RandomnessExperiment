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

        public void PopulateGraph()
        {
            myVertices.Clear();
            for (int i = 0; i < myNumberOfVertices; i++)
            {
                myVertices.Add(new Vertex(myOrder, i));
            }
        }
    }
}
