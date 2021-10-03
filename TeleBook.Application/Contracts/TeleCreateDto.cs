using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using TeleBook.Application.Attributes;
using TeleBook.Domain.Models;

namespace TeleBook.Application.Contracts
{
    public class TeleCreateDto
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Gender { get; set; }
        [LengthControl(10,Error.NationalCodeError)][Required] public string NationalCode { get; set; }
        [Required] public string Telephone { get; set; }
        [CanBeNull] public string Address { get; set; }
        [Required] public bool SpecTag { get; set; }
    }
}