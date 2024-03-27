using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticleDestroy : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(DestroyDelay());
    }
    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
