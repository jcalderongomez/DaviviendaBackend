using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Config
{
    public class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Nombre).IsRequired();
            builder.Property(p => p.Precio).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Stock).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ProveedorId).IsRequired();
            
            //TODO Relaciones
            builder.HasOne(p => p.Proveedor).WithMany().HasForeignKey(p => p.ProveedorId).OnDelete(DeleteBehavior.NoAction);    
        }
    }
}