using System.ComponentModel.DataAnnotations;

namespace Ksiegarnia.Models
{
    public class Klient
    {
        [Key]
        public int Id_klient { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Wymagane jest Imie")]
        [Display(Name = "Imie")]
        public string Imie { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Wymagane jest Nazwisko")]
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }
        [Display(Name = "Numer Telefonu")]
        [StringLength(9)]
        [Required(ErrorMessage = "Podaj 9-cyfrowy numer telefonu")]
        public string Nr_telefon { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }

        public virtual ICollection<Zamowienie>? Zamowienia { get; set; }
    }
}
