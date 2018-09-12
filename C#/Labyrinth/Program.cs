using System;
using System.Collections.Generic;

namespace Labyrinth
{
    class Program
    {
        private static string[,] matrix;
        private static Queue<Cell> queue = new Queue<Cell>();

        static void Main(string[] args)
        {
            matrix = new string[,]
            {
                {"0","0","0","x","0","x"},
                {"0","x","0","x","0","x"},
                {"0","*","x","0","x","0"},
                {"0","x","0","0","0","0"},
                {"0","0","0","x","x","0"},
                {"0","0","0","x","0","x"},
            };

            Run();
            Print();

        }

        private static void ShortestPath(Cell cell, int dept)
        {
            if (cell.Row + 1 < matrix.GetLength(0) && matrix[cell.Row+1, cell.Col] == "0")
            {
                queue.Enqueue(new Cell(cell.Row + 1, cell.Col, cell.Value + 1));
            }
            if (cell.Row - 1 >= 0 && matrix[cell.Row - 1, cell.Col] == "0")
            {
                queue.Enqueue(new Cell(cell.Row - 1, cell.Col, cell.Value + 1));
            }
            if (cell.Col - 1 >= 0 && matrix[cell.Row, cell.Col - 1] == "0")
            {
                queue.Enqueue(new Cell(cell.Row, cell.Col - 1, cell.Value + 1));
            }
            if (cell.Col + 1 < matrix.GetLength(1) && matrix[cell.Row, cell.Col + 1] == "0")
            {
                queue.Enqueue(new Cell(cell.Row, cell.Col + 1, cell.Value + 1));
            }

            if (matrix[cell.Row, cell.Col] == "0")
            {
                matrix[cell.Row, cell.Col] = cell.Value.ToString();
            }

            if (queue.Count > 0)
            {
                ShortestPath(queue.Dequeue(), cell.Value + 1);
            }
        }

        private static void Run()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "*")
                    {
                        ShortestPath(new Cell(i, j, 0), 0);
                        FillUnreachable();
                        return;
                    }
                }
            }
        }

        private static void FillUnreachable()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "0")
                    {
                        matrix[i, j] = "u";
                    }
                }
            }
        }

        public static void Print()
        {
            Console.Clear();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var s = matrix[i, j];
                    Console.Write(String.Format("{0,-6}",
                        String.Format("{0," + ((6 + s.Length) / 2).ToString() + "}", s)));
                }
                Console.WriteLine();
            }
        }
    }

    struct Cell
    {
        public int Row { get; }
        public int Col { get; }
        public int Value { get; }

        public Cell(int row, int col, int value)
        {
            Row = row;
            Col = col;
            Value = value;
        }
    }
}
