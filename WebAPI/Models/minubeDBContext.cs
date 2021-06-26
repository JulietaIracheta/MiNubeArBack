using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Models
{
    public partial class minubeDBContext : DbContext
    {
        public minubeDBContext()
        {
        }

        public minubeDBContext(DbContextOptions<minubeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActividadCurso> ActividadCurso { get; set; }
        public virtual DbSet<Actividades> Actividades { get; set; }
        public virtual DbSet<Comentarios> Comentarios { get; set; }
        public virtual DbSet<Comunicados> Comunicados { get; set; }
        public virtual DbSet<ContenidoMateriaCurso> ContenidoMateriaCurso { get; set; }
        public virtual DbSet<Contenidos> Contenidos { get; set; }
        public virtual DbSet<CursoDocente> CursoDocente { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<EstudianteCurso> EstudianteCurso { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Historiales> Historiales { get; set; }
        public virtual DbSet<Informes> Informes { get; set; }
        public virtual DbSet<InstitucionCurso> InstitucionCurso { get; set; }
        public virtual DbSet<InstitucionDocente> InstitucionDocente { get; set; }
        public virtual DbSet<InstitucionEstudiante> InstitucionEstudiante { get; set; }
        public virtual DbSet<InstitucionMateria> InstitucionMateria { get; set; }
        public virtual DbSet<InstitucionTutor> InstitucionTutor { get; set; }
        public virtual DbSet<Instituciones> Instituciones { get; set; }
        public virtual DbSet<MateriaCurso> MateriaCurso { get; set; }
        public virtual DbSet<MateriaDocente> MateriaDocente { get; set; }
        public virtual DbSet<MateriaEstudiante> MateriaEstudiante { get; set; }
        public virtual DbSet<Materias> Materias { get; set; }
        public virtual DbSet<NivelEducativo> NivelEducativo { get; set; }
        public virtual DbSet<NivelEducativoEstudiante> NivelEducativoEstudiante { get; set; }
        public virtual DbSet<Notificacion> Notificacion { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<RolInstitucion> RolInstitucion { get; set; }
        public virtual DbSet<RolPermiso> RolPermiso { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TutorEstudiante> TutorEstudiante { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HOQKQ7D\\SQLEXPRESS2019;Database=minubeDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActividadCurso>(entity =>
            {
                entity.HasKey(e => e.IdActividadCurso)
                    .HasName("PK__Activida__153F1E0D2576B4A1");

                entity.ToTable("Actividad_Curso");

                entity.Property(e => e.IdActividadCurso).HasColumnName("idActividadCurso");

                entity.Property(e => e.IdActividad).HasColumnName("idActividad");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.HasOne(d => d.IdActividadNavigation)
                    .WithMany(p => p.ActividadCurso)
                    .HasForeignKey(d => d.IdActividad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Curso_Actividad");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.ActividadCurso)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Actividad_Curso");
            });

            modelBuilder.Entity<Actividades>(entity =>
            {
                entity.HasKey(e => e.IdActividad)
                    .HasName("PK__Activida__327F9BED826ABA7D");

                entity.Property(e => e.IdActividad).HasColumnName("idActividad");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comentarios>(entity =>
            {
                entity.HasKey(e => e.IdComentario)
                    .HasName("PK__Comentar__C74515DA1C70AC3B");

                entity.Property(e => e.IdComentario).HasColumnName("idComentario");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdContenido).HasColumnName("idContenido");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdContenidoNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.IdContenido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Comentario_Contenido");
            });

            modelBuilder.Entity<Comunicados>(entity =>
            {
                entity.HasKey(e => e.IdComunicado)
                    .HasName("PK__Comunica__C3A14C53272D24A1");

                entity.Property(e => e.IdComunicado).HasColumnName("idComunicado");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdDocente).HasColumnName("idDocente");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdDocenteNavigation)
                    .WithMany(p => p.ComunicadosIdDocenteNavigation)
                    .HasForeignKey(d => d.IdDocente)
                    .HasConstraintName("fk_docente");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ComunicadosIdUsuarioNavigation)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_Comunicado");
            });

            modelBuilder.Entity<ContenidoMateriaCurso>(entity =>
            {
                entity.HasKey(e => e.IdContenidoMateriaCurso)
                    .HasName("PK__Contenid__D68ED76E0CA2E5B1");

                entity.ToTable("Contenido_Materia_Curso");

                entity.Property(e => e.IdContenidoMateriaCurso).HasColumnName("idContenidoMateriaCurso");

                entity.Property(e => e.IdContenido).HasColumnName("idContenido");

                entity.Property(e => e.IdMateriaCurso).HasColumnName("idMateriaCurso");

                entity.HasOne(d => d.IdContenidoNavigation)
                    .WithMany(p => p.ContenidoMateriaCurso)
                    .HasForeignKey(d => d.IdContenido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Contenido_Materia_Curso");

                entity.HasOne(d => d.IdMateriaCursoNavigation)
                    .WithMany(p => p.ContenidoMateriaCurso)
                    .HasForeignKey(d => d.IdMateriaCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Materia_Curso_Contenido");
            });

            modelBuilder.Entity<Contenidos>(entity =>
            {
                entity.HasKey(e => e.IdContenido)
                    .HasName("PK__Contenid__7FB5C29E6BE6AB3C");

                entity.Property(e => e.IdContenido).HasColumnName("idContenido");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unidad).HasColumnName("unidad");

                entity.Property(e => e.Video)
                    .HasColumnName("video")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CursoDocente>(entity =>
            {
                entity.HasKey(e => e.IdCursoDocente)
                    .HasName("PK__Curso_Do__B27B0DE7F54A5730");

                entity.ToTable("Curso_Docente");

                entity.Property(e => e.IdCursoDocente).HasColumnName("idCursoDocente");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdDocente).HasColumnName("idDocente");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.CursoDocente)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Docente_Curso");

                entity.HasOne(d => d.IdDocenteNavigation)
                    .WithMany(p => p.CursoDocente)
                    .HasForeignKey(d => d.IdDocente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Curso_Docente");
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Cursos__8551ED052FFF827E");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstudianteCurso>(entity =>
            {
                entity.HasKey(e => e.IdEstudianteCurso)
                    .HasName("PK__Estudian__6F838887FF022DD6");

                entity.ToTable("Estudiante_Curso");

                entity.Property(e => e.IdEstudianteCurso).HasColumnName("idEstudianteCurso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.EstudianteCurso)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Curso_Estudiante");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.EstudianteCurso)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Estudiante_Curso");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__Evento__C8DC7BDA5DBD498A");

                entity.Property(e => e.IdEvento).HasColumnName("idEvento");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.Start)
                    .HasColumnName("start")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Evento_Curso");
            });

            modelBuilder.Entity<Historiales>(entity =>
            {
                entity.HasKey(e => e.IdHistorial)
                    .HasName("PK__Historia__4712FB33C5327CC0");

                entity.Property(e => e.IdHistorial).HasColumnName("idHistorial");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Historiales)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Curso_Historial");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Historiales)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_Historial");
            });

            modelBuilder.Entity<Informes>(entity =>
            {
                entity.HasKey(e => e.IdInforme)
                    .HasName("PK__Informes__8BC324EA938D0E1B");

                entity.Property(e => e.IdInforme).HasColumnName("idInforme");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Informes)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Curso_Informe");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Informes)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_Informe");
            });

            modelBuilder.Entity<InstitucionCurso>(entity =>
            {
                entity.HasKey(e => e.IdInstitucionCurso)
                    .HasName("PK__Instituc__F57B97AAB00A065C");

                entity.ToTable("Institucion_Curso");

                entity.Property(e => e.IdInstitucionCurso).HasColumnName("idInstitucionCurso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdInstitucion).HasColumnName("idInstitucion");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.InstitucionCurso)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Institucion_Curso");

                entity.HasOne(d => d.IdInstitucionNavigation)
                    .WithMany(p => p.InstitucionCurso)
                    .HasForeignKey(d => d.IdInstitucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Institucion4");
            });

            modelBuilder.Entity<InstitucionDocente>(entity =>
            {
                entity.HasKey(e => e.IdInstitucionDocente)
                    .HasName("PK__Instituc__11AD28D2DBBA28B7");

                entity.ToTable("Institucion_Docente");

                entity.Property(e => e.IdInstitucionDocente).HasColumnName("idInstitucionDocente");

                entity.Property(e => e.IdDocente).HasColumnName("idDocente");

                entity.Property(e => e.IdInstitucion).HasColumnName("idInstitucion");

                entity.HasOne(d => d.IdDocenteNavigation)
                    .WithMany(p => p.InstitucionDocente)
                    .HasForeignKey(d => d.IdDocente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Institucion_Docente");

                entity.HasOne(d => d.IdInstitucionNavigation)
                    .WithMany(p => p.InstitucionDocente)
                    .HasForeignKey(d => d.IdInstitucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Institucion2");
            });

            modelBuilder.Entity<InstitucionEstudiante>(entity =>
            {
                entity.HasKey(e => e.IdInstitucionEstudiante)
                    .HasName("PK__Instituc__E00C5551E0D2DFC9");

                entity.ToTable("Institucion_Estudiante");

                entity.Property(e => e.IdInstitucionEstudiante).HasColumnName("idInstitucionEstudiante");

                entity.Property(e => e.IdInstitucion).HasColumnName("idInstitucion");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdInstitucionNavigation)
                    .WithMany(p => p.InstitucionEstudiante)
                    .HasForeignKey(d => d.IdInstitucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Institucion_Estudiante");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.InstitucionEstudiante)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Estudiante_Institucion");
            });

            modelBuilder.Entity<InstitucionMateria>(entity =>
            {
                entity.HasKey(e => e.IdInstitucionMateria)
                    .HasName("PK__Instituc__4A944EF84841BC38");

                entity.ToTable("Institucion_Materia");

                entity.Property(e => e.IdInstitucionMateria).HasColumnName("idInstitucionMateria");

                entity.Property(e => e.IdInstitucion).HasColumnName("idInstitucion");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.HasOne(d => d.IdInstitucionNavigation)
                    .WithMany(p => p.InstitucionMateria)
                    .HasForeignKey(d => d.IdInstitucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Institucion3");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.InstitucionMateria)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Institucion_Materia");
            });

            modelBuilder.Entity<InstitucionTutor>(entity =>
            {
                entity.HasKey(e => e.IdInstitucionTutor)
                    .HasName("PK__Instituc__77FEF413FCE71BE0");

                entity.ToTable("Institucion_Tutor");

                entity.Property(e => e.IdInstitucionTutor).HasColumnName("idInstitucionTutor");

                entity.Property(e => e.IdInstitucion).HasColumnName("idInstitucion");

                entity.Property(e => e.IdTutor).HasColumnName("idTutor");

                entity.HasOne(d => d.IdInstitucionNavigation)
                    .WithMany(p => p.InstitucionTutor)
                    .HasForeignKey(d => d.IdInstitucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Institucion");

                entity.HasOne(d => d.IdTutorNavigation)
                    .WithMany(p => p.InstitucionTutor)
                    .HasForeignKey(d => d.IdTutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Institucion_Tutor");
            });

            modelBuilder.Entity<Instituciones>(entity =>
            {
                entity.HasKey(e => e.IdInstitucion)
                    .HasName("PK__Instituc__DF824EF247A888D0");

                entity.Property(e => e.IdInstitucion).HasColumnName("idInstitucion");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MateriaCurso>(entity =>
            {
                entity.HasKey(e => e.IdMateriaCurso)
                    .HasName("PK__Materia___CAECACA9A454F343");

                entity.ToTable("Materia_Curso");

                entity.Property(e => e.IdMateriaCurso).HasColumnName("idMateriaCurso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.MateriaCurso)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Materia_Curso");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.MateriaCurso)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Curso_Materia");
            });

            modelBuilder.Entity<MateriaDocente>(entity =>
            {
                entity.HasKey(e => e.IdMateriaDocente)
                    .HasName("PK__Materia___48FD32CCE46A7B14");

                entity.ToTable("Materia_Docente");

                entity.Property(e => e.IdMateriaDocente).HasColumnName("idMateriaDocente");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.MateriaDocente)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Materia_Docente");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.MateriaDocente)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Docente_Materia");
            });

            modelBuilder.Entity<MateriaEstudiante>(entity =>
            {
                entity.HasKey(e => e.IdMateriaEstudiante)
                    .HasName("PK__Materia___CB2C43FEE4196CBF");

                entity.ToTable("Materia_Estudiante");

                entity.Property(e => e.IdMateriaEstudiante).HasColumnName("idMateriaEstudiante");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.MateriaEstudiante)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Materia_Estudiante");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.MateriaEstudiante)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Estudiante_Materia");
            });

            modelBuilder.Entity<Materias>(entity =>
            {
                entity.HasKey(e => e.IdMateria)
                    .HasName("PK__Materias__4B740AB35D6BBB65");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NivelEducativo>(entity =>
            {
                entity.HasKey(e => e.IdNivelEducativo)
                    .HasName("PK__NivelEdu__9DE22F0B433D429B");

                entity.Property(e => e.IdNivelEducativo).HasColumnName("idNivelEducativo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NivelEducativoEstudiante>(entity =>
            {
                entity.HasKey(e => e.IdNivelEducativoEstudiante)
                    .HasName("PK__Nivel_Ed__38BE3624104EAB61");

                entity.ToTable("Nivel_Educativo_Estudiante");

                entity.Property(e => e.IdNivelEducativoEstudiante).HasColumnName("idNivelEducativoEstudiante");

                entity.Property(e => e.IdNivelEducativo).HasColumnName("idNivelEducativo");

                entity.Property(e => e.IdUsuarioEstudiante).HasColumnName("idUsuarioEstudiante");

                entity.HasOne(d => d.IdNivelEducativoNavigation)
                    .WithMany(p => p.NivelEducativoEstudiante)
                    .HasForeignKey(d => d.IdNivelEducativo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Nivel_Educativo_Estudiante");

                entity.HasOne(d => d.IdUsuarioEstudianteNavigation)
                    .WithMany(p => p.NivelEducativoEstudiante)
                    .HasForeignKey(d => d.IdUsuarioEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_Estudiante2");
            });

            modelBuilder.Entity<Notificacion>(entity =>
            {
                entity.HasKey(e => e.IdNotificacion)
                    .HasName("PK__Notifica__AFE1D7E40FF749E3");

                entity.Property(e => e.IdNotificacion).HasColumnName("idNotificacion");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdDestinatario).HasColumnName("idDestinatario");

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .HasColumnName("mensaje")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoNotificacion).HasColumnName("tipoNotificacion");

                entity.HasOne(d => d.IdDestinatarioNavigation)
                    .WithMany(p => p.Notificacion)
                    .HasForeignKey(d => d.IdDestinatario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_destinatario");
            });

            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.HasKey(e => e.IdPermiso)
                    .HasName("PK__Permisos__06A5848604D2594E");

                entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");

                entity.Property(e => e.Operacion)
                    .IsRequired()
                    .HasColumnName("operacion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Personas__A478814140A689BA");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasColumnName("telefono");
            });

            modelBuilder.Entity<RolInstitucion>(entity =>
            {
                entity.HasKey(e => e.IdRolInstitucion)
                    .HasName("PK__Rol_Inst__0A8717A2654BE143");

                entity.ToTable("Rol_Institucion");

                entity.Property(e => e.IdRolInstitucion).HasColumnName("idRolInstitucion");

                entity.Property(e => e.IdInstitucion).HasColumnName("idInstitucion");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.HasOne(d => d.IdInstitucionNavigation)
                    .WithMany(p => p.RolInstitucion)
                    .HasForeignKey(d => d.IdInstitucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Institucion_Rol");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolInstitucion)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Rol_Institucion");
            });

            modelBuilder.Entity<RolPermiso>(entity =>
            {
                entity.HasKey(e => e.IdrolPermiso)
                    .HasName("PK__Rol_Perm__6489BF9FD7C895EB");

                entity.ToTable("Rol_Permiso");

                entity.Property(e => e.IdrolPermiso).HasColumnName("idrolPermiso");

                entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.HasOne(d => d.IdPermisoNavigation)
                    .WithMany(p => p.RolPermiso)
                    .HasForeignKey(d => d.IdPermiso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Permiso");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolPermiso)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Rol_Permiso");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Roles__3C872F766A61C711");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TutorEstudiante>(entity =>
            {
                entity.HasKey(e => e.IdTutorEstudiante)
                    .HasName("PK__Tutor_Es__625558DA16D70579");

                entity.ToTable("Tutor_Estudiante");

                entity.Property(e => e.IdTutorEstudiante).HasColumnName("idTutorEstudiante");

                entity.Property(e => e.IdUsuarioEstudiante).HasColumnName("idUsuarioEstudiante");

                entity.Property(e => e.IdUsuarioTutor).HasColumnName("idUsuarioTutor");

                entity.HasOne(d => d.IdUsuarioEstudianteNavigation)
                    .WithMany(p => p.TutorEstudianteIdUsuarioEstudianteNavigation)
                    .HasForeignKey(d => d.IdUsuarioEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_Estudiante");

                entity.HasOne(d => d.IdUsuarioTutorNavigation)
                    .WithMany(p => p.TutorEstudianteIdUsuarioTutorNavigation)
                    .HasForeignKey(d => d.IdUsuarioTutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_Tutor");
            });

            modelBuilder.Entity<UsuarioRol>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioRol)
                    .HasName("PK__Usuario___50B092079C68C1D9");

                entity.ToTable("Usuario_Rol");

                entity.Property(e => e.IdUsuarioRol).HasColumnName("idUsuarioRol");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.UsuarioRol)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Rol");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioRol)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A6F2EF94A4");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaEliminacionLogico)
                    .HasColumnName("fecha_eliminacion_logico")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fecha_modificacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioNombre)
                    .IsRequired()
                    .HasColumnName("usuario_nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("fk_Persona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
