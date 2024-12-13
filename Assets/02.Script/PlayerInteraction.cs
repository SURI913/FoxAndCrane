using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInteraction : MonoBehaviour //������ ���츦 �����°� ����? ����
{
    protected const float length = 1.5f;
    void Update()
    {
        HitRayCast();
    }
    protected virtual void HitRayCast()
    {
       
    }
}
