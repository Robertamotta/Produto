using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.WebAPI.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public string Status { get; set; }
 
        private readonly int id;
        private readonly string nome;
        private List<Produto> produtos = new List<Produto>();
 
 
        public Categoria() => this.NomeCategoria = nome;


        public Categoria(int IdCategoria, string nome)
        {
            this.IdCategoria = id;
            this.NomeCategoria = nome;
        }

 
        internal List<Produto> Produtos
        {
            get
            {
                return produtos;
            }

            set
            {
                produtos = value;
            }
        }
    }

    }
