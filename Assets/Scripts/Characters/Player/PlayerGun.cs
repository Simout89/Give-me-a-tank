using System;
using System.Collections;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    private IShootable[] Guns;
    private void Awake()
    {
        PlayerInput.OnFire.AddListener(HandleFire);
    }

    private void HandleFire()
    {
        Guns = GetComponentsInChildren<IShootable>();
        for (int i = 0; i < Guns.Length; i++)
        {
            Guns[i].Shoot();
        }
    }
}