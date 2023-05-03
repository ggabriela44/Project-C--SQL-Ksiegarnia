using System.ComponentModel.DataAnnotations;

namespace Ksiegarnia.Models
{

    public enum Category
    {
        Akcja = 1,
        Drama = 2,
        Komedia = 3,
        Horror = 4 ,
        Fantasty = 5 ,
        Romantyka = 6,
        Baśń = 7
    }

    public class Gatunek
    {
        [Key]
        [Display(Name = "ID")]
        public int Id_gatunek { get; set; }
        [StringLength (50)]
        [Display(Name = "Gatunek")]
        [Required(ErrorMessage = "Podaj ID gatunku")]
        public Category? Gatunek_ksiazki { get; set; }

        //Relacje
        public virtual ICollection<Ksiazka>? Ksiazka { get; set; }
    }
}
