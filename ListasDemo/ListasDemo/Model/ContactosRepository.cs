using Foundation.ObjectHydrator;
using ListasDemo.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasDemo.Model
{
    public class ContactosRepository
    {
        public IList<Contactos> Contacto {get; set;}
        public ContactosRepository()
        {
            //Hydrator<Contactos> _contactoHydrator = new Hydrator<Contactos>();
            //Contacto = _contactoHydrator.GetList(50);

            //En el constructor de la clase ContactosRepository utilizábamos el Hydrator para generar automaticamente x objetos de tipo 
            //Contactos. Pero ahora que ya tenemos acceso a nuestro database, ya no queremos coger una lista que se genere automaticamente 
            //con el Hidrator sino queremos que coja la que tenemos en nuestro database.
            //Dado que estamos dentro de un contructor y no está permitido poner directamente un Async, vamos a poner la tarea Task que habíamos 
            //desarrollado en la clase COntactosDataBase, para que coja la info de nuestro database y la ponga en una lista.
            Task.Run(async () =>
           Contacto = await App.Database.GetItemsAsync()).Wait();
            //Accedemos a la propiedad Database a través de la clase App que es donde la habíamos declarado. Y como Database es una propiedad de 
            //tipo ContactosDataBase podemos invocar la tarea GetItemsAsync que había creado en dicha clase.

        }
        public IList<Contactos> GetAll()
        {
            return Contacto;
        }

        public IList<Contactos> GetAllByFirstLetter(string letter)
        {
            var query = from q in Contacto
                        where q.FirstName.StartsWith(letter)
                        select q;
            return query.ToList();
        }

        public ObservableCollection<Grouping<string, Contactos>> GetAllGrouped()
        //Aquí habíamos creado un método que nos devolvía el conjunto de información dentro de nuestro repositorio (que antes era
        //generado automaticamente por el hydrator) agrupados según un determinado criterio
        {
            //Pero como ahora ya no se genera automaticamente, cuando ejecutemos nuestra aplicación e intente agrupar los elementos en 
            //el database, éste estará vacío y este método nos daría un error. Para resolver este problema tenemos que hacer lo siguiente:
            IEnumerable<Grouping<string, Contactos>> sorted = new Grouping<string, Contactos>[0];
            if (Contacto!=null)
            { 

            sorted = from f in Contacto
                         orderby f.FirstName
                         group f by f.FirstName[0].ToString()
                         into theGroup
                         select new Grouping<string, Contactos>(theGroup.Key, theGroup);
            }
            return new ObservableCollection<Grouping<string, Contactos>>(sorted);
           
        }

    }
}
