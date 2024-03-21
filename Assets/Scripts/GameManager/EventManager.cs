using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent OnObjectDestroy = new UnityEvent();
    public static UnityEvent OnObjectPlace = new UnityEvent();
    
}
