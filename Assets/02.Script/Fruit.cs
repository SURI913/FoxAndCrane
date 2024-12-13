using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Fruit : MonoBehaviour
{
    

    public int mass; //mass값 써야할 듯


    public Action<Fruit> OnPositionChanged;

    Vector3 lastPosition;

    Rigidbody rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rigid.mass = mass;
        lastPosition = transform.position;
    }
    private void Update()
    {
        if(transform.position != lastPosition)
        {
            lastPosition = transform.position;

            //위치 변경 시 이벤트 호출
            OnPositionChanged?.Invoke(this);
        }
    }
}
