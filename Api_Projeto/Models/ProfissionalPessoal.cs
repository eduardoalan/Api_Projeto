using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class ProfissionalPessoal
    {
        public ProfissionalPessoal()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int IdProfissionalPessoal { get; set; }
        public string DsTrabalhoProfi { get; set; }
        public string DsAtividade { get; set; }
        public string DsEndereco { get; set; }
        public string DsTelefone { get; set; }
        public string IeEscolaridadePessoal { get; set; }
        public int? NrDependentes { get; set; }
        public string IeEstadoCivil { get; set; }
        public string NmConjuge { get; set; }
        public decimal? VlSalario { get; set; }
        public decimal? VlRendaMensal { get; set; }
        public int? VlTempoServico { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
