using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.Domain.Entities
{
    [Table("tb_fornecedor")]
    public class FornecedorEntity
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Cnpj { get; set; }
        public String Endereco { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}
