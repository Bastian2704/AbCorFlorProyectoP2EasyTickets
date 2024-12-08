using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbCorFlorProyectoP2EasyTicketsMVC.Migrations
{
    /// <inheritdoc />
    public partial class ACF1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACFTicket",
                columns: table => new
                {
                    ACFTicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACFEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACFFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACFLugar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACFButacaSeccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACFPrecio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ACFTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACFVendido = table.Column<bool>(type: "bit", nullable: false),
                    ACFContrasenia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACFTicket", x => x.ACFTicketID);
                });

            migrationBuilder.CreateTable(
                name: "ACFReviews",
                columns: table => new
                {
                    ACFReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACFComentario = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ACFCalificacion = table.Column<int>(type: "int", nullable: false),
                    ACFFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ACFTicketID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACFReviews", x => x.ACFReviewID);
                    table.ForeignKey(
                        name: "FK_ACFReviews_ACFTicket_ACFTicketID",
                        column: x => x.ACFTicketID,
                        principalTable: "ACFTicket",
                        principalColumn: "ACFTicketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACFReviews_ACFTicketID",
                table: "ACFReviews",
                column: "ACFTicketID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACFReviews");

            migrationBuilder.DropTable(
                name: "ACFTicket");
        }
    }
}
