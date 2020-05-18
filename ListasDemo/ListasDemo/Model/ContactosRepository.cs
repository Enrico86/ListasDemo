using Foundation.ObjectHydrator;
using ListasDemo.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ListasDemo.Model
{
    public class ContactosRepository
    {
        public IList<Contactos> Contacto {get; set;}
        public ContactosRepository()
        {
            Hydrator<Contactos> _contactoHydrator = new Hydrator<Contactos>();
            Contacto = _contactoHydrator.GetList(50);
        }
        public IList<Contactos> GetAll()
        {
            return Contacto;
        }

        public IList<Contactos> GetAllFirstLetter(string letter)
        {
            var query = from q in Contacto
                        where q.FirstName.StartsWith(letter)
                        select q;
            return query.ToList();
        }

        public ObservableCollection<Grouping<string, Contactos>> GetAllGrouped()
        {
            var sorted = from f in Contacto
                         orderby f.FirstName
                         group f by f.FirstName[0].ToString()
                         into theGroup
                         select new Grouping<string, Contactos>(theGroup.Key, theGroup);
            return new ObservableCollection<Grouping<string, Contactos>>(sorted);
           
        }

    }
}
