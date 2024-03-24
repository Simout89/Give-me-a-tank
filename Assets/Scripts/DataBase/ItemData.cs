using UnityEngine;

[CreateAssetMenu(menuName = "DataBase/ItemData")]
public class ItemData : ScriptableObject
{
    [field: SerializeField] public string itemName { get; private set; }
    [field: SerializeField] public string id { get; private set; }
    [field: SerializeField] public GameObject ItemOnGround { get; private set; }
    [field: SerializeField] public GameObject Item { get; private set; }
    [field: SerializeField] public float Score { get; private set; }
    [field: SerializeField] public float LifeTime { get; private set; }
}