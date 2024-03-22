using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class TankSpawner : MonoBehaviour
{
    [Header("TankCount")]
    [SerializeField] private int Light = 1;
    [SerializeField] private int ArmoredCar = 1;
    [SerializeField] private int Medium = 1;
    [SerializeField] private int Heavy = 1;
    [Header("SpawnSettings")]
    [SerializeField] private int MaxTankOnScene = 5;
    [SerializeField] private int SpawnDelay = 5;
    [HideInInspector]
    public int TotalTank;
    private int[] Tank;
    private GameObject[] Spawner;
    private bool spawnDelay = false;
    private void Awake()
    {
        Spawner = GameObject.FindGameObjectsWithTag("EnemySpawner");
        Tank = new int[4];
        Tank[0] = Light;
        Tank[1] = ArmoredCar;
        Tank[2] = Medium;
        Tank[3] = Heavy;
        TotalTank = Light + ArmoredCar + Medium + Heavy;
    }

    private void FixedUpdate()
    {
        if ((GameObject.FindGameObjectsWithTag("Enemy").Length < MaxTankOnScene) && (TotalTank != 0) && !spawnDelay)
        {
            System.Random rnd = new System.Random();
            int i = rnd.Next(0, Tank.Length);
            if (Tank[i] != 0)
            {
                Tank[i]--;
                GameObject gameObject = Instantiate(DataBase.GetItemByID((i + 1).ToString()).ItemOnGround, Spawner[rnd.Next(0,Spawner.Length)].transform.position, Quaternion.identity);
                StartCoroutine(Delay());
            }
        }
    }
    private IEnumerator Delay()
    {
        spawnDelay = true;
        yield return new WaitForSeconds(SpawnDelay);
        spawnDelay = false;
    }
}
