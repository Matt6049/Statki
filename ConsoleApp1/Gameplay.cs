using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Statki {
    public enum TILE_TYPE {
        EMPTY = 0,
        EMPTY_SHOT = 1,
        SHIP = 2,
        SHIP_SHOT = 3
    }
    internal class Gameplay {
        int[][] playerMap;
        int[][] enemyMap;
        static int SHIP_AMOUNT = 8;


        public Gameplay(int[][] playerMap) {
            this.playerMap = playerMap;
            enemyMap = new int[10][];

            int ships = Gameplay.SHIP_AMOUNT;

            for (int i = 0; i < playerMap.Length; i++) {
                enemyMap[i] = new int[10];
                for (int j = 0; j < playerMap[i].Length; j++) {
                    enemyMap[i][j] = 0;
                }
            }

            Random rand = new Random();
            int row;
            int col;
            while (ships > 0) {
                row = rand.Next(0, 9);
                col = rand.Next(0, 9);
                if(PlaceShip(enemyMap, row, col)) {
                    ships--;
                }
            }
        }

        public bool CheckWin(int[][] map) {
            foreach (int[] arr in map) {
                foreach(int tile in arr) {
                    if (tile == 2) return false;
                }
            }
            return true;
        }

        public void ShootPlayer() {
            Random rand = new Random();
            int row = rand.Next(0, 9);
            int col = rand.Next(0, 9);
            while(!ShootTile(this.playerMap, row, col)) {
                row = rand.Next(0, 9);
                col = rand.Next(0, 9);
            }
        }

        //Zwraca true jeżeli można strzelić, zwraca false jeżeli nie można
        public bool ShootTile(int[][] map, int row, int col) {
            int tile = map[row][col];
            if (tile == (int)TILE_TYPE.EMPTY) {
                map[row][col] = (int)TILE_TYPE.EMPTY_SHOT;
            }
            else if (tile == (int)TILE_TYPE.SHIP) {
                map[row][col] = (int)TILE_TYPE.SHIP_SHOT;
            }
            else { return false; }
            return true;
        }

        public bool PlaceShip(int[][] map, int row, int col) {
            int tile = map[row][col];
            if (tile == (int)TILE_TYPE.SHIP) return false;
            map[row][col] = (int)TILE_TYPE.SHIP;
            return true;
        }
    }
}
