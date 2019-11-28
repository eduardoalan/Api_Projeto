using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class ProdutoTamanho
    {
        public ProdutoTamanho()
        {
            Estoque = new HashSet<Estoque>();
            ItemPedido = new HashSet<ItemPedido>();
        }

        public int IdProdutoTamanho { get; set; }
        public int IdProduto { get; set; }
        public int IdTamanho { get; set; }
        public int VlQuantidade { get; set; }

        public Notafiscal notafiscal { get; set; }

        public virtual Produto IdProdutoNavigation { get; set; }
        public virtual Tamanho IdTamanhoNavigation { get; set; }
        public virtual ICollection<Estoque> Estoque { get; set; }
        public virtual ICollection<ItemPedido> ItemPedido { get; set; }
    }
}
