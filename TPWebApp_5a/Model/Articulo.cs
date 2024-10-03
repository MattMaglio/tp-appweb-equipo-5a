using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Articulo
    {
        public int Id { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        
        //public int IdMarca { get; set; }
       // public int IdCategoria { get; set; }
        public decimal Precio { get; set; }

        public Imagen Imagen { get; set; }
        public Categoria Categoria { get; set; }
        public Marca Marca { get; set; }


    }
}
