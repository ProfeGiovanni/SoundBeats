using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundBeats.Core.Domain
{
    [Table("Albums")]
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public byte[] PhotoCover { get; set; }
        public string ImageType { get; set; }

        public int ArtistId { get; set; }
        public  Artist Artist { get; set; }

        public ICollection<Song> Song { get; set;  }

    }
}
