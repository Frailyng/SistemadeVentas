using Microsoft.EntityFrameworkCore;
using SistemadeVentas.Models;
namespace SistemadeVentas.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
        : base(options) { }

    public DbSet<Productos> Productos { get; set; }

    public DbSet<Inventario> Inventario { get; set; }

    public DbSet<Facturacion> Facturaciones { get; set; }
}
