using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Estoque.WebAPI.Models
{
    public partial class Movimento
    {
        [Required]
        public int IdMovimento { get; set; }
        [Required]
        public int? CodProduto { get; set; }
        [Required]
        public int? IdUsuario { get; set; }
        [DataType(DataType.Currency)]
        public DateTime DataEntrada { get; set; }
        [DataType(DataType.Currency)]
        public DateTime DataSaida { get; set; }
        [JsonIgnore]
        public virtual Produto CodProdutoNavigation { get; set; }
        [JsonIgnore]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
