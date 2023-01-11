using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppSti3.Data.Context;
using WpfAppSti3.Data.Entidades;
using WpfAppSti3.View.UserControls;
using WpfAppSti3.ViewModel;

namespace WpfAppSti3.Business
{
    public class PedidoBusiness
    {
        private readonly WpfAppSti3Context _context;

        public PedidoBusiness()
        {
            _context = new WpfAppSti3Context();
        }

        public void Adicionar(PedidoViewModel pedidoViewModel)
        {


            _context.Pedidos.Add(new Pedido
            {
                ClienteId = pedidoViewModel.ClienteId,
                FormPagamento = pedidoViewModel.FormPagamento,
                Valor = pedidoViewModel.Valor,
              
            });

        }
  
     
    }
}
