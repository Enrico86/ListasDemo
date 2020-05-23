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
    {
        public ObservableCollection<Grouping<string, Contactos>> ContactoLista { get; set; }

        public Command AddContactoCommand { get; set; }
        private INavigation Navigation;
        private Contactos currentContacto;

        public Command ItemTappedCommand { get; set; }
        public Contactos CurrentContacto
        {
            get => currentContacto; set
            {
                currentContacto = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel(INavigation navigation)
        {
            ContactosRepository repository = new ContactosRepository();
            ContactoLista = repository.GetAllGrouped();
            Navigation = navigation;
            AddContactoCommand = new Command(async () => await NavigateToContactoView());
            ItemTappedCommand = new Command(async () => await NavigateToEditContactoView());
        }

        public async Task NavigateToContactoView()
        {
            await Navigation.PushAsync(new ContactosView());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }

        public async Task NavigateToEditContactoView()
        {
            await Navigation.PushAsync(new ContactosView(CurrentContacto));
        }
    }
}
