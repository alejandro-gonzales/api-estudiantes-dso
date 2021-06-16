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
    public class EstudianteController : ControllerBase
    {
        private readonly AppDbContext context;
        public EstudianteController(AppDbContext _context)
        {
            this.context = _context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(context.estudiante.ToList());
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
                var estudiante = context.estudiante.FirstOrDefault(item => item.id == id);
                return Ok(estudiante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("id", Name = "GetByIdEstudiante")]
        [HttpPost]
        public ActionResult Post([FromBody] Estudiante estudiante)
        {
            try
            {
                context.estudiante.Add(estudiante);
                context.SaveChanges();
                return CreatedAtRoute("GetByIdCarrera", new { estudiante.id }, estudiante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
