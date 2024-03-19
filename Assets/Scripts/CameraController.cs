using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float Speed;
    [SerializeField] private float Z;
    [SerializeField] private float Y;
    private void LateUpdate()
    {
        var target = player.position;
        target.z +=Z;
        target.y +=Y;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * Speed);
    }
}
