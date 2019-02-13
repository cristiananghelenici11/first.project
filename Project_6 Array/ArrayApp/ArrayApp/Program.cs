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

            ArrayOperation.Show(ArrayOperation.SortUnidimensional(new int[]{15, 2, 40, 10, -50}));

            ArrayOperation.Show(ArrayOperation.concatArray(new int[] {10, -2, 100}, ArrayOperation.RandomInitialize(new int[10])));

            //Create two functions with multi-dimensional arrays
            ArrayOperation.Show(ArrayOperation.SortBidimensional(ArrayOperation.RandomInitialize(new int[5, 5])));

            // Jagged array
            // Initialize the elements:
            int[][] arr = new int[][]
            {
                new int[] {1, 3, 5, 7, 9},
                new int[] {1, 3, 5, 7, 9, 5}
            };              
            int[][,] arr2 = new int[][,]
            {
                new int[,] {{1, 3, 5, 7, 9}, {3, 4, 1, 7, 4}},
                new int[,] {{1, 3, 5, 7, 9}, {2, 3, 4, 3, 7}}
            };

            ArrayOperation.Show(arr);
            ArrayOperation.Show(arr2);
            Array.Sort(ArrayOperation.RandomInitialize(new int[22]));
            int n = ArrayOperation.RandomInitialize(new int[10, 3]).Rank;
            Console.WriteLine(n);

            Console.WriteLine("String");
            StringExample.StringGo();

            Console.WriteLine("String Builder");
            StringExample.StringBuilderGo();

            Console.ReadKey();
        }

      
    }
}
