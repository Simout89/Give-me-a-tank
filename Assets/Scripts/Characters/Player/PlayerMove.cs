using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IMovable
{
    private PlayerInput playerInput;
    private Rigidbody rigidBody;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        
    }

    public void Moving()
    {
        throw new System.NotImplementedException();
    }

    public void Rotate()
    {
        throw new System.NotImplementedException();
    }
}
