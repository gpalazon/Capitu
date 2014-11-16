using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitu.MVC.Models
{
    public class FornecedorVM
    {
        public FornecedorVO Fornecedor { get; set; }

        public UsuarioVO Usuario { get; set; }
    }
}