using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Labirynth
{
    public partial class MainWindow : Window
    {
        bool palyaBetoltve = false;
        bool finished = false;
        bool terembeVolt = false;
        int jatekosPosX = -1;
        int jatekosPosY = -1;

        int termekSzama = 0;
        HashSet<(int, int)> latogatottTermek = new HashSet<(int, int)>();

        string aktualisNyelv = "hu";
        Dictionary<string, Dictionary<string, string>> nyelvek;

        DispatcherTimer visszaszamlalo;
        TimeSpan hatralevoIdo;

        string[] pillPalya;

        public MainWindow()
        {
            InitializeComponent();
            //Loaded += Window_Loaded;
            KeyDown += MainWindow_KeyDown;

            Nyelvek_Betoltese();
            Felulet_Frissitese();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (palyaBetoltve)
            {
                Palya_Rajzolasa();
            }
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //MessageBox.Show($"W: {cnvPalya.ActualWidth}, H: {cnvPalya.ActualHeight}");
        //    //Palya();
        //}

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (finished)
            {
                return;
            }

            if (!palyaBetoltve)
            {
                return;
            }

            int ujX = jatekosPosX;
            int ujY = jatekosPosY;
            switch (e.Key)
            {
                case Key.W:

                    ujY--;
                    break;

                case Key.S:

                    ujY++;
                    break;
                case Key.A:


                    ujX--;
                    break;
                case Key.D:

                    ujX++;
                    break;


                default:
                    return;
            }

            switch (pillPalya[jatekosPosY][jatekosPosX])
            {
                case '╬':

                    break;
                case '═':

                    ujY = jatekosPosY;
                    break;

                case '╦':
                    if (e.Key == Key.W)
                    {
                        ujY = jatekosPosY;
                    }
                    break;
                case '╩':
                    if (e.Key == Key.S)
                    {
                        ujY = jatekosPosY;
                    }
                    break;
                case '║':
                    if (e.Key == Key.A || e.Key == Key.D)
                    {
                        ujX = jatekosPosX;
                    }
                    break;
                case '╣':

                    if (e.Key == Key.D)
                    {
                        ujX = jatekosPosX;
                    }
                    break;
                case '╠':

                    if (e.Key == Key.A)
                    {
                        ujX = jatekosPosX;
                    }
                    break;
                case '╗':

                    if (e.Key == Key.W || e.Key == Key.D)
                    {
                        ujY = jatekosPosY;
                        ujX = jatekosPosX;
                    }
                    break;
                case '╝':

                    if (e.Key == Key.S || e.Key == Key.D)
                    {
                        ujY = jatekosPosY;
                        ujX = jatekosPosX;
                    }
                    break;
                case '╚':

                    if (e.Key == Key.S || e.Key == Key.A)
                    {
                        ujY = jatekosPosY;
                        ujX = jatekosPosX;
                    }
                    break;
                case '╔':

                    if (e.Key == Key.W || e.Key == Key.A)
                    {
                        ujY = jatekosPosY;
                        ujX = jatekosPosX;
                    }
                    break;

                case '█':

                    break;

                default:
                    return;

            }


            if (ujX >= 0 && ujX < pillPalya[0].Length && ujY >= 0 && ujY < pillPalya.Length && pillPalya[ujY][ujX] != '.')
            {


                jatekosPosX = ujX;
                jatekosPosY = ujY;

                if (pillPalya[jatekosPosY][jatekosPosX] == '█')
                {
                    latogatottTermek.Add((jatekosPosY, jatekosPosX));
                }


                if (termekSzama > 0 && latogatottTermek.Count >= termekSzama)
                {
                    terembeVolt = true;
                }


                Palya_Rajzolasa();
                Jatek_Vege();

            }
        }

        //string[] palyaEszkozok = { "╬", "═", "╦", "╩", "║", "╣", "╠", "╗", "╝", "╚", "╔", ".", "█" };
        private void Lehetosegek_Frissitese()
        {
            if (!palyaBetoltve) return;

            char c = pillPalya[jatekosPosY][jatekosPosX];

            var iranyok = new Dictionary<char, string[]>
            {
                { '╬', new[] { T("Up"), T("Down"), T("Left"), T("Right") } },
                { '═', new[] { T("Left"), T("Right") } },
                { '║', new[] { T("Up"), T("Down") } },
                { '╦', new[] { T("Down"), T("Left"), T("Right") } },
                { '╩', new[] { T("Up"), T("Left"), T("Right") } },
                { '╣', new[] { T("Up"), T("Down"), T("Left") } },
                { '╠', new[] { T("Up"), T("Down"), T("Right") } },
                { '╗', new[] { T("Down"), T("Left") } },
                { '╝', new[] { T("Up"), T("Left") } },
                { '╚', new[] { T("Up"), T("Right") } },
                { '╔', new[] { T("Down"), T("Right") } },
                { '█', new[] { T("RoomState") } },
            };

            bool felSzabad = jatekosPosY > 0 && pillPalya[jatekosPosY - 1][jatekosPosX] != '.';
            bool leSzabad = jatekosPosY < pillPalya.Length - 1 && pillPalya[jatekosPosY + 1][jatekosPosX] != '.';
            bool balraSzabad = jatekosPosX > 0 && pillPalya[jatekosPosY][jatekosPosX - 1] != '.';
            bool jobbraSzabad = jatekosPosX < pillPalya[jatekosPosY].Length - 1 && pillPalya[jatekosPosY][jatekosPosX + 1] != '.';

            var elerhetoIranyok = new Dictionary<string, bool>
                    {
                        { T("Up"),    felSzabad },
                        { T("Down"),     leSzabad },
                        { T("Left"),  balraSzabad },
                        { T("Right"), jobbraSzabad },
                    };

            if (c == '█')
            {
                lblLehetosegek.Content = T("RoomState");
                return;
            }

            if (!iranyok.TryGetValue(c, out string[] lehetsegesek))
            {
                lblLehetosegek.Content = "";
                return;
            }

            var eredmeny = lehetsegesek.Where(i => elerhetoIranyok.ContainsKey(i) && elerhetoIranyok[i]);

            lblLehetosegek.Content = T("Options") + string.Join(", ", eredmeny);
        }

        public void Palya(string palyaNev)
        {

            cnvPalya.Children.Clear();

            pillPalya = File.ReadAllLines(palyaNev, Encoding.UTF8);

            termekSzama = 0;
            latogatottTermek.Clear();
            terembeVolt = false;

            bool allasBetoltese = false;

            var mentettTermek = pillPalya.Where(s => s.StartsWith("R")).Select(s => {var reszek = s.Substring(1).Split(':');
                return (int.Parse(reszek[0]), int.Parse(reszek[1]));
            })
            .ToHashSet();

            for (int j = 0; j < pillPalya.Length; j++)
            {
                for (global::System.Int32 i = 0; i < pillPalya[j].Length; i++)
                {
                    if (pillPalya[j][i] == 'P')
                    {
                        jatekosPosX = i;
                        jatekosPosY = j;
                        char eredeti = pillPalya[j][i + 1]; 
                        pillPalya[j] = pillPalya[j].Remove(i, 2).Insert(i, eredeti.ToString());
                        allasBetoltese = true;
                        break;
                    }

                    if (pillPalya[j][i] == '█')
                    {
                        termekSzama++;
                    }
                }
            }

            pillPalya = pillPalya.Where(s => s != "V" && !s.StartsWith("T") && !s.StartsWith("R")).ToArray();

            if (!allasBetoltese)
            {
                Jatekos_Kezdes();
            }

            foreach (var pos in mentettTermek)
            {
                latogatottTermek.Add(pos);
            }

            if (latogatottTermek.Count >= termekSzama && termekSzama > 0)
            {
                terembeVolt = true;
            }


            if (termekSzama > 0)
            {
                if (latogatottTermek.Count >= termekSzama || terembeVolt)
                    txtMission.Text = T("MissionFindExit");
                else
                    txtMission.Text = string.Format(T("MissionFindRooms"), latogatottTermek.Count, termekSzama);
            }
            else
            {
                txtMission.Text = T("MissionExitOnly");
            }

            string idoSor = File.ReadAllLines(palyaNev, Encoding.UTF8).FirstOrDefault(s => s.StartsWith("T"));

            if (idoSor != null)
            {
                int mentettMasodperc = int.Parse(idoSor.Substring(1));
                hatralevoIdo = TimeSpan.FromSeconds(mentettMasodperc);
            }


            int oszlopokSzama = pillPalya[0].Length;
            int sorokSzama = pillPalya.Length;
            int kockaHosszusag = (int)(cnvPalya.ActualWidth / oszlopokSzama);
            int kockaMagassag = (int)(cnvPalya.ActualHeight / sorokSzama);


            for (global::System.Int32 j = 0; j < sorokSzama; j++)
            {
                for (global::System.Int32 i = 0; i < pillPalya[j].Length; i++)
                {
                    Border cella = new Border
                    {
                        Width = kockaHosszusag,
                        Height = kockaMagassag,
                        BorderBrush = Brushes.Transparent
                    };

                    TextBlock tb = new TextBlock
                    {
                        Text = pillPalya[j][i].ToString(),
                        FontFamily = new FontFamily("Consolas"),
                        FontSize = Math.Min(kockaHosszusag, kockaMagassag) * 6,
                        TextAlignment = TextAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                       
                    };

                    if (pillPalya[j][i] == '.')
                    {
                        tb.Text = "";
                    }



                    if (j == jatekosPosY && i == jatekosPosX)
                    {

                        cella.Background = Brushes.Green;
                    }



                    cella.Child = tb;

                    Canvas.SetLeft(cella, i * kockaHosszusag);
                    Canvas.SetTop(cella, j * kockaMagassag);

                    cnvPalya.Children.Add(cella);


                }
            }
        }

        private void Palya_Rajzolasa()
        {
            cnvPalya.Children.Clear();

            if (latogatottTermek.Count >= termekSzama && termekSzama > 0 || terembeVolt == true)
            {
                txtMission.Text = T("MissionFindExit");
                terembeVolt = true;
            }
            else if (termekSzama > 0)
            {
                txtMission.Text = string.Format(T("MissionFindRooms"), latogatottTermek.Count, termekSzama);
            }
            else
            {
                txtMission.Text = T("MissionExitOnly");
            }

            int oszlopokSzama = pillPalya[0].Length;
            int sorokSzama = pillPalya.Length;
            int kockaHosszusag = (int)(cnvPalya.ActualWidth / oszlopokSzama);
            int kockaMagassag = (int)(cnvPalya.ActualHeight / sorokSzama);


            for (global::System.Int32 j = 0; j < sorokSzama; j++)
            {
                for (global::System.Int32 i = 0; i < pillPalya[j].Length; i++)
                {

                    Border cella = new Border
                    {
                        Width = kockaHosszusag,
                        Height = kockaMagassag,
                        BorderBrush = Brushes.Transparent
                    };

                    TextBlock tb = new TextBlock
                    {
                        Text = pillPalya[j][i].ToString(),
                        FontFamily = new FontFamily("Consolas"),
                        FontSize = Math.Min(kockaHosszusag, kockaMagassag) * 6,
                        TextAlignment = TextAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center

                    };

                    if (pillPalya[j][i] == '.')
                    {
                        tb.Text = "";
                    }

                    if (j == jatekosPosY && i == jatekosPosX)
                    {

                        cella.Background = Brushes.Green;
                    }



                    cella.Child = tb;

                    Canvas.SetLeft(cella, i * kockaHosszusag);
                    Canvas.SetTop(cella, j * kockaMagassag);

                    cnvPalya.Children.Add(cella);
                }
            }

            Lehetosegek_Frissitese();
        }

        private bool NyitFel(char c)
        {
            return c is '╬' or '╩' or '║' or '╣' or '╠' or '╝' or '╚';
        }

        private bool NyitLe(char c)
        {
            return c is '╬' or '╦' or '║' or '╣' or '╠' or '╗' or '╔';
        }

        private bool NyitBalra(char c)
        {
            return c is '╬' or '═' or '╦' or '╩' or '╣' or '╗' or '╝';
        }

        private bool NyitJobbra(char c)
        {
            return c is '╬' or '═' or '╦' or '╩' or '╠' or '╔' or '╚';
        }

        private bool Bejaratok(int sor, int oszlop)
        {
            char c = pillPalya[sor][oszlop];

            if (c == '.' || c == '█')
            {
                return false;
            }

            if (sor == 0 && NyitFel(c))
            {
                return true;
            }

            if (sor == pillPalya.Length - 1 && NyitLe(c))
            {
                return true;
            }

            if (oszlop == 0 && NyitBalra(c))
            {
                return true;
            }

            if (oszlop == pillPalya[sor].Length - 1 && NyitJobbra(c))
            {
                return true;
            }

            return false;
        }

        private void Jatekos_Kezdes()
        {


            for (int i = 0; i < pillPalya.Length; i++)
            {
                for (int j = 0; j < pillPalya[i].Length; j++)
                {
                    bool szele = i == 0 || i == pillPalya.Length - 1 || j == 0 || j == pillPalya[i].Length - 1;

                    if (Bejaratok(i, j))
                    {
                        jatekosPosX = j;
                        jatekosPosY = i;
                        return;
                    }
                }
            }
        }

        private void Jatek_Vege()
        {
            if (Bejaratok(jatekosPosY, jatekosPosX) && terembeVolt)
            {
                visszaszamlalo.Stop();
                MessageBoxResult valasz = MessageBox.Show(
                    T("ExitQuestion"),
                    T("ExitTitle"),
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (valasz == MessageBoxResult.Yes)
                {
                    btnMegallitas.Visibility = Visibility.Hidden;
                    txtAllas.Visibility = Visibility.Hidden;
                    txtMission.Text = "";
                    visszaszamlalo.Stop();
                    lblLehetosegek.Content = "";
                    lblIdo.Content = "";
                    finished = true;
                    cnvPalya.Children.Clear();
                    MessageBox.Show(T("ExitCongrats"));
                    palyaBetoltve = false;
                    finished = false;
                    terembeVolt = false;
                    latogatottTermek.Clear();
                    termekSzama = 0;


                }

                if (valasz == MessageBoxResult.No)
                {
                    visszaszamlalo.Start();
                }

                // Nem tudfom, hogy ez kell -e 
                if (valasz == MessageBoxResult.No)
                {
                    return;
                }

            }
        }

        private void Palya_Betoltes(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = T("OpenFilter");
            ofd.Title = T("OpenTitle");

            if (ofd.ShowDialog() == true)
            {
                jatekosPosX = -1;
                jatekosPosY = -1;
                Ido_Countdown();
                Palya(ofd.FileName);
                Focus();
                palyaBetoltve = true;
                Lehetosegek_Frissitese();

                btnMegallitas.Visibility = Visibility.Visible;
                txtAllas.Visibility = Visibility.Visible;
                Felulet_Frissitese();

            }

        }

        private void Allas_Mentese(object sender, RoutedEventArgs e)
        {

            if (!palyaBetoltve)
            {
                return;
            }

            string[] mentendoAllas = (string[])pillPalya.Clone();


            char alattaLevo = pillPalya[jatekosPosY][jatekosPosX];
            mentendoAllas[jatekosPosY] = mentendoAllas[jatekosPosY].Remove(jatekosPosX, 1).Insert(jatekosPosX, "P" + alattaLevo);

            foreach (var (sor, oszlop) in latogatottTermek)
            {
                mentendoAllas = mentendoAllas.Append($"R{sor}:{oszlop}").ToArray();
            }

            mentendoAllas = mentendoAllas.Append($"T{(int)hatralevoIdo.TotalSeconds}").ToArray();


            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = T("SaveFilter");
            sfd.Title = T("SaveTitle");


            if (sfd.ShowDialog() == true)
            {
                File.WriteAllLines(sfd.FileName, mentendoAllas, Encoding.UTF8);
            }
        }




        private void Ido_Countdown()
        {
            hatralevoIdo = TimeSpan.FromSeconds(30);

            if (visszaszamlalo != null)
            {
                visszaszamlalo.Stop();
            }

            visszaszamlalo = new DispatcherTimer();
            visszaszamlalo.Interval = TimeSpan.FromSeconds(1);
            visszaszamlalo.Tick += Visszaszamlalo_Tick;

            lblIdo.Content = string.Format(T("TimeLabel"), hatralevoIdo.Seconds);

            visszaszamlalo.Start();


        }

        private void Visszaszamlalo_Tick(object sender, EventArgs e)
        {
            hatralevoIdo = hatralevoIdo.Subtract(TimeSpan.FromSeconds(1));
            lblIdo.Content = string.Format(T("TimeLabel"), hatralevoIdo.Seconds);

            if (hatralevoIdo <= TimeSpan.Zero)
            {
                visszaszamlalo.Stop();
                lblIdo.Content = "";
                MessageBox.Show(T("TimeExpired"));
                finished = false;
                cnvPalya.Children.Clear();
                palyaBetoltve = false;
                terembeVolt = false;
                latogatottTermek.Clear();
                termekSzama = 0;
            }
        }

        private void Jatek_Megallitas(object sender, RoutedEventArgs e)
        {
            if (!palyaBetoltve || visszaszamlalo == null)
            {
                return;
            }

            visszaszamlalo.Stop();

            MessageBoxResult stop = MessageBox.Show(
                T("PauseText"),
                T("PauseTitle"),
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            if (stop == MessageBoxResult.OK)
            {
                visszaszamlalo.Start();
            }
        }

        private void Nyelvek_Betoltese()
        {
            string json = File.ReadAllText("lang.json", Encoding.UTF8);
            nyelvek = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json);
        }

        private string T(string kulcs)
        {
            if (nyelvek != null &&
                nyelvek.ContainsKey(aktualisNyelv) &&
                nyelvek[aktualisNyelv].ContainsKey(kulcs))
            {
                return nyelvek[aktualisNyelv][kulcs];
            }

            return kulcs;
        }

        private void Felulet_Frissitese()
        {
            if (txtTitle != null) txtTitle.Text = T("Title");
            if (Title != null) Title = T("Title");
            if (btnMegallitas != null) btnMegallitas.Content = T("PauseButton");
            if (txtAllas != null) txtAllas.Text = T("Position");
            if (btnBetoltes != null) btnBetoltes.Content = T("LoadMap");
            if (btnMentes != null) btnMentes.Content = T("SaveGame");

            if (palyaBetoltve)
            {
                if (termekSzama > 0)
                {
                    if (latogatottTermek.Count >= termekSzama || terembeVolt)
                        txtMission.Text = T("MissionFindExit");
                    else
                        txtMission.Text = string.Format(T("MissionFindRooms"), latogatottTermek.Count, termekSzama);
                }
                else
                {
                    txtMission.Text = T("MissionExitOnly");
                }

                Lehetosegek_Frissitese();
                lblIdo.Content = string.Format(T("TimeLabel"), (int)hatralevoIdo.TotalSeconds);
            }
        }

        private void cmbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbLanguage.SelectedItem is ComboBoxItem selectedItem && selectedItem.Tag != null)
            {
                aktualisNyelv = selectedItem.Tag.ToString();
                Felulet_Frissitese();
            }
        }
    }
}