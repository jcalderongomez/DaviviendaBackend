using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entidades
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }
        public int ProveedorId { get; set; }
        
        [ForeignKey ("ProveedorId")]
        public Proveedor Proveedor { get; set; }
    }
}