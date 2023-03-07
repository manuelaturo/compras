using compras.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace compras.Service
{
    public class MenuService
    {
        public bool insertMenu(string menu, int day)
        {
            try
            {
                MenuDAO dao = new MenuDAO();
                var responseMenu = dao.getMenu(day);
                if (String.IsNullOrEmpty(responseMenu))
                {
                    var result = dao.addMenu(menu, day);
                }
                else
                {
                    var result = dao.updateMenu(menu, day);
                }
                    
                decimal costTotal = 0;
               

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        } 
    }
}