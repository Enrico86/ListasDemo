using System;
using System.Collections.Generic;
using System.Text;

namespace ListasDemo.Services
{
    public interface IFileHelper
    //Cuando trabajamos con BBDD lo que estamos haciendo es crear (o cargar si ya lo hemos creado) un archivo
    //dentro del dispositivo. Esta archivo es la BBDD con la que vamos a trabajar. Entonces con esta Interfaz
    //pretendemos crear una interfaz que se vaya a implementar en cada plataforma, en las que le pasaremos 
    //la ruta donde estará éste archivo. Hay que hacerlo así porqué cada plataforma lo almacena en una ruta 
    //ligeramente diferente.
    {
        string GetLocalFilePath(string fileName);
        //El miembro de la interfaz es un método que llamamos GetLocalFilePath (ya que pretendemos que nos proprcione 
        //la ruta del archivo por cada plataforma).
        //Va a devolver un dato de tipo string y recibirá por parametro otro dato de tipo string que es el nombre del archivo.
    }

}
