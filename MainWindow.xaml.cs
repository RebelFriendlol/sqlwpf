//****************************
//Strona główna
//****************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Threading;


namespace sqlwpfkurwamac
{
    public partial class MainWindow : Window
    {
        public List<AlbertoUser> MyUsers { get; set; } //deklarowanie klasy z bazy danych
        private DispatcherTimer timer; //timer potrzebny do odswiezania tabeli 


        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer(); //inicjacja timera
            timer.Interval = TimeSpan.FromSeconds(1); // Odświeżanie co sekundę
            timer.Tick += Timer_Tick;
            timer.Start();

            OdswiezDataGrid();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e) //przenosi na okno rejestracja
        {
            rejestracja noweOkno = new rejestracja(); 
            noweOkno.ShowDialog();           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            OdswiezDataGrid();
        }

        private void OdswiezDataGrid()
        {
            using (AlbertoDbContext _context = new AlbertoDbContext())
            {
                MyUsers = _context.AlbertoUsers.ToList(); //wyswietla wszystkie potrzebne dane z bazy dany
            }

            usersDataGrid.ItemsSource = MyUsers;
        }

        private void Button_Click2(object sender, RoutedEventArgs e) //przenosi na okno logowanie
        {
            logowanie noweOknoLogowanie = new logowanie();
            noweOknoLogowanie.ShowDialog();
        }

        private void Button_Click4(object sender, RoutedEventArgs e) //przenosi do playera
        {
            dupa noweOknoplayer = new dupa();
            noweOknoplayer.ShowDialog();
        }
    }
}
