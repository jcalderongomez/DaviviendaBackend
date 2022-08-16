using System.ComponentModel.DataAnnotations;

namespace Core.Entidades
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Pagina { get; set; }
    }
}