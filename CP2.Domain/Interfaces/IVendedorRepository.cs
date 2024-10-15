using CP2.Domain.Entities;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        IEnumerable<VendedorEntity> ObterTodos();
        VendedorEntity? ObterPorId(int id);
        VendedorEntity? SalvarDados(VendedorEntity entity);
        VendedorEntity? EditarDados(VendedorEntity entity);
        VendedorEntity? DeletarDados(int id);
    }
}
