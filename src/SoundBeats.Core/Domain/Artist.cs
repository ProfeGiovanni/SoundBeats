using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundBeats.Core.Domain
{
    [Table("Artist")]
    public class Artist
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "Nombre del artista")]
        public string Name { get; set; }

        [Display(Name = "Biografía")]
        public string Biography { get; set; }

        [Display(Name = "País de origen")]
        public int CountryId { get; set; }
        public Country Country { get; set; }


        public ICollection<Album> Album { get; set;  }
    }
}
