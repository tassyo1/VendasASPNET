using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendasASP.NET.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public String Nome { get; set; }
        public float Preco { get; set; }
        public String Descricao { get; set; }

    }
}