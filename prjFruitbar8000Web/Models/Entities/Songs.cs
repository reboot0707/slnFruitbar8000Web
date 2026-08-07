namespace prjFruitbar8000Web.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fruitbar.Songs")]
    public partial class Songs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Songs()
        {
            ArtistsSongs = new HashSet<ArtistsSongs>();
            SongGenres = new HashSet<SongGenres>();
            SongsAlbums = new HashSet<SongsAlbums>();
        }

        [Key]
        public int SongId { get; set; }

        [Required]
        [StringLength(200)]
        public string SongName { get; set; }

        public bool IsDeleted { get; set; }

        public string Lyrics { get; set; }

        public int? Duration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArtistsSongs> ArtistsSongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SongGenres> SongGenres { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SongsAlbums> SongsAlbums { get; set; }
    }
}
