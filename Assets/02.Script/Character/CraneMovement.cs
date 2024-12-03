using Default;
using System;
using UnityEngine;

public class CraneMovement : PlayerMovement
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
}
