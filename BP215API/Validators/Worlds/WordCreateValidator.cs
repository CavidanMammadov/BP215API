using BP215API.DTOs.Words;
using FluentValidation;

namespace BP215API.Validators.Worlds
{
    public class WordCreateValidator :AbstractValidator<WordCreateDto>
    {
        public WordCreateValidator()
        {
            RuleForEach(x => x.BannedWords)
                .NotNull()
                .MinimumLength(2);
            RuleFor(x => x.BannedWords)
                .Must(x => x.Count == 6);

            
        }
    }
}
