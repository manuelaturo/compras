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
        private List<GuidesRS> assemblerGuides(List<GuidesEntity> guides)
        {
            return guides.ConvertAll(x => new GuidesRS(x.numEmpployed, x.Name, x.conpany, x.destination, x.description,
         x.size, x.kg, x.ledgerAccount, x.costCenter, x.guide));
        }
    }
}