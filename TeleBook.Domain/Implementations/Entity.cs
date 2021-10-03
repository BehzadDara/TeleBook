using System;
using TeleBook.Domain.Interfaces;

namespace TeleBook.Domain.Implementations
{
    public abstract class Entity : IEntity
    {
        protected Entity()
        {
            Id = Comb.Create();
        }

        public Guid Id { get; set; }
    }
}