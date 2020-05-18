using ListasDemo.Helpers;
using ListasDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ListasDemo.ViewModel
{
    public class MainPageViewModel
    {
        public ObservableCollection<Grouping<string, Contactos>> ContactoLista { get; set; }
        public MainPageViewModel ()
        {
            ContactosRepository repository = new ContactosRepository();
            ContactoLista = repository.GetAllGrouped();
        }

    }
}
