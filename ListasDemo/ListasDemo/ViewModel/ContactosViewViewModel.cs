using ListasDemo.Model;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListasDemo.ViewModel
{
    public class ContactosViewViewModel
    {
        public Command SaveContactoCommand { get; set; }
        public Contacto NewContacto { get; set; }
        private INavigation Navigation;
        public ContactosViewViewModel (INavigation navigation)
        {
            NewContacto = new Contacto();
            SaveContactoCommand = new Command(async () => await SaveContacto());
            Navigation = navigation;
        }

        public ContactosViewViewModel (INavigation navigation, Contacto contacto)
        {
            NewContacto = contacto;
            SaveContactoCommand = new Command(async () => await SaveContacto());
            Navigation = navigation;
        }

        public async Task SaveContacto()
        {
            await App.Database.SaveItemAsync(NewContacto);
            await Navigation.PopToRootAsync();
        }
    }
}
