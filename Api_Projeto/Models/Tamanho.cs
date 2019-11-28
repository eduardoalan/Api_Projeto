using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class Tamanho
    {
        public Tamanho()
        {
            ProdutoTamanho = new HashSet<ProdutoTamanho>();
        }

        public int IdTamanho { get; set; }
        public string DsTamanho { get; set; }
        public DateTime? DtCadastro { get; set; }
        public DateTime? DtAtualizado { get; set; }

        public virtual ICollection<ProdutoTamanho> ProdutoTamanho { get; set; }
    }
}
