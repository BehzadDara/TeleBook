using JetBrains.Annotations;

namespace TeleBook.Application.Contracts
{
    public class TeleUpdateDto
    {
        [CanBeNull] public string FirstName { get; set; }
        [CanBeNull] public string LastName { get; set; }
        [CanBeNull] public string Gender { get; set; }
        [CanBeNull] public string NationalCode { get; set; }
        [CanBeNull] public string Telephone { get; set; }
        [CanBeNull] public string Address { get; set; }
        [CanBeNull] public bool? SpecTag { get; set; }
    }
}