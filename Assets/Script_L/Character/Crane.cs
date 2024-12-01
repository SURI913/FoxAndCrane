using Default;
using System;
using UnityEngine;

public class Crane : Player
{
    protected override void Start()
    {       
        base.Start(); //�θ� ���� ���� �ʼ�

        //�η�̴� ���� x 
        myRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ |
            RigidbodyConstraints.FreezeRotationX;
    }
    protected override void Update()
    {
        base.Update();

        //���� �߰�
    }

    protected override PlayerType GetPlayerType()
    {
        return PlayerType.Crane;
    }

    private void OnDisable()
    {
        //������ ���� ���������� �̵� ���� �� �ʿ����
        if (myRigidBody != null)
        {
            myRigidBody.velocity = Vector3.zero;
            myRigidBody.isKinematic = true;
        }
    }

    private void OnEnable()
    {
        if (myRigidBody != null)
        {
            myRigidBody.isKinematic = false;
        }
    }
}
