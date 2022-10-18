using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using pif.Kodlama.io.Devs.Domain.Entities;

namespace pif.Kodlama.io.Devs.Persistance.Contexts
{
	public class BaseDbContext : DbContext
	{
		protected IConfiguration Configuration { get; set; }
		public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
		public DbSet<Technology> Technologies { get; set; }
		public DbSet<GithubProfile> GithubProfiles { get; set; }


		public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
		{
			Configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProgrammingLanguage>(a =>
			{
				a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
				a.Property(p => p.Id).HasColumnName("Id");
				a.Property(p => p.Name).HasColumnName("Name");
				a.HasMany(p => p.Technologies);
			});

			ProgrammingLanguage[] brandEntitySeeds = { new(1, "C#"), new(2, "Java") };
			modelBuilder.Entity<ProgrammingLanguage>().HasData(brandEntitySeeds);



			modelBuilder.Entity<Technology>(a =>
			{
				a.ToTable("Technologies").HasKey(k => k.Id);
				a.Property(p => p.Id).HasColumnName("Id");
				a.Property(p => p.Name).HasColumnName("Name");
				a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
				a.HasOne(p => p.ProgrammingLanguage);
			});

			Technology[] technologyEntitySeeds = { new(1, "WPF",1), new(2, "Asp.NET",1), new(3, "JPS",2) };
			modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);



			modelBuilder.Entity<GithubProfile>(a =>
			{
				a.ToTable("GithubProfiles").HasKey(k => k.Id);
				a.Property(p => p.Id).HasColumnName("Id");
				a.Property(p => p.GithubAddress).HasColumnName("GithubAddress");
				a.Property(p => p.UserId).HasColumnName("UserId");
				a.HasOne(p => p.User);
			});



		}
	}
}
