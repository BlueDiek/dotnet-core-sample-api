using Consulting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace Consulting.Infrastructure.Repositories.Mapper
{
    public partial class Question 
    {
        public static Consulting.Domain.Models.Entities.Question Map(IDictionary<string, object> model)
        {
            var map = new Consulting.Domain.Models.Entities.Question()
            {
                ID = model.ContainsKey("id") ? int.Parse(model["id"].ToString()) : -1,
               QuestionTypeID = model.ContainsKey("qty_id") ? int.Parse(model["qty_id"].ToString()) : -1,
                Name = model.ContainsKey("name") ? model["name"].ToString() : string.Empty,
                Description = model.ContainsKey("question") ? model["question"].ToString() : string.Empty
            };        
            return map;
        }
    }
}