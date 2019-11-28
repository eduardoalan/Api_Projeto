using System;
using System.Collections.Generic;

namespace Api_Projeto.Models
{
    public partial class Parcelas
    {
        public int IdParcelas { get; set; }
        public int IdNotafiscal { get; set; }
        public decimal VlParcela { get; set; }
        public DateTime DtVencimento { get; set; }

        public virtual Notafiscal IdNotafiscalNavigation { get; set; }
    }
}
