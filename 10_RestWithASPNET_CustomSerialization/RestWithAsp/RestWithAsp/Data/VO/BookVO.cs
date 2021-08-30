 
using System;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Data.VO
{
    public class BookVO  
    {
        public long id { get; set; }

        public string title { get; set; }

        public string author { get; set; }

        public decimal price { get; set; }

        public DateTime launchDate { get; set; }
  

    }
}