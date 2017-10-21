namespace Sikayet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SilinmisKullanici")]
    public partial class SilinmisKullanici
    {
        [Key]
        [StringLength(11)]
        public string TC { get; set; }

        [StringLength(150)]
        public string Adi { get; set; }

        [StringLength(150)]
        public string Soyadi { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Telefon { get; set; }

        [StringLength(250)]
        public string Sifre { get; set; }
    }
}
