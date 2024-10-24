using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeVentas.DAL;
using SistemadeVentas.Models;

namespace SistemadeVentas.Services
{
    public class FacturacionService
    {
        private readonly Contexto _context;

        public FacturacionService(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Guardar(Facturacion facturacion)
        {
            if (facturacion.FacturaId == 0)
                return await Insertar(facturacion);
            else
                return await Modificar(facturacion);
        }

        public async Task<bool> Insertar(Facturacion facturacion)
        {
            try
            {
                await _context.Facturaciones.AddAsync(facturacion);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Modificar(Facturacion facturacion)
        {
            try
            {
                _context.Facturaciones.Update(facturacion);
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
            var facturacion = await _context.Facturaciones.FindAsync(id);
            if (facturacion == null) return false;

            try
            {
                _context.Facturaciones.Remove(facturacion);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Facturacion> Buscar(int id)
        {
            return await _context.Facturaciones.FindAsync(id);
        }

        public async Task<List<Facturacion>> Lista()
        {
            return await _context.Facturaciones.Include(f => f.DetallesFactura).ToListAsync();
        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Facturaciones.AnyAsync(f => f.FacturaId == id);
        }
    }
}

