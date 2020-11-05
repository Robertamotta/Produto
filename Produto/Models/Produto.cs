using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.WebAPI.Models
{
    public class Produto
    {
         
        [Key]
        public int CodProduto { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double ValorCusto { get; set; }
        public double ValorVenda { get; set; }
        public string Categoria { get; set; }
    }


}
