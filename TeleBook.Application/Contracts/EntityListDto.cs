using System.Collections.Generic;

namespace TeleBook.Application.Contracts
{
    public class EntityListDto<TEntityDto>
    {
        public int TotalCount { get; set; }
        public IList<TEntityDto> Entities { get; set; }
    }
}