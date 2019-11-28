using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Notafiscal = new HashSet<Notafiscal>();
            ProdutoFornecedor = new HashSet<ProdutoFornecedor>();
            Referencias = new HashSet<Referencias>();
        }

        public int IdCliente { get; set; }
        public int? IdProfissionalPessoal { get; set; }
        public int IdCrediario { get; set; }
        public string Nmcliente { get; set; }
        public DateTime DtNascimento { get; set; }
        public string DsCpfCnpj { get; set; }
        public string DsRgUf { get; set; }
        public string DsTipo { get; set; }
        public string DsNaturalidade { get; set; }
        public string IeSexo { get; set; }
        public bool? StFornecedor { get; set; }
        public DateTime? DtCadastro { get; set; }
        public DateTime? DtAtualizado { get; set; }
        public int IdEndereco { get; set; }

        public virtual Crediario IdCrediarioNavigation { get; set; }
        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual ProfissionalPessoal IdProfissionalPessoalNavigation { get; set; }
        public virtual ICollection<Notafiscal> Notafiscal { get; set; }
        public virtual ICollection<ProdutoFornecedor> ProdutoFornecedor { get; set; }
        public virtual ICollection<Referencias> Referencias { get; set; }
    }
}
