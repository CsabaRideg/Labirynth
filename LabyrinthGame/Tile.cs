using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LabyrinthGame
{
    internal class Tile
    {
        public string type = "0";
        public int row;
        public int column;

        public Tile( int x, int y)
        {
            this.row = x;
            this.column = y;
        }
        public static char GetCharFromType(string type)
        {
            return type switch
            {
                "0" => '.',
                "0LR" => '═',
                "0BT" => '║',
                "0BLRT" => '╬',
                "0RT" => '╚',
                "0BR" => '╔',
                "0BL" => '╗',
                "0LT" => '╝',
                "0LRT" => '╩',
                "0BRT" => '╠',
                "0BLR" => '╦',
                "0BLT" => '╣',
                "0T" => '█',
                "0R" => '█',
                "0B" => '█',
                "0L" => '█'
            };
        }
        public static string GetTypeFromChar(char c)
        {
            return c switch
            {
                '.' => "0",
                '═' => "0LR",
                '║' => "0BT",
                '╬' => "0BLRT",
                '╚' => "0RT",
                '╔' => "0BR",
                '╗' => "0BL",
                '╝' => "0LT",
                '╩' => "0LRT",
                '╠' => "0BRT",
                '╦' => "0BLR",
                '╣' => "0BLT",
                '█' => "0T"
            };
        }
        public bool isEntrance(int lastrow, int lastcolumn)
        {
            bool isBorder =
                    row == 0 || column == 0 ||
                    row == lastcolumn ||
                    column == lastrow;

            if (!isBorder || type == "0" || isRoom()) return false;                                     //Empty or not border or room

            return ((column, row, type) switch
            {                                                                
                (0, 0, "0LT") => false,                                                                 //TopLeft
                (0, var row, "0BL") when row == lastrow => false,                                       //BottomLeft
                (var col, 0, "0RT") when col == lastcolumn => false,                                    //TopRight
                (var col, var row, "0BR") when row == lastrow && col == lastcolumn => false,            //BottomRight

                (0, _, var type) when type.Contains("L") => true,                                       //Left
                (var col,_, var type) when type.Contains("R") && col == lastcolumn => true,             //Right
                (_, 0, var type) when type.Contains("T") => true,                                       //Top
                (_, var row, var type) when type.Contains("B") && row == lastrow => true,               //Bottom
                _ => false
            });
        }
        public bool isRoom()
        {
            return type == "0T" || type == "0R" || type == "0B" || type == "0L";
        }
        public bool CanMoveTo(char Direction, Tile[,] Tiles) 
        {

            return false;
        }
        public Tile TileToDirection(char Direction, Tile[,] Tiles)
        {
            return null;
        }
    }
}
