using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            Cliente = new HashSet<Cliente>();
            Funcionario = new HashSet<Funcionario>();
        }

        public int IdEndereco { get; set; }
        public int? DsCep { get; set; }
        public string DsLogradouro { get; set; }
        public string DsComplemento { get; set; }
        public string NmBairro { get; set; }
        public string NmCidadeUf { get; set; }
        public string DsProximidade { get; set; }
        public string DsObservacoes { get; set; }
        public string NmPais { get; set; }
        public string NmEstado { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Funcionario> Funcionario { get; set; }
    }
}
