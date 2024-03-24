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
        if ((other.tag != Sender) && (other.TryGetComponent(out IDamageable damageable)) &&
            !((Sender == "Item") && (other.tag == "PlayerObject"))
            &&
            !((Sender == "Item") && (other.tag == "Player")))
        {
            damageable.ApplyDamage(Damage);
        }
        if ((other.tag != Sender) && (other.tag != "UpgradePlatform") && (other.name != "Bullet(Clone)") && (other.tag != "Item") && (other.tag != "Item"))
        {
            Destroy(gameObject);
        }
    }
}
