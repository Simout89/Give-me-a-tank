using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            MenuButton();
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
        if (Menu.active)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
    public void ExitButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void VolumeSlider()
    {
        AudioListener.volume = Slider.value;
    }
}
