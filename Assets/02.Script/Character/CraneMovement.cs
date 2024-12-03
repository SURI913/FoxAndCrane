using Default;
using System;
using UnityEngine;

public class CraneMovement : PlayerMovement
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
}
