using Consulting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace Consulting.Infrastructure.Repositories.Mapper
{
    public partial class FormQuestion
    {
        public static Consulting.Domain.Models.Entities.FormQuestion Map(IDictionary<string, object> model)
        {
            var map = new Consulting.Domain.Models.Entities.FormQuestion()
            {
                ID = model.ContainsKey("id") ? int.Parse(model["id"].ToString()) : -1,
                FormID = model.ContainsKey("formid") ? int.Parse(model["formid"].ToString()) : -1,
                QuestionID = model.ContainsKey("questionid") ? int.Parse(model["questionid"].ToString()) : -1,
                Order = model.ContainsKey("order") ? int.Parse(model["order"].ToString()) : -1,
                Next = model.ContainsKey("next") ? int.Parse(model["next"].ToString()) : -1,
                AlternativeNext = model.ContainsKey("alternativenext") ? int.Parse(model["alternativenext"].ToString()) : -1,
            };
            return map;
        }      
    }
}