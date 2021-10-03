using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using TeleBook.Domain.Enums;
using TeleBook.Domain.Implementations;

namespace TeleBook.Domain.Models
{
    public class Tele : TrackableEntity
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public GenderType Gender { get; set; }
        [Required] public string NationalCode { get; set; }
        [Required] public string Telephone { get; set; }
        [CanBeNull] public string Address { get; set; }
        [Required] public bool SpecTag { get; set; }
    }
}