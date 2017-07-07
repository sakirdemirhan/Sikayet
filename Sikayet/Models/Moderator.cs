namespace Sikayet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Moderator")]
    public partial class Moderator
    {
        public int ModeratorId { get; set; }

        [Required]
        [StringLength(150)]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(250)]
        public string Sifre { get; set; }
    }
}
