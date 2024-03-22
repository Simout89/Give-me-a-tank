using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretStay : MonoBehaviour, IItem
{
    private GameObject[] enemy;
    private GameObject closest;
    [SerializeField] private GameObject Anchor;
    [SerializeField] private float Distance = 5f;
    private IShootable[] Guns;

    public string ID { get; set; }

    private void FixedUpdate()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        Vector3 enemypos = FindClosestEnemy();
        if(enemypos != Anchor.transform.position)
        {

            Guns = GetComponentsInChildren<IShootable>();
            for (int i = 0; i < Guns.Length; i++)
            {
                Guns[i].Shoot();
            }
            enemypos.y = Anchor.transform.position.y;
            Anchor.transform.LookAt(enemypos);
        }
    }
    
    Vector3 FindClosestEnemy()
    {
        bool flag = true;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach(GameObject go in enemy)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            RaycastHit hit;
            var direction = go.transform.position - transform.position;
            if ((curDistance < distance) && Physics.Raycast(transform.position,direction, out hit, Distance) && (hit.collider.gameObject.tag == "Enemy"))
            {
                flag = false;
                closest = go;
                distance = curDistance;
            }
        }
        if(!flag)
            return closest.transform.position;
        else
            return Anchor.transform.position;
    }
}
