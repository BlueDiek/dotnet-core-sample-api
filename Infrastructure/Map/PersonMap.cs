using Consulting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace Consulting.Infrastructure.Repositories.Mapper
{
    public partial class Person
    {
        public static Consulting.Domain.Models.Entities.Person Map(IDictionary<string, object> model)
        {
            var map = new Consulting.Domain.Models.Entities.Person()
            {
                ID = model.ContainsKey("id") ? int.Parse(model["id"].ToString()) : -1,
                UserID = model.ContainsKey("userid") ? int.Parse(model["userid"].ToString()) : -1,
                Reference = model.ContainsKey("reference") ? model["reference"].ToString() : string.Empty

            };
            return map;
        }
    }
}