using BookRental.Api.Contracts;
using BookRental.Api.Models;
using FluentValidation;

namespace BookRental.Api.Validation;

internal sealed class BookStatusChangeValidator : AbstractValidator<BookStatusChange>
{
    public BookStatusChangeValidator()
    {
        When(x => x.NewStatus is BookStatus.OnShelf, () =>
        {
            RuleFor(x => x.CurrentStatus).Must(currentStatus => currentStatus is BookStatus.OnShelf or BookStatus.Returned or BookStatus.Damaged)
                .WithMessage($"You can only change to 'OnShelf' status from 'Returned' or 'Damaged' statuses.");
        });

        When(x => x.NewStatus is BookStatus.Borrowed, () =>
        {
            RuleFor(x => x.CurrentStatus).Must(currentStatus => currentStatus is BookStatus.Borrowed or BookStatus.OnShelf)
                .WithMessage($"You can only change to 'Borrowed' status from 'OnShelf' status.");
        });

        When(x => x.NewStatus is BookStatus.Returned, () =>
        {
            RuleFor(x => x.CurrentStatus).Must(currentStatus => currentStatus is BookStatus.Returned or BookStatus.Borrowed)
                .WithMessage($"You can only change to 'Returned' status from 'Borrowed' status.");
        });

        When(x => x.NewStatus is BookStatus.Damaged, () =>
        {
            RuleFor(x => x.CurrentStatus).Must(currentStatus => currentStatus is BookStatus.Damaged or BookStatus.OnShelf or BookStatus.Returned)
                .WithMessage($"You can only change to 'Damaged' status from 'OnShelf' or 'Returned' statuses.");
        });

        // Do not allow changing to Unknown status
        When(x => x.NewStatus is BookStatus.Unknown, () =>
        {
            RuleFor(x => x.CurrentStatus).Custom((_, context) => context.AddFailure(
                nameof(BookStatusChange.NewStatus), $"New status cannot be {BookStatus.Unknown}"))
                .When(x => x.CurrentStatus != BookStatus.Unknown);
        });
    }
}
