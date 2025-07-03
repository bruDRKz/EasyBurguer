using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyBurguer.Migrations
{
    /// <inheritdoc />
    public partial class CarrinhoCompraItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrinhoCompraItems",
                columns: table => new
                {
                    CarrinhoCompraItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LancheID = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    CarrinhoCompraID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoCompraItems", x => x.CarrinhoCompraItemID);
                    table.ForeignKey(
                        name: "FK_CarrinhoCompraItems_Lanches_LancheID",
                        column: x => x.LancheID,
                        principalTable: "Lanches",
                        principalColumn: "LancheID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompraItems_LancheID",
                table: "CarrinhoCompraItems",
                column: "LancheID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoCompraItems");
        }
    }
}
