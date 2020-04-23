using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Domain.Models.Entities
{
    public class Question
    {
        public int ID { get; set; }
        public int QuestionTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
