using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomnessExperiment
{
    class CubeGraph : Graph
    {
        public int myHeight;
        public int myWidth;
        public int myDepth;

        public CubeGraph(int width, int height, int depth)
        {
            myHeight = height;
            myWidth = width;
            myDepth = depth;
            myNumberOfVertices = width * height * depth;
            myOrder = 4;
            myVertices = new List<Vertex>();
            PopulateGraph();
            ConstructGraph();

        }

        public void ConstructGraph()
        {
            int row = 0;
            int depth = 1;
            foreach (Vertex v in myVertices)
            {
                if (v.myID >= row * myWidth)
                    row++;
                if (v.myID >= depth * myWidth * myHeight)
                    depth++;
                v.myEdges.Add(new Edge(v.myID, Wrap(v.myID + 1, myWidth * (row - 1), myWidth * row)));
                v.myEdges.Add(new Edge(v.myID, Wrap(v.myID - 1, myWidth * (row - 1), myWidth * row)));
                v.myEdges.Add(new Edge(v.myID, Chain(v.myID + myWidth, myHeight * myWidth * (depth-1), myHeight * myWidth * depth)));
                v.myEdges.Add(new Edge(v.myID, Chain(v.myID - myWidth, myHeight * myWidth * (depth-1), myHeight * myWidth * depth)));
                v.myEdges.Add(new Edge(v.myID, Cube(v.myID + (myWidth * myHeight))));
                v.myEdges.Add(new Edge(v.myID, Cube(v.myID - (myWidth * myHeight))));

            }

        }

        public int Cube(int a)
        {
            if (a > myNumberOfVertices -1 )
                return a - myNumberOfVertices;
            if (a < 0)
                return a + myNumberOfVertices;
            else
                return a;




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

        public int Chain(int a, int lower, int upper)
        {
            if (a < lower)
                return a +( myWidth * myHeight);
            if (a > upper -1)
                return a - (myWidth * myHeight);
            else
                return a;
                
            
        }
    }
}
