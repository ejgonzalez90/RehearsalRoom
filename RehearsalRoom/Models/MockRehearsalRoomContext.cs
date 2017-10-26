using Microsoft.EntityFrameworkCore;
using RehearsalRoom.Model;

namespace RehearsalRoom
{
    public class MockRehearsalRoomContext : DbContext
    {
        public MockRehearsalRoomContext(DbContextOptions<MockRehearsalRoomContext> options) : base(options)
        {
        }

        //In Entity Framework terminology, an entity set typically corresponds to a database table, and an entity corresponds to a row in the table.
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Turn> Turns { get; set; }

        public DbSet<Interval> Intervals { get; set; }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<InstrumentBrand> InstrumentBrands { get; set; }
        public DbSet<BrandModel> BrandModels { get; set; }

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
