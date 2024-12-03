using Default;
using System;
using UnityEngine;


public class Fox : Player
{
    protected override void Start()
    {
        base.Start(); //부모 먼저 실행 필수
    }

    protected override void Update()
    {
        base.Update();

        //로직 추가
    }

    protected override PlayerType GetPlayerType()
    {
        return PlayerType.Fox;
    }
}
