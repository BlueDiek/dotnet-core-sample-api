using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Domain.Models.Entities
{
    public class FormQuestion
    {
        public int ID { get; set; }
        public int FormID { get; set; }
        public int QuestionID { get; set; }
        public int Order { get; set; }
        public int Next { get; set; }
        public int AlternativeNext { get; set; }

    }
}
