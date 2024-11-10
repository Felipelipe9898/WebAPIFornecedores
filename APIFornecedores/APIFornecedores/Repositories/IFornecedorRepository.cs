using APIFornecedores.Models;

namespace APIFornecedores.Repositories
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<Fornecedor>> GetFornecedoresAsync();
        Task<Fornecedor> GetFornecedorAsync(int id);
        Task<Fornecedor> CreateAsync(Fornecedor fornecedor);
        Task<Fornecedor> UpdateAsync(Fornecedor fornecedor);
        Task<Fornecedor> DeleteAsync(int id);
    }
}
