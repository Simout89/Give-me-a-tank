using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshSurfaceController : MonoBehaviour
{
    private NavMeshSurface meshSurface;

    private void Awake()
    {
        meshSurface = GetComponent<NavMeshSurface>();
        EventManager.OnObjectDestroy.AddListener(HandleObjectDestroy);
        EventManager.OnObjectPlace.AddListener(HandleObjectDestroy);
    }

    private void HandleObjectDestroy()
    {
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.01f);
        meshSurface.BuildNavMesh();
    }
}
