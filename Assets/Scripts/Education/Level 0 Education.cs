using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0Education : MonoBehaviour
{
    private int Counter = 0;
    [SerializeField] private GameObject Spawner;
    private void Awake()
    {
        EventManager.OnObjectDestroy.AddListener(HandleObjectDestroy);
    }

    private void HandleObjectDestroy()
    {
        Counter++;
        if(Counter == 2)
        {
            DialogBox.OnTextMenu.Invoke("Ќа горизноте враг, покажи ему чему ты научилс€.");
            Spawner.SetActive(true);
        }
    }

}
