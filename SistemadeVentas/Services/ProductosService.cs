using Microsoft.EntityFrameworkCore;
using SistemadeVentas.DAL;
using SistemadeVentas.Models;
using System.Linq.Expressions;

namespace SistemadeVentas.Services
{
    public class ProductosService
    {
        private readonly Contexto _context;

        public ProductosService(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Guardar(Productos producto)
        {
            if (await Existe(producto.ProductoId)) // Verifica si el producto existe
            {
                return await Modificar(producto); // Si existe, llama al método Modificar
            }
            else
            {
                return await Insertar(producto); // Si no existe, llama al método Insertar
            }
        }


        public async Task<bool> Insertar(Productos producto)
        {
            try
            {
                await _context.Productos.AddAsync(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Modificar(Productos producto)
        {
            try
            {
                _context.Productos.Update(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            try
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Productos> Buscar(int id)
        {
            return await _context.Productos.FindAsync(id);
        }
        public async Task<List<Productos>> Listar(Expression<Func<Productos, bool>> criterio)
        {
            return await _context.Productos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();

        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Productos.AnyAsync(p => p.ProductoId == id);
        }

        public async Task<bool> Existe(string? descripcion, int? productoId = null)
        {
            return await _context.Productos
                .AnyAsync(p => p.Descripcion.Equals(descripcion));
        }


        public async Task<bool> Existe(int productoId, string? descripcion)
        {
            //TODO: Unir los dos existe en uno solo para reducir duplicidad de codigo.
            return await _context.Productos
                .AnyAsync(p => p.ProductoId != productoId && p.Descripcion.Equals(descripcion));
        }
    }
}
