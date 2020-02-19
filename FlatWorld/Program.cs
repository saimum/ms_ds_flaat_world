using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Nullable<bool>[,] arr;

            Console.Write("Number of row: ");
            int row = Convert.ToInt32(Console.ReadLine());

            Console.Write("Number of colum: ");
            int colum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
            arr = new Nullable<bool>[row, colum];

            Random random = new Random();

            using (System.IO.StreamWriter input =
            new System.IO.StreamWriter(@"C:\Users\saimum_pc\Downloads\FlatWorld_1\FlatWorld_1\FlatWorld\input.txt"))
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < colum; j++)
                    {
                        int temp = random.Next(0, 2);
                        if (temp == 0)
                        {
                            input.Write("-");
                        }
                        else
                        {
                            input.Write("+");
                        }
                    }
                    input.WriteLine();
                }
            }

            int res = numOrganisms(arr);
            Console.WriteLine("\n result : " + res);
            Console.ReadKey();
        }

        static int numOrganisms(Nullable<bool>[,] arr)
        {
            int row = arr.GetLength(0);
            int colum = arr.GetLength(1);
            int count = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < colum; j++)
                {
                    if (arr[i, j] == true)
                    {
                        count = count + 1;
                        convert(arr, i, j, count);
                    }
                }
                Console.WriteLine();
            }

            //traversal  
            //Console.WriteLine("--------------------------------------");
            //for (int i = 0; i < row; i++)
            //{
            //    for (int j = 0; j < colum; j++)
            //    {
            //        Console.Write(arr[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            return count;
        }

        static void convert(Nullable<bool>[,] arr, int i, int j, int count)
        {
            if (arr[i, j] == true)
            {
                arr[i, j] = false;
                //left
                if (j - 1 >= 0)
                {
                    convert(arr, i, j - 1, count);
                }
                //down
                int row = arr.GetLength(0);
                if (i + 1 < row)
                {
                    convert(arr, i + 1, j, count);
                }
                //right
                int colum = arr.GetLength(1);
                if (j + 1 < colum)
                {
                    convert(arr, i, j + 1, count);
                }
                //up
                if (i - 1 >= 0)
                {
                    convert(arr, i - 1, j, count);
                }

            }
        }

    }
}
