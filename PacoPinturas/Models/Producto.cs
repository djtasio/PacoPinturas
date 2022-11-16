using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Models
{
    class Producto
    {
        public string id { get; set; }
        public string color { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public string descripcion { get; set; }
        public enum Calidad { Estandar,Premium}
        public enum Productos { Spray, Cubo, Rotulador}

        private static int idNumberSeed = 1;

        public Producto()
        {

        }

        public Producto(string color, int cantidad,decimal precio,string descripcion, Calidad calidad , Productos productos){
            this.id = idNumberSeed.ToString();
            

        }

    }
}
