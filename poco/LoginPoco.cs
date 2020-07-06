using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace poco
{
    [Table("Login")]
    public class LoginPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid AutorId { get; set; }
        public string Role { get; set; }
    }
}