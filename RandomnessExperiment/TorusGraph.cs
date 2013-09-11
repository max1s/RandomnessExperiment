using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomnessExperiment
{
    class TorusGraph : Graph
    {

        public int myWidth;
        public int myHeight;

        public TorusGraph(int width, int height)
        {
            myWidth = width;
            myHeight = height;
            myOrder = 4;
            myNumberOfVertices = width * height;
            myVertices = new List<Vertex>();
            PopulateGraph();
            ConstructGraph();
        }

        public void ConstructGraph()
        {
            int row = 0;
            foreach (Vertex v in myVertices)
            {
                if (v.myID >= row * myWidth)
                    row++;
                v.myEdges.Add(new Edge(v.myID, Wrap(v.myID -1, myWidth * (row -1), myWidth * row) ));
                v.myEdges.Add(new Edge(v.myID, Wrap(v.myID + 1, myWidth * (row -1), myWidth * row)));
                v.myEdges.Add(new Edge(v.myID, Chain(v.myID + myWidth, myNumberOfVertices)));
                v.myEdges.Add(new Edge(v.myID, Chain(v.myID - myWidth, myNumberOfVertices)));

            }
        }

        public int Wrap(int a, int lower, int upper)
        {
            if (a < lower)
                return upper - 1;
            if (a > upper -1)
                return lower;
            else
                return a;
            

        }

        public int Chain(int a, int upper)
        {
            if (a < 0)
                return upper + a;
            if (a > upper - 1)
                return -upper + a;
            else
                return a;
        }

    }
}
