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
                //Log Ȱ��ȭ �ϴ°ɷ�
                logObject.SetActive(true);
                branchCount = 0; // ī��Ʈ �ʱ�ȭ
            }

            if (obstacleManager != null)
            {
                //ObstacleManager���� Ǯ�� ��ȯ
                obstacleManager.ReturnObstacle("Branch", other.gameObject);
            }
            else
            {
                Debug.LogError("ObstacleManager is not set");
            }
        }
    }

}
