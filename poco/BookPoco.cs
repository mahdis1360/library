using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace poco
{
    [Table("Book")]
    public class BookPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AutorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public virtual AuthorPoco authorpoco { get; set; }


    }
}
