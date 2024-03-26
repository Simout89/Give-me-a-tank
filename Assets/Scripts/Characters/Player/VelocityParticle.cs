using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityParticle : MonoBehaviour
{
    private PlayerInput input;
    [SerializeField] private ParticleSystem[] particle;
    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        if(Math.Abs(input.Horizontal) + Math.Abs(input.Vertical) > 0.1f)
        {
            foreach (var particle in particle)
            {
                particle.Play();
            }
        }
        else
        {
            foreach(var particle in particle)
            {
                particle.Stop();
            }
        }
    }
}
