using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;
public class PlayerInventory : MonoBehaviour
{
    public static UnityEvent<int> OnChangeState = new UnityEvent<int>();
    public int Inventory;
    

    private void Awake()
    {
        Inventory = -1;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IItemPickUp itemPickUp))
        {
            CollectItem(other);
            itemPickUp.PickUp();
        }
    }
    private void CollectItem(Collider other)
    {
        if ((other.tag == "Item") && other.TryGetComponent(out IItem iItem))
        {
            Inventory = iItem.ID;
            OnChangeState.Invoke(iItem.ID);
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
