using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor {

    int index = 0;

    public override void OnInspectorGUI()
    {
        //guardamos el contexto en una variable para tener acceso a la informacion del gameObject
        Inventory context = (Inventory)this.target;

        //escribimos la lógica para que se muestren los datos en el inspector
        itemDBController database = GameManager.instance.GetComponent<itemDBController>();
        //preparamos las opciones del desplegable
        string[] options = new string[database.db.items.Count];

        //creamos el diccionario para guardar el id y el nombre del item para que luego en el editor sea todo mas amigable
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        foreach(Item it in  database.db.items)
        {
            dictionary.Add(it.itemName, it.id);
        }


        //copiamos las claves del diccionario al array de opciones.
        dictionary.Keys.CopyTo(options,0);

        EditorGUILayout.LabelField("Item", "Cantidad");

        foreach(InvItem it in context.itemList)
        {
            Item actualItem = database.getById(it.id);
            EditorGUILayout.LabelField(actualItem.itemName, it.quantity.ToString());
        }



        //añadimos la lista desplegable
        index = EditorGUILayout.Popup(index, options); //se iguala porque se guarda el indice de la ultima opcion que se ha seleccionado

        //añadimos un boton con su funcionalidad
        if(GUILayout.Button("Add Item"))
        {
            int itemIndex;
            if (dictionary.TryGetValue(options[index], out itemIndex))
            {
                context.addItem(itemIndex);
            }

        }

        //añadimos un boton con su funcionalidad
        if (GUILayout.Button("Delete Item"))
        {
            int itemIndex;
            if (dictionary.TryGetValue(options[index], out itemIndex))
            {
                context.deleteItem(itemIndex);
            }
        }
    }
}
