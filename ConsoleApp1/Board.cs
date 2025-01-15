using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Statki;
using static Statki.Gameplay;

namespace lab_programowanie4
{
    internal class Board
    {
        public static int[][] board; 

         Board() 
        {
            board = new int[10][];
            for (int i = 0; i < 10; i++)
            {
                board[i] = new int[10];
            }
            InitializeBoard(board);
        }

        
        public static void InitializeBoard(int[][] tab)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tab[i][j] = (int)TILE_TYPE.EMPTY;
                }
            }
        }

       
        public static void DisplayBoard(int[][] tab)
        {
            Console.WriteLine("   A B C D E F G H I J");
            for (int i = 0; i < 10; i++)
            {
                Console.Write((i + 1).ToString().PadLeft(2) + " ");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(tab[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        
        public static void FogOfWar(int[][] tab)
        {
            Console.WriteLine("  A B C D E F G H I J");
            for (int i = 0; i < 10; i++)
            {
                Console.Write((i + 1) + " ");
                for (int j = 0; j < 10; j++)
                {
                    if (tab[i][j] == (int)TILE_TYPE.EMPTY || tab[i][j] == (int)TILE_TYPE.SHIP)
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

    
        public static (int row, int col) GetPlayerCoordinates()
        {
            int row = 0;
            char col = '\0';

            while (true)
            {
                Console.WriteLine("Wybierz wiersz (1-10) oraz kolumnę (A-J) w formacie np. A5:");

                
                string input = Console.ReadLine()?.ToUpper();

               
                if (!string.IsNullOrEmpty(input) && input.Length == 2)
                {
                 
                    col = input[0]; 
                    string rowInput = input[1].ToString(); 

                 
                    if (col >= 'A' && col <= 'J')
                    {
                        
                        if (int.TryParse(rowInput, out row) && row >= 1 && row <= 10)
                        {
                            row--; 
                            break; 
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy wiersz. Spróbuj ponownie.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowa kolumna. Spróbuj ponownie.");
                    }
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy format. Podaj dane w formacie np. A5.");
                }
            }

           
            int colIndex = col - 'A'; 

            return (row, colIndex);
        }

    }
}
