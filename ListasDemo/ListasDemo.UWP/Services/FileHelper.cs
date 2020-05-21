using ListasDemo.Services;
using ListasDemo.UWP.Services;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly:Dependency(typeof(FileHelper))]
namespace ListasDemo.UWP.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);
            //Vemos que con UWP es bastante más sencillo crear la ruta de nuestra BBDD. Hacemos un Combine de
            //la ruta (Path), del LocalFolder (es donde en Windows se guardan estos archivos databases) de la aplicación
            //corriente (Current es una propiedad estatica de la clase ApplicationData que contiene una referencia al objeto de la aplicación actual)
            //y del fileName.
        }
    }
}
