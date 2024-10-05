using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cliente
    {
        /*
         dni
        nombre
        apellido
        email
        direccion
        ciudad
        cp
              
         */


        public int ClienteId { get; set; }

        public int ClienteDNI { get; set; }

        public string ClienteNombre { get; set; }

        public string ClienteApellido { get; set; }

        public string ClienteEmail { get; set; }

        public string ClienteDireccion { get; set; }

        public string ClienteCiudad { get; set; }

        public int ClienteCP { get; set; }

        public Cliente() { }
    }
}
