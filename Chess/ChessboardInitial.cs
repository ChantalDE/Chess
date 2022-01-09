using System;
using System.Collections.Generic;
using System.Text;


namespace Chess
{
    //setup 8x8 board of pieces.
    public partial class Chessboard { 
    
        public List<List<aPiece>> chessBoard = new List<List<aPiece>>(8);

        public Chessboard()
        {
            initializeBoard();
        }

        //----------------------------------------------Initialize Pieces--------------------------------------------------------
        private void initializeBoard()
        {
            //make space in list
            for (int i = 0; i < 8; i++)
            {
                List<aPiece> row = new List<aPiece>(8);
                for (int j = 0; j < 8; j++) row.Add(null); 
                this.chessBoard.Add(row);
            }
            //add pieces on board
            addPawns();
            addBlackPieces();
            addWhitePieces();
        }
        private void addPawns()
        {
            List<aPiece> blackPawns = new List<aPiece>(8);
            List<aPiece> whitePawns = new List<aPiece>(8);
            for (int i = 0; i < 8; i++)
            {
                aPiece blackPawn = new Pawn(Color.BLACK, new Location(1, i));
                blackPawns.Add(blackPawn);
                aPiece whitePawn = new Pawn(Color.WHITE, new Location(6, i));
                whitePawns.Add(whitePawn);
            };
            this.chessBoard[1] = blackPawns;
            this.chessBoard[6] = whitePawns;
        }
        private void addBlackPieces()
        {
            List<aPiece> blackPieces = new List<aPiece>(8);
            aPiece bRook = new Rook(Color.BLACK, new Location(0, 0));       blackPieces.Add(bRook);
            aPiece bKnight = new Knight(Color.BLACK, new Location(0, 1));   blackPieces.Add(bKnight);
            aPiece bBishop = new Bishop(Color.BLACK, new Location(0, 2));   blackPieces.Add(bBishop);
            aPiece bQueen = new Queen(Color.BLACK, new Location(0, 3));     blackPieces.Add(bQueen);
            aPiece bKing = new King(Color.BLACK, new Location(0, 4));       blackPieces.Add(bKing);
            aPiece bBishop2 = new Bishop(Color.BLACK, new Location(0, 5));  blackPieces.Add(bBishop2);
            aPiece bKnight2 = new Knight(Color.BLACK, new Location(0, 6));  blackPieces.Add(bKnight2);
            aPiece bRook2 = new Rook(Color.BLACK, new Location(0, 7));      blackPieces.Add(bRook2);
            this.chessBoard[0] = blackPieces;
        }

        private void addWhitePieces()
        {
            List<aPiece> whitePieces = new List<aPiece>(8);
            aPiece wRook = new Rook(Color.WHITE, new Location(7, 0));       whitePieces.Add(wRook);
            aPiece wKnight = new Knight(Color.WHITE, new Location(7, 1));   whitePieces.Add(wKnight);
            aPiece wBishop = new Bishop(Color.WHITE, new Location(7, 2));   whitePieces.Add(wBishop);
            aPiece wQueen = new Queen(Color.WHITE, new Location(7, 3));     whitePieces.Add(wQueen);
            aPiece wKing = new King(Color.WHITE, new Location(7, 4));       whitePieces.Add(wKing);
            aPiece wBishop2 = new Bishop(Color.WHITE, new Location(7, 5));  whitePieces.Add(wBishop2);
            aPiece wKnight2 = new Knight(Color.WHITE, new Location(7, 6));  whitePieces.Add(wKnight2);
            aPiece wRook2 = new Rook(Color.WHITE, new Location(7, 7));      whitePieces.Add(wRook2);
            this.chessBoard[7] = whitePieces;
        }
    };
};