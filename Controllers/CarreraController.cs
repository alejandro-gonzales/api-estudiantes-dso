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
    public class CarreraController : ControllerBase
    {
        private readonly AppDbContext context;
        public CarreraController(AppDbContext _context)
        {
            this.context = _context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(context.carrera.ToList());
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
                var carrera = context.carrera.FirstOrDefault(item => item.id == id);
                return Ok(carrera);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("id", Name = "GetByIdCarrera")]
        [HttpPost]
        public ActionResult Post([FromBody] Carrera carrera)
        {
            try
            {
                context.carrera.Add(carrera);
                context.SaveChanges();
                return CreatedAtRoute("GetByIdCarrera", new { carrera.id }, carrera);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
