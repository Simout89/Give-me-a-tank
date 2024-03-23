using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour,IDamageable, IEnemyShield
{
    [SerializeField] private float MaxEnemyHealth = 2;
    [SerializeField] private GameObject ShieldGameObject;
    [HideInInspector]
    public float Health;
    private void Awake()
    {
        Health = MaxEnemyHealth;
    }

    public void ApplyDamage(float damageValue)
    {
        Health -= damageValue;
        if (Health <= 0)
        {
            EventManager.OnObjectDestroy.Invoke();
            Destroy(gameObject);
        }
        ShieldGameObject.SetActive(false);
    }

    public void ActiveShield(float health)
    {
        StartCoroutine(Delay(health));
    }

    private IEnumerator Delay(float health)
    {
        yield return new WaitForSeconds(0.01f);
        Health+= health;
    }
}
