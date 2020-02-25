using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinterWorkShop.Cinema.Data
{
    public class CinemaContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Projection> Projections { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public CinemaContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagMovie>().HasKey(x => new { x.MovieId, x.TagId });

            base.OnModelCreating(modelBuilder);

            #region Seat - Auditorium
            /// <summary>
            /// Seat -> Auditorium relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Seat>()
                .HasOne(x => x.Auditorium)
                .WithMany(x => x.Seats)
                .HasForeignKey(x => x.AuditoriumId)
                .IsRequired();

            /// <summary>
            /// Auditorium -> Seat relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Auditorium>()
                .HasMany(x => x.Seats)
                .WithOne(x => x.Auditorium)
                .IsRequired();
            #endregion

            #region Cinema - Auditorium
            /// <summary>
            /// Cinema -> Auditorium relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Cinema>()
                .HasMany(x => x.Auditoriums)
                .WithOne(x => x.Cinema)
                .IsRequired();
            
            /// <summary>
            /// Auditorium -> Cinema relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Auditorium>()
                .HasOne(x => x.Cinema)
                .WithMany(x => x.Auditoriums)
                .HasForeignKey(x => x.CinemaId)
                .IsRequired();
            #endregion

            #region Projection - Auditorium
            /// <summary>
            /// Auditorium -> Projection relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Auditorium>()               
               .HasMany(x => x.Projections)
               .WithOne(x => x.Auditorium)
               .IsRequired();

            /// <summary>
            /// Projection -> Auditorium relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Projection>()
                .HasOne(x => x.Auditorium)
                .WithMany(x => x.Projections)
                .HasForeignKey(x => x.AuditoriumId)
                .IsRequired();
            #endregion

            #region Projection - Movie
            /// <summary>
            /// Projection -> Movie relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Projection>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.Projections)
                .HasForeignKey(x => x.MovieId)
                .IsRequired();

            /// <summary>
            /// Movie -> Projection relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Movie>()
                .HasMany(x => x.Projections)
                .WithOne(x => x.Movie)
                .IsRequired();
            #endregion

            #region Reservation - User
            /// <summary>
            /// User -> Reservation relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<User>()
                .HasMany(x => x.Reservations)
                .WithOne(x => x.User)
                .IsRequired();

            /// <summary>
            /// Reservation -> User relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.User)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.UserId)
                .IsRequired();
            #endregion

            #region Reservation - Seat
            /// <summary>
            /// Seat -> Reservation relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Seat>()
                .HasMany(x => x.Reservations)
                .WithOne(x => x.Seat)
                .IsRequired();

            /// <summary>
            /// Reservation -> Seat relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.Seat)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.SeatId)
                .IsRequired();
            #endregion

            #region Reservation - Projection
            /// <summary>
            /// Projection -> Reservation relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Projection>()
                .HasMany(x => x.Reservations)
                .WithOne(x => x.Projection)
                .IsRequired();

            /// <summary>
            /// Reservation -> Projection relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.Projection)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.ProjectionId)
                .IsRequired();

            #endregion
        }
    }
}
