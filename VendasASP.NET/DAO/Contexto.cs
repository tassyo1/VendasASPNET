using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using VendasASP.NET.Models;

namespace VendasASP.NET.DAO
{
    public class Contexto :DbContext
    {
        public DbSet<Categoria>Categorias { get; set; }
    }
}