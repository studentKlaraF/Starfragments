using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeminarskaNaloga.Migrations
{
    public partial class AppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racun_Uporabnik_UporabnikId",
                table: "Racun");

            migrationBuilder.DropForeignKey(
                name: "FK_ZgodovinaNarocanja_Uporabnik_UporabnikId",
                table: "ZgodovinaNarocanja");

            migrationBuilder.DropIndex(
                name: "IX_ZgodovinaNarocanja_UporabnikId",
                table: "ZgodovinaNarocanja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Uporabnik",
                table: "Uporabnik");

            migrationBuilder.DropIndex(
                name: "IX_Racun_UporabnikId",
                table: "Racun");

            migrationBuilder.AddColumn<string>(
                name: "UporabnikId1",
                table: "ZgodovinaNarocanja",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Uporabnik",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Uporabnik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Uporabnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Uporabnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Uporabnik",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Uporabnik",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Uporabnik",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Uporabnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Uporabnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Uporabnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Uporabnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Uporabnik",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Uporabnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Uporabnik",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Uporabnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UporabnikId1",
                table: "Racun",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Artikel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Uporabnik",
                table: "Uporabnik",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    priimek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZgodovinaNarocanja_UporabnikId1",
                table: "ZgodovinaNarocanja",
                column: "UporabnikId1");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_UporabnikId1",
                table: "Racun",
                column: "UporabnikId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Racun_Uporabnik_UporabnikId1",
                table: "Racun",
                column: "UporabnikId1",
                principalTable: "Uporabnik",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ZgodovinaNarocanja_Uporabnik_UporabnikId1",
                table: "ZgodovinaNarocanja",
                column: "UporabnikId1",
                principalTable: "Uporabnik",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racun_Uporabnik_UporabnikId1",
                table: "Racun");

            migrationBuilder.DropForeignKey(
                name: "FK_ZgodovinaNarocanja_Uporabnik_UporabnikId1",
                table: "ZgodovinaNarocanja");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_ZgodovinaNarocanja_UporabnikId1",
                table: "ZgodovinaNarocanja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Uporabnik",
                table: "Uporabnik");

            migrationBuilder.DropIndex(
                name: "IX_Racun_UporabnikId1",
                table: "Racun");

            migrationBuilder.DropColumn(
                name: "UporabnikId1",
                table: "ZgodovinaNarocanja");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Uporabnik");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Uporabnik");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Uporabnik");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Uporabnik");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Uporabnik");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Uporabnik");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Uporabnik");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Uporabnik");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Uporabnik");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Uporabnik");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Uporabnik");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Uporabnik");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Uporabnik");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Uporabnik");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Uporabnik");

            migrationBuilder.DropColumn(
                name: "UporabnikId1",
                table: "Racun");

            migrationBuilder.DropColumn(
                name: "img",
                table: "Artikel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Uporabnik",
                table: "Uporabnik",
                column: "UporabnikId");

            migrationBuilder.CreateIndex(
                name: "IX_ZgodovinaNarocanja_UporabnikId",
                table: "ZgodovinaNarocanja",
                column: "UporabnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_UporabnikId",
                table: "Racun",
                column: "UporabnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Racun_Uporabnik_UporabnikId",
                table: "Racun",
                column: "UporabnikId",
                principalTable: "Uporabnik",
                principalColumn: "UporabnikId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZgodovinaNarocanja_Uporabnik_UporabnikId",
                table: "ZgodovinaNarocanja",
                column: "UporabnikId",
                principalTable: "Uporabnik",
                principalColumn: "UporabnikId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
