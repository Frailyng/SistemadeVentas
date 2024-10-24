using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemadeVentas.Models
{
    public class Inventario
    {
        [Key]
        public int InventarioId { get; set; }  

        [Required(ErrorMessage = "El producto es obligatorio.")]
        [ForeignKey("Producto")] 
        public int ProductoId { get; set; }  

        public Productos Producto { get; set; } 

        [Required(ErrorMessage = "La cantidad disponible es obligatoria.")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor o igual a 0.")]
        public int CantidadDisponible { get; set; }  

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        public DateTime FechaIngreso { get; set; }  

        public DateTime FechaUltimaActualizacion { get; set; }  
    }
}
