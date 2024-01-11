﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVAraujoWebsites.ViewModel
{
    public class UcClienteViewModel: PropertyChange
    {
        private long _id;

        public long Id
        {
            get => _id;
            set
            {
                _id = value;

                OnPropertyChanged(nameof(Id));
            }
        }

        private string _nome;

        public string Nome
        {
            get => _nome;
            set
            {
                _nome = value;

                OnPropertyChanged(nameof(Nome));
            }
        }

        private DateTime _dataNascimento;

        public DateTime DataNascimento
        {
            get => _dataNascimento;
            set
            {
                _dataNascimento = value;

                OnPropertyChanged(nameof(DataNascimento));
            }
        }

        private string _cep;

        public string Cep
        {
            get => _cep;
            set
            {
                _cep = value;

                OnPropertyChanged(nameof(Cep));
            }
        }

        private string _endereco;

        public string Endereco
        {
            get => _endereco;
            set
            {
                _endereco = value;

                OnPropertyChanged(nameof(Endereco));
            }
        }

        private string _cidade;

        public string Cidade
        {
            get => _cidade;
            set
            {
                _cidade = value;

                OnPropertyChanged(nameof(Cidade));
            }
        }

        private bool _alteracao;

        public bool Alteracao
        {
            get => _alteracao;
            set
            {
                _alteracao = value;

                OnPropertyChanged(nameof(Alteracao));
            }
        }

        private ObservableCollection<ClienteViewModel> _clientesAdicionados;

        public ObservableCollection<ClienteViewModel> ClientesAdicionados
        {
            get => _clientesAdicionados;
            set
            {
                _clientesAdicionados = value;

                OnPropertyChanged(nameof(ClientesAdicionados));
            }
        }
    }
}
