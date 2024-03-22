using UnityEngine;

[CreateAssetMenu(menuName = "DataBase/TankData")]
public class TankData : ScriptableObject
{
    [field: SerializeField] public string itemName { get; private set; }
    [field: SerializeField] public string id { get; private set; }
    [field: SerializeField] public GameObject Tank { get; private set; }
}