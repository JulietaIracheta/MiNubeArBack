﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Dto;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IInformeRepository
    {
        Informes GetById(int id);
        IQueryable<string> GetInformeTrayectoria(int estudianteId, int anio);
        IQueryable<string> GetByEstudianteId(int estudianteId);
        Informes Crear(InformeDto informe, string contentRootPath);
    }
    public class InformeRepository : IInformeRepository
    {
        private readonly minubeDBContext _context;

        public InformeRepository(minubeDBContext context)
        {
            _context = context;
        }
        public Informes GetById(int id)
        {
            return _context.Informes.FirstOrDefault(x => x.IdInforme == id);
        }

        public IQueryable<string> GetByEstudianteId(int estudianteId)
        {
            DateTime año = DateTime.Today;
            var a = año.Year;

            var inf = _context.Informes
                .Include(p => p.IdUsuarioNavigation)
                .Where(c => c.IdUsuario == estudianteId && c.Año == a).Select(p => p.Informe);
            return inf;

        }
        public IQueryable<string> GetInformeTrayectoria(int estudianteId, int anio)
        {

            var inf = _context.Informes
                .Include(p => p.IdUsuarioNavigation)
                .Where(c => c.IdUsuario == estudianteId && c.Año == anio).Select(p => p.Informe);
            return inf;

        }
        public List<InformeTrayectoria> GetInformeTrayectoriaEstudiante(int estudianteId)
        {

            var inf = _context.InformeTrayectoria
                .Where(c => c.IdEstudiante == estudianteId).OrderBy(x => x.Año).ToList();
            return inf;

        }
        public List<TrayectoriaDto> GetTrayectoriaEstudiante(int estudianteId)
        {

            var inf = _context.Trayectoria.Include(x => x.IdInformeNavigation).ThenInclude(x => x.IdCursoNavigation).ThenInclude(x => x.EstudianteCurso)
                .Where(c => c.IdInformeNavigation.IdUsuario == estudianteId);

            var años = inf.OrderByDescending(a => a.Año).Select(x => x.Año).Distinct();
            var listaTrayectoria = new List<TrayectoriaDto>();
            foreach (var año in años)
            {
                var t = new TrayectoriaDto
                {
                    Año = año,
                    Curso = inf.First(c => c.Año == año).IdInformeNavigation.IdCursoNavigation.Nombre,
                    Informe = inf.First(c => c.Año == año).IdInformeNavigation.Informe,
                    MateriaCalificacion = new List<MateriaCalificacionDto>()
                };
                foreach (var i in inf.Where(a => a.Año == año))
                {

                    t.MateriaCalificacion.Add(new MateriaCalificacionDto
                    {
                        Materia = i.Materia,
                        Calificacion = i.Calificacion
                    });
                };
                listaTrayectoria.Add(t);
            }

            return listaTrayectoria;

        }

        public Informes Crear(InformeDto informe, string contentRootPath)
        {
            var nombreInforme = FileHelper2.GuardarInforme(contentRootPath, informe.file);

            var informes = new Informes
            {
                IdUsuario = informe.IdUsuario,
                Informe = nombreInforme,
                IdCurso = informe.IdCurso,
                Año = informe.Año
            };

            _context.Informes.Add(informes);
            _context.SaveChanges();
            return informes;
        }

        /*    public InformeTrayectoria CrearInformeTrayectoria(InformeTrayectoria informe)
            {
                var informes = new InformeTrayectoria
                {
                    IdEstudiante = informe.IdEstudiante,
                    Curso = informe.Curso,
                    Año = informe.Año,
                    Institucion = informe.Institucion,
                    Matematica = informe.Matematica,
                    Lengua = informe.Lengua,
                    Sociales = informe.Sociales,
                    Naturales = informe.Naturales,
                    Promedio = Promedio(informe.IdEstudiante, informe.Año)
                };
                _context.InformeTrayectoria.Add(informes);
                _context.SaveChanges();
                return informes;
            }*/

        public Trayectoria CrearInformeTrayectoria(Trayectoria informe)
        {
            var materias = new List<MateriaCalificacion>();
            var tray = new Trayectoria();
            var inf = new Informes();
            foreach (var i in informe.Calificaciones)
            {

                tray.IdInforme = 26;
                tray.Año = informe.Año;
                tray.Materia = i.Materia;
                tray.Calificacion = i.Calificacion;
               
                _context.Trayectoria.Add(tray);
               
            }
            _context.SaveChanges();


            return informe;
        }

        public decimal Promedio(int est, int año)
        {

            /*int materias = _context.Boletin.GroupBy(x => new { x.Año }).Count();
            return _context.Boletin
                .Where(z => z.IdEstudiante == est && z.Año == año)
                .GroupBy(m => new { m.IdEstudiante, m.Año })
                .Select(m => m.Sum(i => i.Prom) / materias).FirstOrDefault();
            */
            return 0;
        }
    }
}
