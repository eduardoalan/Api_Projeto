using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class Crediario
    {
        public Crediario()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int IdCrediario { get; set; }
        public string NmAvalista { get; set; }
        public bool? StAutorizaSms { get; set; }
        public bool? StAutorizaLigacoes { get; set; }
        public bool? StAutorizaCartas { get; set; }
        public bool? StAutorizaEmail { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
