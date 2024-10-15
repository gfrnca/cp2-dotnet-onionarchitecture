using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CP2.Domain.Entities
{
    [Table("tb_vendedor")]
    public class VendedorEntity
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email {  get; set; }
        public String Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Endereco { get; set; }
        public DateTime DataContratacao { get; set; }
        public Decimal ComissaoPercentual { get; set; }
        public Decimal MetaMensal { get; set; }
        public DateTime CriadoEm { get; set; }
    }
    
}
