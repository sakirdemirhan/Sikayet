namespace Sikayet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mahalle")]
    public partial class Mahalle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mahalle()
        {
            Sikayets = new HashSet<Sikayet>();
            SilinmisSikayets = new HashSet<SilinmisSikayet>();
        }

        public int MahalleId { get; set; }

        [Required]
        [StringLength(250)]
        public string Adi { get; set; }

        [StringLength(150)]
        public string Muhtar { get; set; }

        [StringLength(150)]
        public string Telefon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sikayet> Sikayets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SilinmisSikayet> SilinmisSikayets { get; set; }
    }
}
