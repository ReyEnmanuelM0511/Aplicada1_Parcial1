using Microsoft.EntityFrameworkCore;
using PrimerParcial.Models;

namespace PrimerParcial.Context;

    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        
        public DbSet<Autores> autores { get; set; }
    }

