using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_programowanie4
{
    internal class Board
    {

    


        private int[][] board;
        public Board()
        {
            board = new int[10][];
            InitializeBoard();
            for (int i = 0; i < 10; i++)
            {

                board[i] = new int[10];
            }
        }


        private void InitializeBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i][j] = 0; 
                }
            }
        }


        public void DisplayBoard()
        {
            Console.WriteLine("  A B C D E F G H I J");
            for (int i = 0; i < 10; i++)
            {
                Console.Write((i + 1) + " "); 
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(board[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        //funkcja strzelania daje false albo true
        public bool PlaceShip(char column, int row )
        {
            int colIndex = column - 'A';
            int rowIndex = row - 1;


            if (board[rowIndex][colIndex] == 0)
            {
                board[rowIndex][colIndex] = 2;
                return true;
            }
            else
            {
                Console.WriteLine("To pole jest już zajęte!");
                return false;
            }
        }

        // 1 nietrafiony 2 trafiony 3 nowy zesrzelony
        // 24

        // Metoda do oddania strzału w określone pole
        public bool Shoot(char column, int row)
        {
            int colIndex = column - 'A'; // Zamiana litery na indeks kolumny
            int rowIndex = row - 1; // Zamiana numeru wiersza na indeks w tablicy

            // Sprawdzanie, czy trafiono w statek
            if (board[rowIndex][colIndex] == 2)
            {
                board[rowIndex][colIndex] = 3; // "X" oznacza trafiony statek
                Console.WriteLine("Trafiono!");
                return true;
            }
            else
            {
                board[rowIndex][ colIndex] = 1; 
                Console.WriteLine("Pudło!");
                return false;
            }
        }
    
        // 0 puste 1 //empty shoot  //2 statek //3 new hit
    




}



    class Test
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.DisplayBoard();


            board.PlaceShip('A', 1);
            board.PlaceShip('B', 2);


            board.Shoot('A', 1);
            board.Shoot('C', 3);

            board.DisplayBoard();
        }
    }
}

