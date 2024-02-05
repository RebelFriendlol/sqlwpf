using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography; //biblioteka do szyfrowania hasel
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sqlwpfkurwamac
{
    public partial class logowanie : Window
    {
        public logowanie()
        {
            InitializeComponent();
        }

        public class AlbertoUser
        {
            [Required]
            public string EmailAddress { get; set; }
            [Required]
            public string PasswordUser { get; set; }
            public string LoginUser { get; set; }

            public void SetPassword(string password)
            {
                using (SHA256 sha256 = SHA256.Create()) //do szyfrowania uzywamy algorytmu sha256
                { 
                    byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password)); //konwertowanie
                    PasswordUser = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower(); 
                }
            }

            public bool VerifyPassword(string password)
            {
                using (SHA256 sha256 = SHA256.Create()) //porownanie hasla zaszyfrowanego z hasel wpisanym w progarmie
                {
                    byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    string inputHash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                    return inputHash == PasswordUser;
                }
            }
        }

        private void zalogujbutton_Click(object sender, RoutedEventArgs e)
        {
            using (AlbertoDbContext _context = new AlbertoDbContext())
            {
                //pobierz hasło z pola hasła
                string enteredPassword = haslopassword.Password;

                //pobierz użytkownika po adresie e-mail
                sqlwpfkurwamac.AlbertoUser user = _context.AlbertoUsers.SingleOrDefault(u => u.EmailAddress == emailtext.Text);

                //sprawdza uzytkownika
                if (user != null && user.VerifyPassword(enteredPassword))
                {
                    MessageBox.Show("Poprawne dane logowania! Witaj, " + user.LoginUser, "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Nieprawidłowe dane logowania. Spróbuj ponownie.", "Błąd logowania", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}