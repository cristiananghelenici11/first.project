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
            Show(Sort(new int[]{15, 2, 40, 10, -50}));

            int[] arrUnidimensional = concatArray(new int[] {10, -2, 100}, RandomInitialize(new int[10]));
            Show(arrUnidimensional);

            //Create two functions with multi-dimensional arrays
            Show(RandomInitialize(new int[3,3]));
            



            Console.ReadKey();
        }

        public static int[]  Sort(int[] arr)
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
