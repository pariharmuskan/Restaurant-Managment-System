using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyRestaurant.Migrations
{
    public partial class createSubmenu2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "SubMenus2",
                columns: table => new
                {
                    SubMenuId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubMenuName = table.Column<string>(type: "text", nullable: false),
                    SubMenuImage = table.Column<byte[]>(type: "bytea", nullable: false),
                    Price = table.Column<string>(type: "text", nullable: false),
                    MenuId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubMenus2", x => x.SubMenuId);
                    table.ForeignKey(
                        name: "FK_SubMenus2_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubMenus2_MenuId",
                table: "SubMenus2",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubMenus2");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "SubMenus2",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
