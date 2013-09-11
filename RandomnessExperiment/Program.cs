using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RandomnessExperiment
{
    class Program
    {

        static void Main(string[] args)
        {


            StreamWriter file = new StreamWriter("C:\\Users\\max\\Dropbox\\Second Year CS\\dimensionalTest2.txt");
            StreamWriter secondFile = new StreamWriter("C:\\Users\\max\\Dropbox\\Second Year CS\\varianceDimensionalTest2.txt");

            for (int i = 4; i < 25; i += 2)
            {

                for (int j = 3; j <= i; j += 3)
                {
                    int averageTime = 0;
                    for (int count = 0; count < 4; count++)
                    {
                        int t = 0;

                        CubeGraph cube = new CubeGraph(i, j, j);
                        RandomnessChecker rc = new RandomnessChecker(cube, 2);


                        if (rc.CheckGraph())
                        {
                            continue;
                        }
                        while (true)
                        {
                            for (int x = 0; x < 5; x++)
                            {
                                rc.myGraph.ParallelNeighbourSwap();
                                t++;
                            }

                            if (rc.CheckGraph())
                                break;

                        }
                        averageTime += t;
                        secondFile.WriteLine(i * j * j + " " + t);
                        secondFile.Flush();

                    }
                    averageTime = averageTime / 4;
                    Console.WriteLine(i * j * j + " " + averageTime);
                    file.WriteLine(i * j * j + " " + averageTime);
                    file.Flush();



                }

            }
            file.Close();
        }
    }
}
