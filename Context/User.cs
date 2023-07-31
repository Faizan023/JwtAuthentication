using System.ComponentModel.DataAnnotations.Schema;

namespace Context
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int Phone { get; set; }
    }
}
