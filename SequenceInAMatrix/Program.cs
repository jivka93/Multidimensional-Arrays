using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceInAMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }
            int maxSequence = 1;

            //HORIZONTAL -
            for (int row = 0; row < rows; row++)
            {
                int currentSequence = 1;
                for (int col = 1; col < cols; col++)
                {
                    if (matrix[row][col] == matrix[row][col - 1])
                    {
                        currentSequence++;

                    }
                    else if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                        currentSequence = 1;
                    }
                }
                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                    currentSequence = 1;
                }
            }

            // VERTICAL |
            for (int col = 0; col < cols; col++)
            {
                int currentSequence = 1;
                for (int row = 1; row < rows; row++)
                {
                    if (matrix[row][col] == matrix[row - 1][col])
                    {
                        currentSequence++;

                    }
                    else if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                        currentSequence = 1;
                    }
                }
                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                    currentSequence = 1;
                }
            }


            //DIAGONAL /

            // direction RIGHT
            for (int col = 0; col < cols; col++)
            {
                int row = 0;
                int currentSequence = 1;

                int dynamicRow = row;
                int dynamicCol = col;

                while (dynamicRow < rows - 1 && dynamicCol > 0 + 1)
                {
                    if (matrix[dynamicRow][dynamicCol] == matrix[dynamicRow + 1][dynamicCol - 1])
                    {
                        currentSequence++;
                    }
                    else
                    {
                        if (maxSequence < currentSequence)
                        {
                            maxSequence = currentSequence;
                        }
                        currentSequence = 1;
                    }
                    dynamicRow++;
                    dynamicCol--;
                    if (row == rows - 1 || col == 0 + 1)
                    {
                        break;
                    }
                }

            }
            // direction DOWN          
            for (int row = 1; row < rows - 1; row++)
            {
                int col = cols - 1;
                int currentSequence = 1;

                int dynamicRow = row;
                int dynamicCol = col;

                while (dynamicRow < rows - 1 && dynamicCol > 0 + 1)
                {
                    if (matrix[dynamicRow][dynamicCol] == matrix[dynamicRow + 1][dynamicCol - 1])
                    {
                        currentSequence++;
                    }
                    else
                    {
                        if (maxSequence < currentSequence)
                        {
                            maxSequence = currentSequence;
                        }
                        currentSequence = 1;
                    }
                    dynamicRow++;
                    dynamicCol--;
                }
            }

            //DIAGONAL \

            // direction UP           
            for (int row = rows - 1; row >= 0; row--)
            {
                int col = 0;
                int currentSequence = 1;

                int dynamicRow = row;
                int dynamicCol = col;

                while (dynamicRow < rows - 1 && dynamicCol < cols - 1)
                {
                    if (matrix[dynamicRow][dynamicCol] == matrix[dynamicRow + 1][dynamicCol + 1])
                    {
                        currentSequence++;
                    }
                    else // ????
                    {
                        if (maxSequence < currentSequence)
                        {
                            maxSequence = currentSequence;
                        }
                        currentSequence = 1;
                    }
                    dynamicRow++;
                    dynamicCol++;
                }
            }
            // direction RIGHT
            for (int col = 1; col < cols; col++)
            {
                int row = 0;
                int currentSequence = 1;

                int dynamicRow = row;
                int dynamicCol = col;

                while (dynamicRow < rows - 1 && dynamicCol < cols - 1)
                {
                    if (matrix[dynamicRow][dynamicCol] == matrix[dynamicRow + 1][dynamicCol + 1])
                    {
                        currentSequence++;
                    }
                    else
                    {
                        if (maxSequence < currentSequence)
                        {
                            maxSequence = currentSequence;
                        }
                        currentSequence = 1;
                    }
                    dynamicRow++;
                    dynamicCol++;
                }
            }

            Console.WriteLine(maxSequence);
        }
    }
}
