using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemadeVentas.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturaciones",
                columns: table => new
                {
                    FacturaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCliente = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FechaFactura = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturaciones", x => x.FacturaId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    CodigoProducto = table.Column<string>(type: "TEXT", nullable: false),
                    Proveedor = table.Column<string>(type: "TEXT", nullable: false),
                    EstaActivo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFactura",
                columns: table => new
                {
                    DetalleFacturaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InventarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "TEXT", nullable: false),
                    Subtotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    FacturacionFacturaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFactura", x => x.DetalleFacturaId);
                    table.ForeignKey(
                        name: "FK_DetalleFactura_Facturaciones_FacturacionFacturaId",
                        column: x => x.FacturacionFacturaId,
                        principalTable: "Facturaciones",
                        principalColumn: "FacturaId");
                    table.ForeignKey(
                        name: "FK_DetalleFactura_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    InventarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadDisponible = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaUltimaActualizacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.InventarioId);
                    table.ForeignKey(
                        name: "FK_Inventarios_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Categoria", "CodigoProducto", "Descripcion", "EstaActivo", "Nombre", "Precio", "Proveedor" },
                values: new object[,]
                {
                    { 1, "Herramientas", "H001", "Martillo de acero de 500g", true, "Martillo de acero", 15.99m, "Ferretería A" },
                    { 2, "Herramientas", "H002", "Destornillador Phillips de acero inoxidable", true, "Destornillador Phillips", 5.50m, "Ferretería A" },
                    { 3, "Herramientas", "H003", "Llave inglesa ajustable de 8 pulgadas", true, "Llave inglesa", 12.30m, "Ferretería A" },
                    { 4, "Pinturas", "P001", "Pintura acrílica color blanco", true, "Pintura acrílica", 20.00m, "Pinturas B" },
                    { 5, "Pinturas", "P002", "Brocha de 2 pulgadas para pintura", true, "Brocha de pintura", 3.75m, "Pinturas B" },
                    { 6, "Pinturas", "P003", "Rodillo de pintura de 10 pulgadas", true, "Rodillo de pintura", 7.25m, "Pinturas B" },
                    { 7, "Plomería", "P004", "Tubería PVC de 2 pulgadas, longitud de 3m", true, "Tubería PVC 2\"", 10.50m, "Plomería C" },
                    { 8, "Plomería", "P005", "Codo PVC de 90 grados", true, "Codo PVC 90°", 2.00m, "Plomería C" },
                    { 9, "Plomería", "P006", "Pegamento especial para PVC", true, "Pegamento para PVC", 4.75m, "Plomería C" },
                    { 10, "Escaleras", "E001", "Escalera de aluminio de 3 escalones", true, "Escalera de aluminio", 75.00m, "Escaleras D" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_FacturacionFacturaId",
                table: "DetalleFactura",
                column: "FacturacionFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_ProductoId",
                table: "DetalleFactura",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_ProductoId",
                table: "Inventarios",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleFactura");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "Facturaciones");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
