using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace sqlwpfkurwamac;

public partial class User
{
    [Key] // Oznaczenie klucza głównego
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Automatyczne generowanie
    public int PersonId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }
}
