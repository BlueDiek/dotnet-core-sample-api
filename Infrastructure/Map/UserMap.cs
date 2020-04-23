using Consulting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace Consulting.Infrastructure.Repositories.Mapper
{
    public partial class User 
    {
        public static Consulting.Domain.Models.Entities.User Map(IDictionary<string, object> model)
        {
            var map = new Consulting.Domain.Models.Entities.User()
            {
                ID = model.ContainsKey("id") ? int.Parse(model["id"].ToString()) : -1,
                UID = model.ContainsKey("uid") ? Guid.Parse(model["uid"].ToString()) : Guid.Empty,
                Username = model.ContainsKey("username") ? model["username"].ToString() : string.Empty

            };        
            return map;
        }
    }
}