using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public string Sender;
    [SerializeField] public float Damage;
    private void Awake()
    {
        StartCoroutine(DestroyDelay());
    }
    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(Damage);
        }
        if(other.tag != Sender)
        {
            Destroy(gameObject);
        }
    }
}