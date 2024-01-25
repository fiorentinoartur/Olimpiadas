using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Routing;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        SessaoMobileEntities ctx = new SessaoMobileEntities();

        [HttpGet]
        [Route("login")]
        public IHttpActionResult Post(string email, string senha)
        {
            try
            {
                return Ok(ctx.Usuario.FirstOrDefault(x => x.email == email && x.senha == senha));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("relatos")]
        public IHttpActionResult GetRelatos()
        {
            try
            {
                var listaRelatos = ctx.Relatos.ToList();
                foreach (var item in listaRelatos)
                {
                    if (item.imagem == null)
                    {
                        item.imagem = "default";
                    }
                    if (item.usuarioid == null)
                    {
                        Usuario user = new Usuario();
                        user.nome = "Anônimo";
                        user.email = "###@###";
                        user.telefone = "(##) ####-####";
                        item.Usuario = user;
                    }
                }

                return Ok(listaRelatos);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("relatos/exluir")]
        public IHttpActionResult Excluir(int id)
        {
            var relato = ctx.Relatos.Find(id);

            ctx.Relatos.Remove(relato);
            ctx.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("relatos/salvar")]
        public IHttpActionResult DeleteRelatos(string relato, string imagem, decimal latitude, decimal longitude, int id)
        {

            Relatos Rel = new Relatos();
            Rel.relato = relato;
            Rel.imagem = imagem;
            Rel.latitude = latitude;
            Rel.longitude = longitude;
            Rel.usuarioid = id;
            if (id == 0)
            {
                Rel.usuarioid = null;
            }

            ctx.Relatos.Add(Rel);
            ctx.SaveChanges();
            return Ok();
        }





    }
}
