using Microsoft.EntityFrameworkCore;
using SistemadeVentas.DAL;
using SistemadeVentas.Models;
using System.Linq.Expressions;

namespace SistemadeVentas.Services
{
    public class InventarioService
    {
        private readonly Contexto _context;

        public InventarioService(Contexto contexto)
        {
            _context = contexto;
        }

        public async Task<bool> Guardar(Inventario inventario)
        {
            if (await Existe(inventario.InventarioId))
                return await Modificar(inventario);
            else
                return await Insertar(inventario);
        }

        public async Task<bool> Insertar(Inventario inventario)
        {
            _context.Inventarios.Add(inventario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Inventario inventario)
        {
            var inventarioExistente = await _context.Inventarios.FindAsync(inventario.InventarioId);
            if (inventarioExistente != null)
            {
                inventarioExistente.CantidadDisponible = inventario.CantidadDisponible; // Asegúrate de que esta propiedad sea actualizada
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> Existe(int inventarioId)
        {
            return await _context.Inventarios
                .AnyAsync(p => p.InventarioId == inventarioId);
        }

        public async Task<bool> Eliminar(int id)
        {
            var filasEliminadas = await _context.Inventarios
                .Where(p => p.InventarioId == id)
                .ExecuteDeleteAsync();
            return filasEliminadas > 0;
        }

        public async Task<Inventario?> Buscar(int id)
        {
            return await _context.Inventarios
                .Include(i => i.Producto)
                .FirstOrDefaultAsync(i => i.InventarioId == id);
        }

        public async Task<Inventario> BuscarPorId(int inventarioId)
        {
            return await _context.Inventarios.FirstOrDefaultAsync(a => a.InventarioId == inventarioId);
        }
        public async Task<bool> Actualizar(Inventario inventario)
        {
            try
            {
                _context.Inventarios.Update(inventario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<List<Inventario>> Listar(Expression<Func<Inventario, bool>> criterio)
        {
            return await _context.Inventarios
                .AsNoTracking()
                .Include(i => i.Producto)
                .Where(criterio)
                .ToListAsync();
        }
    }
}

