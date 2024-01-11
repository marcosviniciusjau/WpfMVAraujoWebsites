using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVAraujoWebsites.ViewModel
{
    public class PedidoViewModel
    {
        public string FormPagamento { get; set; }

        public decimal Valor { get; set; }

        public long ClienteId { get; set; }

        public List<ItensPedidosViewModel> ItemPedido { get; set; }
    }
}
