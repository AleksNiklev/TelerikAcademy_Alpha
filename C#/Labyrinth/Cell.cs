using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    public struct Cell
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
