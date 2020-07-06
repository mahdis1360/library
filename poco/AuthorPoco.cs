using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace poco
{
    [Table("Author")]
    public class AuthorPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public string AuthorPseudonym { get; set; }
        public virtual ICollection<BookPoco> bookPocos { get; set; }


    }
}
