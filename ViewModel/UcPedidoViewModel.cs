using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppSti3.ViewModel
{
    public class UcPedidoViewModel: PropertyChange
    {
        private ObservableCollection<ClienteViewModel> _listaClientes;

        public ObservableCollection<ClienteViewModel> ListaClientes
        {
            get => _listaClientes;
            set
            {
                _listaClientes = value;

                OnPropertyChanged(nameof(ListaClientes));
            }
        }

        private ObservableCollection<ProdutoViewModel> _listaProdutos;

        public ObservableCollection<ProdutoViewModel> ListaProdutos
        {
            get => _listaProdutos;
            set
            {
                _listaProdutos = value;

                OnPropertyChanged(nameof(ListaProdutos));
            }
        }

        private ObservableCollection<string> _listaPagamentos;

        public ObservableCollection<string> ListaPagamentos
        {
            get => _listaPagamentos;
            set
            {
                _listaPagamentos = value;

                OnPropertyChanged(nameof(ListaPagamentos));
            }
        }

        private int _quantidade;

        public int Quantidade
        {
            get => _quantidade;
            set
            {
                _quantidade = value;

                OnPropertyChanged(nameof(Quantidade));
            }
        }

        private decimal _valorUnit;

        public decimal  ValorUnit
        {
            get => _valorUnit;
            set
            {
                _valorUnit = value;

                OnPropertyChanged(nameof(ValorUnit));
            }
        }

        private decimal _valorTotalPedidos;

        public decimal ValorTotalPedidos
        {
            get => _valorTotalPedidos;
            set
            {
                _valorTotalPedidos = value;

                OnPropertyChanged(nameof(ValorTotalPedidos));
            }
        }

        private ObservableCollection<UcPedidoItemViewModel> _itensAdicionados;

        public ObservableCollection<UcPedidoItemViewModel> ItensAdicionados
        {
            get => _itensAdicionados;
            set
            {
                _itensAdicionados = value;

                OnPropertyChanged(nameof(ItensAdicionados));
            }
        }

    }
}
