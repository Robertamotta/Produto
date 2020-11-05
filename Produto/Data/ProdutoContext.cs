using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estoque.WebAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Estoque.WebAPI.Data
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = "estoque-infrastruture-db-server.database.windows.net";
            builder.UserID = "treinamentormp";
            builder.Password = "Rmp251702";
            builder.InitialCatalog = "Estoque.Infrastruture_db";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

             } }

    public DbSet<Estoque.WebAPI.Models.Produto> Produto { get; set; }
    }
}
