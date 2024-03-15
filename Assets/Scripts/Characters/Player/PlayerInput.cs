using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private bool _state = true;
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool Fire { get; private set; }
    public static UnityEvent OnFire = new UnityEvent();
    public static UnityEvent<bool> OnInputState = new UnityEvent<bool>();
    private void Awake()
    {
        OnInputState.AddListener(HandleInputState);
    }

    private void HandleInputState(bool arg0)
    {
        _state = arg0;
    }

    private void Update()
    {
        if (_state)
        {
            Vertical = Input.GetAxisRaw("Hoirzontal");
            Horizontal = Input.GetAxisRaw("Horizontal");
            Fire = Input.GetButtonDown("Fire");
            if (Fire) OnFire.Invoke();
        }
        else
        {
            Horizontal = 0;
        }
    }
}
