namespace Sikayet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SilinmisSikayet")]
    public partial class SilinmisSikayet
    {
        [Key]
        public int SilinmisId { get; set; }

        [StringLength(11)]
        public string KullaniciTC { get; set; }

        public int? MahalleID { get; set; }

        [StringLength(50)]
        public string Sokak { get; set; }

        [StringLength(50)]
        public string Baslik { get; set; }

        [Column(TypeName = "text")]
        public string Aciklama { get; set; }

        [StringLength(250)]
        public string Fotograf { get; set; }

        public DateTime? Tarih { get; set; }

        [Column(TypeName = "text")]
        public string Yorum { get; set; }

        public virtual Mahalle Mahalle { get; set; }
    }
}
