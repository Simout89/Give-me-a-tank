using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour, IShootable, IGunChangeSettings
{
    [Header("DefaultSettings")]
    [SerializeField] private Rigidbody BulletPrefab;
    [SerializeField] private Transform Muzzle;
    [SerializeField] private Transform Anchor;
    [SerializeField] private ParticleSystem FireParticle;
    [Header("Settings")]
    [SerializeField] private float ForeBullet;
    [SerializeField] private float DamageBullet;
    [SerializeField] private float ShootingDelay;
    private bool ShootingReady = true;

    public void FireRate(float fireRate)
    {
        ShootingDelay /= fireRate;
    }

    public void Shoot()
    {
        if (ShootingReady)
        {
            StartCoroutine(shootingDelay());
            Rigidbody bullet = Instantiate(BulletPrefab, Muzzle.position, Quaternion.identity);
            var direction = Muzzle.position - Anchor.position;
            bullet.AddForce(direction * ForeBullet, ForceMode.VelocityChange);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Sender = transform.root.gameObject.tag;
            bulletScript.Damage = DamageBullet;
            FireParticle.Play();
        }
    }
    private IEnumerator shootingDelay()
    {
        ShootingReady = false;
        yield return new WaitForSeconds(ShootingDelay);
        ShootingReady = true;
    }
}
