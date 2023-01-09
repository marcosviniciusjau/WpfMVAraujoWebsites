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
    /// Interação lógica para UcClientes.xam
    /// </summary>
    public partial class UcClientes : UserControl
    {
        private UcClienteViewModel UcClienteVm = new UcClienteViewModel();

        public UcClientes()
        {
            InitializeComponent();

            DataContext= UcClienteVm;
     
            
           UcClienteVm.DataNascimento = new System.DateTime(1990, 1, 1);

           CarregarRegistros();

        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!ValidarCliente())
                    return;

                if (UcClienteVm.Alteracao)
                {
                    AlterarCliente();
                }
                else
                {
                    AdicionarCliente();
                }
                LimparCampo();
            }
        }

        private void AdicionarCliente()
        {

            var novoCliente = new ClienteViewModel
            {
                Nome = UcClienteVm.Nome,
                DataNascimento = UcClienteVm.DataNascimento,
                Cep = UcClienteVm.Cep,
                Endereco = UcClienteVm.Endereco,
                Cidade = UcClienteVm.Cidade,
            };

            new ClienteBusiness().Adicionar(novoCliente);

            CarregarRegistros();
        }

        private void CarregarRegistros()
        {
            UcClienteVm.ClientesAdicionados = new ObservableCollection<ClienteViewModel>(new ClienteBusiness().Listar());
        }

        private void AlterarCliente()
        {
            var clienteAlteracao = new ClienteViewModel
            {
                Id = UcClienteVm.Id,
                Nome = UcClienteVm.Nome,
                DataNascimento = UcClienteVm.DataNascimento,
                Cep = UcClienteVm.Cep,
                Cidade = UcClienteVm.Cidade,
                Endereco = UcClienteVm.Endereco,
              

            };
            new ClienteBusiness().Alterar(clienteAlteracao);

            CarregarRegistros();
        }

        private void LimparCampo()
        {
            UcClienteVm.Id = 0;
            UcClienteVm.Nome = "";
            UcClienteVm.DataNascimento = new System.DateTime(1990, 1, 1);
            UcClienteVm.Cep = "";
            UcClienteVm.Endereco = "";
            UcClienteVm.Cidade = "";
            UcClienteVm.Alteracao = false;

        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            var cliente = (sender as Button).Tag as ClienteViewModel;
            PreencherCampo(cliente);
        }


        private void PreencherCampo(ClienteViewModel cliente)
        {
            UcClienteVm.Id = cliente.Id;
            UcClienteVm.Nome = cliente.Nome;
            UcClienteVm.DataNascimento = cliente.DataNascimento;
            UcClienteVm.Cep = cliente.Cep;
            UcClienteVm.Endereco = cliente.Endereco;
            UcClienteVm.Cidade = cliente.Cidade;

            UcClienteVm.Alteracao = true;
        }

        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {
            var cliente = (sender as Button).Tag as ClienteViewModel;

            RemoverCliente(cliente.Id);
        }

        private void RemoverCliente(long id)
        {
            var resultado = MessageBox.Show("Tem certeza que deseja remover o cliente?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (resultado == MessageBoxResult.Yes)
            {
                new ClienteBusiness().Remover(id);
                CarregarRegistros();
                LimparCampo();
            }
        }
        private bool ValidarCliente()
        {
            if (string.IsNullOrEmpty(UcClienteVm.Nome))
            {
                MessageBox.Show("O campo nome é obrigatório", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);

                return false;
            }

            return true;
        }

    }
}
