using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemadeVentas.Models
{
    public class Facturacion
    {
        [Key]
        public int FacturaId { get; set; }  // Identificador único de la factura

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del cliente no puede exceder los 100 caracteres.")]
        public string NombreCliente { get; set; }  // Nombre del cliente

        [Required(ErrorMessage = "La fecha de la factura es obligatoria.")]
        public DateTime FechaFactura { get; set; }  // Fecha de la facturación

        [Required(ErrorMessage = "El total de la factura es obligatorio.")]
        [Range(0.01, 1000000.00, ErrorMessage = "El total debe ser mayor que 0.")]
        public decimal Total { get; set; }  // Total de la venta

        // Relación con los productos vendidos
        [Required(ErrorMessage = "Debe haber al menos un producto en la factura.")]
        public List<DetalleFactura> DetallesFactura { get; set; }  // Lista de productos vendidos y sus cantidades

        public string MetodoPago { get; set; }  // Opcional: Método de pago utilizado (efectivo, tarjeta, etc.)
    }
}
