using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Web.Http.Validation;

namespace Estoque.WebAPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Movimento = new HashSet<Movimento>();
        }
        [Required]
        public int IdUsuario { get; set; }

        [StringLength(40, MinimumLength = 3)]
        [Required]
        public string NomeUsuario { get; set; }
        [Required]
        public string SenhaUsuario { get; set; }
        [Required]
        public int StatusUsuario { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        [JsonIgnore]
        public virtual ICollection<Movimento> Movimento { get; set; }
        [JsonIgnore]
        public string NomeValido
        {
            get => NomeUsuario;
        }

         public bool StatusValido()
        {
            if (StatusUsuario == 1 || StatusUsuario == 0)
            {
                return true;
            }
            return false;

        }

    }
}

