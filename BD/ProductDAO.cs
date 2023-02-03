using compras.BD.Entities;
using Dapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace compras.BD
{
    public class ProductDAO
    {
        private readonly string con = ConfigurationManager.ConnectionStrings["Comedor"].ConnectionString;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public List<ProductEntity> GetProducts()
        {
            try
            {
                List<ProductEntity> report = new List<ProductEntity>();

                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    report = db.Query<ProductEntity>("SELECT  IdProduct,NameProduct,Description,Category," +
                        "KeyProduct,Item,Folio,Typeimage,image,AddUser,UpdateUser," +
                        "AddDate,UpdateDate  FROM Products", commandType: CommandType.Text).ToList();
                    db.Close();
                    return report;
                }

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool addProduct(ProductEntity product)
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
                                product.nameProduct,
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

        public bool updateProduct(ProductEntity product)
        {
            try
            {

                product.updaeDate = DateTime.Now;
                using (var db = new SqlConnection(con))
                {
                    db.Open();
                    db.Execute("UPDATE Products" +
                        "SET NameProduct = NameProduct,Description = Description," +
                        "Category = Category,KeyProduct = KeyProduct,Item = Item," +
                        "Folio = Folio,Typeimage = Typeimage,image = image," +
                        "UpdateUser =UpdateUser,UpdateDate = UpdateDate " +
                        "WHERE idProduct = @idProduct ",
                            new
                            {
                                product.idProduct,
                                product.nameProduct,
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