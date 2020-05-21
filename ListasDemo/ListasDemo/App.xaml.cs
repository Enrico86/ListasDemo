using ListasDemo.BBDD;
using ListasDemo.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListasDemo
{
    public partial class App : Application
    {
        //App es una clase "global" de nuestra aplicación, en el sentido que todos los proyectos acceden a ella para 
        //inicializar los componentes e instanciar la MainPage.
        //Y la idea es que tengamos acceso a la BBDD de manera global y que tenga abierta solo una conexión a la BBDD
        //abierta a la vez.
        //Aquí entonces definimos una variable estatica database de la clase ContactosDataBase
        private static ContactosDataBase database;
        public static ContactosDataBase Database
            //La propiedad Database tendrá solo un método getter (es una propiedad de sola lectura, no queremos que 
            //se puedan asignar otros valores.
        {
            get
            {
                if (database==null)
                {
                    database = new ContactosDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("contactosdb.sqlite"));
                }
                return database;
                //En el caso en que la variable database sea nula (es decir, que aún no tengamos creado nuestro database), vamos a
                //asignar a esta variable una nueva instancia de ContactosDataBase. Acordemonos que en el constructor de esta clase 
                //dijimos que necesitaba recibir como parametro la ruta de este database. Pues aquí es donde vamos a utilizar el 
                //Dependency Service, para que reciba como ruta el resultado de la implementación de la interfaz IFileHelper en 
                //cada plataforma.
                //El DependencyService va a coger la implementación de la interfaz, más especificamente de su miembro GetLocalFilePath.
                //Esto porqué en la Interfaz podríamos tener más de un miembro (métodos o propiedades), por lo que hay que especificar 
                //a que método nos estamos refiriendo.
                //El mnétodo GetLocalFilePath tiene que recibir por parámetro el nombre del archivo BBDD (podemos darle el nombre que queramos,
                //pero la extensión es mejor que acabe con .sqlite)
                //Es decir, si no estaba creado el database, lo creamos en la ruta propia de cada plataforma y lo devolvemos, y si ya estaba 
                //creado entonces solo lo devolvemos sin necesidad de volver a crearlo.
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
