using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    [SerializeField] private Sprite[] hearts;
    [SerializeField] private Image image;
    [SerializeField] private Animator animator;
    private int state = 0;
    private void Awake()
    {
        EventManager.OnLiveLose.AddListener(HandleLiveLose);
    }

    private void HandleLiveLose()
    {
        animator.SetTrigger("Death");
        state++;
        image.sprite = hearts[state];
    }
}
