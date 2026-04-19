using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2LuciaGarciaLopez
{
    internal class DatosAnimales
    {
        public class AnimalData
        {
            public string nombre { get; set; }
            public string imagen { get; set; }
            public string familia { get; set; }
            public int numeroPatas { get; set; }
        }
        public class Datos
        {
            public AnimalData animal = new AnimalData();
            public AnimalData GetAnimalData(string nombreAnimal)
            {
                switch (nombreAnimal)
                {
                    case "Gato":
                        animal.nombre = "Gato";
                        animal.imagen = "foto_gato.jpg";
                        animal.familia = "Mamífero";
                        animal.numeroPatas = 4;
                        break;
                    case "Araña":
                        animal.nombre = "Araña";
                        animal.imagen = "foto_arana.jpg";
                        animal.familia = "Arácnidos";
                        animal.numeroPatas = 8;
                        break;
                    default:
                        break;
                }
                return animal;
            }
        }
    }
}
