using Foundation.ObjectHydrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListasDemo.Model
{
    public class ContactosRepository
    {
        public IList<Contactos> Contactos {get; set;}
        public ContactosRepository()
        {
            Hydrator<Contactos> _contactosHydrator = new Hydrator<Contactos>();
            Contactos = _contactosHydrator.GetList(50);

        }

        public IList<Contactos> GetAll()
        {
            return Contactos;
        }

    }
}
