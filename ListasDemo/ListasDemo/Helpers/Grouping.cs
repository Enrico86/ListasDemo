using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ListasDemo.Helpers
{
    public class Grouping<K,T>:ObservableCollection<T>
        //L estamos diciendo que esta clase tiene que ser inizializada con dos valores, un valor tipo K y
        //otro tipo T. Además hereda de ObservableCollection.
        //La idea de esta clase es que el primer parametro sea la llave por la cual vamos a realizar el agrupamiento
        //en una lista. Si por ejemplo quiero agrupar según la primera letra del FirstName, todas las primeras letras
        //del FirstName de cada elemento de mi lista sería nuestra K.
        //El parametro T representa el tipo de dato de cada uno de los elemntos de nuestra lista. La ObservableCXollection
        //tiene entonces que ser de tipo T, del tipo de dato de la lista.
    {
        public K Key { get; }
        public Grouping (K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
            {
                Items.Add(item);
            }
        } 
    }
}
