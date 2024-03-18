using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class GunLaser : MonoBehaviour
{
    [SerializeField] private Transform LasterStartPoint;
    private LineRenderer lineRenderer;
    //private void OnDrawGizmos()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(LasterStartPoint.position, (LasterStartPoint.position - transform.position), out hit, 100f))
    //    {
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawLine(LasterStartPoint.position, hit.point);
    //    }
    //}
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(LasterStartPoint.position, (transform.position - LasterStartPoint.position), out hit, 100f))
        {
            lineRenderer.SetPosition(0, LasterStartPoint.position);
            lineRenderer.SetPosition(1, hit.point);
        }
    }
}
