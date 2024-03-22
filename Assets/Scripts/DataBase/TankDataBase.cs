using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DataBase/TankDataBase")]
public class TankDataBase : ScriptableObject
{
    public List<TankData> allTanks;
}
