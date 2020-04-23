using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Domain.Models.Entities
{
    public class Form
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

    }
}
