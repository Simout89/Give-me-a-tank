using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TankCount : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        EventManager.OnTankChangeCount.AddListener(HandleTankChangeCount);
    }

    private void HandleTankChangeCount(int arg0)
    {
        text.text = arg0.ToString();
    }
}
