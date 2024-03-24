using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ScoreOnScene : MonoBehaviour
{
    public static UnityEvent<float> OnGetScore = new UnityEvent<float>();

    private float Score;

    private void Awake()
    {
        Score = 0;
        OnGetScore.AddListener(HandleGetScore);
    }

    private void HandleGetScore(float arg0)
    {
        Score += arg0;
        Debug.Log($"�������� {arg0} �����, �����: {Score}");
    }
}
