using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBranch : MonoBehaviour, ICraneInteractable
{
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    public void Interaction(CraneInteraction obj)
    {
        if (obj.transform.childCount == 0)
        {
            //플레이어 자식으로 같이 움직이기
            transform.SetParent(obj.transform);

            //※자식 위치 수정 필요
        }
        else //집은 상태로 놓기
        {
            transform.SetParent(null);

            //떨어트리기
            if (!rigid) return;
            rigid.isKinematic = false;
        }
    }
}
