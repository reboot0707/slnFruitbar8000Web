using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace prjFruitbar8000Web.Models.Entities
{
    public partial class FruitbarDB : DbContext
    {
        public FruitbarDB()
            : base("name=FruitbarDB")
        {
        }

        public virtual DbSet<AlbumArtist> AlbumArtist { get; set; }
        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<ArtistsSongs> ArtistsSongs { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<SongGenres> SongGenres { get; set; }
        public virtual DbSet<Songs> Songs { get; set; }
        public virtual DbSet<SongsAlbums> SongsAlbums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Albums>()
                .HasMany(e => e.AlbumArtist)
                .WithRequired(e => e.Albums)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Albums>()
                .HasMany(e => e.SongsAlbums)
                .WithRequired(e => e.Albums)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artists>()
                .HasMany(e => e.AlbumArtist)
                .WithRequired(e => e.Artists)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artists>()
                .HasMany(e => e.ArtistsSongs)
                .WithRequired(e => e.Artists)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.SongGenres)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Songs>()
                .HasMany(e => e.ArtistsSongs)
                .WithRequired(e => e.Songs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Songs>()
                .HasMany(e => e.SongGenres)
                .WithRequired(e => e.Songs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Songs>()
                .HasMany(e => e.SongsAlbums)
                .WithRequired(e => e.Songs)
                .WillCascadeOnDelete(false);
        }
    }
}
