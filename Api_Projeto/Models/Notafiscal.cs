using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{

    public partial class Notafiscal
    {
        public Notafiscal()  
        {
            Estoque = new HashSet<Estoque>();
            ItemPedido = new HashSet<ItemPedido>();
            Parcelas = new HashSet<Parcelas>();
            ProdutoTamanhos = new HashSet<ProdutoTamanho>();
        }

        

        public int IdNotafiscal { get; set; }
        public int IdCliente { get; set; }
        public string DsTipo { get; set; }
        public int? IdFuncionario { get; set; }
        public decimal? VlTotal { get; set; }
        public string DsObservacoes { get; set; }
        public string DsStatus { get; set; }
        public DateTime? DtCriacao { get; set; }
        public DateTime? DtAlteracao { get; set; }
               


        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Funcionario IdFuncionarioNavigation { get; set; }
        public virtual ICollection<Estoque> Estoque { get; set; }

        public virtual ICollection<ProdutoTamanho> ProdutoTamanhos { get; set; }

        public virtual ICollection<ItemPedido> ItemPedido { get; set; }
        public virtual ICollection<Parcelas> Parcelas { get; set; }
    }
}
