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
                Nome = pedidoViewModel.Nome,
                Cidade = pedidoViewModel.Cidade,
                DataNascimento = pedidoViewModel.DataNascimento,
                Endereco = pedidoViewModel.Endereco,
                Cep = pedidoViewModel.Cep
            });

            _context.SaveChanges();
        }

        public void Alterar(PedidoViewModel pedidoViewModel)
        {
            var pedido = _context.Pedidos.First(x => x.Id == pedidoViewModel.Id);

            pedido.Nome = pedidoViewModel.Nome;
            pedido.Cep = pedidoViewModel.Cep;
            pedido.Cidade = pedidoViewModel.Cidade;
            pedido.DataNascimento = pedidoViewModel.DataNascimento;
            pedido.Endereco = pedidoViewModel.Endereco;

            _context.SaveChanges();

        }

        public void Remover(long id)
        {
            var pedido = _context.Clientes.First(x => x.Id == id);

            _context.Clientes.Remove(pedido);
            _context.SaveChanges();
        }

        public List<PedidoViewModel> Listar()
        {

            return _context.Pedidos.AsNoTracking()

                .Select(s => new PedidoViewModel
                {
                    Id = s.Id,
                    Nome = s.Nome,
                    Cep = s.Cep,
                    Cidade = s.Cidade,
                    DataNascimento = s.DataNascimento,
                    Endereco = s.Endereco

                }).ToList()
                .OrderBy(x => x.Nome).ToList();
        }
    }
}
