using CP2.Domain.Entities;
using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System;
using System.Linq;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }

        public FornecedorEntity MapToFornecedorEntity(FornecedorDto dto)
        {
            return new FornecedorEntity
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Cnpj = dto.Cnpj,
                Endereco = dto.Endereco,
                Telefone = dto.Telefone,
                Email = dto.Email,
                CriadoEm = dto.CriadoEm
            };
        }

    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(f => f.Id)
                .GreaterThan(0).WithMessage("Informe um Id válido, maior que zero.");

            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O nome do fornecedor é obrigatório.")
                .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres.");

            RuleFor(f => f.Cnpj)
                .NotEmpty().WithMessage("Informe o CNPJ do fornecedor.")
                .Matches(@"^\d{14}$").WithMessage("O CNPJ deve conter exatamente 14 dígitos numéricos.");

            RuleFor(f => f.Endereco)
                .NotEmpty().WithMessage("O endereço do fornecedor é obrigatório.")
                .Length(5, 150).WithMessage("O endereço deve ter entre 5 e 150 caracteres.");

            RuleFor(f => f.Telefone)
                .NotEmpty().WithMessage("Informe o telefone do fornecedor.")
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$").WithMessage("Insira o telefone no formato correto (com DDD).");

            RuleFor(f => f.Email)
                .NotEmpty().WithMessage("Informe o email do fornecedor.")
                .EmailAddress().WithMessage("Insira um endereço de email válido.");

            RuleFor(f => f.CriadoEm)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de criação não pode ser futura.");
        }
    }
}
