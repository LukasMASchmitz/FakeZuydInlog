
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace FakeZuydInlog.Models
{
    public class Inlog
    {
        [Key]
        public string Gebruikersnaam { get; set; }  
        public string Wachtwoord { get; set; }

    }
}
