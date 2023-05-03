using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ksiegarnia.Models
{
    public class Zamowienie
    {
        /*public Zamowienie() 
        {
            this.Ksiazka = new HashSet<Ksiazka>();   
        }*/

        [Key]
        [Display(Name = "ID")]
        public int Id_zamowienia { get; set; }
        //[ForeignKey("Ksiazka")]
        //public int KsiazkaID { get; set; }
        [ForeignKey("Klient")]
        [Display(Name = "ID Klient")]
        [Required(ErrorMessage = "Podaj ID klienta")]
        public int KlientID { get; set; }
        [ForeignKey("Dostawa")]
        [Required(ErrorMessage = "Podaj ID dostawy")]
        [Display(Name = "ID Dostawa")]
        public int DostawaID { get; set; }
        [Display(Name = "Cena książek")]
        public float Cena_ksiazek { get; set; }
        [Display(Name = "Cena dostawy")]
        public float Cena_dostawy { get; set; }
        [Display(Name = "Typ zaplaty")]
        [StringLength (50)]
        public string Typ_zaplaty { get; set; }
        [Required(ErrorMessage = "Podaj ulicę adresu")]
        [Display(Name = "Ulica")]
        [StringLength (50)]
        public string? Ulica { get; set; }
        [Display(Name = "Numer domu")]
        [Required(ErrorMessage = "Podaj numer domu")]
        [StringLength (50)]
        public string Nr_domu { get; set; }
        [Display(Name = "Miejscowosc")]
        [Required(ErrorMessage = "Podaj miejscowość")]
        [StringLength (50)]
        public string Miejscowosc { get; set; }
        [Required(ErrorMessage = "Podaj kod pocztowy")]
        [Display(Name = "Kod pocztowy")]
        [StringLength (6)]
        public string Kod_pocztowy { get; set; }


        //Relacja
       // public virtual ICollection<Ksiazka> Ksiazka { get; set; }
        //public virtual Ksiazka Ksiazka { get; set; }
        public virtual Dostawa? Dostawa { get; set; }
        public virtual Klient? Klient { get; set; }

        public virtual ICollection<KsiazkaZamowienie>? KsiazkaZamowione { get; set; }

    }
}
