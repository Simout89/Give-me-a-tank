using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Base : MonoBehaviour,IDamageable
{
    [SerializeField] private float MaxHealth = 1;
    private float Health;
    private void Awake()
    {
        Health = MaxHealth;
    }
    public void ApplyDamage(float damageValue)
    {
        Health -= damageValue;
        if (Health <= 0)
        {
            EventManager.OnGameLose.Invoke();
            EventManager.OnObjectDestroy.Invoke();
            Destroy(gameObject);
        }
    }
}
