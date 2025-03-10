using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyBurguer.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabelaCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao)" +
                "VALUES('Normal', 'Lanche feito com ingredientes normais.')");

            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao)" +
               "VALUES('Natural', 'Lanche feito com ingredientes saudaveis e sem embutidos.')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
