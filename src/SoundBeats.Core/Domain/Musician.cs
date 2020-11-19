using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundBeats.Core.Domain
{
    public class Musician
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(100)]
        public string BirthPlace { get; set; }

        public byte[] Photo { get; set; }
        public string ImageType { get; set; }

        public ICollection<GroupMember> GroupMember { get; set; }
    }
}
