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
                .Where(c => c.IdUsuario == estudianteId && c.Año == a).Select(p=>p.Informe);
            return inf;
                
        }
        public IQueryable<string> GetInformeTrayectoria(int estudianteId, int anio)
        {

            var inf = _context.Informes
                .Include(p => p.IdUsuarioNavigation)
                .Where(c => c.IdUsuario == estudianteId && c.Año == anio).Select(p => p.Informe);
            return inf;

        }

        public Informes Crear(InformeDto informe, string contentRootPath)
        {
            var nombreInforme = FileHelper2.GuardarInforme(contentRootPath, informe.file);

            var informes = new Informes
            {
                IdUsuario = informe.IdUsuario,
                Informe = nombreInforme,
                Año = informe.Año
            };
          
            _context.Informes.Add(informes);
            _context.SaveChanges();
            return informes;
        }
    }
}
