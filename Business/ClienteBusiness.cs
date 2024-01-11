﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVAraujoWebsites.Data.Context;
using WpfMVAraujoWebsites.Data.Entidades;
using WpfMVAraujoWebsites.ViewModel;

namespace WpfMVAraujoWebsites.Business
{
    public class ClienteBusiness
    {
        private readonly WpfMVAraujoWebsitesContext _context;

        public ClienteBusiness()
        {
            _context = new WpfMVAraujoWebsitesContext();
        }

        public void Adicionar(ClienteViewModel clienteViewModel)
        {


            _context.Clientes.Add(new Cliente
            {
                Nome = clienteViewModel.Nome,
                Cidade = clienteViewModel.Cidade,
                DataNascimento = clienteViewModel.DataNascimento,
                Endereco = clienteViewModel.Endereco,
                Cep = clienteViewModel.Cep
            });

            _context.SaveChanges();
        }

        public void Alterar(ClienteViewModel clienteViewModel)
        {
            var cliente = _context.Clientes.First(x => x.Id == clienteViewModel.Id);

            cliente.Nome = clienteViewModel.Nome;
            cliente.Cep = clienteViewModel.Cep;
            cliente.Cidade = clienteViewModel.Cidade;
            cliente.DataNascimento = clienteViewModel.DataNascimento;
            cliente.Endereco = clienteViewModel.Endereco;

            _context.SaveChanges();

        }

        public void Remover(long id)
        {
            var cliente = _context.Clientes.First(x => x.Id == id);

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public List<ClienteViewModel> Listar()
        {

            return _context.Clientes.AsNoTracking()

                .Select(s => new ClienteViewModel
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
