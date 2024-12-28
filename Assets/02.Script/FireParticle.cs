using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour
{
    public ParticleSystem fireParticle;
    public GameObject crane;

    [SerializeField]
    float particleRange;

    ParticleSystem.EmissionModule emissionModule;

    bool isPlay = false;

    private void Update()
    {
        Invoke("Fire",0.5f);
    }
    void Fire()//파티클 멈추기
    {
        float distance = Vector3.Distance(transform.position, crane.transform.position);

        if(distance <= particleRange)
        {
            if(!isPlay)
            {
                fireParticle.Play();
                isPlay = true;
            } 
        }
        else
        {
            if(isPlay)
            {
                fireParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                isPlay = false;
            }
        }
    }
}
