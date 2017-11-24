using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int r = int.Parse(inputs[0]);
            int c = int.Parse(inputs[1]);

            int[,] matrix = new int[r, c];

            for (int rows = 0; rows < r; rows++)
            {
                inputs = Console.ReadLine().Split(' ');
                for (int cols = 0; cols < c; cols++)
                {
                    matrix[rows, cols] = int.Parse(inputs[cols]);
                }
            }

            int maxSum = int.MinValue;
            for (int row = 0; row <= r-3; row++)
            {
                for (int col = 0; col <= c-3; col++)
                {
                    int currentSum =   matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                                  + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row+1, col+2]
                                  + matrix[row+2, col] + matrix[row+2, col+1] + matrix[row+2, col+2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }
            Console.WriteLine(maxSum);
        }
    }
}
