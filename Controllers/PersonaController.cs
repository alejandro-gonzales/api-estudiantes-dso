using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstudiantesV2.Context;
using ApiEstudiantesV2.Models;

namespace ApiEstudiantesV2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly AppDbContext context;
        public PersonaController(AppDbContext _context)
        {
            this.context = _context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(context.persona.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("id", Name="GetById")]
        public ActionResult GetById(int id)
        {
            try
            {
                var persona = context.persona.FirstOrDefault(persona => persona.id == id);
                return Ok(persona);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }
        [HttpPost]
        public ActionResult Post([FromBody]Persona persona)
        {
            try
            {
                context.persona.Add(persona);
                context.SaveChanges();
                return CreatedAtRoute("GetById", new { persona.id }, persona);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
