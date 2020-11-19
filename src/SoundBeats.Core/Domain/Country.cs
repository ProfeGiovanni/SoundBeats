using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundBeats.Core.Domain
{
    /// <summary>
    /// Country entity
    /// </summary>
    [Table("Country")]
    public class Country
    {
        //[Key]
        public int Id { get; set; }

        [StringLength(80)]
        [Display(Name = "Nombre en Inglés")]
        public string NameEn { get; set; }

        [StringLength(80)]
        [Display(Name = "Nombre en Español")]
        public string NameEs { get; set; }

        [StringLength(2)]
        [Display(Name = "Código ISO2")]
        public string ISO2 { get; set; }

        [StringLength(3)]
        [Display(Name = "Código ISO3")]
        public string ISO3 { get; set; }

        public Artist Artist { get; set; }
    }
}
