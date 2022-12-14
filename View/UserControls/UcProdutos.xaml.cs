using System;
using System.Collections.Generic;
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
            UcProdutoVm.Nome = "Produto 1";
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }

    
}