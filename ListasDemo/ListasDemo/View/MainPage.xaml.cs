using ListasDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListasDemo
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        
            //this.BindingContext = new MainPageViewModel();
        }
        private void BotonLlamadaClick(object sender, EventArgs e)
        {
            DisplayAlert("Llamada", "Llamada en curso", "OK");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new MainPageViewModel(Navigation);
        }

    }
}
