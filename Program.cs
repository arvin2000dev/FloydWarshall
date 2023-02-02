using System;
using System.Collections;

namespace FloydWarshall
{
    class Program
    {
        static byte[,] matrix;
        static void Main(string[] args)
        {
            

            //Fill matrix with user input
            Console.Write("Enter matrix row-column number: ");
            int n = int.Parse(Console.ReadLine());
            matrix = new byte[n,n];
            for (int index = 0; index < n; index++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("Enter matrix[" + (index + 1) + "," + (j + 1) + "]: ");
                    matrix[index, j] = byte.Parse(Console.ReadLine()); 
                }
            }

            //Test matrix data
            //matrix = new byte[,]  { { 0,0,1,0 }
                                  //, { 1,0,0,1 }
                                  //, { 0,0,0,1 }
                                  //, { 1,0,1,1 } };

            ArrayList c = new ArrayList();
            ArrayList r = new ArrayList();
            byte[] cr = new byte[] { };

            //Matrix has 4 columns and 4 rows so step should be 4
            for (int steps = 0; steps < (matrix.GetUpperBound(0) + 1); steps++)
            {
                //Wi = Wi + 1
                PrintMatrix();

                //C should be all 1 values of current step row
                //R should be all 1 values of current step column
                for (int index = 0; index < (matrix.GetUpperBound(0) + 1); index++)
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
                Console.Write("CxR={");
                for (int index = 0; index < r.Count; index++)
                {
                    for(int iterator = 0; iterator < c.Count; iterator++)
                    {
                        Console.Write("(" + (Convert.ToByte(r[index]) + 1) + "," + (Convert.ToByte(c[iterator]) + 1) + ")");
                        matrix[Convert.ToByte(r[index]), Convert.ToByte(c[iterator])] = 1;

                    }
                }
                Console.Write("}");
                c.Clear();
                r.Clear();
                Console.WriteLine();
            }

            PrintMatrix();

            Console.ReadKey();
        }

        static void PrintMatrix()
        {
            for (int i = 0; i < (matrix.GetUpperBound(0) + 1); i++)
            {
                ChangeBackgroundColor(ConsoleColor.White);
                ChangeForegroundColor(ConsoleColor.Black);
                for (int j = 0; j < (matrix.GetUpperBound(0) + 1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
            ChangeBackgroundColor(ConsoleColor.Black);
            ChangeForegroundColor(ConsoleColor.White);
        }

        static void ChangeBackgroundColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }
        static void ChangeForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
