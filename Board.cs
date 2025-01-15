using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_programowanie4
{
    internal class Board
    {

    


        public int[][] board;
        public Board()
        {
            board = new int[10][];
            InitializeBoard(board);
            for (int i = 0; i < 10; i++)
            {

                board[i] = new int[10];
            }
        }




        private void InitializeBoard(int[][] tab)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                   tab[i][j] = 0; 
                }
            }
        }


        public void DisplayBoard(int[][] tab)
        {
            Console.WriteLine("  A B C D E F G H I J");
            for (int i = 0; i < 10; i++)
            {
                Console.Write((i + 1) + " "); 
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(tab[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        //funkcja strzelania daje false albo true
        public bool PlaceShip(int[][] tab, int row , char column)
        {
            int colIndex = column - 'A';
            int rowIndex = row - 1;


            if (tab[rowIndex][colIndex] == 0)
            {
                tab[rowIndex][colIndex] = 2;
                return true;
            }
            else
            {
                Console.WriteLine("To pole jest już zajęte!");
                return false;
            }
        }


        public void FogOfWar(int[][] tab)
        {

            Console.WriteLine("  A B C D E F G H I J");
            for (int i = 0; i < 10; i++)
            {
                Console.Write((i + 1) + " ");
                for (int j = 0; j < 10; j++)
                {
                    if (tab[i][j] == 0 || tab[i][j] == 2)
                    {
                        Console.Write(tab[i][j] + "? ");
                    }
                    else
                    {
                        Console.Write(tab[i][j] + " ");
                    }
                }
                Console.WriteLine();
            }

        }

        

        // Metoda do oddania strzału w określone pole
        public bool Shoot(int[][] tab, int row, char column )
        {
            int colIndex = column - 'A'; // Zamiana litery na indeks kolumny
            int rowIndex = row - 1; // Zamiana numeru wiersza na indeks w tablicy

            // Sprawdzanie, czy trafiono w statek
            if (tab[rowIndex][colIndex] == 2)
            {
                tab[rowIndex][colIndex] = 3; // "X" oznacza trafiony statek
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



}

