
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemadeVentas.DAL;
using SistemadeVentas.Models;

namespace SistemadeVentas.Services
{
    public class FacturacionService(Contexto contexto)
    {

        public async Task<bool> Existe(int facturacionid)
        {
            return await contexto.Facturaciones.AnyAsync(c => c.FacturaId == facturacionid);
        }

        public async Task<bool> Insertar(Facturacion factura)
        {
            contexto.Facturaciones.Add(factura);
            await AfectarFacturas(factura.DetalleFactura.ToArray());
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task AfectarFacturas(DetalleFactura[] detalle)
        {
            foreach (var item in detalle)
            {
                var producto = await contexto.Productos.SingleAsync(p => p.ProductoId == item.ProductoId);
               
            }
        }
        public async Task<bool> Modificar(Facturacion factura)
        {
            contexto.Update(factura);
            return await contexto.SaveChangesAsync() > 0;

        }

        public async Task<bool> Guardar(Facturacion factura)
        {
            if (!await Existe(factura.FacturaId))
            {
                return await Insertar(factura);
            }
            else
            {
                return await Modificar(factura);
            }
        }

        //Buscar
        public async Task<Facturacion> Buscar(int facturaid)
        {
            return await contexto.Facturaciones
                .Include(d => d.DetalleFactura)
                .FirstOrDefaultAsync(r => r.FacturaId == facturaid);
        }

        public async Task<bool> Eliminar(int facturaId)
        {
            return await contexto.Facturaciones.Include(c => c.DetalleFactura)
                .Where(c => c.FacturaId == facturaId)
                .ExecuteDeleteAsync() > 0;
        }
        // Listar
        public async Task<List<Facturacion>> Listar(Expression<Func<Facturacion, bool>> criterio)
        {
            return await contexto.Facturaciones
                .Include(d => d.DetalleFactura)
                .Where(criterio)
                 .AsNoTracking()
                .ToListAsync();
        }
    }
}

