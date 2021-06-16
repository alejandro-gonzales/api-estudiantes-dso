using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstudiantesV2.Context;
using ApiEstudiantesV2.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEstudiantesV2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly AppDbContext context;
        public TipoUsuarioController(AppDbContext _context)
        {
            this.context = _context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(context.tipoUsuario.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var tipoUsuario = context.tipoUsuario.FirstOrDefault(item => item.id == id);
                return Ok(tipoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("id", Name = "GetByIdTipoUsuario")]
        [HttpPost]
        public ActionResult Post([FromBody] TipoUsuario tipoUsuario)
        {
            try
            {
                context.tipoUsuario.Add(tipoUsuario);
                context.SaveChanges();
                return CreatedAtRoute("GetByIdTipoUsuario", new { tipoUsuario.id }, tipoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TipoUsuario tipoUsuario)
        {
            try
            {
                if (tipoUsuario.id == id)
                {
                    context.Entry(tipoUsuario).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetById", new { id = tipoUsuario.id }, tipoUsuario);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var tipoUsuario = context.tipoUsuario.FirstOrDefault(p => p.id == id);
                if (tipoUsuario != null)
                {
                    context.tipoUsuario.Remove(tipoUsuario);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
