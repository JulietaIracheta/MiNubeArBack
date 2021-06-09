﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using WebAPI.Dto;

namespace WebAPI.Data

{
    public interface IUsuarioRepository
    {
        Usuarios GetByEmail(string email);
    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly minubeDBContext _context;

        public UsuarioRepository(minubeDBContext context)
        {
            _context = context;
        }
        
        public Usuarios GetByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.UsuarioNombre == email);
        }

        
    }
}
