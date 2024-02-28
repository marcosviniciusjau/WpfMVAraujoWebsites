using WpfMVAraujoWebsites.Data.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfMVAraujoWebsites.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.MetodoPagamento).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Preco).HasColumnType("decimal(15,2)").IsRequired();

            builder.HasMany(f => f.ItemPedido).WithOne(p => p.Pedido).HasForeignKey(p => p.IdPedido).IsRequired();
        }
    }
}