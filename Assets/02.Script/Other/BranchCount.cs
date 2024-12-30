using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BranchCount : MonoBehaviour
{
    public TMP_Text myBranchText;
    public  ObstacleManager obstacleManager;

    public GameObject logObject;

    private int branchCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("branch"))
        {
            branchCount++;
            myBranchText.text = branchCount.ToString() + " / 5";

            if (branchCount >= 5)
            {
                //Log 활성화 하는걸로
                logObject.SetActive(true);
                branchCount = 0; // 카운트 초기화
            }

            if (obstacleManager != null)
            {
                //ObstacleManager통해 풀로 반환
                obstacleManager.ReturnObstacle("Branch", other.gameObject);
            }
            else
            {
                Debug.LogError("ObstacleManager is not set");
            }
        }
    }

}
