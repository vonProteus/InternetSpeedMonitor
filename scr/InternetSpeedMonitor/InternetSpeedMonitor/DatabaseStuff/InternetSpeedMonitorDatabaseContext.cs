using InternetSpeedMonitor.Data;
using Microsoft.EntityFrameworkCore;

namespace InternetSpeedMonitor.DatabaseStuff;

public class InternetSpeedMonitorDatabaseContext : DbContext
{
	public DbSet<SpeedResult> SpeedResults { get; set; }

	protected override void OnConfiguring(
		DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseNpgsql(DbConfig.GetConnectionString());
	}

	protected override void OnModelCreating(
		ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema("public");
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<SpeedResult>().HasKey(speedResult => speedResult.Id);
		modelBuilder.Entity<SpeedResult>().HasIndex(speedResult => speedResult.Timestamp);
	}

	public void Init()
	{
		Database.Migrate();
	}
}

