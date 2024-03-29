using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "DataBase/ItemData")]
public class ItemData : ScriptableObject
{
    [field: SerializeField] public string itemName { get; private set; }
    [field: SerializeField] public int id { get; set; }
    [field: SerializeField] public GameObject ItemOnGround { get; private set; }
    [field: SerializeField] public GameObject Item { get; private set; }
    [field: SerializeField] public float Score { get; private set; }
    [field: SerializeField] public float LifeTime { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
}