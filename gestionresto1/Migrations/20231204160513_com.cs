using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestionresto1.Migrations
{
    /// <inheritdoc />
    public partial class com : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    idCategorie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.idCategorie);
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    idcommande = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomuser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenomuser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomproduit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    prix = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.idcommande);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    idusers = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.idusers);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    idProduit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prix = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categrieId = table.Column<int>(type: "int", nullable: true),
                    CategorieidCategorie = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.idProduit);
                    table.ForeignKey(
                        name: "FK_Produits_Categories_CategorieidCategorie",
                        column: x => x.CategorieidCategorie,
                        principalTable: "Categories",
                        principalColumn: "idCategorie");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CategorieidCategorie",
                table: "Produits",
                column: "CategorieidCategorie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
