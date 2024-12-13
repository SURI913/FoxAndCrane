using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Fruit : MonoBehaviour
{
    

    public int mass; //mass�� ����� ��


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

            //��ġ ���� �� �̺�Ʈ ȣ��
            OnPositionChanged?.Invoke(this);
        }
    }
}
