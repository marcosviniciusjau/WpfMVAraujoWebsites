
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
using WpfAppSti3.Business;
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
            FinalizarPedido();
        }

        private void InicialzarOperacao()
        {
            DataContext = UcPedidoVm;

            UcPedidoVm.ListaClientes = new ObservableCollection<ClienteViewModel>(new ClienteBusiness().Listar());
          
            UcPedidoVm.ListaProdutos = new ObservableCollection<ProdutoViewModel> (new ProdutoBusiness().Listar());


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

                ValorTotalItem = UcPedidoVm.Quantidade * UcPedidoVm.ValorUnit,
                ProdutoId= produtoSelecionado.Id

            };

            UcPedidoVm.ItensAdicionados.Add(ItemVm);

            UcPedidoVm.ValorTotalPedidos = UcPedidoVm.ItensAdicionados.Sum(i => i.ValorTotalItem);
           
            LimparCamposProduto();
        }
        private void LimparCamposProduto()
        {
            UcPedidoVm.Quantidade = 1;
            CmbProduto.SelectedItem = null;
            UcPedidoVm.ValorUnit = 0;
        }

        private void LimparTodosCampos()
        {
            UcPedidoVm.ItensAdicionados = new ObservableCollection<UcPedidoItemViewModel>();
            UcPedidoVm.ValorTotalPedidos = 0;
            CmbCliente.SelectedItem = null;
            CmbFormPagamento.SelectedItem = null;

            LimparCamposProduto();
        }

        private void FinalizarPedido()
        {
            var clienteSelecionado = CmbCliente.SelectedItem as ClienteViewModel;
            var FormPagamentoSelecionado = CmbFormPagamento.SelectedItem as string;

            var pedidoViewModel = new PedidoViewModel
            {
                ClienteId = clienteSelecionado.Id,
                FormPagamento = FormPagamentoSelecionado,
                Valor= UcPedidoVm.ValorTotalPedidos,
                ItemPedido= UcPedidoVm.ItensAdicionados.Select(s=> new ItensPedidosViewModel
               {
                    ProdutoId = s.ProdutoId,
                    Quantidade = s.Quantidade,
                    Valor= (int)s.ValorTotalItem
                }).ToList()
            };
            new PedidoBusiness().Adicionar(pedidoViewModel);
            MessageBox.Show("Pedido Realizado com sucesso", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            LimparTodosCampos();
        }
       
        private void BtnAdicionarItem_Click(object sender, RoutedEventArgs e)
        {
            AdicionarItem();
        }
    }
  
}
