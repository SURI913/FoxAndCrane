using Default;
using System;
using UnityEngine;


public class Fox : Player
{
    protected override void Start()
    {
        base.Start(); //�θ� ���� ���� �ʼ�
    }

    protected override void Update()
    {
        base.Update();

        //���� �߰�
    }

    protected override PlayerType GetPlayerType()
    {
        return PlayerType.Fox;
    }
}
