using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private float _elapsedTime = 0f;
    private string _timetext;
    private string TimeText;
    private void Awake()
    {
        EventManager.OnGameWin.AddListener(HandleGameWin);
    }

    private void HandleGameWin()
    {
        ScoreOnScene score = GameObject.Find("GameManager").GetComponent<ScoreOnScene>();
        text.text = $"Score: {(int)score.Score}\nTime: {TimeText}";
    }
    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        string minutes = Mathf.Floor(_elapsedTime / 60).ToString("00");
        string seconds = (_elapsedTime % 60).ToString("00");
        _timetext = $"{minutes}.{seconds}";
        TimeText = string.Format(_timetext);
    }
}
