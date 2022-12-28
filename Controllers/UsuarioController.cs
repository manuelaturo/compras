using compras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Service.UsuarioService.GetUsuario();
            return null;
        }

        //[System.Web.Http.Route("Api/UsuarioById/{Id}")]
        //[System.Web.Http.HttpGet]
        public ActionResult getById(int Id)
        {
            Service.UsuarioService.GetUsuarioBynoEmpleado(Id);
            return null;
            //return Ok(Service.UsuarioService.GetUsuarioBynoEmpleado(Id));
        }

        //[System.Web.Http.Route("Api/UsuarioADD")]
        //[System.Web.Http.HttpPost]
        public ActionResult Add(Usuario usuario)
        {
            Service.UsuarioService.AddUsuario(usuario);
            return null;
            //return Ok(Service.UsuarioService.AddUsuario(usuario));
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
