using System;
using System.Collections;
using System.Windows.Forms;

namespace kMeanClustering
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            double[,] table1 = new double[,]
            {
                { 100, 34, 98 ,45 },
                { 56, 89, 68, 98 },
                { 78, 88, 98, 100 },
                { 38, 81, 66, 79 },
                { 99, 23, 83, 56 },
                { 78, 88, 87, 69 },
                { 77, 89, 98, 79 },
                { 34, 23, 33, 45 },
                { 88, 45, 100, 71 },
                { 55, 32, 41, 65 },
                { 65, 23, 54, 44 },
                { 42, 32, 44, 52 },
                { 55, 100, 65, 74},
                { 98, 83, 78, 89 },
                { 56, 56, 61, 77 },
                { 79, 45, 90, 65 },
                { 32, 33, 45, 54 },
                { 66, 100, 64, 78},
                { 99, 89, 87, 86 },
                { 78, 45, 86, 56 },
                { 65, 54, 76, 77 },
                { 56, 94, 69, 80 },
                { 100, 78, 88, 89 },
                { 46, 96, 63, 83 },
            };

            double[,] table2 = new double[,]
            {
                { 87, 56, 95, 58 },
                { 67, 89, 45, 92 },
                { 93, 84, 79, 85 },
                { 34, 44, 54, 24 },
                { 56, 88, 65, 100 },
                { 89, 56, 63, 89 },
                { 32, 56, 63, 45 },
                { 99, 87, 81, 98 },
                { 89, 45, 78, 58 }
            };

            double[,] table3 = new double[,]
            {
                { 87, 45, 76, 56 },
                { 95, 89, 85, 90 },
                { 51, 87, 45, 79 },
                { 45, 43, 56, 43 }
            };
            int noOfVar = table1.GetLength(1); //fixed
            ArrayList centroid = new ArrayList();
            centroid.Add(new double[,] { { 70, 70, 70, 70 } });
            centroid.Add(new double[,] { { 34, 32, 39, 40 }, { 71, 75, 73, 78 } });
            centroid.Add(new double[,] { { 40, 40, 40, 40 }, { 60, 60, 60, 60 }, { 80, 80, 80, 80 } });
            centroid.Add(new double[,] { { 40, 40, 40, 40 }, { 55, 55, 55, 55 }, 
                { 70, 70, 70, 70 }, { 85, 85, 85, 85 } });
            centroid.Add(new double[,] { { 40, 40, 40, 40 }, { 54, 54, 54, 54 },
                { 66, 66, 66, 66 }, { 78, 78, 78, 78 }, { 90, 90, 90, 90 } });
            centroid.Add(new double[,] { { 40, 40, 40, 40 }, { 54, 54, 54, 54 },
                { 66, 66, 66, 66 }, { 77, 77, 77, 77 }, { 86, 86, 86, 86 }, { 92, 92, 92, 92 } });

            //create a list to assign classified point later
            ArrayList clsfedPoint = new ArrayList();
            for (int k = 0; k < centroid.Count; k++)
                clsfedPoint.Add(new ArrayList());
            
            //get total SSE for each k to plot graph later
            double[] totalSSE = new double[centroid.Count];

            for (int k = 0; k < centroid.Count; k++)
            {
                double[,] temp; //to check centroid same or not

                while (true)
                {
                    totalSSE[k] = 0;

                    ((ArrayList)clsfedPoint[k]).Clear();
                    for (int centroidNo = 0; centroidNo < k + 1; centroidNo++) //since k = no of centroids
                        ((ArrayList)clsfedPoint[k]).Add(new ArrayList());

                    temp = (double[,])((double[,])centroid[k]).Clone();

                    for (int sampleNo = 0; sampleNo < table1.GetLength(0); sampleNo++)
                    {
                        int minPoint = 0;
                        double minValue = double.MaxValue;
                        double[] point = new double[4];
                        double[] sse2 = new double[((double[,])centroid[k]).GetLength(0)];//to find lowest SSE
                        for (int centroidNo = 0; centroidNo < sse2.Length; centroidNo++)
                        {
                            //Euclidean algorithm
                            for (int a = 0; a < noOfVar; a++)
                                sse2[centroidNo] += Math.Pow(((double[,])centroid[k])[centroidNo, a] - table1[sampleNo, a], 2);
                            
                            //find least SSE
                            if (sse2[centroidNo] < minValue)
                            {
                                minPoint = centroidNo;
                                minValue = sse2[centroidNo];
                            }
                        }
                        //classify point into centroid with least SSE
                        for (int varNo = 0; varNo < noOfVar; varNo++)
                            point[varNo] = table1[sampleNo, varNo];
                        ((ArrayList)((ArrayList)clsfedPoint[k])[minPoint]).Add(point.Clone());

                        totalSSE[k] += minValue;//add the classified point's SSE into total SSE of specific k
                    }
                    //reset all value of centroid to zero, for recalculate new centroid later
                    for (int centroidNo = 0; centroidNo < ((double[,])centroid[k]).GetLength(0); centroidNo++)
                    {
                        if (((ArrayList)((ArrayList)clsfedPoint[k])[centroidNo]).Count != 0)
                        {
                            for (int varNo = 0; varNo < noOfVar; varNo++)
                                ((double[,])centroid[k])[centroidNo, varNo] = 0;
                        }
                    }
                    //recalculate new centroid
                    for (int centroidNo = 0; centroidNo < ((double[,])centroid[k]).GetLength(0); centroidNo++)
                    {
                        if (((ArrayList)((ArrayList)clsfedPoint[k])[centroidNo]).Count != 0)
                        {
                            for (int varNo = 0; varNo < noOfVar; varNo++)
                            {
                                for (int clsfedPointNo = 0; clsfedPointNo < ((ArrayList)((ArrayList)clsfedPoint[k])[centroidNo]).Count; clsfedPointNo++)
                                    ((double[,])centroid[k])[centroidNo, varNo] += ((double[])((ArrayList)((ArrayList)clsfedPoint[k])[centroidNo])[clsfedPointNo])[varNo];
                                ((double[,])centroid[k])[centroidNo, varNo] /= ((ArrayList)((ArrayList)clsfedPoint[k])[centroidNo]).Count;
                            }
                        }
                    }
                    //check whether all centroids of a specific k same or not with previous one
                    bool same = true;
                    for (int centroidNo = 0; centroidNo < ((double[,])centroid[k]).GetLength(0); centroidNo++)
                    {
                        for (int varNo = 0; varNo < noOfVar; varNo++)
                        {
                            if (((double[,])centroid[k])[centroidNo, varNo] != temp[centroidNo, varNo])
                                same = false;
                        }
                    }
                    if (same)
                        break;
                }
            }

            //display
            Console.WriteLine("\n1 ) Finding Total SSE^2 for K = 1 to K = 6\n");
            for (int x = 0; x < centroid.Count; x++)
            {
                Console.WriteLine("K = " + (x + 1));
                for (int y = 0; y < x + 1; y++)
                {
                    Console.Write("( ");
                    for (int a = 0; a < noOfVar; a++)
                        Console.Write(String.Format("{0:f2}{1}", ((double[,])centroid[x])[y, a], a != noOfVar - 1 ? ", " : " ) : "));
                    Console.Write(Convert.ToString(((ArrayList)((ArrayList)clsfedPoint[x])[y]).Count) +"\n");
                }
                Console.WriteLine("Total SSE^2 : " + totalSSE[x] + "\n");
            }

            int finalK = 2; //selected K-value (zero-based) after plotting graph

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("2 ) Graph is plotted and K = " + (finalK + 1) + " is selected.\n");
            for (int y = 0; y < finalK + 1; y++)
            {
                Console.Write("Centroid No." + (y + 1) + ": ( ");
                for (int a = 0; a < noOfVar; a++)
                    Console.Write(String.Format("{0:f2}{1}", ((double[,])centroid[finalK])[y, a], a != noOfVar - 1 ? ", " : " )"));
                Console.WriteLine();
            }

            //Below is for table 2
            //classifly table 2
            Console.WriteLine("\n--------------------------------------------------------------------------");
            Console.WriteLine("3 ) Classification for Table 2\n");
            for (int sampleNo = 0; sampleNo < table2.GetLength(0); sampleNo++)
            {
                int minPoint = 0;
                double minValue = double.MaxValue;
                double[] point = new double[4];
                double[] sse2 = new double[((double[,])centroid[finalK]).GetLength(0)];//to find lowest SSE
                for (int centroidNo = 0; centroidNo < sse2.Length; centroidNo++)
                {
                    //Euclidean algorithm
                    for (int a = 0; a < noOfVar; a++)
                        sse2[centroidNo] += Math.Pow(((double[,])centroid[finalK])[centroidNo, a] - table2[sampleNo, a], 2);

                    //find least SSE
                    if (sse2[centroidNo] < minValue)
                    {
                        minPoint = centroidNo;
                        minValue = sse2[centroidNo];
                    }
                }
                //classify point into centroid with least SSE
                Console.Write("( ");
                for (int varNo = 0; varNo < noOfVar; varNo++)
                {
                    point[varNo] = table2[sampleNo, varNo];
                    Console.Write(String.Format("{0}{1}", point[varNo], varNo != noOfVar - 1 ? ", " : " )"));
                }
                Console.WriteLine(" : Centroid No." + (minPoint + 1));
                ((ArrayList)((ArrayList)clsfedPoint[finalK])[minPoint]).Add(point.Clone());
            }
            
            //reset all value of centroid to zero, for recalculate new centroid later
            for (int centroidNo = 0; centroidNo < ((double[,])centroid[finalK]).GetLength(0); centroidNo++)
            {
                if (((ArrayList)((ArrayList)clsfedPoint[finalK])[centroidNo]).Count != 0)
                {
                    for (int varNo = 0; varNo < noOfVar; varNo++)
                        ((double[,])centroid[finalK])[centroidNo, varNo] = 0;
                }
            }
            //recalculate new centroid
            for (int centroidNo = 0; centroidNo < ((double[,])centroid[finalK]).GetLength(0); centroidNo++)
            {
                if (((ArrayList)((ArrayList)clsfedPoint[finalK])[centroidNo]).Count != 0)
                {
                    for (int varNo = 0; varNo < noOfVar; varNo++)
                    {
                        for (int clsfedPointNo = 0; clsfedPointNo < ((ArrayList)((ArrayList)clsfedPoint[finalK])[centroidNo]).Count; clsfedPointNo++)
                            ((double[,])centroid[finalK])[centroidNo, varNo] += ((double[])((ArrayList)((ArrayList)clsfedPoint[finalK])[centroidNo])[clsfedPointNo])[varNo];
                        ((double[,])centroid[finalK])[centroidNo, varNo] /= ((ArrayList)((ArrayList)clsfedPoint[finalK])[centroidNo]).Count;
                    }
                }
                
            }
            //display new centroid
            Console.WriteLine("\n--------------------------------------------------------------------------");
            Console.WriteLine("4 ) Recalculated centroid ( K = " + (finalK + 1) + " )\n");
            for (int y = 0; y < finalK + 1; y++)
            {
                Console.Write("Centroid No." + (y + 1) + ": ( ");
                for (int a = 0; a < noOfVar; a++)
                    Console.Write(String.Format("{0:f2}{1}", ((double[,])centroid[finalK])[y, a], a != noOfVar - 1 ? ", " : " )"));
                Console.WriteLine();
            }
            
            //Below is for table 3
            //classify table 3
            Console.WriteLine("\n--------------------------------------------------------------------------");
            Console.WriteLine("5 ) Classification for Table 3\n");
            for (int sampleNo = 0; sampleNo < table3.GetLength(0); sampleNo++)
            {
                int minPoint = 0;
                double minValue = double.MaxValue;
                double[] point = new double[4];
                double[] sse2 = new double[((double[,])centroid[finalK]).GetLength(0)];//to find lowest SSE
                for (int centroidNo = 0; centroidNo < sse2.Length; centroidNo++)
                {
                    //Euclidean algorithm
                    for (int a = 0; a < noOfVar; a++)
                        sse2[centroidNo] += Math.Pow(((double[,])centroid[finalK])[centroidNo, a] - table3[sampleNo, a], 2);

                    //find least SSE
                    if (sse2[centroidNo] < minValue)
                    {
                        minPoint = centroidNo;
                        minValue = sse2[centroidNo];
                    }
                }
                //classify point into centroid with least SSE
                Console.Write("( ");
                for (int varNo = 0; varNo < noOfVar; varNo++)
                {
                    point[varNo] = table3[sampleNo, varNo];
                    Console.Write(String.Format("{0}{1}", point[varNo], varNo != noOfVar - 1 ? ", " : " )"));
                }
                Console.WriteLine(" : Centroid No." + (minPoint + 1));
                ((ArrayList)((ArrayList)clsfedPoint[finalK])[minPoint]).Add(point.Clone());
            }
            Console.WriteLine();

            //display graph
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmGraph(totalSSE, finalK));
        }
    }
}
