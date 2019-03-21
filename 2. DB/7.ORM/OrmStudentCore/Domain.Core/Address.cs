using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core
{
    public class Address
    {
         public string Street { get; set; }
         public string PostCode { get; set; }
         public Person Person { get; set; }
    }
}
