using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInteraction : MonoBehaviour //거위와 여우를 나누는게 좋나? 생각
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
