using System;

namespace WpfMVAraujoWebsites.Data.Entitites
{
    public class ItemPedido
    {
        public long Id { get; set; }
        public long IdPedido { get; set; }
        public long IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }

    }
}
