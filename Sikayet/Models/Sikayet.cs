namespace Sikayet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sikayet")]
    public partial class Sikayet
    {
        public int SikayetId { get; set; }

        [Required]
        [StringLength(11)]
        public string KullaniciTC { get; set; }

        public int MahalleID { get; set; }

        [Required]
        [StringLength(50)]
        public string Sokak { get; set; }

        [StringLength(50)]
        public string Baslik { get; set; }

        [Column(TypeName = "text")]
        public string Aciklama { get; set; }

        [StringLength(250)]
        public string Fotograf { get; set; }

        public bool Durum { get; set; }

        public DateTime? Tarih { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Mahalle Mahalle { get; set; }
    }
}
