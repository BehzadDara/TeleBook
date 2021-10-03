using System;

namespace TeleBook.Domain.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}