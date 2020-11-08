using System;
using System.Collections.Generic;

namespace Estoque.WebAPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Movimento = new HashSet<Movimento>();
        }

        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public int StatusUsuario { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public virtual ICollection<Movimento> Movimento { get; set; }
    }
}
