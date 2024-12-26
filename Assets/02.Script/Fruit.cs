using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Fruit : MonoBehaviour
{

    public int mass; 


    public Action<Fruit> OnPositionChanged;

    Vector3 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;
    }
    private void Update()
    {
        if (transform.position != lastPosition)
        {
            lastPosition = transform.position;

            //위치 변경 시 이벤트 호출
            OnPositionChanged?.Invoke(this);
        }
    }
}
