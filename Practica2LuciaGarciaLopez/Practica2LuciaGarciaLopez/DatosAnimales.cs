using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2LuciaGarciaLopez
{
    internal class DatosAnimales
    {
        /// <summary>
        /// Clase para almacenar los datos de cada animal, incluyendo su nombre común, nombre científico, imagen y familia.
        /// </summary>
        public class AnimalData
        {
            public string nombre { get; set; }
            public string nombreCientifico { get; set; }
            public string imagen { get; set; }
            public string familia { get; set; }
        }
        public class Datos
        {
            public AnimalData animal = new AnimalData();
            public AnimalData GetAnimalData(string nombreAnimal)
            {
                // Asigna los datos del animal según el nombre recibido
                switch (nombreAnimal)
                {
                    case "Ciervo":
                        animal.nombre = "Ciervo de Cola Blanca";
                        animal.nombreCientifico = "Odocoileus virginianus";
                        animal.imagen = "deer.jpg";
                        animal.familia = "Mamífero";
                        break;
                    case "Tigre":
                        animal.nombre = "Tigre Dorado";
                        animal.nombreCientifico = "Panthera tigris tigris";
                        animal.imagen = "tiger.jpg";
                        animal.familia = "Mamífero";                        
                        break;
                    case "Secretario":
                        animal.nombre = "Secretario";
                        animal.nombreCientifico = "Sagittarius serpentarius";
                        animal.imagen = "Secretary_bird.jpg";
                        animal.familia = "Ave";
                        break;
                    case "Suricata":
                        animal.nombre = "Suricata";
                        animal.nombreCientifico = "Suricata suricatta";
                        animal.imagen = "meerkat.jpg";
                        animal.familia = "Mamífero";
                        break;
                    case "Borrego":
                        animal.nombre = "Borrego Cimarrón";
                        animal.nombreCientifico = "Ovis canadensis";
                        animal.imagen = "bighorn_sheep.jpg";
                        animal.familia = "Mamífero";
                        break;
                    default:
                        break;
                }
                return animal;
            }
        }
    }
}
