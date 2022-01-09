using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public enum Color { WHITE, BLACK };

    public class Location
    {
        public Location(int r, int c)
        {
            row = r;
            column = c;
        }
        private int row;
        private int column;

        public int Row
        {
            get => row;
            set => row = value;
        }
        public int Column
        {
            get => column;
            set => column = value;
        }
    };
};
