using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Estoque.WebAPI.Models
{
    public partial class Produto
    {
        public Produto()
        {
            Movimento = new HashSet<Movimento>();
        }
        [Required]
        public int CodProduto { get; set; }
        [StringLength(40, MinimumLength = 3)]
        [Required]
        public string Nome { get; set; }
        public int? Quantidade { get; set; }
        [Range(0, 100)]
        public double? ValorCusto { get; set; }
        [Range(0, 100)]
        public double? ValorVenda { get; set; }
        public int CodCategoria { get; set; }
        [JsonIgnore]
        public virtual Categoria CodCategoriaNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Movimento> Movimento { get; set; }
    }
}
