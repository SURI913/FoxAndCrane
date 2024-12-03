using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour, IInteractable
{
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
   public void Interaction(GameObject obj)
    {
        if(obj.transform.childCount == 0)
        {
            Debug.Log("집었다");
            //플레이어 자식으로 같이 움직이기
            transform.SetParent(obj.transform);
        }
        else //집은 상태로 놓기
        {
            Debug.Log("놓앗다");
            transform.SetParent(null);
            //떨어트리기
            rigid.isKinematic = false;
        }
    }
}
