using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogBox : MonoBehaviour
{
    [SerializeField] private GameObject DialogBoxGameObject;
    [SerializeField] private TMP_Text tMP;
    [SerializeField] float speed = 1f;
    public static UnityEvent<string> OnTextMenu = new UnityEvent<string>();
    private IEnumerator coroutine;
    private void Awake()
    {
        OnTextMenu.AddListener(HandleTextMenu);
    }

    private void HandleTextMenu(string arg0)
    {
        coroutine = WriteText(arg0);
        StartCoroutine(coroutine);
    }
    private IEnumerator WriteText(string arg0)
    {
        Time.timeScale = 0f;
        tMP.text = "";
        PlayerInput.OnInputState.Invoke(false);
        DialogBoxGameObject.SetActive(true);
        char[] chars = arg0.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            tMP.text += chars[i];
            yield return new WaitForSecondsRealtime(speed);
        }
        yield return new WaitForSecondsRealtime(1f);
    }
    public void CloseButton()
    {
        StopCoroutine(coroutine);
        DialogBoxGameObject.SetActive(false);
        PlayerInput.OnInputState.Invoke(true);
        Time.timeScale = 1f;
    }
}
