using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBranch : MonoBehaviour, ICraneInteractable
{
    public ObstacleManager obsManager;

    public void Interaction(CraneInteraction obj) 
    {
        if (obj.transform.childCount == 0)
        {
            GameObject branch = null;
            branch = obsManager.SpawnObstacle("Branch", obj.transform.position, Quaternion.identity);
            //플레이어 자식으로 같이 움직이기
            branch.transform.SetParent(obj.transform);

            //자식 위치 수정
            branch.transform.localPosition = new Vector3(0,-0.1f, 0.55f); 
            branch.transform.localRotation = Quaternion.Euler(0 ,180, 0);
        }
        //else
        //{
        //    Debug.Log("자식 제거");
        //    // 자식 오브젝트 가져오기
        //    branch = obj.transform.GetChild(0).gameObject;

        //    branch.transform.SetParent(null);

        //    //떨어트리기
        //    Rigidbody rigid = branch.GetComponent<Rigidbody>();
        //    if (!rigid) return;
        //    rigid.isKinematic = false;
        //}
    }
}
