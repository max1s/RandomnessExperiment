
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomnessExperiment
{
    class Edge : IEquatable<Edge>
    {
        public int myFirstVertex;
        public int mySecondVertex;
        public bool isBeingSwapped;

        public Edge(int firstVertex, int secondVertex)
        {
            myFirstVertex = firstVertex;
            mySecondVertex = secondVertex;
            isBeingSwapped = false;
        }

        //if the numbers are the wrong way round they are still the same edge obviously
        public bool Equals(Edge edge)
        {
            if ((edge.myFirstVertex == this.myFirstVertex && edge.mySecondVertex == this.mySecondVertex) ||
                (edge.mySecondVertex == this.myFirstVertex && edge.myFirstVertex == this.mySecondVertex))
            {
                return true;
            }

            else
                return false;

        }

        public override string ToString()
        {
            return "[V1: " + myFirstVertex + " V2: " + mySecondVertex + " ]";
        }
        
    }
}
