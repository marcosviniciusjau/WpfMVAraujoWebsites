using System;

namespace WpfMVAraujoWebsites.Data.Entitites
{
    public class Pedido
    {
        public long Id { get; set; }
        public long IdProduto { get; set; }
        public string MetodoPagamento { get; set; }

        public decimal Preco { get; set; }

        public Cliente Cliente { get; set; }

        public List<ItemPedido> ItemPedido { get; set; }

    }
}
