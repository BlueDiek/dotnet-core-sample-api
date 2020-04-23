using Consulting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace Consulting.Infrastructure.Repositories.Mapper
{
    public partial class Form
    {
        public static Consulting.Domain.Models.Entities.Form Map(IDictionary<string, object> model)
        {
            var map = new Consulting.Domain.Models.Entities.Form()
            {
                ID = model.ContainsKey("id") ? int.Parse(model["id"].ToString()) : -1,
                Name = model.ContainsKey("name") ? model["name"].ToString() : string.Empty,
                Description = model.ContainsKey("description") ? model["description"].ToString() : string.Empty,
                Active = model.ContainsKey("active") ? bool.Parse(model["active"].ToString()) : false
            };
            return map;
        }
    }
}