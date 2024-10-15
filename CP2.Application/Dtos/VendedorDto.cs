using CP2.Domain.Entities;
using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System;
using System.Linq;

namespace CP2.Application.Dtos
{
    public class VendedorDto : IVendedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public DateTime DataContratacao { get; set; }
        public decimal ComissaoPercentual { get; set; }
        public decimal MetaMensal { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new VendedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }

        public VendedorEntity MapToVendedorEntity(VendedorDto dto)
        {
            return new VendedorEntity
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                DataNascimento = dto.DataNascimento,
                Endereco = dto.Endereco,
                DataContratacao = dto.DataContratacao,
                ComissaoPercentual = dto.ComissaoPercentual,
                MetaMensal = dto.MetaMensal,
                CriadoEm = dto.CriadoEm
            };
        }

    }

    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("O Id deve ser um valor positivo.");

            RuleFor(v => v.Nome)
                .NotEmpty().WithMessage("Informe o nome do vendedor.")
                .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres.");

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Informe o email do vendedor.")
                .EmailAddress().WithMessage("Insira um endereço de email válido.");

            RuleFor(v => v.Telefone)
                .NotEmpty().WithMessage("Informe o telefone do vendedor.")
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$").WithMessage("Insira o telefone no formato correto (com DDD).");

            RuleFor(v => v.DataNascimento)
                .LessThan(DateTime.Now.AddYears(-18)).WithMessage("O vendedor deve ter no mínimo 18 anos.");

            RuleFor(v => v.Endereco)
                .NotEmpty().WithMessage("Informe o endereço do vendedor.")
                .Length(5, 150).WithMessage("O endereço deve ter entre 5 e 150 caracteres.");

            RuleFor(v => v.DataContratacao)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de contratação não pode ser uma data futura.");

            RuleFor(v => v.ComissaoPercentual)
                .InclusiveBetween(0, 100).WithMessage("O percentual de comissão deve estar entre 0% e 100%.");

            RuleFor(v => v.MetaMensal)
                .GreaterThan(0).WithMessage("A meta mensal deve ser um valor maior que zero.");

            RuleFor(v => v.CriadoEm)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de criação não pode ser no futuro.");
        }
    }
}
