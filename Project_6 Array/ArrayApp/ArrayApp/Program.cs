using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create two functions with one-dimensional arrays
            // Sort, Show, RandomInitialize, concatArray
            Show(SortUnidimensionalArray(new int[] { 15, 2, 40, 10, -50 }));

            int[] arrUnidimensional = concatArray(new int[] { 10, -2, 100 }, RandomInitialize(new int[10]));
            Show(arrUnidimensional);

            //Create two functions with multi-dimensional arrays
            Show(RandomInitialize(new int[3, 3]));
            Show(Sort2DArray(RandomInitialize(new int[3,3])));
            Console.WriteLine("-----------");

            //
            //jaged arr
            Console.WriteLine("jaged arr");

            int[][] data = new int[][] {
            new int[] {1,2,3},
            new int[] {2,3,4},
            new int[] {2,4,1}
            };

            ////
            // Declare the array of two elements:
            int[][] arr = new int[2][];

            // Initialize the elements:
            arr[0] = new int[5] { 1, 3, 5, 7, 9 };
            arr[1] = new int[4] { 2, 4, 6, 8 };

            // Display the array elements:
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.Write("Element({0}): ", i);

                for (int j = 0; j < arr[i].Length; j++)
                {
                    System.Console.Write("{0}{1}", arr[i][j], j == (arr[i].Length - 1) ? "" : " ");
                }
                System.Console.WriteLine();
            }

            ////

            Console.ReadKey();
        }

        public static T[,] Sort2DArray<T>(T[,] matrix)
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

        public static int[] SortUnidimensionalArray(int[] arr)
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

        public static void Show(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
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
                Console.WriteLine();
            }
            return arr;
        }

        public static int[] concatArray(int[] first, int[] second)
        {
            return first.Concat(second).ToArray();
        }
    }
}
