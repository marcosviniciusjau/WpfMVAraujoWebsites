using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            UcProdutoVm.ProdutosAdicionados = new ObservableCollection<ProdutoViewModel>
            {
                new ProdutoViewModel { Nome = "Tênis" , Valor=10 },
                 new ProdutoViewModel { Nome = "Camiseta", Valor = 10 },
                  new ProdutoViewModel { Nome = "Shorts", Valor = 10 }
            };
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    
}