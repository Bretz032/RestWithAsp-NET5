using RestWithAsp.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp.Model
{
    [Table("books")]
    public class Book: BaseEntity
    { 


        [Column("author")]
        public string author { get; set; }

        [Column("launch_date")]
        public DateTime launch_date { get; set; }

        [Column("price")]
        public double price { get; set; }

        [Column("title")]
        public string title { get; set; }

    }
}
