using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePlatform : MonoBehaviour
{

    private Vector3 PlacePoint;
    private GameObject Slot;
    private DataBase db;
    private void Awake()
    {
        db = Resources.Load<DataBase>("Database");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && other.TryGetComponent(out PlayerInventory playerInventory) && (playerInventory.Inventory != -1) && Slot == null)
        {
            PlacePoint = transform.position;
            PlacePoint.x = (int)PlacePoint.x;
            PlacePoint.y = (int)PlacePoint.y + 1;
            PlacePoint.z = (int)PlacePoint.z;

            GameObject gameObject = Instantiate(db.GetItemByID(playerInventory.Inventory).Item, PlacePoint, Quaternion.identity);
            Slot = gameObject;
            EventManager.OnObjectPlace.Invoke();
            if(db.GetItemByID(playerInventory.Inventory).LifeTime != 0)
            {
                StartCoroutine(DeleteDelay(db.GetItemByID(playerInventory.Inventory).LifeTime, gameObject));
            }
            playerInventory.Inventory = -1;
            PlayerInventory.OnChangeState.Invoke(-1);
        }
    }
    IEnumerator DeleteDelay(float time, GameObject item)
    {
        yield return new WaitForSeconds(time);
        Destroy(item);
        Slot = null;
    }
}
