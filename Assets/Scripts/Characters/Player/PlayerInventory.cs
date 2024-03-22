using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
public class PlayerInventory : MonoBehaviour
{
    public string Inventory;

    private void Awake()
    {
        Inventory = "-1";
    }
    private void OnTriggerEnter(Collider other)
    {
        CollectItem(other);
    }
    private void CollectItem(Collider other)
    {
        if ((other.tag == "Item") && other.TryGetComponent(out IItem iItem))
        {
            Inventory = iItem.ID;
        }
    }
    //private void PlaceItem(Collider other)
    //{
    //    //if ((other.tag == "UpgradePlatform") && other.TryGetComponent(out Item item))
    //    //{
    //    //    Inventory = (Items)item.ItemId;
    //    //}
    //}
}
