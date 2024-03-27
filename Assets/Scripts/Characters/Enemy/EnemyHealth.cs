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
    [SerializeField] private GameObject DestrotyParticle;
    [HideInInspector]
    public float Health;

    
    public int ID { get; set; }
    private DataBase db;
    private void Awake()
    {
        db = Resources.Load<DataBase>("Database");
        Health = MaxEnemyHealth;
    }

    public void ApplyDamage(float damageValue)
    {
        Health -= damageValue;
        if (Health <= 0)
        {
            System.Random rnd = new System.Random();
            var itemdroppos = transform.position;
            itemdroppos.y += 0.3f;
            if (rnd.Next(0, ChanceDropItem) == 0)
            {
                Instantiate(db.GetItemByID(rnd.Next(5, 5 + ItemCount)).ItemOnGround, itemdroppos, Quaternion.identity);
            }
            ScoreOnScene.OnGetScore.Invoke(db.GetItemByID(ID).Score);
            EventManager.OnObjectDestroy.Invoke();
            Instantiate(DestrotyParticle, itemdroppos, Quaternion.identity);
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
