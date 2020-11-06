using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estoque.WebAPI.Models;

namespace Estoque.WebAPI.Data
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext (DbContextOptions<EstoqueContext> options)
            : base(options)
        {
        }

        public DbSet<Estoque.WebAPI.Models.Produto> Produto { get; set; }

        public DbSet<Estoque.WebAPI.Models.Categoria> Categoria { get; set; }

        public DbSet<Estoque.WebAPI.Models.Usuario> Usuario { get; set; }
    }
}
