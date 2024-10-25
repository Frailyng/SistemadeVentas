using System;
using System.ComponentModel.DataAnnotations;

namespace SistemadeVentas.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; } 

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }  // Nombre del producto

        [Required(ErrorMessage = "La descripción del producto es obligatoria.")]
        [StringLength(255, ErrorMessage = "La descripción no puede exceder los 255 caracteres.")]
        public string Descripcion { get; set; }  // Descripción del producto

        [Required(ErrorMessage = "El precio del producto es obligatorio.")]
        [Range(0.01, 10000.00, ErrorMessage = "El precio debe estar entre 0.01 y 10,000.")]
        public decimal Precio { get; set; }  // Precio del producto

        [Required(ErrorMessage = "La categoría del producto es obligatoria.")]
        public string Categoria { get; set; }  // Categoría del producto

        [Required(ErrorMessage = "El código del producto es obligatorio.")]
        public string CodigoProducto { get; set; }  // Código único del producto

        [Required(ErrorMessage = "El proveedor del producto es obligatorio.")]
        public string Proveedor { get; set; }  // Proveedor del producto

        public bool EstaActivo { get; set; }  // Indica si el producto está activo para la venta
    }
}
