using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WpfAppSti3.View.UserControls;
using WpfAppSti3.ViewModel;

namespace WpfAppSti3.View.UserControls
{
    /// <summary>
    /// Interação lógica para UcProdutos.xam
    /// </summary>
    public partial class UcProdutos : UserControl
    {

        private UcProdutoViewModel UcProdutoVm = new UcProdutoViewModel();

        public UcProdutos()
        {
            InitializeComponent();

            DataContext = UcProdutoVm;
            UcProdutoVm.ProdutosAdicionados = new ObservableCollection<ProdutoViewModel>();
          
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarProduto())
                return;

            if (UcProdutoVm.Alteracao)
            {
                AlterarProduto();
            }
            else
            {
                AdicionarProduto();
            }
            LimparCampo();
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            var produto = (sender as Button).Tag as ProdutoViewModel;
            PreencherCampo(produto);
        }

        private void AdicionarProduto()
        {
           
            var novoProduto = new ProdutoViewModel
            {
                Nome = UcProdutoVm.Nome,
                Valor = UcProdutoVm.Valor
            };

            UcProdutoVm.ProdutosAdicionados.Add(novoProduto);
        }


        private void PreencherCampo(ProdutoViewModel produto)
        {
            UcProdutoVm.Nome = produto.Nome;
            UcProdutoVm.Valor = produto.Valor;

            UcProdutoVm.Alteracao = true;
        }
        private void AlterarProduto()
        {

        }

        private void LimparCampo()
        {
            UcProdutoVm.Nome = "";
            UcProdutoVm.Valor = 0;

            UcProdutoVm.Alteracao = false;

        }

        private bool ValidarProduto()
        {
            if (string.IsNullOrEmpty(UcProdutoVm.Nome))
            {
                MessageBox.Show("O campo nome é obrigatório", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);

                return false;
            }

            return true;
        }
        

        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TxtValor_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }

    
}