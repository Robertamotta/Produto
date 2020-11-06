    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.WebAPI.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public string StatusUsuario { get; set; }



        public Usuario() { }


 
    }

    }
