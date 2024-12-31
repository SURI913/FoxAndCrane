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
    }
}
