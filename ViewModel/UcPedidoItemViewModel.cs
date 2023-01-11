using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppSti3.ViewModel
{
    public class UcPedidoItemViewModel
    {
        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorUnit { get; set; }

        public decimal ValorTotalItem { get; set; }

        public long ProdutoId { get; set; }
    }
}
