using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListasDemo.Model
{
    public class Contactos
    {

        

        private int _ID;
        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        //Para que esta clase sea compatible con SQLite y podamos poner, quitar, nmodificar, etc. todas las propiedades que definimos en 
        //su interior (en nuestro caso FirstName, Phone e Email), tenemos que crear en esta clase una variable ID.
        //De esta manera cuando SQLite vaya a agregar, modificar, eliminar etc. algo en nuestra tabla del database, sabrá de que ID lo tendrá
        //que hacer. También en el caso de tener que eliminar todos los elementos o coger todos los elementos, SQLite necesita un ID. El ID
        //es básico para el correcto funcionamiento de SQLite.
        //Además a esta propiedad la asignamos diferentes atributos propio de la clase SQLite (tendremos que importar el using correspondiente):
        //el PrimaryKey, que significa que este ID será la llave primaria con la que SQLite irá a hacer todas las operaciones (métodos, como 
        //agregar, eliminar, etc) en la tabla que más adelante definamos.
        //El Autoincrement hará de manera que cada vez que SQLite asigne a un contacto un ID, éste se autoincremente, de manera que no puedan
        //haber nunca ID repetidos.
        //Comentar que podemos definir los atributos que más nos interesen o necesitemos, y que hay que hacerlo antes de la propiedad.

        private string _FirstName;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        private string _Phone;

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

    }
}

