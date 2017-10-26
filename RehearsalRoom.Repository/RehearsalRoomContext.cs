using Microsoft.EntityFrameworkCore;
using RehearsalRoom.Model;

namespace RehearsalRoom.Repository
{
    public class RehearsalRoomContext : DbContext
    {
        public RehearsalRoomContext(DbContextOptions<RehearsalRoomContext> options) : base(options)
        {
        }

        //In Entity Framework terminology, an entity set typically corresponds to a database table, and an entity corresponds to a row in the table.
        public DbSet<RehearsalRoom.Model.Room> Rooms { get; set; }
        public DbSet<RehearsalRoom.Model.Turn> Turns { get; set; }

        public DbSet<RehearsalRoom.Model.Interval> Intervals { get; set; }

        public DbSet<RehearsalRoom.Model.Band> Bands { get; set; }
        public DbSet<RehearsalRoom.Model.Player> Players { get; set; }

        public DbSet<RehearsalRoom.Model.Instrument> Instruments { get; set; }
        public DbSet<RehearsalRoom.Model.InstrumentBrand> InstrumentBrands { get; set; }
        public DbSet<RehearsalRoom.Model.BrandModel> BrandModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BandPlayer>()
                .HasKey(bp => new { bp.BandId, bp.PlayerId });

            modelBuilder.Entity<BandPlayer>()
                .HasOne(bp => bp.Band)
                .WithMany(b => b.BandPlayers)
                .HasForeignKey(bp => bp.BandId);

            modelBuilder.Entity<BandPlayer>()
                .HasOne(bp => bp.Player)
                .WithMany(p => p.PlayerBands)
                .HasForeignKey(bp => bp.PlayerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
