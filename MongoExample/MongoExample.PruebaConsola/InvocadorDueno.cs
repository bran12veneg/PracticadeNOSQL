using MongoDB.Driver;
using MongoExample.Modelo.MisColecciones;
using MongoExample.Negocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoExample.PruebaConsola
{
    public class InvocadorDueno
    {
        private string nombreDuenoDeAnimalito;
        public void ConsultarAnimalitos ()
        {
            CapturarInformacion();
            var listaAnimalitos = EjecutarConsulta(nombreDuenoDeAnimalito);
            ImprimirListaDeAnimalitos(listaAnimalitos);
        }

        private void ImprimirListaDeAnimalitos(IList<Animalito> listaAnimalitos)
        {
            if (listaAnimalitos.Count > 0)
            {
                foreach (var item in listaAnimalitos)
                {
                    Console.WriteLine("Nombre: {0} - Tipo: {1} - Edad: {2}", item.nombre, item.tipo, item.Age);
                    if (item.dueno != null)
                        Console.WriteLine("Dueños: Nombre: {0} - email: {1}", item.dueno.Nombre, item.dueno.Email);
                    else
                        Console.WriteLine("Dueños: Desconocido");                }
            }
            else
                Console.WriteLine("No se encontraron animalitos.");
            ;
            Console.ReadLine();
        }

        private IList<Modelo.MisColecciones.Animalito> EjecutarConsulta(string nombreDueno)
        {
            var elConsultante = new Animalitos();
            var elResultado = elConsultante.ListarAnimalitosPorNombreDelDueno(nombreDueno);
            return elResultado;
        }

        private void CapturarInformacion()
        {
            Console.Write("Digite el nombre del dueño del animalito: ");
            nombreDuenoDeAnimalito = Console.ReadLine();
        }
    }
}
