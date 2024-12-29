using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour //ȶ�ҿ��� ����ҵ�
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
    void Fire()//��ƼŬ ���߱�
    {
        float distance = Vector3.Distance(transform.position, crane.transform.position);

        if(distance <= particleRange)
        {
            if(!isPlay)
            {
                fireParticle.Play(); //��ƼŬ �����
                isPlay = true;
            } 
        }
        else
        {
            if(isPlay)
            {
                fireParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting); //��ƼŬ ����
                isPlay = false;
            }
        }
    }
}
