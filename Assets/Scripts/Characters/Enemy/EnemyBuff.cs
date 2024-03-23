using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBuff : MonoBehaviour
{
    [Header("Chance (1 to N)")]
    [SerializeField] private int ShieldChance;
    [SerializeField] private int FuryModChance;
    [Header("BuffSettings")]
    [SerializeField] private float FuryModSpeedBuff;
    [SerializeField] private float FuryModFireRate;
    [SerializeField] private float ShieldHealth;
    [Header("GameObject")]
    [SerializeField] private GameObject ShieldGameObject;
    private NavMeshAgent Agent;
    private int ShieldState;
    private int FuryModState;
    private IGunChangeSettings[] Guns;
    private void Awake()
    {
        System.Random random = new System.Random();
        ShieldState = random.Next(0, ShieldChance);
        FuryModState = random.Next(0, FuryModChance);

        FuryMod();
        Shield();
    }
    private void Shield()
    {
        if (ShieldState == 0)
        {
            if (TryGetComponent(out IEnemyShield enemyShield))
                enemyShield.ActiveShield(ShieldHealth);
            ShieldGameObject.SetActive(true);
        }
    }
    private void FuryMod()
    {
        if(FuryModState == 0)
        {
            Agent = GetComponent<NavMeshAgent>();
            Agent.speed *= FuryModSpeedBuff;

            Guns = GetComponentsInChildren<IGunChangeSettings>();
            for (int i = 0; i < Guns.Length; i++)
            {
                Guns[i].FireRate(FuryModFireRate);
            }   
        }
    }
}
