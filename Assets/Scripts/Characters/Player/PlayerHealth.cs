using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float HealthMax = 5;
    [SerializeField] private int MaxLives = 3;
    private float Health;
    private int Lives;
    private Vector3 Startpos;
    private void Awake()
    {
        Startpos = transform.position;
        Health = HealthMax;
        Lives = MaxLives;
    }
    public void ApplyDamage(float damageValue)
    {
        Health -= damageValue;
        if(Health <= 0)
        {
            Health = HealthMax;
            Lives--;
            transform.position = Startpos;
            if(Lives <= 0)
            {
                EventManager.OnGameLose.Invoke();
            }
        }
    }
}
