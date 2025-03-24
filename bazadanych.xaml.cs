using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace sqlwpfkurwamac
{
    /// <summary>
    /// Logika interakcji dla klasy dupa.xaml
    /// </summary>
    public partial class bazadanych : Window
    {
        private byte[] imageBytes;

        public dupa()
        {
            InitializeComponent();
        }

        private void button1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg;*.gif)|*.png;*.jpg;*.jpeg;*.gif|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Wczytaj obrazek
                BitmapImage bitmapImage = new BitmapImage(new Uri(openFileDialog.FileName));
                imagePreview.Source = bitmapImage;

                // Konwertuj obrazek na tablicę bajtów
                imageBytes = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

        private void button2(object sender, RoutedEventArgs e)
        {
            if (imageBytes != null)
            {
                try
                {
                    using (var context = new AlbertoDbContext())
                    {
                        // Załóżmy, że masz identyfikator wiersza, np. IDsong = 1
                        int targetSongId = 10;

                        // Pobierz istniejący obiekt z bazy danych na podstawie identyfikatora
                        var existingSong = context.AlbertoSongs.Find(targetSongId);

                        if (existingSong != null)
                        {
                            // Aktualizuj właściwość Zdjecie obiektu
                            existingSong.Zdjecie = imageBytes;

                            // Zapisz zmiany
                            context.SaveChanges();

                            MessageBox.Show("Obrazek zaktualizowany w bazie danych.");
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono wiersza o podanym identyfikatorze.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Wybierz obrazek przed dodaniem do bazy danych.");
            }
        }

    }
}
