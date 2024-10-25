using Microsoft.EntityFrameworkCore;
using SistemadeVentas.Models;
namespace SistemadeVentas.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
        : base(options) { }

    public DbSet<Productos> Productos { get; set; }

    public DbSet<Inventario> Inventarios { get; set; }

    public DbSet<Facturacion> Facturaciones { get; set; }

    public DbSet<DetalleFactura> DetalleFactura { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Productos>().HasData(new List<Productos>()
        {
            new Productos() { ProductoId = 1, Nombre = "Martillo de acero", Descripcion = "Martillo de acero de 500g", Precio = 15.99m, Categoria = "Herramientas", CodigoProducto = "H001", Proveedor = "Ferretería A", EstaActivo = true },
            new Productos() { ProductoId = 2, Nombre = "Destornillador Phillips", Descripcion = "Destornillador Phillips de acero inoxidable", Precio = 5.50m, Categoria = "Herramientas", CodigoProducto = "H002", Proveedor = "Ferretería A", EstaActivo = true },
            new Productos() { ProductoId = 3, Nombre = "Llave inglesa", Descripcion = "Llave inglesa ajustable de 8 pulgadas", Precio = 12.30m, Categoria = "Herramientas", CodigoProducto = "H003", Proveedor = "Ferretería A", EstaActivo = true },

            new Productos() { ProductoId = 4, Nombre = "Pintura acrílica", Descripcion = "Pintura acrílica color blanco", Precio = 20.00m, Categoria = "Pinturas", CodigoProducto = "P001", Proveedor = "Pinturas B", EstaActivo = true },
            new Productos() { ProductoId = 5, Nombre = "Brocha de pintura", Descripcion = "Brocha de 2 pulgadas para pintura", Precio = 3.75m, Categoria = "Pinturas", CodigoProducto = "P002", Proveedor = "Pinturas B", EstaActivo = true },
            new Productos() { ProductoId = 6, Nombre = "Rodillo de pintura", Descripcion = "Rodillo de pintura de 10 pulgadas", Precio = 7.25m, Categoria = "Pinturas", CodigoProducto = "P003", Proveedor = "Pinturas B", EstaActivo = true },

            new Productos() { ProductoId = 7, Nombre = "Tubería PVC 2\"", Descripcion = "Tubería PVC de 2 pulgadas, longitud de 3m", Precio = 10.50m, Categoria = "Plomería", CodigoProducto = "P004", Proveedor = "Plomería C", EstaActivo = true },
            new Productos() { ProductoId = 8, Nombre = "Codo PVC 90°", Descripcion = "Codo PVC de 90 grados", Precio = 2.00m, Categoria = "Plomería", CodigoProducto = "P005", Proveedor = "Plomería C", EstaActivo = true },
            new Productos() { ProductoId = 9, Nombre = "Pegamento para PVC", Descripcion = "Pegamento especial para PVC", Precio = 4.75m, Categoria = "Plomería", CodigoProducto = "P006", Proveedor = "Plomería C", EstaActivo = true },

            new Productos() { ProductoId = 10, Nombre = "Escalera de aluminio", Descripcion = "Escalera de aluminio de 3 escalones", Precio = 75.00m, Categoria = "Escaleras", CodigoProducto = "E001", Proveedor = "Escaleras D", EstaActivo = true }

        });
    }
}
