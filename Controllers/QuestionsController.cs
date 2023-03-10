using compras.Models.Request;
using compras.Service;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace compras.Controllers
{
    public class QuestionsController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult denEmail(string module)
        {

            QuestionsService service = new QuestionsService();
            
            service.SendEmail(module);

            return View();
        }
        public ActionResult addQuetions(QuesionsRQ quesions)
        {

            QuestionsService service = new QuestionsService();
            var result = service.AddQuestions(quesions);

            return View(result);
        }

        public ActionResult updateQuetions(QuesionsRQ quesions)
        {

            QuestionsService service = new QuestionsService();
            var result = service.UpdateQuestions(quesions);

            return View(result);
        }
        public ActionResult Index()
        {

            QuestionsService service = new QuestionsService();
            var result = service.getQuestions();

            return View(result);
        }
    }
}