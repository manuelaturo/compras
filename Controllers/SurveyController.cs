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
    public class SurveyController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ActionResult AddSurvey(SurveyRQ quesions)
        {

            SurveyService service = new SurveyService();
            var result = service.AddSurvey(quesions);

            return View(result);
        }
        public ActionResult GetQuetions()
        {

            SurveyService service = new SurveyService();
            var result = service.getSurvey();

            return View(result);
        }
    }
}
