using System.ComponentModel.DataAnnotations;
using TeleBook.Domain.Models;

namespace TeleBook.Application.Attributes
{
    public class LengthControlAttribute : ValidationAttribute
    {
        private readonly int _length;

        public LengthControlAttribute(int length, string errorMessage = Error.LengthError)
        {
            _length = length;
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object value)
        {
            var myString = value.ToString();
            return myString.Length == _length;
        }
    }
}