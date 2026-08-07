namespace prjFruitbar8000Web.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fruitbar.Artists")]
    public partial class Artists
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artists()
        {
            AlbumArtist = new HashSet<AlbumArtist>();
            ArtistsSongs = new HashSet<ArtistsSongs>();
        }

        [Key]
        public int ArtistId { get; set; }

        [Required]
        [StringLength(200)]
        public string ArtistName { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(50)]
        public string ArtistType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlbumArtist> AlbumArtist { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArtistsSongs> ArtistsSongs { get; set; }
    }
}
