using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody rigidBody;
    [SerializeField] private float MoveSpeed = 1.0f;
    [SerializeField] private float RotateSpeed = 1.0f;
    private float directional;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        Moving();
    }

    public void Moving()
    {
        Vector3 movement = new Vector3(0f, 0f, playerInput.Vertical) * MoveSpeed * Time.deltaTime;
        if (playerInput.Vertical < 0)
            directional = -1;
        else
            directional = 1;
        Quaternion rotation = Quaternion.Euler(Vector3.up * playerInput.Horizontal * directional * RotateSpeed * Time.deltaTime);
        rigidBody.MovePosition(rigidBody.position + transform.TransformDirection(movement));
        rigidBody.MoveRotation(rigidBody.rotation * rotation);
    }
}
