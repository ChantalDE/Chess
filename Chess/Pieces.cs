using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Pawn : aPiece
    {
        List<List<Location>> pawnMoves = new List<List<Location>>();

        public Pawn(Color color, Location loc) : base(color, loc)
        { }

        public override List<List<Location>> moveBehavior()
        {
            pawnMoves.Clear(); //clear previous moves
            List<Location> path = new List<Location>();
            int pawnMove = base.position.Row;
            if (base.color == Color.WHITE) pawnMove -= 1;
            else pawnMove += 1;
            if (base.isValidMove(pawnMove, 0))
                path.Add(new Location(pawnMove, base.position.Column));
            if((base.position.Row == 1 && base.color == Color.BLACK) || (base.position.Row == 6 && base.color == Color.WHITE)) //has pawn been moved? (first move)
            {
                pawnMove = base.position.Row;
                if (base.color == Color.WHITE) pawnMove -= 2;
                else pawnMove += 2;
                if (base.isValidMove(pawnMove, 0))
                    path.Add(new Location(pawnMove, base.position.Column));
            }
            pawnMoves.Add(path);
            return pawnMoves;
        }
    }
    public class Bishop : aPiece
    {
        List<List<Location>> bishopMoves = new List<List<Location>>();
        public Bishop(Color color, Location loc) : base(color, loc)
        {
        }

        //increments in [-i, -i], [-i, +i], [+i, -i], [+i, +i]
        public override List<List<Location>> moveBehavior()
        {
            bishopMoves.Clear(); 
            bishopMove(-1, -1);
            bishopMove(-1, 1);
            bishopMove(1, -1);
            bishopMove(1, 1);
            return this.bishopMoves;
        }
        private void bishopMove(int moveR, int moveC)
        {
            List<Location> path = new List<Location>(); //one path
            for (int i = 0; i < 7; i++)
            {
                int bishopMoveR = base.position.Row;
                int bishopMoveC = base.position.Column;
                bishopMoveR += (i * moveR);
                bishopMoveC += (i * moveC);
                if (base.isValidMove(bishopMoveR, bishopMoveC))
                    path.Add(new Location(bishopMoveR, bishopMoveC));
            }
            this.bishopMoves.Add(path);
        }
    };

    public class Knight : aPiece
    {
        public List<List<Location>> knightMoves = new List<List<Location>>();
        public Knight(Color color, Location loc) : base(color, loc) {
        }
        
        public override List<List<Location>> moveBehavior()
        {
            knightMoves.Clear();
            KnightMove(-2, -1);            
            KnightMove(-2, 1);
            KnightMove(-1, +2);
            KnightMove(1, 2);
            KnightMove(2, 1);
            KnightMove(2, -1);
            KnightMove(1, -2); 
            KnightMove(-1, -2);
            return this.knightMoves;
        }

        private void KnightMove(int moveR, int moveC)
        {
            List<Location> path = new List<Location>();
            int knightMoveR = base.position.Row;
            int knightMoveC = base.position.Column;
            knightMoveR += moveR;
            knightMoveC += moveC;
            if (base.isValidMove(knightMoveR, knightMoveC))
                path.Add(new Location(knightMoveR, knightMoveC));
            knightMoves.Add(path);
        }
    };

    public class Rook : aPiece
    {
        public List<List<Location>> rookMoves = new List<List<Location>>();
        public Rook(Color color, Location loc) : base(color, loc)
        {
        }
        public override List<List<Location>> moveBehavior()
        {
            rookMoves.Clear();
            RookMove(-1, 0);
            RookMove(0, 1);
            RookMove(1, 0);
            RookMove(0, -1);
            return this.rookMoves;
        }

        private void RookMove(int moveR, int moveC)
        {
            List<Location> path = new List<Location>();
            for (int i = 0; i < 7; i++) 
            {
                int knightMoveR = base.position.Row;
                int knightMoveC = base.position.Column;
                knightMoveR += (i * moveR);
                knightMoveC += (i * moveC);
                if (base.isValidMove(knightMoveR, knightMoveC))
                    path.Add(new Location(knightMoveR, knightMoveC));
            }
            this.rookMoves.Add(path);
        }
    };

    public class Queen : aPiece
    {
        public Queen(Color color, Location loc) : base(color, loc)
        {
        }

        public List<List<Location>> queenMoves = new List<List<Location>>();
        public override List<List<Location>> moveBehavior()
        {
            queenMoves.Clear();
            queenMove(-1, 0);
            queenMove(0, 1);
            queenMove(1, 0);
            queenMove(0, -1);
            queenMove(-1, -1);
            queenMove(-1, 1);
            queenMove(1, -1);
            queenMove(1, 1);
            return this.queenMoves;
        }
        private void queenMove(int moveR, int moveC)
        {
            List<Location> path = new List<Location>();
            for (int i = 0; i < 7; i++)
            {
                int queenMoveR = base.position.Row;
                int queenMoveC = base.position.Column;
                queenMoveR += (i * moveR);
                queenMoveC += (i * moveC);
                if (base.isValidMove(queenMoveR, queenMoveC))
                    path.Add(new Location(queenMoveR, queenMoveC));
            }
            this.queenMoves.Add(path);
        }
    };

    public class King : aPiece
    {
        public List<List<Location>> kingMoves = new List<List<Location>>();
        public King(Color color, Location loc) : base(color, loc)
        {
        }
        public override List<List<Location>> moveBehavior()
        {
            kingMoves.Clear();
            KingMove(-1, 0);
            KingMove(0, 1);
            KingMove(1, 0);
            KingMove(0, -1);
            KingMove(-1, -1);
            KingMove(-1, 1);
            KingMove(1, -1);
            KingMove(1, 1);
            return this.kingMoves;
        }

        private List<List<Location>> KingMove(int moveR, int moveC)
        {
            List<Location> path = new List<Location>();
            int kingMoveR = base.position.Row;
            int kingMoveC = base.position.Column;
            kingMoveR += moveR;
            kingMoveC += moveC;
            if (base.isValidMove(kingMoveR, kingMoveC))
                path.Add(new Location(kingMoveR, kingMoveC));
            this.kingMoves.Add(path);
            return this.kingMoves;
        }
    };
};
