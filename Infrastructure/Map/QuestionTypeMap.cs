using Consulting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace Consulting.Infrastructure.Repositories.Mapper
{
    public partial class QuestionType
    {
        public static Consulting.Domain.Models.Entities.QuestionType Map(IDictionary<string, object> model)
        {
            var map = new Consulting.Domain.Models.Entities.QuestionType()
            {
                ID = model.ContainsKey("id") ? int.Parse(model["id"].ToString()) : -1,
                Name = model.ContainsKey("name") ? model["name"].ToString() : string.Empty,
                Description = model.ContainsKey("description") ? model["description"].ToString() : string.Empty,

            };
            return map;
        }
    }
}