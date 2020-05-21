using ListasDemo.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListasDemo.BBDD
{
    public class ContactosDataBase
        //Con esta clase pretendemos primero construir nuestro database, y en el constructor crear una conexión
        //con nuestra base de datos pasandole la ruta dbPath. 
    {
        private readonly SQLiteAsyncConnection database;
        //Declaramos la variable database de la clase SQLiteAsyncConnection (que es la clase que tiene todos los métodos
        //para conectar con una BBDD a través de SQLite).
        public ContactosDataBase (string dbPath)
            //Creamos el constructor de la clase ContactosDataBase, que recibirá como parametro un string
            //en el que habrá almacenada la ruta de nuestra base de datos (dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            //Definimos la variable database como una nueva instancia de la clase SQLiteAsyncConnection. Esta clase necesita recibir
            //como parametro la ruta de la BBDD.
            database.CreateTableAsync<Contactos>().Wait();
            //El método CreateTableAsync se encarga de crear la tabla de tipo Contactos dentro de nuestro database, en el caso 
            //que no exista (esto lo comprueba solo, no tengo que decirle nada). Con el método Wait esperamos a que se lleve a 
            //cabo esta operación.
        }

        
        //Y ahora pretendemos crear los métodos que nos permitan hacer las querys a la tabla que hemos
        //creado dentro nuestro database: poder agregar Contactos, guardar cambios en un contacto, coger la información
        //de todos los Contactos, coger la ifnormación de un solo Contacto, etc.
        public async Task<List<Contactos>> GetItemsAsync()
        //Este método va a coger toda la información de la tabla y la mete en una lista (la utilizaremos por ejemplo
        //para visualizar todos los elementos en un ListView)
        {
            return await database.Table<Contactos>().ToListAsync();
        }


        public Task<Contactos> GetItemAsync(int id)
        //Este método servirá para coger en la tabla la información de un solo contacto.
        {
            return database.Table<Contactos>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
            //Le estamos diciendo al método que devuelva la info del primer elemento contacto donde (en el caso en que) i.ID (el ID del elemento)
            //sea igual al id que ha recibido por parametro.
        }


        public Task<int> SaveItemAsync (Contactos item)
        {
            //Con este método pretendemos guardar los contactos en la base de datos.
            if (item.ID!=0)
            {
                return database.UpdateAsync(item);
            }
            //Si el ID es diferente de 0, entonces quiere decir que ya existe el contacto, porqué lo asigna el propio 
            //SQLite cuando le pusimos las propiedades FirstKey y Autoincrement, y además con el Autoincrement ya 
            //estamos evitando que se dupliquen ID, ya que cada vez que asigna uno luego lo
            //autoincrementa. Si ya existe actualiza la información (UpdateAsync)
            else
            {
                return database.InsertAsync(item);
            }
            //Si el ID es igual a 0, quiere decir que el contacto no existe todavía, por lo cual lo agrega a database
            //(InsertAsync)
        }

        public Task<int> DeleteItemAsync (Contactos item)
        {
            return database.DeleteAsync(item); 
        }
        //Con este método pretendemos eliminar un determinado contacto (que recibirá por parametro) 
        //de la tabla de nuestro database.
    }
}
