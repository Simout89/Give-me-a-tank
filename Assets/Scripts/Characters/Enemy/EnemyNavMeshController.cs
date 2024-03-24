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
    private GameObject Base;
    [SerializeField] private float Distance = 5f;
    [SerializeField] private float RageSpeed = 1f;
    private int state = 0;  // 0 - патруль ,    1 - атака базы


    private void Awake()
    {
        Base = GameObject.FindGameObjectWithTag("Base");
        agent = GetComponent<NavMeshAgent>();
        Points = GameObject.FindGameObjectsWithTag("EnemyPoint");
        GetNewPoint();
    }
    private void SwitchState()
    {
        switch (state)
        {
            case 0:
                {
                    if (Vector3.Distance(SelectedPoint.position, transform.position) < 0.3f)
                        GetNewPoint();
                }; break;
            case 1:
                {
                    agent.SetDestination(Base.transform.position);
                    agent.speed = RageSpeed;
                }; break;
        }
        if (Vector3.Distance(Base.transform.position, transform.position) < Distance)
        {
            state = 1;
        }
    }
    private void FixedUpdate()
    {
        Shoot();
        SwitchState();
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
