using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Funcionario = new HashSet<Funcionario>();
        }

        public int IdUsuario { get; set; }
        public string NmLogin { get; set; }
        public string CdSenha { get; set; }

        public virtual ICollection<Funcionario> Funcionario { get; set; }
    }
}
