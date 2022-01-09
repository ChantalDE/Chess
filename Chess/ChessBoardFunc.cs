using System;
using System.Collections.Generic;

namespace Chess
{

    //NOTE: be able to unselect the piece, to pick another one
    public partial class Chessboard
    {
        public void movePiece(Location l, Location r) {
            aPiece piece = chessBoard[l.Row][l.Column]; //retrievd piece from place
            chessBoard[l.Row][l.Column] = null; //set spot empty
            chessBoard[r.Row][r.Column] = piece; //move to new spot
            piece.position = r; //set Location
        }

        //checks if it hits an opponents piece
        private bool isOtherPawn(aPiece selected, Location move)
        {
            aPiece moveTo = chessBoard[move.Row][move.Column];
            if (moveTo != null)
            {
                if (moveTo.color == selected.color)
                {
                    Console.WriteLine("Your piece is already there");
                    return false; //if spot moved to is other color == hit
                }
                else if (moveTo.color != selected.color) return true;
            }
            return true;
        }

        //verifies if move is valid
        public bool isValidMove(aPiece selected, Location move) {
            List<List<Location>> pieceBehavior = selected.moveBehavior();
            
            if (!isOtherPawn(selected, move)) return false; //return false if end destination is your own pawn
            if(selected is Pawn)
            {
                if (isValidPawnHit(selected, move)) return true; //check if pawn is diagonal from the board
            }
            for (int i = 0; i < pieceBehavior.Count; i++) //iterate through the paths
            {
                for (int j = 0; j < pieceBehavior[i].Count; j++) //iterate through the path
                { 
                    if (move.Row == pieceBehavior[i][j].Row && move.Column == pieceBehavior[i][j].Column) //if is in list  !!??!
                    {
                        for (int k = 0; move.Row != pieceBehavior[i][k].Row || move.Column != pieceBehavior[i][k].Column; k++) //check if pawns are in the way in the paths
                        {
                            aPiece spotOnPath = chessBoard[pieceBehavior[i][k].Row][pieceBehavior[i][k].Column];
                            if (spotOnPath != null)
                            {

                                if (spotOnPath.position.Row == selected.position.Row && spotOnPath.position.Column == selected.position.Column && spotOnPath.color == selected.color) continue; //skip own pawn
                                Console.WriteLine("Unvalid move. Piece is in the way."); return false;
                            }
                        }
                        return true;
                    }
                }
            }
            Console.WriteLine("Unvalid move"); return false;
        }

        public bool isValidPawnHit(aPiece selected, Location move)
        {
            //NOTE: include en passant later

            int row;
            int column;

            if (isOtherPawn(selected, move))
            {
                //white
                if (selected.color == Color.WHITE)
                {
                    row = selected.position.Row - 1;
                    column = selected.position.Column - 1;
                    if (row == move.Row && column == move.Column) return true;
                    column = selected.position.Column + 1;
                    if (row == move.Row && column == move.Column) return true; //[-1, +1]
                }

                if (selected.color == Color.BLACK)
                {
                    row = selected.position.Row + 1;
                    column = selected.position.Column + 1;
                    if (row == move.Row && column == move.Column) return true; //[+1, +1]
                    column = selected.position.Column - 1;
                    if (row == move.Row && column == move.Column) return true; //[+1, -1]
                }
            }
            return false;
        }

        //called after every move to check if there is a winner
        public bool isCheckMate() { return false; }
    }
}
