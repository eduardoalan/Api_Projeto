using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class Referencias
    {
        public int IdReferencias { get; set; }
        public string NmReferencia { get; set; }
        public string DsTelefone { get; set; }
        public string DsVinculado { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
