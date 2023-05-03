using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ksiegarnia.Models
{
    public class Ksiazka
    {
        [Key]
        public int Id_ksiazka { get; set; }
        [StringLength (50)]
        [Required(ErrorMessage ="Tytuł książki jest wymagany")]
        [Display(Name ="Tytuł")]
        public string Tytul { get; set; }
        [StringLength (50)]
        [Required(ErrorMessage = "Autor książki jest wymagany")]
        [Display(Name = "Autor")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "Gatunek książki jest wymagany. Wybierz wartość od 1 do 7")]
        [ForeignKey("Gatunek")]
        [Range(1, 7)]
        public int GatunekID { get; set; }
        [Range(0, 10)]
        [Required(ErrorMessage = "Ocena książki jest wymagana")]
        [Display(Name = "Ocena")]
        public int Ocena { get; set; }
        [StringLength (50)]
        [Display(Name = "Wydawnictwo")]
        [Required(ErrorMessage = "Wydawnictwo książki jest wymagane")]
        public string Wydawnictwo { get; set;}
        [DataType(DataType.Date)]
        [Display(Name = "Data wydania")]
        [Required(ErrorMessage = "Data wydania książki jest wymagana")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data_wydania { get; set; }
        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Cena książki jest wymagana. Format XX.XX")]
        public float Cena { get; set; }
        [StringLength(int.MaxValue)]
        [Display(Name = "Opis")]
        public string? Opis { get; set; }

        //Relacje
        public virtual Gatunek? Gatunek { get; set; }//1 ksiazka ~~ gatunków
       // public virtual ICollection<Zamowienie> Zamowienia { get; set; }
        public virtual ICollection<KsiazkaZamowienie>? KsiazkiZamowione { get; set; }    

    }
}
