namespace quanlysach.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [Key]
        public int idbook { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public int? idctg { get; set; }

        public double? price { get; set; }

        [StringLength(255)]
        public string linkimg { get; set; }

        public int? idauthor { get; set; }

        [StringLength(255)]
        public string nameauthor { get; set; }

        public virtual Category Category { get; set; }
    }
}
