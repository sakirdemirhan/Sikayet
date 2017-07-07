namespace Sikayet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            Sikayets = new HashSet<Sikayet>();
        }

        [Key]
        [StringLength(11)]
        public string TC { get; set; }

        [Required]
        [StringLength(150)]
        public string Adi { get; set; }

        [Required]
        [StringLength(150)]
        public string Soyadi { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        public string Telefon { get; set; }

        [Required]
        [StringLength(250)]
        public string Sifre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sikayet> Sikayets { get; set; }
    }
}
