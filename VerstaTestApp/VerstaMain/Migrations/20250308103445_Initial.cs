using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerstaMain.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    SenderCity = table.Column<string>(type: "longtext", nullable: false),
                    SenderHomeAddress = table.Column<string>(type: "longtext", nullable: false),
                    ReceiverCity = table.Column<string>(type: "longtext", nullable: false),
                    ReceiverHomeAddress = table.Column<string>(type: "longtext", nullable: false),
                    OrderWeight = table.Column<float>(type: "float", nullable: false),
                    OrderPickupTime = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
