using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppSti3.View.UserControls;

namespace WpfAppSti3.ViewModel
{
    public class UcProdutoViewModel : PropertyChange
    {
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

        private decimal _valor;

        public decimal Valor
        {
            get => _valor;
            set
            {
                _valor = value;

                OnPropertyChanged(nameof(Valor));
            }
        }

    }
}
