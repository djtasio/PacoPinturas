using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Models
{
        //Variables con valores definidas
        public enum Calidad { Estandar,Premium}
        public enum Productos { Spray, Cubo, Rotulador}
    class Producto
    {
        public string Id { get; set; }
        public string Color { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio {
            get {
                decimal price = 0;

                if(productos.Equals(Productos.Spray) && calidad.Equals(Calidad.Estandar))
                {
                    price = 3.40m;
                }
                if (productos.Equals(Productos.Spray) && calidad.Equals(Calidad.Premium))
                {
                    price = 6.50m;
                }
                if (productos.Equals(Productos.Cubo) && calidad.Equals(Calidad.Estandar))
                {
                    price = 13;
                }
                if (productos.Equals(Productos.Cubo) && calidad.Equals(Calidad.Premium))
                {
                    price = 23;
                }
                if (productos.Equals(Productos.Rotulador) && calidad.Equals(Calidad.Estandar))
                {
                    price = 3.45m;
                }
                if (productos.Equals(Productos.Rotulador) && calidad.Equals(Calidad.Premium))
                {
                    price = 5.10m;
                }
                return price * Cantidad;
            }
        }
        //Descripcion del producto 
        public string Descripcion { 
            get {

                var description = new StringBuilder();

                if (productos.Equals(Productos.Spray)) {
                    description.AppendLine("-Aerosol de pintura de altas prestaciones de baja presión y acabado mate.");
                    description.AppendLine("-Maxima precisión.");
                    description.AppendLine("-Secado ultrarápido.");
                    description.AppendLine("-Muelle de presión suave.");
                    description.AppendLine("-Alta cubrición");
                    description.AppendLine("-Excelente resistencia al exterior");
                }
                if (productos.Equals(Productos.Cubo))
                {
                    description.AppendLine("Pintura plástica mate para uso en interior, con buen anclaje y cubrición.");
                    description.AppendLine("Alta transpirabilidad.");
                    description.AppendLine("Indicada  en obra y mantenimiento de techos, sótanos parkings");
                    description.AppendLine("Alta cubrición.");

                }
                if (productos.Equals(Productos.Rotulador))
                {
                    description.AppendLine("Rotuladores de pintura al agua.");
                    description.AppendLine("Acabado mate.");
                    description.AppendLine("Rellenables.");
                    description.AppendLine("Gran opacidad.");
                }
                return description.ToString();
            } 
        }

        public Calidad calidad;

        public Productos productos;

        private static int idNumberSeed = 1;

        public Producto()
        {

        }

        public Producto(string color, int cantidad, Calidad calidad , Productos productos){
            this.Id = idNumberSeed.ToString();
            idNumberSeed++;
            this.Color = color;
            this.Cantidad = cantidad;    
            this.calidad = calidad;
            this.productos = productos;
           
        }

    }
}
