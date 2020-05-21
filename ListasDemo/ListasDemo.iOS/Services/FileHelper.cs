using System;
using System.IO;
using ListasDemo.iOS.Services;
using ListasDemo.Services;
using Xamarin.Forms;

[assembly:Dependency(typeof(FileHelper))]
namespace ListasDemo.iOS.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string libFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..","Library", "Databases");
            //Apple va a restringir que los archivos de la aplicación estén en un folder específico, no en Personal.Es una carpeta hermana 
            //de Personal, ya que se encuentra en la misma carpeta padre. Para poder acceder entonces tendremos que salir de la carpeta 
            //Personal(con el comando "..") y a través de la carpeta padre acceder a la otra carpeta.
            //Para combinar la ruta de la carpeta entonces utilizamos Combine de la clase Path, con el parámetro ".." le decimos al Combine 
            //que salga de la carpeta Personal y entre en la carpeta padre, y con el parámetro "Library" que entre en la carpeta Library, 
            //que es donde Apple nos permite guardar los archivos de nuestra carpeta.Opcionalmente podemos añadirle un último parámetro con la 
            //carpeta en la que se guardarán los archivos de la base de datos("Databases")

            if (!Directory.Exists(libFolder))
                //Si este directorio no existe, entonces lo creamos
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }
    }
}