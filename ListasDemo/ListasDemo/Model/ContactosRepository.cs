using Foundation.ObjectHydrator;
using System;
using System.Collections.Generic;
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
    }
}
