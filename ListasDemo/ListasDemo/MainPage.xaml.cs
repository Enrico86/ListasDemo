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
            BindingContext =
                new[]
                {
                    new
                    {
                        FirstName="Enrico",
                        Phone = "(654)854254",
                        Email="enrico@ejemplo.com",
                    },
                    new
                    {
                        FirstName="Anais",
                        Phone = "(626)123456",
                        Email="anais@ejemplo.com",
                    },
                    new
                    {
                        FirstName="Angelo Prueba para ver el HasUnevenRows, la fila será más alta",
                        Phone = "(636)789524",
                        Email="angelo@ejemplo.com",
                    },
                    new
                    {
                        FirstName="Lise",
                        Phone = "(636)854165",
                        Email="lise@ejemplo.com",
                    },
                    new
                    {
                        FirstName="Lidia",
                        Phone = "(636)754892",
                        Email="lidia@ejemplo.com",
                    },
                }.ToList();
        }
        private void BotonLlamadaClick(object sender, EventArgs e)
        {
            DisplayAlert("Llamada", "Llamada en curso", "OK");
        }
    }
}
