using Consulting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace Consulting.Infrastructure.Repositories.Mapper
{
    public partial class QuestionValue 
    {
        public static Consulting.Domain.Models.Entities.QuestionValue Map(IDictionary<string, object> model)
        {
            var map = new Consulting.Domain.Models.Entities.QuestionValue()
            {
                ID = model.ContainsKey("id") ? int.Parse(model["id"].ToString()) : -1     ,
                QuestionID= model.ContainsKey("que_id") ? int.Parse(model["que_id"].ToString()) : -1,
                Name = model.ContainsKey("name") ? model["name"].ToString() : string.Empty,
                Description = model.ContainsKey("description") ? model["description"].ToString() : string.Empty,
                Value = model.ContainsKey("value") ? int.Parse(model["value"].ToString()) : -1,
            };        
            return map;
        }
    }
}