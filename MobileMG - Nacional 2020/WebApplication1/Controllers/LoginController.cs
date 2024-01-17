using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
 
    public class LoginController : ApiController
    {
      
        private SessaoMobileEntities ctx = new SessaoMobileEntities();
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login([FromBody] LoginModel loginModel)
        {
            var usuario = ctx.Usuario.FirstOrDefault(x => x.email == loginModel.UserName && x.senha == loginModel.Password);

            if (usuario != null)
            {
          
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Login bem-sucedido" });
            }
            else
            {
           
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Message = "Usuário ou senha inválidos" });
            }
        }
        [HttpGet]
        [Route("api/usuarios")]
        public HttpResponseMessage Get()
        {
            var usuarios = ctx.Usuario.ToList()
                                    .Select(u => new UsuarioViewModel
                                    {
                                        Id = u.id,
                                        Nome = u.nome,
                                        Email = u.email,
                                        Telefone = u.telefone,
                                        FuncaoId = u.funcaoid
      
                                    }).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, usuarios);
        }
    }
}
