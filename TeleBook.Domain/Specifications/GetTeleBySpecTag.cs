using System;
using System.Linq.Expressions;
using TeleBook.Domain.Interfaces;
using TeleBook.Domain.Models;

namespace TeleBook.Domain.Specifications
{
    public class GetTeleBySpecTag : Specification<Tele>
    {

        private readonly bool _specTag;

        public GetTeleBySpecTag(bool specTag)
        {
            _specTag = specTag;
        }

        public override Expression<Func<Tele, bool>> Criteria =>
            myTele => myTele.SpecTag == _specTag;
    }
}