using CP2.Domain.Entities;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorApplicationService
    {
        IEnumerable<VendedorEntity> ObterTodosVendedores();
        VendedorEntity? ObterVendedorPorId(int id);
        VendedorEntity? SalvarDadosVendedor(VendedorEntity entity);
        VendedorEntity? EditarDadosVendedor(int id, VendedorEntity entity);
        VendedorEntity? DeletarDadosVendedor(int id);

    }
}
