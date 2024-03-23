using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string FirstLevel = "";
    public void PlayButton()
    {
        SceneManager.LoadScene(FirstLevel);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}