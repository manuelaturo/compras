using compras.BD;
using compras.BD.Entities;
using compras.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Service
{
    public class GuideService
    {
        public List<GuidesRS> getGuides()
        {
            try
            {
                GuideDAO dao = new GuideDAO();
                return  assemblerGuides (dao.GetGuides());
            } catch (Exception e)
            {
                throw e;
            }
        }
        public List<GuidesRS> getGuides(string initDate, string endDate)
        {
            try
            {
                var dateInit = DateTime.ParseExact(initDate, "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                var dateEnd = DateTime.ParseExact(endDate, "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);


                GuideDAO dao = new GuideDAO();
                return assemblerGuides(dao.GetGuides(dateInit, dateEnd));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private List<GuidesRS> assemblerGuides(List<GuidesEntity> guides)
        {
            return guides.ConvertAll(x => new GuidesRS(x.numEmpployed, x.Name, x.conpany, x.destination, x.description,
         x.size, x.kg, x.ledgerAccount, x.costCenter, x.guide));
        }
    }
}