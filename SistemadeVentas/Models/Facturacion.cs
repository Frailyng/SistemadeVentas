using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemadeVentas.Models
{
    public class Facturacion
    {
        [Key]
        public int FacturaId { get; set; } 

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del cliente no puede exceder los 100 caracteres.")]
        public string NombreCliente { get; set; }  

        [Required(ErrorMessage = "La fecha de la factura es obligatoria.")]
        public DateTime FechaFactura { get; set; }  

        [Required(ErrorMessage = "El total de la factura es obligatorio.")]
        [Range(0.01, 1000000.00, ErrorMessage = "El total debe ser mayor que 0.")]
        public decimal Total { get; set; }  
        public string MetodoPago { get; set; }  

        public ICollection<DetalleFactura> DetalleFactura { get; set; } = new List<DetalleFactura>();
    }

}
