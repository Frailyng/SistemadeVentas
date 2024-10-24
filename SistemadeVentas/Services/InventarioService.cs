using Microsoft.EntityFrameworkCore;
using SistemadeVentas.DAL;
using SistemadeVentas.Models;

namespace SistemadeVentas.Services
{
    public class InventarioService
    {
        private readonly Contexto _context;

        public InventarioService(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Guardar(Inventario inventario)
        {
            if (inventario.InventarioId == 0)
                return await Insertar(inventario);
            else
                return await Modificar(inventario);
        }

        public async Task<bool> Insertar(Inventario inventario)
        {
            try
            {
                await _context.Inventarios.AddAsync(inventario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Modificar(Inventario inventario)
        {
            try
            {
                _context.Inventarios.Update(inventario);
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
            var inventario = await _context.Inventarios.FindAsync(id);
            if (inventario == null) return false;

            try
            {
                _context.Inventarios.Remove(inventario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Inventario> Buscar(int id)
        {
            return await _context.Inventarios.FindAsync(id);
        }

        public async Task<List<Inventario>> Lista()
        {
            return await _context.Inventarios.ToListAsync();
        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Inventarios.AnyAsync(i => i.InventarioId == id);
        }
    }
}
