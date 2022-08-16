using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Config
{
    public class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
     public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.FechaVenta).IsRequired();
            builder.Property(p => p.ClienteId).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ProductoId).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Descuento).IsRequired();
            builder.Property(p => p.Total).IsRequired();
            
            //TODO Relaciones
            builder.HasOne(p => p.Cliente).WithMany().HasForeignKey(p => p.ClienteId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Producto).WithMany().HasForeignKey(p => p.ProductoId).OnDelete(DeleteBehavior.NoAction);
            
        }   
    }
}