using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Models.Request
{
    public class EmailRQ
    {
        public string module { get; set; }
        public string link { get; set; }
        public List<int> user { get; set; }
    }
}