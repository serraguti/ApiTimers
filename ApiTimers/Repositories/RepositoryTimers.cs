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

        public Empresa CreateEmpresa(string nombre)
        {
            int idempresa = this.GetMaxIdEmpresa(); 
            Empresa empresa = new Empresa();
            empresa.IdEmpresa = idempresa;
            empresa.NombreEmpresa = nombre;
            empresa.Imagen = "https://www.nomaspapel.es/assets/blog/5e99714cb4a08947402795.png";
            this.context.Empresas.Add(empresa);
            this.context.SaveChanges();
            return empresa;
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

        public Evento CreateEvento(string nombreevento
            , DateTime inicio, DateTime fin)
        {
            int id = this.GetMaxIdEvento();
            Evento evento = new Evento();
            evento.IdEvento = id;
            evento.NombreEvento = nombreevento;
            evento.InicioEvento = inicio;
            evento.FinEvento = fin;
            this.context.Eventos.Add(evento);
            this.context.SaveChanges();
            return evento;
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
            if (this.context.Eventos.Count() == 0)
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

        public Sala CreateSala(string nombre)
        {
            Sala sala = new Sala();
            sala.IdSala = this.GetMaxIdSala();
            sala.NombreSala = nombre;
            this.context.Salas.Add(sala);
            this.context.SaveChanges();
            return sala;
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
            if (this.context.Salas.Count() == 0)
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

        public Temporizador CreateTemporizador(DateTime inicio,
            int idcategoria)
        {
            int id = this.GetMaxIdTimer(); 
            Temporizador timer = new Temporizador();
            timer.IdTemporizador = id;
            timer.Inicio = inicio;
            timer.IdCategoria = idcategoria;
            timer.Pausa = false;
            this.context.Timers.Add(timer);
            this.context.SaveChanges();
            return timer;
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
            if (this.context.Timers.Count() == 0)
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

        public TiempoEmpresaSala CreateTiempoEmpresaSalas(
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
            return tiempo;
        }

        private int GetMaxIdTiempoEmpresaSala()
        {
            if (this.context.TiempoEmpresaSalas.Count() == 0)
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

        public Usuario CreateUser(string username, string pass)
        {
            Usuario user = new Usuario();
            user.IdUsuario = this.GetMaxIdUsuarios();
            user.UserName = username;
            user.Password = pass;
            this.context.Usuarios.Add(user);
            this.context.SaveChanges();
            return user;
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
            if (this.context.Usuarios.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Usuarios.Max(z => z.IdUsuario) + 1;
            }
        }
        #endregion

        #region CATEGORIAS TIMER
        public List<CategoriaTimer> GetCategoriasTimer()
        {
            return this.context.CategoriasTimers.ToList();
        }

        public CategoriaTimer FindCategoriasTimer(int id)
        {
            return this.context.CategoriasTimers.FirstOrDefault(z => z.IdCategoria == id);
        }

        public CategoriaTimer CreateCategoriaTimer
            (string nombreCategoria, int duracion)
        {
            CategoriaTimer cat = new CategoriaTimer();
            cat.IdCategoria = this.GetMaxIdCategoriaTimers();
            cat.Categoria = nombreCategoria;
            cat.Duracion = duracion;
            this.context.CategoriasTimers.Add(cat);
            this.context.SaveChanges();
            return cat;
        }

        public void UpdateCategoriaTimer(int id
            , string nombreCategoria, int duracion)
        {
            CategoriaTimer cat = this.FindCategoriasTimer(id);
            cat.Categoria = nombreCategoria;
            cat.Duracion = duracion;
            this.context.SaveChanges();
        }

        public void DeleteCategoriaTimer(int id)
        {
            CategoriaTimer cat = this.FindCategoriasTimer(id);
            this.context.CategoriasTimers.Remove(cat);
            this.context.SaveChanges();
        }

        private int GetMaxIdCategoriaTimers()
        {
            if (this.context.CategoriasTimers.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.CategoriasTimers.Max(z => z.IdCategoria) + 1;
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
