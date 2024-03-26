using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBoxTrigger : MonoBehaviour
{
    [SerializeField] private string Text;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DialogBox.OnTextMenu.Invoke(Text);
            Destroy(gameObject);
        }
    }
}