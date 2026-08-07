namespace prjFruitbar8000Web.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fruitbar.Albums")]
    public partial class Albums
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Albums()
        {
            AlbumArtist = new HashSet<AlbumArtist>();
            SongsAlbums = new HashSet<SongsAlbums>();
        }

        [Key]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(200)]
        public string AlbumName { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReleaseDate { get; set; }

        public byte[] CoverPic { get; set; }

        [StringLength(50)]
        public string AlbumType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlbumArtist> AlbumArtist { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SongsAlbums> SongsAlbums { get; set; }
    }
}
