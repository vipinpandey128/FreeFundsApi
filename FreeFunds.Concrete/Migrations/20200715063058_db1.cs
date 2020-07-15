using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeFundsApi.Concrete.Migrations
{
    public partial class db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AllGame",
                columns: table => new
                {
                    GameId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(nullable: true),
                    SchemeId = table.Column<int>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllGame", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "MemberRegistration",
                schema: "dbo",
                columns: table => new
                {
                    MemberId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberNo = table.Column<string>(nullable: true),
                    MemberFName = table.Column<string>(nullable: false),
                    MemberLName = table.Column<string>(nullable: false),
                    MemberMName = table.Column<string>(nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    Age = table.Column<string>(nullable: false),
                    Contactno = table.Column<string>(nullable: false),
                    EmailId = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    PlanID = table.Column<int>(nullable: true),
                    SchemeID = table.Column<int>(nullable: true),
                    Createdby = table.Column<long>(nullable: true),
                    ModifiedBy = table.Column<long>(nullable: true),
                    JoiningDate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    MainMemberId = table.Column<long>(nullable: true),
                    MemImagePath = table.Column<string>(nullable: true),
                    MemImagename = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRegistration", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                schema: "dbo",
                columns: table => new
                {
                    PaymentID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanID = table.Column<int>(nullable: false),
                    WorkouttypeID = table.Column<int>(nullable: true),
                    Paymenttype = table.Column<string>(nullable: true),
                    PaymentFromdt = table.Column<DateTime>(nullable: false),
                    PaymentTodt = table.Column<DateTime>(nullable: false),
                    PaymentAmount = table.Column<decimal>(nullable: true),
                    NextRenwalDate = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Createdby = table.Column<int>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    RecStatus = table.Column<string>(nullable: true),
                    MemberID = table.Column<long>(nullable: true),
                    MemberNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.PaymentID);
                });

            migrationBuilder.CreateTable(
                name: "PeriodTB",
                schema: "dbo",
                columns: table => new
                {
                    PeriodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodTB", x => x.PeriodID);
                });

            migrationBuilder.CreateTable(
                name: "PlanMaster",
                schema: "dbo",
                columns: table => new
                {
                    PlanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanName = table.Column<string>(nullable: true),
                    PlanAmount = table.Column<decimal>(nullable: true),
                    ServicetaxAmount = table.Column<decimal>(nullable: true),
                    ServiceTax = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    CreateUserID = table.Column<int>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyUserID = table.Column<int>(nullable: true),
                    RecStatus = table.Column<bool>(nullable: false),
                    SchemeID = table.Column<int>(nullable: true),
                    PeriodID = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: true),
                    ServicetaxNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanMaster", x => x.PlanID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SchemeMaster",
                schema: "dbo",
                columns: table => new
                {
                    SchemeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchemeName = table.Column<string>(nullable: true),
                    Createdby = table.Column<int>(nullable: false),
                    Createddate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemeMaster", x => x.SchemeID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                schema: "dbo",
                columns: table => new
                {
                    TransationTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionTypeName = table.Column<string>(maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.TransationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    Contactno = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Createdby = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CurrentBal = table.Column<long>(nullable: false, defaultValueSql: "0"),
                    IsTermsAndConditions = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    IsPasswordUpdated = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    Status = table.Column<bool>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawalLimit",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxWithdrawalBal = table.Column<int>(nullable: false),
                    IsActive = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawalLimit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AllTransaction",
                columns: table => new
                {
                    TransactionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionTypeId = table.Column<int>(nullable: false),
                    BetId = table.Column<long>(nullable: false),
                    BetAmount = table.Column<decimal>(nullable: false),
                    CurrentBal = table.Column<decimal>(nullable: false, defaultValueSql: "0"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    IpAddress = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllTransaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_AllTransaction_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginStatus",
                columns: table => new
                {
                    LoginStatusId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastLogin = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginStatus", x => x.LoginStatusId);
                    table.ForeignKey(
                        name: "FK_LoginStatus_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bet",
                schema: "dbo",
                columns: table => new
                {
                    BetId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchemeID = table.Column<int>(nullable: false),
                    BetNumber = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    BetAmount = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bet", x => x.BetId);
                    table.ForeignKey(
                        name: "FK_Bet_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersInRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserRolesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInRoles", x => x.UserRolesId);
                    table.ForeignKey(
                        name: "FK_UsersInRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Winning",
                schema: "dbo",
                columns: table => new
                {
                    WinId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BetId = table.Column<long>(nullable: false),
                    WinAmount = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winning", x => x.WinId);
                    table.ForeignKey(
                        name: "FK_Winning_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllTransaction_UserId",
                table: "AllTransaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginStatus_UserId",
                table: "LoginStatus",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_UserId",
                schema: "dbo",
                table: "Bet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInRoles_UserId",
                schema: "dbo",
                table: "UsersInRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Winning_UserId",
                schema: "dbo",
                table: "Winning",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllGame");

            migrationBuilder.DropTable(
                name: "AllTransaction");

            migrationBuilder.DropTable(
                name: "LoginStatus");

            migrationBuilder.DropTable(
                name: "Bet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MemberRegistration",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PaymentDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PeriodTB",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlanMaster",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SchemeMaster",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TransactionType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UsersInRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Winning",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WithdrawalLimit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");
        }
    }
}
