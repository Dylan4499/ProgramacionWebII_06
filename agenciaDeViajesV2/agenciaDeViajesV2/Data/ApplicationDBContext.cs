using Microsoft.EntityFrameworkCore;
using agenciaDeViajesV2.Models;

namespace agenciaDeViajesV2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para las entidades
        public DbSet<UserClass> Users { get; set; }
        public DbSet<RoleClass> Roles { get; set; }
        public DbSet<ClientClass> Clients { get; set; }
        public DbSet<FlyClass> Flies { get; set; }
        public DbSet<HotelClass> Hotels { get; set; }
        public DbSet<RoomClass> Rooms { get; set; }
        public DbSet<OfferClass> Offers { get; set; }
        public DbSet<SeatClass> Seats { get; set; }
        public DbSet<ActivityClass> Activities { get; set; }
        public DbSet<PaymentClass> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir las tablas en la base de datos
            modelBuilder.Entity<UserClass>().ToTable("tbusers");
            modelBuilder.Entity<RoleClass>().ToTable("tbroles");
            modelBuilder.Entity<ClientClass>().ToTable("tbclients");
            modelBuilder.Entity<FlyClass>().ToTable("tbflies");
            modelBuilder.Entity<HotelClass>().ToTable("tbhotels");
            modelBuilder.Entity<RoomClass>().ToTable("tbrooms");
            modelBuilder.Entity<OfferClass>().ToTable("tboffers");
            modelBuilder.Entity<SeatClass>().ToTable("tbseats");
            modelBuilder.Entity<ActivityClass>().ToTable("tbactivities");
            modelBuilder.Entity<PaymentClass>().ToTable("tbpayments");

            // Configuración de las relaciones
            modelBuilder.Entity<RoomClass>()
                .HasOne(h => h.Hotel)
                .WithMany()
                .HasForeignKey(r => r.FK_hotel);

            modelBuilder.Entity<OfferClass>()
                .HasOne(r => r.Room)
                .WithMany()
                .HasForeignKey(o => o.FK_room);

            modelBuilder.Entity<OfferClass>()
                .HasOne(c => c.Client)
                .WithMany()
                .HasForeignKey(o => o.FK_client);

            modelBuilder.Entity<OfferClass>()
                .HasOne(a => a.Activity)
                .WithMany()
                .HasForeignKey(o => o.FK_activity);

            modelBuilder.Entity<SeatClass>()
                .HasOne(f => f.Fly)
                .WithMany()
                .HasForeignKey(s => s.FK_fly);

            modelBuilder.Entity<SeatClass>()
                .HasOne(o => o.Offer)
                .WithMany()
                .HasForeignKey(s => s.FK_offer);

            modelBuilder.Entity<PaymentClass>()
                .HasOne(o => o.Offer)
                .WithMany()
                .HasForeignKey(p => p.FK_offer);
        }
    }
}
