using ApiTimers.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTimers.Data
{
    public class TimersContext: DbContext
    {
        public TimersContext(DbContextOptions<TimersContext> options)
      : base(options) { }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Sala> Salas{ get; set; }
        public DbSet<Temporizador> Timers { get; set; }
        public DbSet<TimerEvento> TimerEventos { get; set; }
        public DbSet<TiempoEmpresaSala> TiempoEmpresaSalas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
