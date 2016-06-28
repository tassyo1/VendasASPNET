using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VendasASPNET.Models
{
    [Table("Produtos")]
    public class Produto
    {
        public int ID { get; set; }
        public String Nome { get; set; }
        public decimal Preco { get; set; }
        public String Descricao { get; set; }
        public int Quantidade { get; set; }
        public Categoria Categoria { get; set; }
        public virtual int categoriaID { get; set; }
    }
}