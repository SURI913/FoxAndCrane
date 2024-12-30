using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFruit : MonoBehaviour, ICraneInteractable //자식으로 하면 문제생김
{

    bool isAttached = false;
    [SerializeField]
    Transform craneTransform;
    Vector3 offset; //두루미와 열매 사이의 초기 상대적 위치

    //두루미 상태를 관리하는 정적 변수
    public static bool isFruitAttachedToCrane = false;
    void LateUpdate()
    {
        if(isAttached && craneTransform != null)
        {
            //열매를 두루미 상대 위치 고정
            transform.position = craneTransform.position + offset;
        }
    }
    public void Interaction(CraneInteraction obj) //자식으로 가져와 트리의 자식에서 빼짐
    {
        if(!isAttached && !isFruitAttachedToCrane) //두루미에 부착
        {
            isAttached = true;
            isFruitAttachedToCrane = true; //다른 열매 부착방지
            craneTransform = obj.transform;
            offset = transform.position - craneTransform.position;
        }
        else if(isAttached)
        {
            isAttached = false;
            isFruitAttachedToCrane = false;
            craneTransform = null;
        }
    }
   
}
