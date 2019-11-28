using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class ItemPedido
    {
        public ItemPedido()
        {
            Notafiscals = new HashSet<Notafiscal>();
            ProdutoTamanhos = new HashSet<ProdutoTamanho>();
        }
        public int IdItemPedido { get; set; }
        public int VlQuantidade { get; set; }
        public decimal VlUnitario { get; set; }
        public decimal VlTotal { get; set; }
        public int IdProdutoTamanho { get; set; }
        public int IdNotafiscal { get; set; }

        public virtual Notafiscal IdNotafiscalNavigation { get; set; }
        public virtual ProdutoTamanho IdProdutoTamanhoNavigation { get; set; }

        public virtual ICollection<Notafiscal> Notafiscals { get; set; }

        public virtual ICollection<ProdutoTamanho> ProdutoTamanhos { get; set; }
    }
}
