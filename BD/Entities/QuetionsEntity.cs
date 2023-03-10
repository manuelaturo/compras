using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.BD.Entities
{
    public class QuetionsEntity
    {
        public int idSurvey { get; set; }
        public string question { get; set; }
        public int module { get; set; }
        public string nameModule { get; set; }
        public int idQuestions { get; set; }
        public int registerUser { get; set; }

        public QuetionsEntity() { }
        public QuetionsEntity(string question, int module, int registerUser,string nameModule) {
            this.question = question;
            this.module = module;
            this.registerUser = registerUser;
            this.nameModule = nameModule;

        }
        public QuetionsEntity(string question, int module, int registerUser,int idQuestions,string nameModule)
        {
            this.question = question;
            this.module = module;
            this.registerUser = registerUser;
            this.idQuestions = idQuestions;
            this.nameModule = nameModule;
        }
    }
}