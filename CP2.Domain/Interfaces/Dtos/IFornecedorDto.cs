namespace CP2.Domain.Interfaces.Dtos
{
    public interface IFornecedorDto
    {
        int Id { get; set; }
        String Nome { get; set; }
        String Cnpj { get; set; }
        String Endereco { get; set; }
        String Telefone { get; set; }
        String Email { get; set; }
        DateTime CriadoEm { get; set; }

        void Validate();
    }
}
