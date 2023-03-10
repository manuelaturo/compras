using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Models.Request
{
    public class QuesionsRQ
    {
        public string question { get; set; }
        public int module { get; set; }
        public int idQuestions { get; set; }
        public int registerUser { get; set; }
    }
}