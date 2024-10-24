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

    public class DetalleFactura
    {
        [Key]
        public int DetalleFacturaId { get; set; }  // Identificador único del detalle de la factura

        [Required(ErrorMessage = "El producto es obligatorio.")]
        [ForeignKey("Producto")]  // Relación con la tabla de Productos
        public int ProductoId { get; set; }  // ID del producto vendido

        public Productos Producto { get; set; }  // Referencia al producto

        [Required(ErrorMessage = "La cantidad vendida es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0.")]
        public int Cantidad { get; set; }  // Cantidad vendida del producto

        [Required(ErrorMessage = "El precio unitario es obligatorio.")]
        [Range(0.01, 10000.00, ErrorMessage = "El precio unitario debe ser mayor que 0.")]
        public decimal PrecioUnitario { get; set; }  // Precio unitario del producto

        [Required(ErrorMessage = "El subtotal es obligatorio.")]
        public decimal Subtotal { get; set; }  // Subtotal (Cantidad * PrecioUnitario)
    }
}
