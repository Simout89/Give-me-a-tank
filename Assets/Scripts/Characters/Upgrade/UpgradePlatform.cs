using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePlatform : MonoBehaviour
{
    [SerializeField] private GameObject PrefabTurret;
    private Vector3 PlacePoint;
    private GameObject Slot;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && other.TryGetComponent(out PlayerInventory playerInventory) && (playerInventory.Inventory != "-1") && Slot == null)
        {
            PlacePoint = transform.position;
            PlacePoint.x = (int)PlacePoint.x;
            PlacePoint.y = (int)PlacePoint.y + 1;
            PlacePoint.z = (int)PlacePoint.z;

            GameObject gameObject = Instantiate(DataBase.GetItemByID(playerInventory.Inventory).Item, PlacePoint, Quaternion.identity);
            Slot = gameObject;
            EventManager.OnObjectPlace.Invoke();
            playerInventory.Inventory = "-1";
        }
    }
}