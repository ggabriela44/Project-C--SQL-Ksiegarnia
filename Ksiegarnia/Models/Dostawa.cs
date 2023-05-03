using System.ComponentModel.DataAnnotations;

namespace Ksiegarnia.Models
{
    public class Dostawa
    {
        [Key]
        [Display(Name = "ID")]
        public int Id_dostawa { get; set; }
        [Required(ErrorMessage = "Proszę podać typ dostawy")]
        [Display(Name = "Typ dostawy")]
        [StringLength(50)]
        public string Typ { get; set; }
        [Required(ErrorMessage = "Podaj koszt XX.XX")]
        [Display(Name = "Opłata")]
        public float Oplata { get; set; }

        //Relacje
        public virtual ICollection<Zamowienie>? Zamowienia { get; set; }
    }
}
