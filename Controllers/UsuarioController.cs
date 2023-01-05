using compras.Models;
using compras.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace compras.Controllers
{
    public class UsuarioController : Controller
    {
        //[System.Web.Http.Route("Api/Usuario")]
        //[System.Web.Http.HttpGet]
        public ActionResult get()
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = Service.UsuarioService.GetUsuario();
            return View(usuarios);
        }

        //[System.Web.Http.Route("Api/UsuarioById/{Id}")]
        //[System.Web.Http.HttpGet]
        public ActionResult getById(int Id)
        {
            Service.UsuarioService.GetUsuarioBynoEmpleado(Id);
            return null;
            //return Ok(Service.UsuarioService.GetUsuarioBynoEmpleado(Id));
        }

        public ActionResult Add()
        {

            return View();
        }

        public ActionResult Save(Usuario usuario)
        {
            try
            {
                UsuarioService us = new UsuarioService();
                us.AddUsuario(usuario);
                return View("Add");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
            
        }
        //[System.Web.Http.Route("Api/UsuarioUpDate")]
        //[System.Web.Http.HttpPut]
        public ActionResult UpDate(Usuario usuario)
        {
            Service.UsuarioService.UpDateUsuario(usuario);
            return null;
            //return Ok(Service.UsuarioService.UpDateUsuario(usuario));
        }

        //[System.Web.Http.Route("Api/UsuarioDelete/{Id}")]
        //[System.Web.Http.HttpDelete]
        public ActionResult Delete(int Id)
        {
            Service.UsuarioService.DeleteUsuario(Id);
            return null;
            //return Ok(Service.UsuarioService.DeleteUsuario(Id));
        }

        public HttpResponseBase GetPlantilla()
        {
            try
            {
                compras.File.GetFile getFile = new File.GetFile();
                var file = getFile.GetPlantilla();
                string fileName = DateTime.Now.ToString() + "_Plantilla.xlsx";
                var response = new FileContentResult(file, "text/csv");
                response.FileDownloadName = fileName;

                Response.Clear();
                Response.AddHeader("content-disposition", "inline; filename=" + fileName);
                Response.ContentType = "text/csv";
                Response.OutputStream.Write(file, 0, file.Length);
                Response.End();
                return Response; 
            
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ActionResult UploadExcel(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    if (!Directory.Exists(Server.MapPath("~/UploadedFiles")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/UploadedFiles"));
                    }
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);

                    compras.File.GetFile getFile = new File.GetFile();
                    bool File = getFile.SaveUsers(_path);
                }
                ViewBag.Message = "Usuarios agregados con Exito";
                return View("Add");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error al cargar usuarios";
                return View("Add");
            }
        }
    }
}
