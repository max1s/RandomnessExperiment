using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomnessExperiment
{
    class Vertex
    {
        List<Edge> myEdges;
        int myID;

        public Vertex(int order, int id)
        {
            myEdges = new List<Edge>(order);
            myID = id;
        }
    }
}
