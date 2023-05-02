using System.ComponentModel.DataAnnotations;

namespace demo.Model
{
    public class Item
    {
        [Key]
        public int UserId { get; set; }
        public string Category { get; set; }

        public string App { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
