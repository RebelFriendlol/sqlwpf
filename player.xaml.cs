using Microsoft.Win32;
using NAudio.Wave;
using System.IO;
using System.Linq;
using System.Windows;

namespace sqlwpfkurwamac
{
    public partial class Player : Window
    {
        public Player()
        {
            InitializeComponent();
            OdswiezListePiosenek();
        }

        private void DodajPlikMuzyczny_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Pliki MP3 (*.mp3)|*.mp3|Wszystkie pliki (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Odczytaj dane pliku muzycznego
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);
                byte[] fileData = File.ReadAllBytes(filePath);

                // Wyświetl okno dialogowe do wprowadzania informacji o piosence
                var dodajPiosenkeDialog = new DodajPiosenkeDialog();
                dodajPiosenkeDialog.Owner = this; // Ustaw właściciela, aby utworzyć okno modalne
                if (dodajPiosenkeDialog.ShowDialog() == true)
                {
                    // Pobierz dane wprowadzone przez użytkownika
                    string wykonawca = dodajPiosenkeDialog.Wykonawca;
                    string tytul = dodajPiosenkeDialog.Tytul;
                    string album = dodajPiosenkeDialog.Album;
                    decimal dlugoscMinuty = dodajPiosenkeDialog.DlugoscMinuty;
                    string jezyk = dodajPiosenkeDialog.Jezyk;
                    decimal cena = dodajPiosenkeDialog.Cena;

                    // Dodaj do bazy danych (przy użyciu Entity Framework)
                    using (var context = new AlbertoDbContext())
                    {
                        // Dodaj nową piosenkę z odwołaniem do pliku muzycznego
                        var newSong = new AlbertoSong
                        {
                            Wykonawca = wykonawca,
                            Tytul = tytul,
                            Album = album,
                            DlugoscMinuty = dlugoscMinuty,
                            Jezyk = jezyk,
                            Cena = cena,
                            FileData = fileData,
                            FileName = fileName
                        };

                        context.AlbertoSongs.Add(newSong);
                        context.SaveChanges();
                    }

                    //odśwież listę piosenek
                    OdswiezListePiosenek();
                }
            }
        }

        private void OdtworzMuzyke_Click(object sender, RoutedEventArgs e)
        {
            var selectedSong = listaPiosenek.SelectedItem as AlbertoSong;

            if (selectedSong != null)
            {
                // Odtwórz wybraną piosenkę (tu wstaw odpowiednią logikę odtwarzania)
                using (var context = new AlbertoDbContext())
                {
                    var musicFile = context.AlbertoSongs.FirstOrDefault(m => m.IDsong == selectedSong.IDsong);
                    if (musicFile != null)
                    {
                        // Odtwórz plik audio
                        var waveOut = new WaveOut();
                        var waveStream = new Mp3FileReader(new MemoryStream(musicFile.FileData));
                        waveOut.Init(waveStream);
                        waveOut.Play();

                        MessageBox.Show($"Odtwarzanie: {selectedSong.Wykonawca} - {selectedSong.Tytul}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszę wybrać piosenkę z listy.");
            }
        }

        private void OdswiezListePiosenek()
        {
            using (var context = new AlbertoDbContext())
            {
                //pobierz listę piosenek z bazy danych
                var listaPiosenekZBazy = context.AlbertoSongs.ToList();

                //ustaw listę piosenek w kontrolce ListBox
                listaPiosenek.ItemsSource = listaPiosenekZBazy;
                listaPiosenek.DisplayMemberPath = "Tytul"; //ustaw właściwość do wyświetlania w ListBox
            }
        }
    }
}