using Consulting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Consulting.Infrastructure.Repositories.Mapper
{
    public static class Primitive<T>
    {
        public static T Map(IDictionary<string, object> model)
        {
            object result = model[model.Keys.FirstOrDefault()];

            return result != null ? (T)result : default(T);
        }
    }
}