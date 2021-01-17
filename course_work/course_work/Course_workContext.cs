using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace course_work
{
    public partial class Course_workContext : DbContext
    {
        public Course_workContext()
        {
        }

        public Course_workContext(DbContextOptions<Course_workContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameRating> GameRatings { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Course_work;Username=postgres;Password=1111");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_Ukraine.1251");

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("games");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(10016L, null, null, null, null, null);

                entity.Property(e => e.AccessRating)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("access_rating");

                entity.Property(e => e.Developer)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("developer");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("genre");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Platform)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("platform");

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("publisher");

                entity.Property(e => e.ReleaseYear).HasColumnName("release_year");
            });

            modelBuilder.Entity<GameRating>(entity =>
            {
                entity.ToTable("game-rating");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasIdentityOptions(10015L, null, null, null, null, null);

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.RatingId).HasColumnName("rating_id");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameRatings)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_fkey");

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.GameRatings)
                    .HasForeignKey(d => d.RatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rating_fkey");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("players");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Eu).HasColumnName("EU");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.Jp).HasColumnName("JP");

                entity.Property(e => e.Na).HasColumnName("NA");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_fkey");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("rating");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(10016L, null, null, null, null, null);

                entity.Property(e => e.Critic).HasColumnName("critic");

                entity.Property(e => e.User).HasColumnName("user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
