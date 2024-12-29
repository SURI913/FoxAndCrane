using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour //È¶ºÒ¿¡°Ô Áà¾ßÇÒµí
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
    void Fire()//ÆÄÆ¼Å¬ ¸ØÃß±â
    {
        float distance = Vector3.Distance(transform.position, crane.transform.position);

        if(distance <= particleRange)
        {
            if(!isPlay)
            {
                fireParticle.Play(); //ÆÄÆ¼Å¬ Àç½ÃÀÛ
                isPlay = true;
            } 
        }
        else
        {
            if(isPlay)
            {
                fireParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting); //ÆÄÆ¼Å¬ ¸ØÃã
                isPlay = false;
            }
        }
    }
}
