using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyHealth : MonoBehaviour,IDamageable , IEnemyShield, IItem
{
    [Header("Settings")]
    [SerializeField] private float MaxEnemyHealth = 2;
    [SerializeField] private int ChanceDropItem = 1;
    [SerializeField] private int ItemCount = 1;
    [Header("GameObject")]
    [SerializeField] private GameObject ShieldGameObject;
    [HideInInspector]
    public float Health;

    public string ID { get; set; }

    private void Awake()
    {
        Health = MaxEnemyHealth;
    }

    public void ApplyDamage(float damageValue)
    {
        Health -= damageValue;
        if (Health <= 0)
        {
            StartCoroutine(DeathDelay());
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
    private IEnumerator DeathDelay()
    {
        System.Random rnd = new System.Random();
        if (rnd.Next(0, ChanceDropItem) == 0)
        {
            Instantiate(DataBase.GetItemByID(rnd.Next(5, 5 + ItemCount).ToString()).ItemOnGround, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
        ScoreOnScene.OnGetScore.Invoke(DataBase.GetItemByID(ID).Score);
        EventManager.OnObjectDestroy.Invoke();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
