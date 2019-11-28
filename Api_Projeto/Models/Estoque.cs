using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class Estoque    
    {
        public int IdEstoque { get; set; }
        public int IdProdutoTamanho { get; set; }
        public int VlQuantidade { get; set; }
        public DateTime DtCriacao { get; set; }
        public string DsTipo { get; set; }
        public string NmUsuario { get; set; }
        public int IdNotafiscal { get; set; }

        public virtual Notafiscal IdNotafiscalNavigation { get; set; }
        public virtual ProdutoTamanho IdProdutoTamanhoNavigation { get; set; }
    }
}
