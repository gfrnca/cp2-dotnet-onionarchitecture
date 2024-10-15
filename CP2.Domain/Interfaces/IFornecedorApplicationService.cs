using CP2.Domain.Entities;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorApplicationService
    {
        IEnumerable<FornecedorEntity> ObterTodosFornecedores();
        FornecedorEntity? ObterFornecedorPorId(int id);
        FornecedorEntity? SalvarDadosFornecedor(FornecedorEntity entity);
        FornecedorEntity? EditarDadosFornecedor(int id, FornecedorEntity entity);
        FornecedorEntity? DeletarDadosFornecedor(int id);
    }
}
