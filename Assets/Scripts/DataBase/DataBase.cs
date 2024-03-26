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
        
        var hasIDInRange = foundItems.Where(i => i.id != -1 && i.id < foundItems.Count).OrderBy(i => i.id).ToList();
        var hasIDNotInRange = foundItems.Where(i => i.id != -1 && i.id >= foundItems.Count).OrderBy(i => i.id).ToList();
        var noID = foundItems.Where(i => i.id <= -1).ToList();
        var index = 0;

        for (int i = 0; i < foundItems.Count; i++)
        {
            ItemData itemToAdd;
            itemToAdd = hasIDInRange.Find(d => d.id == i);

            if(itemToAdd != null)
            {
                _itemDataBase.Add(itemToAdd);
            }
            else if(index < noID.Count)
            {
                noID[index].id = i;
                itemToAdd = noID[index];
                index++;
                _itemDataBase.Add(itemToAdd);
            }
        }

        foreach (var item in hasIDNotInRange)
        {
            _itemDataBase.Add(item);
        }
    }

    public ItemData GetItemByID(int ID)
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
