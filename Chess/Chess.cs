using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Chess
    {
        public Chess(){}

        public Color bPlayer = Color.BLACK;
        public Color wPlayer = Color.WHITE;

        private Location selectPiece()
        {
            Console.WriteLine("Select a piece to move: ");
            Console.WriteLine("type row: ");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("type column: ");
            int column = Convert.ToInt32(Console.ReadLine());
            return new Location(row, column);
        }
        private Location moveTo()
        {
            Console.WriteLine("Select spot to move to: ");
            Console.WriteLine("To row: ");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("To column: ");
            int column = Convert.ToInt32(Console.ReadLine());
            return new Location(row, column);
        }

        private bool isValidPiece(aPiece selected, Color turn)
        {
            if (selected == null)
            {
                Console.WriteLine("There is no piece on this board");
                return false;
            }
            if (selected.color != turn)
            {
                Console.WriteLine("You selected wrong color");
                return false;
            }
            else return true;
        }

        private aPiece pickPiece(Chessboard board, Color turn)
        {
            aPiece selected;
            do
            {
                Location pieceLocation = selectPiece();
                selected = board.chessBoard[pieceLocation.Row][pieceLocation.Column];
            } while (!isValidPiece(selected, turn)); //validate the piece turn
            return selected;
        }

        private bool pickAnother()
        { 
            Console.WriteLine("Would you like to pick another piece?");
            Console.WriteLine("0: no");
            Console.WriteLine("1: yes");
            int userAnswer = Convert.ToInt32(Console.ReadLine());
            if (userAnswer == 0) return false;
            if (userAnswer == 1) return true;
            else {
                Console.WriteLine("Invalid Input");
                return false;
                }
         }

            public void play()
        {
            Chessboard board = new Chessboard();
            printBoard(board);
            aPiece selected;
            Location move;
            Color turn = wPlayer; //white goes first

            selected = pickPiece(board, turn);  //access current piece

            do     //move to
            {
                if (pickAnother()) selected = pickPiece(board, turn);
                move = moveTo(); 
            }
            while (!board.isValidMove(selected, move)); //validate move
            board.movePiece(selected.position, move); //call function to move piece

            printBoard(board); //helper function

            //keep playing till someone wins
            while (!board.isCheckMate())
            {
                if (turn == wPlayer) turn = bPlayer;
                else turn = wPlayer;

                //access current piece
                selected = pickPiece(board, turn);

                //move to
                do { move = moveTo(); }
                while (!board.isValidMove(selected, move)); //validate move
                board.movePiece(selected.position, move); //call function to move piece

                printBoard(board); //helper function
            }
        }

        public void printBoard(Chessboard board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board.chessBoard[i][j] == null) Console.Write("--\t");
                    else Console.Write(board.chessBoard[i][j].GetType() + "  ");
                }
                Console.WriteLine('\n');
            }
        }
    }
}
