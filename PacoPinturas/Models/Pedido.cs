using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Models
{
    class Pedido
    {
        public string Id { get; set; }

        //Date de hoy
        public DateTime Fecha {
            get {
                DateTime thisDay = DateTime.Today;
                thisDay.ToString("g");

                return thisDay;
            }
        }

        //Lista de productos
        public List<Producto> producto;

        public bool Entrega24h;

        public string Direccion { get; set; }

        private static int idNumberSeed = 1;

        public Pedido()
        {

        }
        public Pedido(List<Producto> producto, Boolean entrega, string direccion)
        {
            this.Id= idNumberSeed.ToString();
            idNumberSeed++;
            this.producto = producto;
            this.Entrega24h = entrega;
            this.Direccion = direccion;
        }
    }
}
