using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Produto = new HashSet<Produto>();
        }

        public int IdDepartamento { get; set; }
        public string DsDepartamento { get; set; }
        public DateTime? DtCadastro { get; set; }
        public DateTime? DtAtualizado { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }
    }
}
