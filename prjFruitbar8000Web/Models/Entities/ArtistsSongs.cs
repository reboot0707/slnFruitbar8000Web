namespace prjFruitbar8000Web.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fruitbar.ArtistsSongs")]
    public partial class ArtistsSongs
    {
        public int Id { get; set; }

        public int SongId { get; set; }

        public int ArtistId { get; set; }

        [StringLength(200)]
        public string CreditRoles { get; set; }

        public virtual Artists Artists { get; set; }

        public virtual Songs Songs { get; set; }
    }
}
