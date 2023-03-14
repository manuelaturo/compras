using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Models.Response
{
    public class QuetionsRS
    {
        public string question { get; set; }
        public int module { get; set; }
        public string nameModule { get; set; }
        public int registerUser { get; set; }

        public QuetionsRS() { }
        public QuetionsRS(string question, int module, int registerUser)
        {
            this.question = question;
            this.module = module;
            this.registerUser = registerUser;


        }
        public QuetionsRS(string question, int module, int registerUser,string nameModule)
        {
            this.question = question;
            this.module = module;
            this.registerUser = registerUser;
            this.nameModule = nameModule;

        }
    }
}