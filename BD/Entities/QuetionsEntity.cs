using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.BD.Entities
{
    public class QuetionsEntity
    {
        public string question { get; set; }
        public int module { get; set; }
        public int registerUser { get; set; }

        public QuetionsEntity() { }
        public QuetionsEntity(string question, int module, int registerUser) {
            this.question = question;
            this.module = module;
            this.registerUser = registerUser;


        }
    }
}