using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Produto = new HashSet<Produto>();
        }

        public int IdMarca { get; set; }
        public string DsMarca { get; set; }
        public DateTime? DtCadastro { get; set; }
        public DateTime? DtAtualizado { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }
    }
}
