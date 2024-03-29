using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableProps : MonoBehaviour,IDamageable
{
    [SerializeField] private GameObject[] Stages;
    [SerializeField] private float HealthMax;
    [SerializeField] private GameObject DestrotyParticle;
    private float Health;
    public void ApplyDamage(float damageValue)
    {

        Health -= damageValue;
        if (Health <= 0)
        {
            EventManager.OnObjectDestroy.Invoke();
            Instantiate(DestrotyParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        Health = HealthMax;
    }
}
