using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillTheMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();
            char type = str[0];

            int[,] matrix = new int[size, size];

            if (type == 'a')
            {               
                for (int row = 0; row < size; row++)
                {
                    int count = row + 1;

                    for (int col = 0; col < size; col++)
                    {
                        matrix[row, col] = count;
                        count += size;
                        if (col == size - 1)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        else
                        {
                            Console.Write(matrix[row, col] + " ");
                        }
                    }
                    Console.WriteLine();
                }
            }


            else if (type == 'b')
            {
                int count = 1;
                for (int col = 0; col < size; col++)
                {
                    if (col % 2 == 0)
                    {
                        for (int row = 0; row < size; row++)
                        {
                            matrix[row, col] = count++;
                        }
                    }
                    else
                    {
                        for (int row = size - 1; row >= 0; row--)
                        {
                            matrix[row, col] = count++;
                        }
                    }
                }           
                // Printing
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (j == size - 1)
                        {
                            Console.Write(matrix[i, j]);
                        }
                        else
                        {
                            Console.Write(matrix[i, j] + " ");
                        }
                    }
                    Console.WriteLine();
                }
            }

            else if (type == 'c')
            {
                int row = size - 1;
                int col = 0;
                int count = 1;

                int usedRows = size - 1;
                int usedCols = 0;

                for (int i = 0; i < size*size; i++)
                {
                    while (matrix[size - 1, size - 1] == 0)
                    {
                        matrix[row, col] = count;
                        count++;
                        if (row + 1 == size) // When you get to the bottom
                        {
                            usedRows--;
                            row = usedRows;
                            col = 0;
                        }
                        else // Falling down the stairs
                        {
                            row++;
                            col++;
                        }                                            
                    }

                    row = 0;
                    col = 1;
                    usedCols = 1;
                    count = (matrix[0,0]) + size;

                    while (matrix[0, size - 1] == 0)
                    {
                        matrix[row, col] = count;
                        count++;
                        if (col + 1 == size) // When you hit the end of the matrix
                        {
                            row = 0;
                            col = usedCols + 1;
                            usedCols++;
                        }
                        else
                        {
                            row++;
                            col++;
                        }                        
                    }
                }

                // PRINTING
                for (int rows = 0; rows < size; rows++)
                {
                    for (int cols = 0; cols < size; cols++)
                    {
                        if (cols == size - 1)
                        {
                            Console.Write(matrix[rows, cols]);
                        }
                        else
                        {
                            Console.Write(matrix[rows, cols] + " ");

                        }
                    }
                    Console.WriteLine();
                }           
            }



            else if (type == 'd')
            {
                int rows = 0;
                int cols = 0;
                int count = 1;
                string direction = "down";

                for (int i = 0; i < size*size; i++)
                {
                    if (direction == "down")    // DIRECTION DOWN
                    {
                        if (rows == size || matrix[rows, cols] != 0)
                        {
                            direction = "right";
                        }
                        else
                        {
                            while (true)
                            {
                                if (rows == size || matrix[rows, cols] != 0)
                                {
                                    direction = "right";
                                    rows--;
                                    cols++;
                                    break;
                                }
                                matrix[rows, cols] = count++;
                                rows++;
                            }

                        }
                    }
                    if (direction == "right")    // DIRECTION RIGHT
                    {
                        if (cols == size || matrix[rows, cols] != 0)
                        {
                            direction = "up";
                        }
                        else
                        {
                            while (true)
                            {
                                if (cols == size || matrix[rows, cols] != 0)
                                {
                                    direction = "up";
                                    cols--;
                                    rows--;
                                    break;
                                }
                                matrix[rows, cols] = count++;
                                cols++;
                            }
                        }
                    }
                    if (direction == "up")    // DIRECTION UP
                    {
                        if (rows == -1 || matrix[rows, cols] != 0)
                        {
                            direction = "left";
                        }
                        else
                        {
                            while (true)
                            {
                                if (rows == -1 || matrix[rows, cols] != 0)
                                {
                                    direction = "left";
                                    cols--;
                                    rows++;
                                    break;
                                }
                                matrix[rows, cols] = count++;
                                rows--;
                            }
                        }
                    }
                    if (direction == "left")    // DIRECTION LEFT
                    {
                        if (cols < 0 || matrix[rows, cols] != 0)
                        {
                            direction = "down";
                        }
                        else
                        {
                            while (true)
                            {
                                if (cols < 0 || matrix[rows, cols] != 0)
                                {
                                    direction = "down";
                                    cols++;
                                    rows++;
                                    break;
                                }
                                matrix[rows, cols] = count++;
                                cols--;
                            }
                        }
                    }

                }
          
                // PRINTING
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (col == size - 1)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        else
                        {
                            Console.Write(matrix[row, col] + " ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
