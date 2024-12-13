using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFireFly : MonoBehaviour, IFoxInteractable
{
    public bool isCatch;
    public void Interaction(FoxInteraction obj)
    {
        if (obj.transform.childCount == 0)
        {
            isCatch = true;
            //플레이어 자식으로 같이 움직이기
            transform.SetParent(obj.transform);

            //※자식 위치 수정 필요
        }
        else //집은 상태로 놓기
        {
            transform.SetParent(null);
            isCatch = false;
        }
    }
}
