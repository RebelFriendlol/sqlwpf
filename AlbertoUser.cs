using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Security.Cryptography;
namespace sqlwpfkurwamac
{
    public  class AlbertoUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDuser { get; set; }

        public required string EmailAddress { get; set; }
        public required string PasswordUser { get; set; }
        public required string LoginUser { get; set; }
        public required string GenderUser { get; set; }
        public DateTime? DateOfBirthUser { get; set; }
        public DateTime DateOfCreateUser { get; set; }
        public string? CountryUser { get; set; }

        public void SetPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                PasswordUser = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public bool VerifyPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string inputHash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return inputHash == PasswordUser;
            }
        }
    }
}
