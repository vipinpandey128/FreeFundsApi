﻿// <auto-generated />
using System;
using FreeFundsApi.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FreeFundsApi.Concrete.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200715063058_db1")]
    partial class db1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FreeFundsApi.Models.AllGame", b =>
                {
                    b.Property<long>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("GameName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("SchemeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("GameId");

                    b.ToTable("AllGame");
                });

            modelBuilder.Entity("FreeFundsApi.Models.AllTransaction", b =>
                {
                    b.Property<long>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("BetId")
                        .HasColumnType("bigint");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("CurrentBal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValueSql("0");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.HasIndex("UserId");

                    b.ToTable("AllTransaction");
                });

            modelBuilder.Entity("FreeFundsApi.Models.Bet", b =>
                {
                    b.Property<long>("BetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BetAmount")
                        .HasColumnType("int");

                    b.Property<int>("BetNumber")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SchemeID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BetId");

                    b.HasIndex("UserId");

                    b.ToTable("Bet","dbo");
                });

            modelBuilder.Entity("FreeFundsApi.Models.LoginStatus", b =>
                {
                    b.Property<long>("LoginStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("LoginStatus");
                });

            modelBuilder.Entity("FreeFundsApi.Models.MemberRegistration", b =>
                {
                    b.Property<long>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contactno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Createdby")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Dob")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("JoiningDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<long?>("MainMemberId")
                        .HasColumnType("bigint");

                    b.Property<string>("MemImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemImagename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberFName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberLName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberMName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<int?>("PlanID")
                        .HasColumnType("int");

                    b.Property<int?>("SchemeID")
                        .HasColumnType("int");

                    b.HasKey("MemberId");

                    b.ToTable("MemberRegistration","dbo");
                });

            modelBuilder.Entity("FreeFundsApi.Models.PaymentDetails", b =>
                {
                    b.Property<long>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Createdby")
                        .HasColumnType("int");

                    b.Property<long?>("MemberID")
                        .HasColumnType("bigint");

                    b.Property<string>("MemberNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NextRenwalDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("PaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentFromdt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaymentTodt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Paymenttype")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlanID")
                        .HasColumnType("int");

                    b.Property<string>("RecStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkouttypeID")
                        .HasColumnType("int");

                    b.HasKey("PaymentID");

                    b.ToTable("PaymentDetails","dbo");
                });

            modelBuilder.Entity("FreeFundsApi.Models.PeriodTB", b =>
                {
                    b.Property<int>("PeriodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PeriodID");

                    b.ToTable("PeriodTB","dbo");
                });

            modelBuilder.Entity("FreeFundsApi.Models.PlanMaster", b =>
                {
                    b.Property<int>("PlanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreateUserID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifyUserID")
                        .HasColumnType("int");

                    b.Property<int>("PeriodID")
                        .HasColumnType("int");

                    b.Property<decimal?>("PlanAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PlanName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RecStatus")
                        .HasColumnType("bit");

                    b.Property<int?>("SchemeID")
                        .HasColumnType("int");

                    b.Property<string>("ServiceTax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ServicetaxAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ServicetaxNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PlanID");

                    b.ToTable("PlanMaster","dbo");
                });

            modelBuilder.Entity("FreeFundsApi.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("RoleId");

                    b.ToTable("Role","dbo");
                });

            modelBuilder.Entity("FreeFundsApi.Models.SchemeMaster", b =>
                {
                    b.Property<int>("SchemeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Createdby")
                        .HasColumnType("int");

                    b.Property<DateTime>("Createddate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SchemeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("SchemeID");

                    b.ToTable("SchemeMaster","dbo");
                });

            modelBuilder.Entity("FreeFundsApi.Models.TransactionType", b =>
                {
                    b.Property<int>("TransationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("TransactionTypeName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TransationTypeId");

                    b.ToTable("TransactionType","dbo");
                });

            modelBuilder.Entity("FreeFundsApi.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contactno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Createdby")
                        .HasColumnType("int");

                    b.Property<long>("CurrentBal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("0");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPasswordUpdated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("IsTermsAndConditions")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users","dbo");
                });

            modelBuilder.Entity("FreeFundsApi.Models.UsersInRoles", b =>
                {
                    b.Property<int>("UserRolesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserRolesId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersInRoles","dbo");
                });

            modelBuilder.Entity("FreeFundsApi.Models.Winning", b =>
                {
                    b.Property<long>("WinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BetId")
                        .HasColumnType("bigint");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("WinAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("WinId");

                    b.HasIndex("UserId");

                    b.ToTable("Winning","dbo");
                });

            modelBuilder.Entity("FreeFundsApi.Models.WithdrawalLimit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<int>("MaxWithdrawalBal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WithdrawalLimit","dbo");
                });

            modelBuilder.Entity("FreeFundsApi.Models.AllTransaction", b =>
                {
                    b.HasOne("FreeFundsApi.Models.Users", "Users")
                        .WithMany("AllTransactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FreeFundsApi.Models.Bet", b =>
                {
                    b.HasOne("FreeFundsApi.Models.Users", "Users")
                        .WithMany("Bets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FreeFundsApi.Models.LoginStatus", b =>
                {
                    b.HasOne("FreeFundsApi.Models.Users", "Users")
                        .WithMany("LoginStatus")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FreeFundsApi.Models.UsersInRoles", b =>
                {
                    b.HasOne("FreeFundsApi.Models.Users", "Users")
                        .WithMany("UsersInRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FreeFundsApi.Models.Winning", b =>
                {
                    b.HasOne("FreeFundsApi.Models.Users", "Users")
                        .WithMany("Winnings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
