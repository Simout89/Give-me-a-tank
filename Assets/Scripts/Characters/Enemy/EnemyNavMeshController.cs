using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshController : MonoBehaviour
{
    private IShootable[] Guns;
    private NavMeshAgent agent;
    private GameObject[] Points;
    private Transform SelectedPoint;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        Points = GameObject.FindGameObjectsWithTag("EnemyPoint");
        GetNewPoint();
    }
    private void FixedUpdate()
    {
        Shoot();
        if (Vector3.Distance(SelectedPoint.position, transform.position) < 0.3f)
            GetNewPoint();
    }
    private void Shoot()
    {
        Guns = GetComponentsInChildren<IShootable>();
        for (int i = 0; i < Guns.Length; i++)
        {
            Guns[i].Shoot();
        }
    }
    private void GetNewPoint()
    {
        System.Random rnd = new System.Random();
        SelectedPoint = Points[rnd.Next(0, Points.Length)].transform;
        agent.SetDestination(SelectedPoint.position);
    }
}
