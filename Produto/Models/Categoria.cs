using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Estoque.WebAPI.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Produto = new HashSet<Produto>();
        }
        [Required]
        public int CodCategoria { get; set; }
        [StringLength(40, MinimumLength = 3)]
        [Required]
        public string NomeCategoria { get; set; }
        [Range(0,1)]
        public int Status { get; set; }
       public DateTime? DataInclusao { get; set; }
       public DateTime? DataAlteracao { get; set; }
        [JsonIgnore]
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
