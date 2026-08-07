namespace prjFruitbar8000Web.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fruitbar.AlbumArtist")]
    public partial class AlbumArtist
    {
        public int Id { get; set; }

        public int AlbumId { get; set; }

        public int ArtistId { get; set; }

        [StringLength(200)]
        public string CreditRoles { get; set; }

        public virtual Albums Albums { get; set; }

        public virtual Artists Artists { get; set; }
    }
}
