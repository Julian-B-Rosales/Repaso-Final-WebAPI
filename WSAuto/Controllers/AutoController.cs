using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Linq;
using WSAuto.Context;
using WSAuto.Models;

namespace WSAuto.Controllers
{
    [Route("api/auto")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly DBWsAutoContext context;
        public AutoController(DBWsAutoContext context)
        {
            this.context = context;
        }

        //GET /api/auto
        [HttpGet]
        public IEnumerable<Auto> GetAll()
        {
            return context.Autos.ToList();
        }

        //GET /api/auto/modelo/{modelo}
        [HttpGet("modelo/{modelo}")]
        public ActionResult<IEnumerable<Auto>> GetByModelo(string modelo)
        {
            List<Auto> autos = (from a in context.Autos
                                where a.Modelo == modelo
                                select a).ToList();

            if (autos == null)
            {
                return NotFound();
            }

            return autos;

        }

        //GET /api/auto/marca/{marca}
        [HttpGet("marca/{marca}")]
        public ActionResult<IEnumerable<Auto>> GetByMarca(string marca)
        {
            List<Auto> autos = (from a in context.Autos
                                where a.Marca == marca
                                select a).ToList();

            if (autos == null)
            {
                return NotFound();
            }

            return autos;

        }

        //GET /api/auto/id
        [HttpGet("{id}")]
        public ActionResult<Auto> Get(string id)
        {
            Auto auto = context.Autos.Find(id);

            if (auto == null)
            {
                return NotFound();
            }

            return auto;

        }

        //GET /api/auto/marca/{marca}/{modelo}
        [HttpGet("marca/{marca}/{modelo}")]
        public ActionResult<Auto> GetByMarcaYModelo(string marca, string modelo)
        {
            Auto auto = (from a in context.Autos
                                where a.Modelo == modelo && a.Marca == marca
                                select a).FirstOrDefault();

            if (auto == null)
            {
                return NotFound();
            }

            return auto;

        }

        //GET /api/auto/color/{color}
        [HttpGet("color/{color}")]
        public ActionResult<IEnumerable<Auto>> GetByColor(string color)
        {
            List<Auto> autos = (from a in context.Autos
                                where a.Color == color
                                select a).ToList();

            if (autos == null)
            {
                return NotFound();
            }

            return autos;

        }

        //POST /api/auto
        public ActionResult Post([FromBody] Auto auto)
        {
            if (!ModelState.IsValid )
            {
                return BadRequest(ModelState);
            }

            context.Autos.Add(auto);
            context.SaveChanges();

            return Ok();

        }

        //PUT /api/auto/id
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Auto auto)
        {
            if (id != auto.Id)
            {
                return BadRequest();
            }

            context.Entry(auto).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();

        }

        //DELETE /api/auto/id
        [HttpDelete("{id}")]
        public ActionResult<Auto> Delete(string id)
        {
            var res = context.Autos.FirstOrDefault(a => a.Id == id);
            if (res == null)
            {
                return NotFound();
            }

            context.Autos.Remove(res);
            context.SaveChanges();

            return res;
        }

    }
}
