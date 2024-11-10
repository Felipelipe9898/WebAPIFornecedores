using APIFornecedores.Models;
using Microsoft.EntityFrameworkCore;

namespace APIFornecedores.Context
{
    public class ApiFornecedorDbContext : DbContext
    {
        public ApiFornecedorDbContext(DbContextOptions<ApiFornecedorDbContext> options ) : base(options)
        {
                
        }
        public DbSet<Fornecedor>? Fornecedores {  get; set; }

    }
}
