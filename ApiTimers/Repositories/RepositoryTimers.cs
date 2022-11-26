using ApiTimers.Data;
using ApiTimers.Models;

namespace ApiTimers.Repositories
{
    public class RepositoryTimers
    {
        private TimersContext context;

        public RepositoryTimers(TimersContext context)
        {
            this.context = context;
        }

        #region EMPRESAS
        
        public List<Empresa> GetEmpresas()
        {
            return this.context.Empresas.ToList();
        }

        public Empresa FindEmpresa(int idempresa)
        {
            return this.context.Empresas.FirstOrDefault(z => z.IdEmpresa == idempresa);
        }

        public void CreateEmpresa(string nombre)
        {
            Empresa empresa = new Empresa();
            empresa.IdEmpresa = this.GetMaxIdEmpresa();
            empresa.NombreEmpresa = nombre;
            empresa.Imagen = "https://www.nomaspapel.es/assets/blog/5e99714cb4a08947402795.png";
            this.context.Empresas.Add(empresa);
            this.context.SaveChanges();
        }

        public void UpdateEmpresa(int id, string nombre)
        {
            Empresa empresa = this.FindEmpresa(id);
            empresa.NombreEmpresa = nombre;
            this.context.SaveChanges();
        }

        private int GetMaxIdEmpresa()
        {
            if (this.context.Empresas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Empresas.Max(z => z.IdEmpresa) + 1;
            }
        }

        #endregion

        #region EVENTOS

        public List<Evento> GetEventos()
        {
            return this.context.Eventos.ToList();
        }

        public void CreateEvento(string nombreevento
            , DateTime inicio, DateTime fin)
        {
            Evento evento = new Evento();
            evento.IdEvento = this.GetMaxIdEvento();
            evento.NombreEvento = nombreevento;
            evento.InicioEvento = inicio;
            evento.FinEvento = fin;
            this.context.Eventos.Add(evento);
            this.context.SaveChanges();
        }

        public void UpdateEvento(int id,
            string nombreevento
            , DateTime inicio, DateTime fin)
        {
            Evento evento = this.FindEvento(id);
            evento.NombreEvento = nombreevento;
            evento.InicioEvento = inicio;
            evento.FinEvento = fin;
            this.context.SaveChanges();
        }

        public Evento FindEvento(int id)
        {
            return this.context.Eventos.FirstOrDefault(z => z.IdEvento == id);
        }

        public void DeleteEvento(int id)
        {
            Evento evento = this.FindEvento(id);
            this.context.Eventos.Remove(evento);
            this.context.SaveChanges();
        }

        private int GetMaxIdEvento()
        {
            if (this.context.Empresas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Eventos.Max(z => z.IdEvento) + 1;
            }
        }

        #endregion

        #region SALAS

        public List<Sala> GetSalas()
        {
            return this.context.Salas.ToList();
        }

        public Sala FindSala(int idsala)
        {
            return this.context.Salas.FirstOrDefault(z => z.IdSala == idsala);
        }

        public void CreateSala(string nombre)
        {
            Sala sala = new Sala();
            sala.IdSala = this.GetMaxIdSala();
            sala.NombreSala = nombre;
            this.context.Salas.Add(sala);
            this.context.SaveChanges();
        }

        public void UpdateSala(int id, string nombre)
        {
            Sala sala = this.FindSala(id);
            sala.NombreSala = nombre;
            this.context.SaveChanges();
        }

        public void DeleteSala(int id)
        {
            Sala sala = this.FindSala(id);
            this.context.Salas.Remove(sala);
            this.context.SaveChanges();
        }

        private int GetMaxIdSala()
        {
            if (this.context.Empresas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Salas.Max(z => z.IdSala) + 1;
            }
        }

        #endregion

        #region TIMERS
        public List<Temporizador> GetTiempos()
        {
            return this.context.Timers.ToList();
        }

        public Temporizador FindTemporizador(int id)
        {
            return this.context.Timers.FirstOrDefault(z => z.IdTemporizador == id);
        }

        public void CreateTemporizador(DateTime inicio,
            int idcategoria)
        {
            Temporizador timer = new Temporizador();
            timer.IdTemporizador = this.GetMaxIdTimer();
            timer.Inicio = inicio;
            timer.IdCategoria = idcategoria;
            timer.Pausa = false;
            this.context.Timers.Add(timer);
            this.context.SaveChanges();
        }

        public void UpdateTemporizador(int id,DateTime inicio,
            int idcategoria, bool pausa)
        {
            Temporizador timer = this.FindTemporizador(id);
            timer.Inicio = inicio;
            timer.IdCategoria = idcategoria;
            timer.Pausa = pausa;
            this.context.SaveChanges();
        }

        public void PausarTemporizador(int id)
        {
            Temporizador timer = this.FindTemporizador(id);
            timer.Pausa = true;
            this.context.SaveChanges();
        }

        public void DeleteTemporizador(int id)
        {
            Temporizador timer = this.FindTemporizador(id);
            this.context.Timers.Remove(timer);
            this.context.SaveChanges();
        }

        private int GetMaxIdTimer()
        {
            if (this.context.Empresas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Timers.Max(z => z.IdTemporizador) + 1;
            }
        }

        #endregion

        #region TIEMPO EMPRESAS SALAS

        public List<TiempoEmpresaSala> GetTiempoEmpresaSalas()
        {
            return this.context.TiempoEmpresaSalas.ToList();
        }

        public TiempoEmpresaSala FindTiempoEmpresaSalas(int id)
        {
            return this.context.TiempoEmpresaSalas.FirstOrDefault(z => z.Id == id);
        }

        public void CreateTiempoEmpresaSalas(
            int idtimer, int idempresa, int idsala, int idevento)
        {
            TiempoEmpresaSala tiempo = new TiempoEmpresaSala();
            tiempo.Id = this.GetMaxIdTiempoEmpresaSala();
            tiempo.IdSala = idsala;
            tiempo.IdTimer = idtimer;
            tiempo.IdEmpresa = idempresa;
            tiempo.IdEvento = idevento;
            this.context.TiempoEmpresaSalas.Add(tiempo);
            this.context.SaveChanges();
        }

        private int GetMaxIdTiempoEmpresaSala()
        {
            if (this.context.Empresas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.TiempoEmpresaSalas.Max(z => z.Id) + 1;
            }
        }

        #endregion

        #region USUARIOS
        public List<Usuario> GetUsuarios()
        {
            return this.context.Usuarios.ToList();
        }

        public void CreateUser(string username, string pass)
        {
            Usuario user = new Usuario();
            user.IdUsuario = this.GetMaxIdUsuarios();
            user.UserName = username;
            user.Password = pass;
            this.context.Usuarios.Add(user);
            this.context.SaveChanges();
        }

        public Usuario 
            ExisteUsuario(String userName, string pass)
        {
            return this.context.Usuarios.SingleOrDefault
                (x => x.UserName == userName 
                && x.Password == pass);
        }


        private int GetMaxIdUsuarios()
        {
            if (this.context.Empresas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Usuarios.Max(z => z.IdUsuario) + 1;
            }
        }
        #endregion



        #region TIMER EVENTOS
        public List<TimerEvento> GetTimersEventos()
        {
            var consulta = from datos in this.context.TimerEventos
                           orderby datos.InicioEvento
                           select datos;
            return consulta.ToList();
        }

        public List<TimerEvento> GetTimersEventosCategoria(int idcategoria)
        {
            var consulta = from datos in this.context.TimerEventos
                           where datos.IdCategoria == idcategoria
                           orderby datos.InicioEvento
                           select datos;
            return consulta.ToList();
        }

        public List<TimerEvento> GetTimersEventosEmpresa(int idempresa)
        {
                var consulta = from datos in this.context.TimerEventos
                               where datos.IdEmpresa == idempresa
                               orderby datos.InicioEvento
                               select datos;
                return consulta.ToList();
        }

        public List<TimerEvento> GetTimersEventosSalas(int idsala)
        {
            var consulta = from datos in this.context.TimerEventos
                           where datos.IdSala == idsala
                           orderby datos.InicioEvento
                           select datos;
            return consulta.ToList();
        }

        public List<TimerEvento> GetTimersEventosEventos(int idevento)
        {
            var consulta = from datos in this.context.TimerEventos
                           where datos.IdEvento == idevento
                           orderby datos.InicioEvento
                           select datos;
            return consulta.ToList();
        }

        public TimerEvento FindTimersEventos(int id)
        {
            return this.context.TimerEventos.FirstOrDefault(z => z.UniqueId == id);
        }
#endregion
    }
}
