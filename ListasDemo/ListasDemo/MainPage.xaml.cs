using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListasDemo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            BindingContext =
                //Primero construimos un array de objetos de una clase anonima, finalmente lo convertimos en una lista, y 
                //esta lista la definimos como BindingContext, a traves del cual enlazaremos la ListView de nuestra MainPage.xaml.
                //Como ya hemos comentado es importante que los datos de la ListView sean homogéneos, es decir del mismo tipo,
                //razón por la que todos los objetos que creemos tienen que pertenecer a la misma clase anonima.
                new[]
                {
                    new
                    {
                        FirstName="Enrico",
                        Phone = "(654)854254",
                        Email="enrico@ejemplo.com",
                    },
                    //Con estas líneas de código acabamos de instanciar el primer objeto perteneciente a una clase anónima.
                    new
                    {
                        FirstName="Anais",
                        Phone = "(626)123456",
                        Email="anais@ejemplo.com",
                    },
                    //Aquí acabamos de instanciar el segundo objeto perteneciente a la misma clase anónima de antes. 
                    //¿Como sabemos que es la misma clase anónima?
                    //Porqué tienen el mismo número de campos de clase, con el mismo nombre, tipo y en el mismo orden.
                    //En nuestro caso todos los objetos tienen 3 campos, que se llaman igual para los 3 objetos, de tipo string y
                    //en el mismo orden.
                    new
                    {
                        FirstName="Angelo",
                        Phone = "(636)789524",
                        Email="angelo@ejemplo.com",
                    },
                }.ToList();
            //Con el método ToList convertimos a una lista el array de nuestros tres objetos que hemos creado 
            //(para que se visualice correctamente una ListView se tiene que enlazar a una lista.

            
        }

        private void BotonLlamadaClick(object sender, EventArgs e)
        {
            DisplayAlert("Llamada", "Llamada en curso", "OK");
        }
    }
}
