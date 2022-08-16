using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Config
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {  
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Cedula).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Apellido).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Direccion).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Telefono).IsRequired().HasMaxLength(15);
        }
    }
}