using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorButton : MonoBehaviour
{
    [SerializeField] private string AuthorUrl;
    public void ButtonClick()
    {
        Application.OpenURL(AuthorUrl);
    }
}
