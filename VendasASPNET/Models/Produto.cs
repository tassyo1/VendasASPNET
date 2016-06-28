using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendasASPNET.Models
{
    [Table("Produtos")]
    public class Produto
    {
        public int ID { get; set; }

        [StringLength(20)]
        public String Nome { get; set; }

        public decimal Preco { get; set; }

        public String Descricao { get; set; }

        public int Quantidade { get; set; }

        public virtual Categoria Categoria { get; set; }

        public  int categoriaID { get; set; }
    }
}