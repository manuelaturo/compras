using compras.BD.Entities;
using Dapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace compras.BD
{
    public class ProductDAO
    {
        private readonly string con = ConfigurationManager.ConnectionStrings["Comedor"].ConnectionString;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool AddComedor(ProductEntity product)
        {
            try
            {

                product.addDate = DateTime.Now;
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                        db.Execute("INSERT INTO Products (NameProduct,Description,Category,KeyProduct,Item,Folio,Typeimage,image,AddUser,AddDate)" +
                                " (@NameProduct,@Description,@Category,@KeyProduct,@Item,@Folio,@Typeimage,@image,@AddUser,@AddDate)",
                                new
                                {
                                    product.namePrduct,
                                    product.decription,
                                    product.category,
                                    product.keyProduct,        
                                    product.item,
                                    product.folio,
                                    product.typeimage,
                                    product.image,
                                    product.addUser,
                                    product.addDate
                                });
                        db.Close();
                        return true;
                }

            }
            catch (SqlException e)
            {
                log.Info("error " + e);
                throw e;
            }
            catch (Exception e)
            {
                log.Info("error " + e);
                throw e;
            }
        }
    }
}