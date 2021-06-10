using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstudiantesV2.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEstudiantesV2.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        {

        }
        public DbSet<Persona> persona { get; set; }
        public DbSet<Estudiante> estudiante { get; set; }
        public DbSet<Carrera> carrera { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<TipoUsuario> tipoUsuario { get; set; }
    }
    

}
