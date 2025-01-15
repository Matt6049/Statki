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

    


        public int[][] board;
        public Board()
        {
            board = new int[10][];
            
            for (int i = 0; i < 10; i++)
            {

                board[i] = new int[10];
            }

            InitializeBoard(board);
        }




        private void InitializeBoard(int[][] tab)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                   tab[i][j] = (int)TILE_TYPE.EMPTY; 
                }
            }
        }


        public void DisplayBoard(int[][] tab)
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





        public void FogOfWar(int[][] tab)
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

        

    
    
      
    




}



}

