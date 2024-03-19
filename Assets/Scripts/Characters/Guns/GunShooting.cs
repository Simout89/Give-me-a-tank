using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour, IShootable
{
    [Header("DefaultSettings")]
    [SerializeField] private Rigidbody BulletPrefab;
    [SerializeField] private Transform Muzzle;
    [SerializeField] private Transform Anchor;
    [Header("Settings")]
    [SerializeField] private float ForeBullet;
    [SerializeField] private float DamageBullet;
    [SerializeField] private float ShootingDelay;
    private bool ShootingReady = true;

    public void Shoot()
    {
        if (ShootingReady)
        {
            StartCoroutine(shootingDelay());
            Rigidbody bullet = Instantiate(BulletPrefab, Muzzle.position, Quaternion.identity);
            var direction = Muzzle.position - Anchor.position;
            bullet.AddForce(direction * ForeBullet, ForceMode.VelocityChange);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Sender = gameObject.transform.parent.gameObject.name;
            bulletScript.Damage = DamageBullet;
        }
    }
    private IEnumerator shootingDelay()
    {
        ShootingReady = false;
        yield return new WaitForSeconds(ShootingDelay);
        ShootingReady = true;
    }
}
