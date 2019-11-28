using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Produto = new HashSet<Produto>();
        }

        public int IdGrade { get; set; }
        public string DsGrade { get; set; }
        public DateTime? DtCadastro { get; set; }
        public DateTime? DtAtualizado { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }
    }
}
