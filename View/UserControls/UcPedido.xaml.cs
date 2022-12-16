using Microsoft.TeamFoundation.Core.WebApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppSti3.ViewModel;

namespace WpfAppSti3.View.UserControls
{
    /// <summary>
    /// Interação lógica para UcPedido.xam
    /// </summary>
    public partial class UcPedido : UserControl
    {
        private UcPedidoViewModel UcPedidoVm = new UcPedidoViewModel();

        public UcPedido()
        {
            InitializeComponent();

            InicialzarOperacao();
        }

        private void CmbProduto_DropDownClosed(object sender, EventArgs e)
        {
            if (sender is ComboBox cmb && cmb.SelectedItem is ProdutoViewModel produto)
            {
                UcPedidoVm.ValorUnit = produto.Valor;
            }
        }

        private void BtnFinalizarPedido_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InicialzarOperacao()
        {
            DataContext = UcPedidoVm;

            UcPedidoVm.ListaClientes = new ObservableCollection<ClienteViewModel>
            {
                new ClienteViewModel{ Nome =  "Cliente 1"},
                new ClienteViewModel{ Nome =  "Cliente 2"},
            };

            UcPedidoVm.ListaProdutos = new ObservableCollection<ProdutoViewModel>
            {
                 new ProdutoViewModel{ Nome =  "Produto 1", Valor=10},
                  new ProdutoViewModel{ Nome =  "Produto 2", Valor=20},
            };

            UcPedidoVm.ListaPagamentos = new ObservableCollection<string>
            {
                "Dinheiro",
                "Boleto",
                "Cartão de Crédito",
                "Cartão de Débito",
                "PIX",
            };

            UcPedidoVm.Quantidade = 1;
            UcPedidoVm.ItensAdicionados = new ObservableCollection<UcPedidoItemViewModel>();
        }
        private void AdicionarItem()
        {
            var produtoSelecionado = CmbProduto.SelectedItem as ProdutoViewModel;

            var ItemVm = new UcPedidoItemViewModel
            {
                Nome = produtoSelecionado.Nome,
                Quantidade = UcPedidoVm.Quantidade,
                ValorUnit = UcPedidoVm.ValorUnit,

                ValorTotalItem = UcPedidoVm.Quantidade * UcPedidoVm.ValorUnit

            };

            UcPedidoVm.ItensAdicionados.Add(ItemVm);

            UcPedidoVm.ValorTotalPedidos = UcPedidoVm.ItensAdicionados.Sum(i => i.ValorTotalItem);
        }

        private void BtnAdicionarItem_Click(object sender, RoutedEventArgs e)
        {
            AdicionarItem();
        }
    }
  
}
