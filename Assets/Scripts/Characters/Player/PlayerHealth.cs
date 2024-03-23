using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float HealthMax = 5;
    private float Health;
    private void Awake()
    {
        Health = HealthMax;
    }
    public void ApplyDamage(float damageValue)
    {
        Health -= damageValue;
        if(Health <= 0)
        {
            EventManager.OnGameLose.Invoke();
        }
    }
}
