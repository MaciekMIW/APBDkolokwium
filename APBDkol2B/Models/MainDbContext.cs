using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDkol2B.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Musician_Track> MusicianTracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Musician>(m =>
            {
                m.HasKey(e => e.IdMusician);
                m.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                m.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                m.Property(e => e.NickName).HasMaxLength(20);
                m.HasData(
                    new Musician { IdMusician = 1, FirstName="Mick",LastName="Jagger" },
                    new Musician { IdMusician = 2, FirstName="Józef",LastName="Ziutalski", NickName="Ziutek" }
                    );
            });
            modelBuilder.Entity<Track>(t =>
            {
                t.HasKey(e => e.IdTrack);
                t.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                t.Property(e => e.Duration).IsRequired();
                t.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum);
                t.HasData(
                    new Track { IdTrack=1,TrackName="Smells Like", Duration = 4F,IdMusicAlbum=1},
                    new Track { IdTrack=2,TrackName="Stairway to", Duration = 6F,IdMusicAlbum=2},
                    new Track { IdTrack=3,TrackName="Come Fly ", Duration = 5F,IdMusicAlbum=1}
                    );
            });
            modelBuilder.Entity<Musician_Track>(m =>
            {
                m.HasKey(e => new { e.IdMusician, e.IdTrack });
                m.HasOne(e => e.Musician).WithMany(e => e.MusicianTracks).HasForeignKey(e => e.IdMusician);
                m.HasOne(e => e.Track).WithMany(e => e.MusicianTracks).HasForeignKey(e => e.IdTrack);
                m.HasData(
                    new Musician_Track { IdMusician=1,IdTrack=3},
                    new Musician_Track { IdMusician=2,IdTrack=2},
                    new Musician_Track { IdMusician=2,IdTrack=1}
                    );
            });
            modelBuilder.Entity<MusicLabel>(m =>
            {
                m.HasKey(e => e.IdMusicLabel);
                m.Property(e => e.Name).IsRequired().HasMaxLength(50);
                m.HasData(
                    new MusicLabel { IdMusicLabel = 1, Name = "EMI" },
                    new MusicLabel { IdMusicLabel = 2, Name = "Sony" },
                    new MusicLabel { IdMusicLabel = 3, Name = "Jakaś " }
                    );
            });
            modelBuilder.Entity<Album>(a =>
            {
                a.HasKey(e => e.IdAlbum);
                a.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                a.Property(e => e.PublishDate).IsRequired();
                a.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel);
                a.HasData(
                    new Album { IdAlbum =1, AlbumName="Good Album",PublishDate=DateTime.Parse("2022-06-12"),IdMusicLabel=3 },
                    new Album { IdAlbum =2, AlbumName="Very Good Album",PublishDate=DateTime.Parse("2021-05-11"),IdMusicLabel=1 },
                    new Album { IdAlbum =3, AlbumName="Somewhat",PublishDate=DateTime.Parse("2020-04-10"),IdMusicLabel=2 }
                    );
            });

        }

    }
}
