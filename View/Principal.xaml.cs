using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WpfAppSti3.Data.Context;
using WpfAppSti3.View.UserControls;
namespace WpfAppSti3.View
{
    /// <summary>
    /// Lógica interna para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
            AplicarMigracoes();

        }

        private void AplicarMigracoes()
        {
            using var context = new WpfAppSti3Context();
            context.AplicarMigracoes();
        }

        private void Testes()
        {
            using var context = new WpfAppSti3Context();
            context.Database.EnsureCreated();
        }

       private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            InicializarUc(sender);
        }

        private void InicializarUc(object sender)
        {
            if(sender is Button btn)
              {
                switch (btn.Name)
                {
                    case nameof(BtnProdutos):
                        Conteudo.Content = new UcProdutos();
                        break;

                        case nameof(BtnClientes):
                        Conteudo.Content = new UcClientes();
                        break;

                    case nameof(BtnPedidos):
                        Conteudo.Content = new UcPedido();
                        break;
                    default:
                        break;
                }           

            }
        }
    }
}
