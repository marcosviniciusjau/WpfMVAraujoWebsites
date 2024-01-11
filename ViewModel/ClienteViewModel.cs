using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVAraujoWebsites.ViewModel
{
    public class ClienteViewModel
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cep { get; set; }
      

        public string Endereco { get; set; }

        public string Cidade { get; set; }
    }
}
