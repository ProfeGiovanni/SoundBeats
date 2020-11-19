using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundBeats.Core.Domain
{
    public class Song
    {
        public int Id { get; set; }
        public int TrackNumber { get; set; }

        [StringLength(80)]
        public string Title { get; set; }
        public decimal Length { get; set; }

        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }

        /* Relación 1 a 1*/
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
