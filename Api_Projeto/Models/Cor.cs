using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class Cor
    {
        public Cor()
        {
            Produto = new HashSet<Produto>();
        }

        public int IdCor { get; set; }
        public string DsCor { get; set; }
        public DateTime? DtCadastro { get; set; }
        public DateTime? DtAtualizado { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }
    }
}
