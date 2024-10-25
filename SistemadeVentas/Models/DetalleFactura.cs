using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemadeVentas.Models
{
    public class DetalleFactura
    {
        [Key]
        public int DetalleFacturaId { get; set; }

        public int InventarioId { get; set; }
        [Required(ErrorMessage = "El producto es obligatorio.")]

        public int ProductoId { get; set; }

        [Required(ErrorMessage = "La cantidad vendida es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio unitario es obligatorio.")]
        [Range(0.01, 10000.00, ErrorMessage = "El precio unitario debe ser mayor que 0.")]
        public decimal PrecioUnitario { get; set; }

        [Required(ErrorMessage = "El subtotal es obligatorio.")]
        public decimal Subtotal { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; } = null!;
    }
}
