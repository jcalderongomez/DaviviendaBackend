using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entidades
{
    public class Venta
    {        
        [Key]
        public int Id { get; set; }
        public string FechaVenta { get; set; }

        public int ClienteId { get; set; }
        
        [ForeignKey ("ClienteId")]
        public Cliente Cliente {get; set; }
        
        public int ProductoId { get; set; }
        
        [ForeignKey ("ProductoId")]
        public Producto Producto  {get; set; }
        
        public double Descuento { get; set; }
        public double Total { get; set; }
    }
}