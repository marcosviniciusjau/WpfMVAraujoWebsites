﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVAraujoWebsites.View.UserControls;

namespace WpfMVAraujoWebsites.ViewModel
{
    public class UcProdutoViewModel : PropertyChange
    {

        private long _id;

        public long Id
        {
            get => _id;
            set
            {
                _id = value;

                OnPropertyChanged(nameof(Id));
            }
        }

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

        private bool _alteracao;

        public bool Alteracao
        {
            get => _alteracao;
            set
            {
                _alteracao = value;

                OnPropertyChanged(nameof(Alteracao));
            }
        }

        private ObservableCollection<ProdutoViewModel> _produtosAdicionados;

        public ObservableCollection<ProdutoViewModel> ProdutosAdicionados 
        {
          get => _produtosAdicionados;
            set
            {
                _produtosAdicionados = value;

                OnPropertyChanged(nameof(ProdutosAdicionados));
    }
}
    }
}
