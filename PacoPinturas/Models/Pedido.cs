using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Models
{
    class Pedido
    {
        public string id { get; set; }
        public DateTime fecha {
            get {
                DateTime thisDay = DateTime.Today;
                thisDay.ToString("g");

                return thisDay;
            }
        }

        public List<Producto> producto;

        public bool entrega24h;

        public string direccion { get; set; }

        private static int idNumberSeed = 1;

        public Pedido()
        {

        }
        public Pedido(List<Producto> producto, Boolean entrega, string direccion)
        {
            this.id= idNumberSeed.ToString();
            idNumberSeed++;
            this.producto = producto;
            this.entrega24h = entrega;
            this.direccion = direccion;
        }
    }
}
