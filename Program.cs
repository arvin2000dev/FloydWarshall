using System;
using System.Collections;

namespace FloydWarshall
{
    class Program
    {
        static byte[,] matrix;
        static void Main(string[] args)
        {
            //Matrix
            // 0 0 1 0
            // 1 0 0 1
            // 0 0 0 1
            // 1 0 1 0 
            //Matrix
            matrix = new byte[,]  { { 0,0,1,0 }
                                          , { 1,0,0,1 }
                                          , { 0,0,0,1 }
                                          , { 1,0,1,1 } };
            ArrayList c = new ArrayList();
            ArrayList r = new ArrayList();
            byte[] cr = new byte[] { };

            //Matrix has 4 columns and 4 rows so step should be 4
            for (int steps = 0; steps < (matrix.Length / 4); steps++)
            {
                //Wi = Wi + 1
                PrintMatrix();

                //C should be all 1 values of current step row
                //R should be all 1 values of current step column
                for (int index = 0; index < (matrix.Length / 4); index++)
                {
                    if(matrix[steps, index] == 1)
                    {
                        c.Add(index);
                    }
                    if (matrix[index, steps] == 1)
                    {
                        r.Add(index);
                    }
                }

                //R x C
                for (int index = 0; index < r.Count; index++)
                {
                    for(int iterator = 0; iterator < c.Count; iterator++)
                    {
                        Console.Write("(" + (Convert.ToByte(r[index]) + 1) + "," + (Convert.ToByte(c[iterator]) + 1) + ")");
                        matrix[Convert.ToByte(r[index]), Convert.ToByte(c[iterator])] = 1;
                    }
                }

                c.Clear();
                r.Clear();
                Console.WriteLine();
            }

            PrintMatrix();

            Console.ReadKey();
        }

        static void PrintMatrix()
        {
            for (int i = 0; i < (matrix.Length / 4); i++)
            {
                for (int j = 0; j < (matrix.Length / 4); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
