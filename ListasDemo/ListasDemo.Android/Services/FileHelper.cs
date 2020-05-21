
using System;
using System.IO;

using ListasDemo.Droid.Services;
using ListasDemo.Services;
using Xamarin.Forms;


[assembly:Dependency(typeof(FileHelper))]
//Registro del service en esta clase
namespace ListasDemo.Droid.Services
{
    public class FileHelper: IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string path = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //A través la clase Environment (heredada de la clase System, OJO, hay dos opciones aquí) podemos invocar el método GetFolderPath 
            //que justamente va a obtener un string de la ruta (Path) de la carpeta que le vamos a pasar (Folder). Esta carpeta está dentro 
            //de la clase Special Folder, a la cual de nuevo podemos acceder desde la clase System.Environment). Dentro de SpecialFolder 
            //tenemos que escoger la carpeta Personal.

            return Path.Combine(path, fileName);
            //Para evitar errores con las diagonales, etc. vamos a utilizar la clase Path. Para poder hacerlo necesitamos utilizar el namespace 
            //System.IO (using System.IO). Ahora que podemos acceder a la clase Path, utilizamos el método Combine que recibe por parámetro un 
            //array de strings(la ruta de la carpeta y el nombre del archivo) y devuelve un string con la ruta y el nombre juntos con un formato 
            //específico para la ruta de un archivo. El fileName es contactosdb.sqlite que habíamos asignado a nuestro archivo (al database) en
            //App.xaml.cs

        }
    }
}