using System;

namespace TeleBook.Application.Contracts
{
    public class TeleDto : EntityDto<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string GenderValue { get; set; }
        public string NationalCode { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public bool SpecTag { get; set; }
    }
}