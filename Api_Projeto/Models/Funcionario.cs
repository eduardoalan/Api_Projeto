using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Notafiscal = new HashSet<Notafiscal>();
        }

        public int IdFuncionario { get; set; }
        public string NmFuncionario { get; set; }
        public string DsCargo { get; set; }
        public string DsCtps { get; set; }
        public decimal VlSalario { get; set; }
        public int IdUsuario { get; set; }
        public int IdEndereco { get; set; }
        public string IeSexo { get; set; }
        public DateTime? DtNascimento { get; set; }
        public string DsCpf { get; set; }
        public string DsTelefone { get; set; }
        public DateTime? DtCadastro { get; set; }
        public DateTime? DtAtualizado { get; set; }
        public string DsRgUf { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Notafiscal> Notafiscal { get; set; }
    }
}
