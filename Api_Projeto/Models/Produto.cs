using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class Produto
    {
        public Produto()
        {
            ProdutoFornecedor = new HashSet<ProdutoFornecedor>();
            ProdutoTamanho = new HashSet<ProdutoTamanho>();
        }

        public int IdProduto { get; set; }
        public string DsProduto { get; set; }
        public int IdCor { get; set; }
        public int IdMarca { get; set; }
        public int IdDepartamento { get; set; }
        public int IdGrade { get; set; }
        public string NmColecao { get; set; }
        public string DsGrupo { get; set; }
        public decimal? VlCustoBase { get; set; }
        public decimal? VlCustoAquisicao { get; set; }
        public decimal? VlPrecoVenda { get; set; }
        public decimal? VlMarkup { get; set; }
        public DateTime? DtCadastro { get; set; }
        public DateTime? DtAtualizado { get; set; }

        public virtual Cor IdCorNavigation { get; set; }
        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual Grade IdGradeNavigation { get; set; }
        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual ICollection<ProdutoFornecedor> ProdutoFornecedor { get; set; }
        public virtual ICollection<ProdutoTamanho> ProdutoTamanho { get; set; }
    }
}
