using BP215API.DTOs.Languages;
using FluentValidation;

namespace BP215API.Validators.Languages
{
    public class LanguageCreateDtoValidator :AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x => x.Code)
                 .NotEmpty()
                 .WithMessage("Ad bosh ola Bilmez")
                 .NotNull()
                 .WithMessage("ad null ola bilmez")
                 .Length(2)
                 .WithMessage(" Uzunluq 2ye beraber olmalidir ");

            RuleFor(x => x.Name)
                .MaximumLength(32)
                .MinimumLength(3);
            RuleFor(x => x.Icon)
                .MaximumLength(128)
                .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
                .WithMessage("Url link olmalidir");
                

        }
    }
}
