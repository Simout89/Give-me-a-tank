using System;
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
        EventManager.OnGameLose.AddListener(HandeGameStop);
        Base = GameObject.FindGameObjectWithTag("Base");
        agent = GetComponent<NavMeshAgent>();
        Points = GameObject.FindGameObjectsWithTag("EnemyPoint");
        GetNewPoint();
    }

    private void HandeGameStop()
    {
        state = 2;
    }

    private void SwitchState()
    {
        switch (state)
        {
            case 0:
                {
                    Debug.Log(Vector3.Distance(SelectedPoint.position, transform.position));
                    if (Vector3.Distance(SelectedPoint.position, transform.position) < 1f)
                    {
                        GetNewPoint();
                    }
                }; break;
            case 1:
                {
                    agent.SetDestination(Base.transform.position);
                    agent.speed = RageSpeed;
                }; break;
                case 2:
                {
                    agent.isStopped = true;
                };break;
        }
            if ((state != 2) && (Vector3.Distance(Base.transform.position, transform.position) < Distance))
                state = 1;
    }
    private void Update()
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
