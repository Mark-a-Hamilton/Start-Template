namespace MinAPI.Library.Validators;

public class LogValidator : AbstractValidator<Log>
{
    public LogValidator()
    {
        RuleFor(p => p.Message).NotEmpty();
        RuleFor(p => p.Level).NotEmpty();
    }
}

//  Other validator clases go below