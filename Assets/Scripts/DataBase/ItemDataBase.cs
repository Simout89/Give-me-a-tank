using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DataBase/ItemDataBase")]
public class ItemDataBase : ScriptableObject
{
    public List<ItemData> allItems;
}
