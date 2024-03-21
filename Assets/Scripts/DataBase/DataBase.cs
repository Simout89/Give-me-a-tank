using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public ItemDataBase items;
    private static DataBase instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }    
    }

    public static ItemData GetItemByID(string ID)
    {
        return instance.items.allItems.FirstOrDefault(i => i.id == ID); 
        //foreach(ItemData item in instance.items.allItems)
        //{
        //    if(item.id == ID)
        //        return item;
        //}
        //return null;
    }

}
