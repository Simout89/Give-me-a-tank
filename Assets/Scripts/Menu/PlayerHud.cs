using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHud : MonoBehaviour
{
    [SerializeField] private GameObject LoseMenu;
    [SerializeField] private GameObject WinMenu;
    private void Awake()
    {
        EventManager.OnGameLose.AddListener(HandleGameLose);
        EventManager.OnGameWin.AddListener(HandleGameWin);
    }

    private void HandleGameWin()
    {
        WinMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    private void HandleGameLose()
    {
        LoseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartButton()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void NextButton()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
}
