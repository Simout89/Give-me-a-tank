using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableProps : MonoBehaviour,IDamageable
{
    [SerializeField] private float HealthMax;
    private float Health;
    public void ApplyDamage(float damageValue)
    {
        Health -= damageValue;
        if (Health <= 0)
        {
            EventManager.OnObjectDestroy.Invoke();
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        Health = HealthMax;
    }
}
