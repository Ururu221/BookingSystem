using BookingSystem_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem_web_api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoomModel>(entity =>
            {
                entity.ToTable("Rooms", "booking");

                entity.HasKey(r => r.Id);
                entity.Property(r => r.RoomType)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(r => r.Address)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.HasIndex(r => r.Price);

            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservations", "booking");

                entity.HasKey(r => r.Id);
                entity.HasOne<RoomModel>()
                    .WithMany(r => r.Reservation)
                    .HasForeignKey(r => r.RoomId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
