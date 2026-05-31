using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthGame
{
    internal class Map
    {
        public int rows;
        public int columns;
        public int map_height;
        public Tile[,] Tiles;
        private List<Uri> Images { get; }
        public Dictionary<string, Uri> TileImages { get; }

        public Map(int rows, int columns, int map_height)
        {
            this.rows = rows;
            this.columns = columns;
            this.map_height = map_height;

            Tiles = new Tile[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Tiles[i, j] = new Tile(i, j);
                }
            }

            string imageFolder = System.IO.Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Images");

            Images = Directory.Exists(imageFolder)
                ? Directory.GetFiles(imageFolder)
                    .Where(f =>
                        f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                        f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                    .Select(f => new Uri(f, UriKind.Absolute))
                    .ToList()
                : new List<Uri>();


            TileImages = new Dictionary<string, Uri>();

            TileImages["0"]     = new Uri(Path.Combine(imageFolder, "0.png"),  UriKind.Absolute);
            TileImages["0LR"]   = new Uri(Path.Combine(imageFolder, "1.png"),  UriKind.Absolute);
            TileImages["0BT"]   = new Uri(Path.Combine(imageFolder, "2.png"),  UriKind.Absolute);
            TileImages["0BLRT"] = new Uri(Path.Combine(imageFolder, "3.png"),  UriKind.Absolute);
            TileImages["0RT"]   = new Uri(Path.Combine(imageFolder, "4.png"),  UriKind.Absolute);
            TileImages["0BR"]   = new Uri(Path.Combine(imageFolder, "5.png"),  UriKind.Absolute);
            TileImages["0BL"]   = new Uri(Path.Combine(imageFolder, "6.png"),  UriKind.Absolute);
            TileImages["0LT"]   = new Uri(Path.Combine(imageFolder, "7.png"),  UriKind.Absolute);
            TileImages["0LRT"]  = new Uri(Path.Combine(imageFolder, "8.png"),  UriKind.Absolute);
            TileImages["0BRT"]  = new Uri(Path.Combine(imageFolder, "9.png"),  UriKind.Absolute);
            TileImages["0BLR"]  = new Uri(Path.Combine(imageFolder, "10.png"), UriKind.Absolute);
            TileImages["0BLT"]  = new Uri(Path.Combine(imageFolder, "11.png"), UriKind.Absolute);
            TileImages["0T"]    = new Uri(Path.Combine(imageFolder, "12.png"), UriKind.Absolute);
            TileImages["0R"]    = new Uri(Path.Combine(imageFolder, "13.png"), UriKind.Absolute);
            TileImages["0B"]    = new Uri(Path.Combine(imageFolder, "14.png"), UriKind.Absolute);
            TileImages["0L"]    = new Uri(Path.Combine(imageFolder, "15.png"), UriKind.Absolute);

        }

        public void SizeChanged(int new_rows, int new_columns)
        {
            Tile[,] newTiles = new Tile[new_rows, new_columns];
            for (int i = 0; i < new_rows; i++)
            {
                for (int j = 0; j < new_columns; j++)
                {
                    if (i < rows && j < columns)
                    {
                        newTiles[i, j] = Tiles[i, j];
                    }
                    else
                    {
                        newTiles[i, j] = new Tile(i, j);
                    }
                }
            }
            Tiles = newTiles;
            rows = new_rows;
            columns = new_columns;
        }
        public static char GetCharFromType(string type)
        {
            return type switch
            {
                "0" => '.',
                "0LR"=> '═',
                "0BT"=> '║',
                "0BLRT" => '╬',
                "0RT" => '╚',
                "0BR" => '╔',
                "0BL" =>'╗',
                "0LT"=>'╝',
                "0LRT"=>'╩',
                "0BRT"=>'╠',
                "0BLR" =>'╦',
                "0BLT"=> '╣',
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
    }

}
