using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<User> Users { get; set; }      


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configurations.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team> (entity =>
            {
                entity
                    .HasKey(c => c.TeamId);

                entity
                    .Property(n => n.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);                    

                entity
                    .Property(d => d.LogoUrl)                   
                    .IsUnicode();

                entity
                    .Property(s => s.Initials)
                    .IsRequired()
                    .IsUnicode(false);

                entity
                    .Property(e => e.Initials)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(3);

                entity
                    .HasOne(t => t.PrimaryKitColor)
                    .WithMany(c => c.PrimaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId);

                entity
                    .HasOne(t => t.SecondaryKitColor)
                    .WithMany(c => c.SecondaryKitTeams)
                    .HasForeignKey(t => t.SecondaryKitColorId);

                entity
                    .HasOne(t => t.Town)
                    .WithMany(town => town.Teams)
                    .HasForeignKey(t => t.TownId);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity
                    .HasKey(c => c.ColorId);

                entity
                    .Property(c => c.Name)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(30);

            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity
                    .HasKey(t => t.TownId);

                entity
                    .Property(c => c.Name)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(50);

                entity
                    .HasOne(t => t.Country)
                    .WithMany(c => c.Towns)
                    .HasForeignKey(t => t.CountryId);

            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity
                    .HasKey(c => c.CountryId);

                entity
                    .Property(c => c.Name)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity
                    .HasKey(p => p.PlayerId);

                entity
                    .Property(p => p.Name)
                    .IsRequired()
                    .IsUnicode(true)
                    .HasMaxLength(80);                

                entity
                    .HasOne(p => p.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey(p => p.TeamId);

                entity
                    .HasOne(p => p.Position)
                    .WithMany(position => position.Players)
                    .HasForeignKey(p => p.PositionId);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity
                    .HasKey(p => p.PositionId);

                entity
                    .Property(p => p.Name)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(30);               
            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity
                    .HasKey(ps => new { ps.GameId, ps.PlayerId });

                entity
                    .HasOne(ps => ps.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(ps => ps.PlayerId);

                entity
                    .HasOne(ps => ps.Game)
                    .WithMany(g => g.PlayerStatistics)
                    .HasForeignKey(ps => ps.GameId);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity
                    .HasKey(ps => ps.GameId);

                entity
                    .Property(g => g.Result)
                    .IsRequired(false)
                    .IsUnicode(false)
                    .HasMaxLength(7);

                entity
                    .HasOne(g => g.HomeTeam)
                    .WithMany(t => t.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId);

                entity
                    .HasOne(g => g.AwayTeam)
                    .WithMany(t => t.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId);
                
            });

            modelBuilder.Entity<Bet>(entity =>
            {
                entity
                    .HasKey(b => b.BetId);

                entity
                    .HasOne(b => b.User)
                    .WithMany(u => u.Bets)
                    .HasForeignKey(b => b.UserId);

                entity
                    .HasOne(b => b.Game)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(b => b.GameId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .HasKey(u => u.UserId);

                entity
                    .Property(u => u.Username)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(50);

                entity
                    .Property(u => u.Password)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(256);

                entity
                    .Property(u => u.Email)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(50);

                entity
                   .Property(u => u.Name)
                   .IsRequired(false)
                   .IsUnicode(true)
                   .HasMaxLength(80);
            });
        }
    }
}
