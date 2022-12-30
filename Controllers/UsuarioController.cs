using compras.Models;
using compras.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

using System.Web.Mvc;

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
    }
}
