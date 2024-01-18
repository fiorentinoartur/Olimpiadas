using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Routing;
using WebApplication1.Models;
using WebApplication1.Views;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
       SessaoMobileEntities ctx = new SessaoMobileEntities();
        [HttpGet]
        [Route("usuarios")]
        public IHttpActionResult Get()
        {
            try
            {
              var usuarios = ctx.Usuario.ToList().Select(u => new UsuarioViewModel
              {
   id = u.id,
   email = u.email,
   senha = u.senha,
   nome = u.nome,
   telefone = u.telefone,
   funcaoid = u.funcaoid,
              }).ToList();
                return Ok(usuarios);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Post(LoginViewModel user)
        {
            try
            {
                var usuarioBuscado = ctx.Usuario.FirstOrDefault(x => x.email == user.email && x.senha == user.senha);

            return Ok(usuarioBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


       
    }
}
