using System.Data;

namespace CP2.Domain.Interfaces.Dtos
{
    public interface IVendedorDto
    {
        int Id { get; set; }
        String Nome { get; set; }
        String Email { get; set; }
        String Telefone { get; set; }
        DateTime DataNascimento { get; set; }
        String Endereco { get; set; }
        DateTime DataContratacao { get; set; }
        Decimal ComissaoPercentual { get; set; }
        Decimal MetaMensal { get; set; }
        DateTime CriadoEm { get; set; }
        void Validate();
    }
}
