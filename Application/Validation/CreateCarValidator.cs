using Application.Models.Requests;
using FluentValidation;

namespace Application.Validation;

public class CreateCarValidator : AbstractValidator<CreateCarRequestModel>
{
    const string FieldMustBeInitializedMessageTemplate = "Field {0} must be initialized.";
    
    public CreateCarValidator()
    {
        RuleFor(r => r)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(r => r.SeatsCount is > 0 and < 13)
            .WithMessage($"{nameof(CreateCarRequestModel.SeatsCount)} must between 1 and 12.")
            .Must(r => r.BrandId.HasValue)
            .WithMessage(string.Format(FieldMustBeInitializedMessageTemplate, nameof(CreateCarRequestModel.BrandId)))
            .Must(r => !string.IsNullOrEmpty(r.Model) && r.Model.Length <= 1000)
            .WithMessage(string.Concat(
                string.Format(FieldMustBeInitializedMessageTemplate, nameof(CreateCarRequestModel.Model)), 
                " and string Length must be \"<\" 1000"))
            .Must(r => r.BodyTypeId.HasValue)
            .WithMessage(string.Format(FieldMustBeInitializedMessageTemplate, nameof(CreateCarRequestModel.BodyTypeId)))
            .Must(r =>
            {
                Uri.TryCreate(r.DealerSiteUrl, UriKind.Absolute, out var uri);

                var q = uri.DnsSafeHost.Split('.')[^1];
                
                return uri == null || (uri.DnsSafeHost.Split('.')[^1] == "ru");
            })
            .WithMessage($"Сайт {nameof(CreateCarRequestModel.DealerSiteUrl)} должен быть в домене «.ru».");
    }
}