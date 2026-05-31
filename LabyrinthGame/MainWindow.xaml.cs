using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace LabyrinthGame
{
    public partial class MainWindow : Window
    {
        private Map labyrinthMap;
        private Tile hoveredTile;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

            this.KeyDown += MainWindow_KeyDown;
            this.Focusable = true;

        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            labyrinthMap = new Map(
                (int)sliRows.Value,
                (int)sliColumns.Value,
                (int)ActualHeight
            );
            BuildGrid();
        }
        private void BuildGrid()
        {
            UgridMap.Children.Clear();

            UgridMap.Rows = labyrinthMap.rows;
            UgridMap.Columns = labyrinthMap.columns;

            for (int x = 0; x < labyrinthMap.rows; x++)
            {
                for (int y = 0; y < labyrinthMap.columns; y++)
                {
                    var tile = labyrinthMap.Tiles[x, y];

                    var img = new Image
                    {
                        Source = new BitmapImage(labyrinthMap.TileImages[tile.type]),
                        Stretch = Stretch.Fill
                    };

                    RenderOptions.SetBitmapScalingMode(img, BitmapScalingMode.NearestNeighbor);

                    var border = new Border
                    {
                        BorderThickness = new Thickness(0.5),
                        BorderBrush = Brushes.White,
                        Child = img,
                        Tag = tile
                    };

                    border.MouseEnter += (s, e) =>
                    {
                        hoveredTile = (Tile)((Border)s).Tag;
                    };

                    border.MouseLeave += (s, e) =>
                    {
                        if (hoveredTile == (Tile)((Border)s).Tag)
                            hoveredTile = null;
                    };

                    UgridMap.Children.Add(border);
                }
            }
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (hoveredTile == null)
                return;

            switch (e.Key)
            {
                case Key.W:
                case Key.Up:
                    if (hoveredTile.type.Contains("T")) hoveredTile.type = hoveredTile.type.Remove(hoveredTile.type.IndexOf("T"), 1);
                    else hoveredTile.type += "T";
                    hoveredTile.type = new string(hoveredTile.type.OrderBy(c => c).ToArray());
                    break;

                case Key.A:
                case Key.Left:
                    if (hoveredTile.type.Contains("L")) hoveredTile.type = hoveredTile.type.Remove(hoveredTile.type.IndexOf("L"), 1);
                    else hoveredTile.type += "L";
                    hoveredTile.type = new string(hoveredTile.type.OrderBy(c => c).ToArray());
                    break;

                case Key.S:
                case Key.Down:
                    if (hoveredTile.type.Contains("B")) hoveredTile.type = hoveredTile.type.Remove(hoveredTile.type.IndexOf("B"), 1);
                    else hoveredTile.type += "B";
                    hoveredTile.type = new string(hoveredTile.type.OrderBy(c => c).ToArray());
                    break;

                case Key.D:
                case Key.Right:
                    if (hoveredTile.type.Contains("R")) hoveredTile.type = hoveredTile.type.Remove(hoveredTile.type.IndexOf("R"), 1);
                    else hoveredTile.type += "R";
                    hoveredTile.type = new string(hoveredTile.type.OrderBy(c => c).ToArray());
                    break;
                case Key.Space:
                    hoveredTile.type = "0";
                    break;
            }
            UpdateTileVisual(hoveredTile);
        }
        private void UpdateTileVisual(Tile tile)
        {
            foreach (Border border in UgridMap.Children)
            {
                if ((Tile)border.Tag == tile)
                {
                    var img = new Image
                    {
                        Source = new BitmapImage(labyrinthMap.TileImages[tile.type]),
                        Stretch = Stretch.Fill
                    };

                    RenderOptions.SetBitmapScalingMode(img, BitmapScalingMode.NearestNeighbor);

                    border.Child = img;
                    break;
                }
            }
        }
        private void sliChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (labyrinthMap == null || UgridMap == null)
                return;

            labyrinthMap.SizeChanged(
                (int)sliRows.Value,
                (int)sliColumns.Value
            );
            BuildGrid();

        }
        private void LockButton_Click(object sender, RoutedEventArgs e)
        {
            sliRows.IsEnabled = !sliRows.IsEnabled;
            sliColumns.IsEnabled = !sliColumns.IsEnabled;
            if (btnLanguageToggle.Content.ToString() == "Nyelv")
            {
                btnLock.Content = sliColumns.IsEnabled ? "meret zarolas" : "meret feloldas";
            }
            else
            {
                btnLock.Content = sliColumns.IsEnabled ? "Lock" : "Unlock";
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Text file (*.txt)|*.txt",
                FileName = $"{txtLbName.Text}"
            };

            if (dialog.ShowDialog() != true)
                return;

            var sb = new StringBuilder();

            for (int x = 0; x < labyrinthMap.Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < labyrinthMap.Tiles.GetLength(1); y++)
                {
                    sb.Append(Map.GetCharFromType(labyrinthMap.Tiles[x, y].type));
                }

                sb.AppendLine();
            }

            File.WriteAllText(dialog.FileName, sb.ToString(), Encoding.UTF8);
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Text file (*.txt)|*.txt"
            };

            if (dialog.ShowDialog() != true)
                return;

            var lines = File.ReadAllLines(dialog.FileName);

            int rows = lines.Length;
            int columns = lines[0].Length;
            sliRows.Value = rows;
            sliColumns.Value = columns;

            labyrinthMap = new Map(rows, columns, (int)ActualHeight);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    labyrinthMap.Tiles[row, col] = new Tile(row, col);
                    labyrinthMap.Tiles[row, col].type = Map.GetTypeFromChar(lines[row][col]);
                }
            }

            BuildGrid();
        }

        private void btlLanguage_Click(object sender, RoutedEventArgs e)
        {
            if (btnLanguageToggle.Content.ToString() == "Language")
            {
                btnLanguageToggle.Content = "Nyelv";
                lblRows.Content = "Sorok";
                lblCols.Content = "Oszlopok";
                btnLock.Content = sliColumns.IsEnabled ? "meret zarolas" : "meret Feloldas";
                btnExport.Content = "letoltes";
                btnImport.Content = "betoltes";
                lblName.Content = "labirintus neve";
            }
            else
            {
                btnLanguageToggle.Content = "Language";
                lblRows.Content = "Rows";
                lblCols.Content = "Columns";
                btnLock.Content = sliColumns.IsEnabled ? "Lock" : "Unlock";
                btnExport.Content = "Export";
                btnImport.Content = "Import";
                lblName.Content = "Labyrinth Name";
            }
        }
    }
}