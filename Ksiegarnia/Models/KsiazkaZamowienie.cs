using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ksiegarnia.Models
{
    public class KsiazkaZamowienie
    {
        //[Key]
       // public int ZamowioneKsiazkiID { get; set; }
        [ForeignKey("Zamowienie")]
        public int ZamowienieID { get; set; }
        public virtual Zamowienie? Zamowienie { get; set; }
        [ForeignKey("Ksiazka")]
        public int KsiazkaID { get; set; }
        public virtual Ksiazka? Ksiazka { get; set; }    


    }
}
