using compras.BD;
using compras.BD.Entities;
using compras.Models;
using compras.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Service
{
    public class GuideService
    {
        public GuideResult getGuides()
        {
            try
            {
                GuideResult response = new GuideResult();
                GuideDAO dao = new GuideDAO();
                var result = dao.GetIdGuides();
                decimal costTotal = 0;

                List<guidesTotal> guidesTotals = new List<guidesTotal>();

                foreach (var item in result)
                {
                    guidesTotal guidesTotal = new guidesTotal();
                    var idGuide = item.Id_Guide_Type;
                    var count = dao.Getcount(idGuide);
                    var total = count * item.price;
                    guidesTotal.guide = item.type;
                    guidesTotal.price = item.price;
                    guidesTotal.count = count;
                    costTotal = costTotal + total;
                    guidesTotals.Add(guidesTotal);
                }

                response.guidesRs = assemblerGuides(dao.GetGuides());
                response.totalCost = costTotal;
                response.guidesTotals = guidesTotals;

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public GuideResult getGuides(string dateinit, string dateend)
        {
            try
            {

                var dateInit = DateTime.ParseExact(dateinit, "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                var dateEnd = DateTime.ParseExact(dateend, "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);

                GuideResult response = new GuideResult();
                GuideDAO dao = new GuideDAO();
                var result = dao.GetIdGuides();
                decimal costTotal = 0;

                List<guidesTotal> guidesTotals = new List<guidesTotal>();

                foreach (var item in result)
                {
                    guidesTotal guidesTotal = new guidesTotal();
                    var idGuide = item.Id_Guide_Type;
                    var count = dao.Getcount(idGuide);
                    var total = count * item.price;
                    guidesTotal.guide = item.type;
                    guidesTotal.price = item.price;
                    guidesTotal.count = count;
                    costTotal = costTotal + total;
                    guidesTotals.Add(guidesTotal);
                }

                response.guidesRs = assemblerGuides(dao.GetGuides(dateInit, dateEnd));
                response.totalCost = costTotal;
                response.guidesTotals = guidesTotals;

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private List<GuidesRS> assemblerGuides(List<GuidesEntity> guides)
        {
            return guides.ConvertAll(x => new GuidesRS(x.numEmpployed, x.Name, x.conpany, x.destination, x.description,
         x.size, x.kg, x.ledgerAccount, x.costCenter, x.guide, x.guideType));
        }
    }
}