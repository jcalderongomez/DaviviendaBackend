using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Config
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
        {
            public void Configure(EntityTypeBuilder<Proveedor> builder){
                builder.Property(p => p.Id).IsRequired();
                builder.Property(p => p.Rut).IsRequired();
                builder.Property(p => p.Nombre).IsRequired().HasMaxLength(50);
                builder.Property(p => p.Telefono).IsRequired().HasMaxLength(50);
                builder.Property(p => p.Pagina).IsRequired(false).HasMaxLength(500);
            }
    }
}