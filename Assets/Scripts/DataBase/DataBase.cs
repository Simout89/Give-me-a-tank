using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DataBase/ItemDataBase")]
public class DataBase : ScriptableObject
{
    [SerializeField] private List<ItemData> _itemDataBase;

    [ContextMenu("Set IDs")]
    public void SetItemIDs()
    {
        _itemDataBase = new List<ItemData>();

        var foundItems = Resources.LoadAll<ItemData>("Items").OrderBy(i => i.id).ToList(); 
    }

    public ItemData GetItemByID(string ID)
    {
        return _itemDataBase.Find(i => i.id == ID);
        //foreach(ItemData item in instance.items.allItems)
        //{
        //    if(item.id == ID)
        //        return item;
        //}
        //return null;
    }

}
