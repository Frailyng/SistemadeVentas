using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemadeVentas.Models
{
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
