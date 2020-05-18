using ListasDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListasDemo.ViewModel
{
    public class MainPageViewModel
    {
        public List<Contactos> ContactoLista { get; set; }
        public MainPageViewModel ()
        {
            ContactosRepository repository = new ContactosRepository();
            ContactoLista = repository.GetAll().ToList();
        }

    }
}
