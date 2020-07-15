using FreeFundsApi.Models;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<WithdrawalLimit> WithdrawalLimit { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<Winning> Winning { get; set; }
        public DbSet<Bet> Bet { get; set; }
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
            modelBuilder.Entity<AllTransaction>()
            .HasOne(p => p.Users)
            .WithMany(b => b.AllTransactions).
            HasForeignKey(p => p.UserId);

            modelBuilder.Entity<AllGame>().ToTable("AllGame").HasKey(ee => ee.GameId);


            modelBuilder.Entity<LoginStatus>().ToTable("LoginStatus").HasKey(ee => ee.LoginStatusId);
            modelBuilder.Entity<LoginStatus>()
            .HasOne(p => p.Users)
            .WithMany(b => b.LoginStatus).
            HasForeignKey(p => p.UserId);


            modelBuilder.Entity<WithdrawalLimit>().ToTable("WithdrawalLimit", "dbo").HasKey(ee => ee.Id);


            modelBuilder.Entity<TransactionType>().ToTable("TransactionType", "dbo").HasKey(ee => ee.TransationTypeId);


            modelBuilder.Entity<Winning>().ToTable("Winning", "dbo").HasKey(ee => ee.WinId);
            modelBuilder.Entity<Winning>()
            .HasOne(p => p.Users)
            .WithMany(b => b.Winnings).
            HasForeignKey(p => p.UserId);


            modelBuilder.Entity<Bet>().ToTable("Bet", "dbo").HasKey(ee => ee.BetId);
            modelBuilder.Entity<Bet>()
            .HasOne(p => p.Users)
            .WithMany(b => b.Bets).
            HasForeignKey(p => p.UserId);


            modelBuilder.Entity<SchemeMaster>().ToTable("SchemeMaster", "dbo").HasKey(ee => ee.SchemeID);


            modelBuilder.Entity<PeriodTB>().ToTable("PeriodTB", "dbo").HasKey(ee => ee.PeriodID);


            modelBuilder.Entity<PlanMaster>().ToTable("PlanMaster", "dbo").HasKey(ee => ee.PlanID);


            modelBuilder.Entity<Role>().ToTable("Role", "dbo").HasKey(ee => ee.RoleId);


            modelBuilder.Entity<MemberRegistration>().ToTable("MemberRegistration", "dbo").HasKey(ee => ee.MemberId);


            modelBuilder.Entity<Users>().ToTable("Users", "dbo").HasKey(ee => ee.UserId);
            modelBuilder.Entity<Users>().Property(b => b.CurrentBal).HasDefaultValueSql("0");
            modelBuilder.Entity<Users>().Property(b => b.IsTermsAndConditions).HasDefaultValueSql("0");
            modelBuilder.Entity<Users>().Property(b => b.IsPasswordUpdated).HasDefaultValueSql("0");
            modelBuilder.Entity<Users>().Property(b => b.Status).HasDefaultValueSql("0");

            modelBuilder.Entity<AllGame>().ToTable("AllGame").HasKey(ee => ee.GameId);



            modelBuilder.Entity<UsersInRoles>().ToTable("UsersInRoles", "dbo").HasKey(ee => ee.UserRolesId);
            modelBuilder.Entity<UsersInRoles>()
            .HasOne(p => p.Users)
            .WithMany(b => b.UsersInRoles).
            HasForeignKey(p => p.UserId);


            modelBuilder.Entity<PaymentDetails>().ToTable("PaymentDetails", "dbo").HasKey(ee => ee.PaymentID);
        }
    }
}
