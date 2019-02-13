using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayApp
{
    static class ArrayOperation
    {
         public static int[] SortUnidimensional(int[] arr)
         {
            int temp = 0;
            for (int write = 0; write < arr.Length; write++) {
                for (int sort = 0; sort < arr.Length - 1; sort++) {
                    if (arr[sort] > arr[sort + 1]) {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }
            return arr;
         }

        public static T[,] SortBidimensional<T>(T[,] matrix)
        {
            var numb = new T[matrix.GetLength(0) * matrix.GetLength(1)];

            int i = 0;
            foreach (var n in matrix)
            {
                numb[i] = n;
                i++;
            }
            Array.Sort(numb);

            int k = 0;
            for (i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = numb[k];
                    k++;
                }
            }
            return matrix;
        }

        public static void Show(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
            Console.WriteLine();

        }        
        public static void Show(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void Show(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.Write("Element({0}): ", i);

                for (int j = 0; j < arr[i].Length; j++)
                {
                    System.Console.Write("{0}{1}", arr[i][j], j == (arr[i].Length - 1) ? "" : " ");
                }
                System.Console.WriteLine();            
            }
            Console.WriteLine();
        }        

        public static void Show(int[][,] arr)
        {
            foreach (int[,] s in arr)
            {
                for (int i = 0; i < s.GetLength(0); i++)
                {
                    for (int j = 0; j < s.GetLength(1); j++)
                    {
                        Console.Write(s[i, j] + " ");
                    }

                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static int[] RandomInitialize(int[] arr)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-100, 100);
            }
            return arr;
        }        
        public static int[,] RandomInitialize(int[,] arr)
        {
            Random random = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = random.Next(-100, 100);
                }
            }
            return arr;
        }

        public static int[] concatArray(int[] first, int[] second)
        {
            return first.Concat(second).ToArray();
        }
    }
}
