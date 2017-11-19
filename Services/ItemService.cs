using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Services
{
    public class ItemService : Service<Item>
    {
        public IEnumerable<Item> Search(string term)
        {
            var query = this.context.Items.AsQueryable();
            if (IsValid(term))
            {
                query = query.Where(x => x.Event.IndexOf(term, StringComparison.OrdinalIgnoreCase) != -1);
            }
            return query.Take(10);
        }
    }
}
