using APIFornecedores.Context;
using APIFornecedores.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace APIFornecedores.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApiFornecedorDbContext _context;
        public FornecedorRepository(ApiFornecedorDbContext context)
        {
           _context = context;
        }
        public async Task<IEnumerable<Fornecedor>> GetFornecedoresAsync()
        {
            return await _context.Fornecedores.AsNoTracking().ToListAsync();

        }
        public async Task<Fornecedor> GetFornecedorAsync(int id)
        {
            return await _context.Fornecedores.FirstOrDefaultAsync(c => c.Id == id);
        }
        
        public async Task<Fornecedor> CreateAsync(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();

            return fornecedor;
        }
        public async Task<Fornecedor> UpdateAsync(Fornecedor fornecedor)
        {
            _context.Entry(fornecedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return fornecedor;
        }

        public async Task<Fornecedor> DeleteAsync(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor is null)  throw new ArgumentNullException(nameof(fornecedor));
            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }
    }
}
