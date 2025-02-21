﻿using FluentValidation;

namespace dotnet_quehuar_worker.Application.UseCase.V1.PersonOperation.Queries.GetByName
{
  public class GetPersonByNameValidation : AbstractValidator<GetPersonByName>
  {
    public GetPersonByNameValidation()
    {
      RuleFor(x => x.Name)
          .Cascade(CascadeMode.Stop)
          .NotEmpty()
          .WithMessage("La propiedad name no puede estar vacía")
          .MaximumLength(255)
          .WithMessage("Name solo puede tener 255 caracteres");
    }
  }
}

