using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBoxUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite EmptySprite;
    private DataBase db;
    private void Awake()
    {
        db = Resources.Load<DataBase>("Database");
        PlayerInventory.OnChangeState.AddListener(HandleChangeState);
    }

    private void HandleChangeState(int arg0)
    {
        if (arg0 != -1)
            image.sprite = db.GetItemByID(arg0).Icon;
        else
            image.sprite = EmptySprite;
    }
}
