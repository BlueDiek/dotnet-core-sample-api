using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Domain.Models.Entities
{
    public class User
    {
        public int ID { get; set; }
        public Guid UID { get; set; }
        public string Username { get; set; }
    }
}
