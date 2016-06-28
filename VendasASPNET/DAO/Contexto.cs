using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using VendasASPNET.Models;

namespace VendasASPNET.DAO
{
    public class Contexto :DbContext
    {
        public DbSet<Categoria>Categorias { get; set; }
        public DbSet<Produto>Produtos { get; set; }
    }
}