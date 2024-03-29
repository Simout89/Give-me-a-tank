using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ScoreOnScene : MonoBehaviour
{
    public static UnityEvent<float> OnGetScore = new UnityEvent<float>();

    public float Score;
    private float _elapsedTime = 0f;
    private string _timetext;
    private void Awake()
    {
        Score = 0;
        OnGetScore.AddListener(HandleGetScore);
    }

    private void HandleGetScore(float arg0)
    {
        Score += arg0 - (_elapsedTime / 10f );
        Debug.Log($"Получено {arg0} очков, всего: {Score}");
    }
    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }
}
