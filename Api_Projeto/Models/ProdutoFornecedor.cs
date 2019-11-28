using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class ProdutoFornecedor
    {
        public int IdProdutoFornecedor { get; set; }
        public int IdProduto { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Produto IdProdutoNavigation { get; set; }
    }
}
