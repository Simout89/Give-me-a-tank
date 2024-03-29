using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    [SerializeField] private GameObject LoseMenu;
    [SerializeField] private GameObject WinMenu;
    [SerializeField] private GameObject Menu;
    [SerializeField] private Slider Slider;
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
    public void MenuButton()
    {
        Menu.SetActive(!Menu.active);
    }
    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
    public void VolumeSlider()
    {
        AudioListener.volume = Slider.value;
    }
}
