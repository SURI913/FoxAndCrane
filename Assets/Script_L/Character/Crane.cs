using Default;
using System;
using UnityEngine;

public class Crane : Player
{
    protected override void Start()
    {       
        base.Start(); //부모 먼저 실행 필수

        //두루미는 점프 x 
        myRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ |
            RigidbodyConstraints.FreezeRotationX;
    }
    protected override void Update()
    {
        base.Update();

        //로직 추가
    }

    protected override PlayerType GetPlayerType()
    {
        return PlayerType.Crane;
    }

    private void OnDisable()
    {
        //움직임 멈춤 포지션으로 이동 구현 시 필요없음
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
