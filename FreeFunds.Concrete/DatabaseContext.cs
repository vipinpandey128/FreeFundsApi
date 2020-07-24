using FreeFundsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace FreeFundsApi.Concrete
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<AllTransaction> AllTransactions { get; set; }
        public DbSet<AllGame> AllGames { get; set; }
        public DbSet<LoginStatus> LoginStatus { get; set; }
        public DbSet<WithdrawalLimit> WithdrawalLimits { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Winning> Winnings { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<SchemeMaster> SchemeMaster { get; set; }
        public DbSet<PeriodTB> PeriodTb { get; set; }
        public DbSet<PlanMaster> PlanMaster { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<MemberRegistration> MemberRegistration { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersInRoles> UsersInRoles { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Map entity to table
            modelBuilder.Entity<AllTransaction>().ToTable("AllTransaction").HasKey(ee => ee.TransactionId);
            modelBuilder.Entity<AllTransaction>().Property(b => b.IsActive).HasDefaultValueSql("0");
            modelBuilder.Entity<AllTransaction>().Property(b => b.CurrentBal).HasDefaultValueSql("0");
            modelBuilder.Entity<AllTransaction>(entity =>
            {
                // Fluent API for column properties

                entity.HasOne(d => d.Users)
                .WithMany(p => p.AllTransactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.Bets)
                    .WithMany(p => p.AllTransactions)
                    .HasForeignKey(d => d.BetId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.AllTransactions)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<AllGame>(entity =>
            {
                entity.ToTable("AllGame").HasKey(ee => ee.GameId);
                entity.HasOne(p => p.SchemeMaster)
                .WithMany(b => b.AllGames).
                HasForeignKey(p => p.SchemeID);
                entity.Property(ee => ee.CreatedDateTime).HasColumnType<DateTime>("datetime");
            });


            modelBuilder.Entity<LoginStatus>().ToTable("LoginStatus").HasKey(ee => ee.LoginStatusId);
            modelBuilder.Entity<LoginStatus>()
            .HasOne(p => p.Users)
            .WithMany(b => b.LoginStatus).
            HasForeignKey(p => p.UserId);


            modelBuilder.Entity<WithdrawalLimit>().ToTable("WithdrawalLimit", "dbo").HasKey(ee => ee.Id);


            modelBuilder.Entity<TransactionType>().ToTable("TransactionType", "dbo").HasKey(ee => ee.TransationTypeId);



            modelBuilder.Entity<Winning>(entity =>
            {
                entity.ToTable("Winning", "dbo").HasKey(ee => ee.WinId);
                entity.HasOne(p => p.Users)
            .WithMany(b => b.Winnings).
            HasForeignKey(p => p.UserId);
            });



            modelBuilder.Entity<Bet>().ToTable("Bet", "dbo").HasKey(ee => ee.BetId);

            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasOne(d => d.AllGame)
                .WithMany(p => p.Bets)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.Users)
               .WithMany(p => p.Bets)
               .HasForeignKey(d => d.UserId)
               .OnDelete(DeleteBehavior.NoAction);
            });


            modelBuilder.Entity<SchemeMaster>(entity =>
            {
                entity.ToTable("SchemeMaster").HasKey(ee => ee.SchemeID);

            });


            modelBuilder.Entity<PeriodTB>().ToTable("PeriodTB", "dbo").HasKey(ee => ee.PeriodID);


            modelBuilder.Entity<PlanMaster>().ToTable("PlanMaster", "dbo").HasKey(ee => ee.PlanID);


            modelBuilder.Entity<Role>().ToTable("Role", "dbo").HasKey(ee => ee.RoleId);


            modelBuilder.Entity<MemberRegistration>().ToTable("MemberRegistration", "dbo").HasKey(ee => ee.MemberId);


            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "dbo").HasKey(ee => ee.UserId);
                entity.Property(b => b.CurrentBal).HasDefaultValueSql("0");
                entity.Property(b => b.IsTermsAndConditions).HasDefaultValueSql("0");
                entity.Property(b => b.IsPasswordUpdated).HasDefaultValueSql("0");
                entity.Property(b => b.Status).HasDefaultValueSql("1");
            });
            




            modelBuilder.Entity<UsersInRoles>(entity =>
            {
                entity.ToTable("UsersInRoles", "dbo").HasKey(ee => ee.UserRolesId);
                entity.HasOne(p => p.Users)
                .WithMany(b => b.UsersInRoles).
                HasForeignKey(p => p.UserId);
            });

            modelBuilder.Entity<PaymentDetails>(entity =>
            {
                entity.ToTable("PaymentDetails", "dbo").HasKey(ee => ee.PaymentID);
            });
        }
        
    }
    

}
