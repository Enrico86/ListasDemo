using ListasDemo.Model;
using ListasDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListasDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactosView : ContentPage
    {
        public ContactosView(Contactos contacto = null)
        {
            InitializeComponent();
            if (contacto == null)
            {
                BindingContext = new ContactosViewViewModel(Navigation);
            }
            else
            {
                BindingContext = new ContactosViewViewModel(Navigation, contacto);
            }

        }
    }
}