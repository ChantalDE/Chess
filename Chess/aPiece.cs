using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public abstract class aPiece
    {
        public aPiece(Color col, Location loc)
        {
            position = loc;
            color = col;
        }
        abstract public List<List<Location>> moveBehavior();
       
        public Location position;
        public Color color;

        protected bool isValidMove(int row, int column) 
        {
            if (row > 7 && column > 7 && row < 0 && column < 0) return false;
            else return true;
        }
    };
};