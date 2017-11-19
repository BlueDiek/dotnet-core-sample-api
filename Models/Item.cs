using System;

namespace Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Event { get; set; }
        public DateTime? Timestamp { get; set; }

        public Item()
        {
            this.Timestamp = DateTime.Now;
        }
    }
}
