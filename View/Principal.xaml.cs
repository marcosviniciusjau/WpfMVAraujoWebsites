using System.Windows;
using System.Windows.Controls;
using WpfMVAraujoWebsites.Data.Context;
using WpfMVAraujoWebsites.View.UserControls;

namespace WpfMVAraujoWebsites.View
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

            using var context = new WpfMVAraujoWebsitesContext();
            context.AplicarMigracoes();
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

        private void Grid_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
