using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using pif.Core.Security.Entities;
using pif.Core.Security.Hashing;
using pif.Kodlama.io.Devs.Domain.Entities;

namespace pif.Kodlama.io.Devs.Persistance.Contexts
{
	public class BaseDbContext : DbContext
	{
		protected IConfiguration Configuration { get; set; }
		public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
		public DbSet<Technology> Technologies { get; set; }
		public DbSet<GithubProfile> GithubProfiles { get; set; }
		public DbSet<KodlamaUser> Users { get; set; }
		public DbSet<OperationClaim> OperationClaims { get; set; }
		public DbSet<KodlamaUserOperationClaim> UserOperationClaims { get; set; }
		public DbSet<RefreshToken> RefreshTokens { get; set; }


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


			//modelBuilder.Entity<KodlamaUser>(a =>
			//{
			//	a.ToTable("Users").HasKey(k => k.Id);
			//	a.Property(p => p.Id).HasColumnName("Id");
			//	a.Property(p => p.FirstName).HasColumnName("FirstName");
			//	a.Property(p => p.LastName).HasColumnName("LastName");
			//	a.Property(p => p.UserName).HasColumnName("UserName");
			//	a.Property(p => p.Email).HasColumnName("Email");
			//	a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
			//	a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
			//	a.Property(p => p.Status).HasColumnName("Status");
			//	a.HasMany(p => p.RefreshTokens);
			//	a.HasMany(p => p.UserOperationClaims);
			//	a.HasMany(p => p.GithubProfiles);
			//});


			byte[] passwordHash, passwordSalt;
			HashingHelper.CreatePasswordHash("TestPassword", out passwordHash, out passwordSalt);


			KodlamaUser[] kodlamaUsers = {
				new(1, "pif128", "pif", "128", "pif@pif128.com", passwordSalt, passwordHash, true),
				new(2, "2pif128", "pif2", "128", "pif2@pif128.com", passwordSalt, passwordHash, true) };
			modelBuilder.Entity<KodlamaUser>().HasData(kodlamaUsers);

			GithubProfile[] githubProfiles = { new(1, 1, "/pif128"), new(2, 1, "/aaa") };
			modelBuilder.Entity<GithubProfile>().HasData(githubProfiles);


			OperationClaim[] operationClaims = { new(1,"Admin"), new(2, "User") };
			modelBuilder.Entity<OperationClaim>().HasData(operationClaims);


			//modelBuilder.Entity<KodlamaUserOperationClaim>(a =>
			//{
			//	a.ToTable("UserOperationClaims").HasKey(k => k.Id);
			//	a.Property(p => p.Id).HasColumnName("Id");
			//	a.HasOne(p => p.KodlamaUser);
			//});

			KodlamaUserOperationClaim[] userOperationClaims = { new(1, 1, 1), new(2, 2, 2) };
			modelBuilder.Entity<KodlamaUserOperationClaim>().HasData(userOperationClaims);



		}
	}
}
