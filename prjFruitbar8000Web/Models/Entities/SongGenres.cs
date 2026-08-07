namespace prjFruitbar8000Web.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fruitbar.SongGenres")]
    public partial class SongGenres
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public int SongId { get; set; }

        [ScaffoldColumn(false)]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual Songs Songs { get; set; }
    }
}
