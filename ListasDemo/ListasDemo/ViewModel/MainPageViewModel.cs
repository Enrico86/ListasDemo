using ListasDemo.Helpers;
using ListasDemo.Model;
using ListasDemo.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListasDemo.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
        //Implementamos INotifyPropertyChanged
    {
        public ObservableCollection<Grouping<string, Contacto>> ContactoLista { get; set; }

        public Command AddContactoCommand { get; set; }
        
        private INavigation Navigation;


        public Command ItemTappedCommand { get; set; }
        //Vamos a crear una propiedad de tipo Command que se llame como el método que hemos puesto en nuestro View, para poder así 
        //definir en el constructor de MainPageViewModel que es lo que hace (tal como hicimos con el comando AddContactoCommand).
        
        private Contacto currentContacto;
        //Esta propiedad de tipo Contactos es el contacto que está seleccionado gracias a la propiedad SelectedItem que hemos definido en 
        //el SelectedView y que hace Binding a CurrentContacto. Con esto conseguimos saber cual es el contacto del que tenemos que mostrar
        //las propiedades en ContactosView
        //Para avisar a la aplicación que ha habído un cambio en esta propiedad, vamos a implementar la interfaz INotifyPropertyChanges en 
        //esta clase, desarrollamos el método OnPropertyChanged y vamos a invocarlo en el setter de currentContacto.
        public Contacto CurrentContacto

        {
            get => currentContacto; 
            set
            {
                currentContacto = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }

        public MainPageViewModel(INavigation navigation)
        {
            ContactosRepository repository = new ContactosRepository();
            ContactoLista = repository.GetAllGrouped();
            Navigation = navigation;
            AddContactoCommand = new Command(async () => await NavigateToContactoView());
            ItemTappedCommand = new Command(async () => await NavigateToEditContactoView());
            //Vamos a decirle que este comando lo que hará será lanzar una tarea NavigateToEditContactoView
            //que todavía no hemos definido. Esta tarea tendrá que hacer navegar el usuario hasta la página ContactosView
            //pero utilizar el segundo constructor que habíamos creado para esa clase, que esperaba recibir por parametro
            //un contacto (del que se enseñaría la información de sus propiedades FirstName, etc).
        }

        public async Task NavigateToContactoView()
        {
            await Navigation.PushAsync(new ContactosView());
        }

        public async Task NavigateToEditContactoView()
            //Vamos entonces a definir la tarea NavigateTpEditContactoView, que creará una nueva instancia de la Page ContactosView pero
            //esta vez utilizando el segundo constructor, el que nos pedía como parámetro un objeto de tipo contacto.
        {
            await Navigation.PushAsync(new ContactosView(CurrentContacto));
        }
        

    }
}
