using BP215API.DTOs.Languages;
using FluentValidation;

namespace BP215API.Validators.Languages
{
    public class LanguageCreateDtoValidator :AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                 .NotEmpty()
                 .WithMessage("Ad bosh ola Bilmez")
                 .NotNull()
                 .WithMessage("ad null ola bilmez")
                 .Length(232)
                 .WithMessage(" Ad uzunlugu 32den artiq ola bilmez ");

        }
    }
}
