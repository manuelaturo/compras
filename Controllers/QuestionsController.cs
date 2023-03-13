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

        public ActionResult sendEmail(string module)
        {

            QuestionsService service = new QuestionsService();
            
            service.SendEmail(module);

            return View();
        }
        public ActionResult AddQuetions(QuesionsRQ quesions)
        {

            QuestionsService service = new QuestionsService();
            var result = service.AddQuestions(quesions);

            return View(result);
        }
        public ActionResult deleteQuetions(int idQuesions)
        {

            QuestionsService service = new QuestionsService();
            var result = service.deleteQuestions(idQuesions);

            return View(result);
        }

        public ActionResult updateQuetions(QuesionsRQ quesions)
        {

            QuestionsService service = new QuestionsService();
            var result = service.UpdateQuestions(quesions);

            return View(result);
        }
        public ActionResult GetQuestions()
        {

            QuestionsService service = new QuestionsService();
            var result = service.getQuestions();

            return View(result);
        }
        public ActionResult GetQuestionsByDate(string initDate, string endDate)
        {

            QuestionsService service = new QuestionsService();
            var result = service.getQuestions(initDate, endDate);

            return View(result);
        }
        public ActionResult GetQuestionsByModule(int module )
        {

            QuestionsService service = new QuestionsService();
            var result = service.getQuestions(module);

            return View(result);
        }
    }
}