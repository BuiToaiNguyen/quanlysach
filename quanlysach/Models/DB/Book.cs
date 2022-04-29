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

        [StringLength(100)]
        public string nameauthor { get; set; }

        public int? idctg { get; set; }

        public double? price { get; set; }

        public virtual Category Category { get; set; }
    }
}
