using System;
using System.Windows;

namespace sqlwpfkurwamac
{
    public partial class DodajPiosenkeDialog : Window
    {
        public DodajPiosenkeDialog()
        {
            InitializeComponent();
        }

        //Deklaracja właściwości do przechowywania danych o piosence
        public string Wykonawca { get; private set; }
        public string Tytul { get; private set; }
        public string Album { get; private set; }
        public decimal DlugoscMinuty { get; private set; }
        public string Jezyk { get; private set; }
        public decimal Cena { get; private set; }

        private void DodajPiosenke_Click(object sender, RoutedEventArgs e)
        {
            Wykonawca = textBoxWykonawca.Text;
            Tytul = textBoxTytul.Text;
            Album = textBoxAlbum.Text;
            Jezyk = textBoxJezyk.Text;

            // Przekształcenie formatu czasu "mm:ss" na decimal
            string czasMinutySekundy = textBoxDlugoscMinuty.Text;
            string[] czasy = czasMinutySekundy.Split(':');

            if (czasy.Length == 2 && decimal.TryParse(czasy[0], out decimal minuty) && decimal.TryParse(czasy[1], out decimal sekundy))
            {
                DlugoscMinuty = minuty + sekundy / 60;
            }
            else
            {
                MessageBox.Show("Wprowadź prawidłowy format czasu (mm:ss).");
                return;
            }

            if (decimal.TryParse(textBoxCena.Text, out decimal cena))
            {
                Cena = cena;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Wprowadź prawidłową wartość dla ceny.");
            }
        }
    }
}
