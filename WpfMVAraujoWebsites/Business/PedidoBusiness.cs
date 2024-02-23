using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVAraujoWebsites.Data.Context;
using WpfMVAraujoWebsites.Data.Entidades;
using WpfMVAraujoWebsites.View.UserControls;
using WpfMVAraujoWebsites.ViewModel;

namespace WpfMVAraujoWebsites.Business
{
    public class PedidoBusiness
    {
        private readonly WpfMVAraujoWebsitesContext _context;

        public PedidoBusiness()
        {
            _context = new WpfMVAraujoWebsitesContext();
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
