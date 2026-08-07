namespace prjFruitbar8000Web.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fruitbar.SongsAlbums")]
    public partial class SongsAlbums
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }

        [ScaffoldColumn(false)]
        public int SongId { get; set; }

        public int TrackNumber { get; set; }

        public virtual Albums Albums { get; set; }

        public virtual Songs Songs { get; set; }
    }
}
