using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [SerializeField] private string ID;
    private void Awake()
    {
        GameObject gameObject = Instantiate(DataBase.GetItemByID(ID).ItemOnGround, transform.position, Quaternion.identity);
        ItemInformation itemInformation = gameObject.GetComponent<ItemInformation>();
        itemInformation.ID = ID;
    }
}
