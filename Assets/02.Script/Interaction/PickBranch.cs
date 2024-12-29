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
            //�÷��̾� �ڽ����� ���� �����̱�
            branch.transform.SetParent(obj.transform);

            //�ڽ� ��ġ ����
            branch.transform.localPosition = new Vector3(0,-0.1f, 0.55f); 
            branch.transform.localRotation = Quaternion.Euler(0 ,180, 0);
        }
        //else
        //{
        //    Debug.Log("�ڽ� ����");
        //    // �ڽ� ������Ʈ ��������
        //    branch = obj.transform.GetChild(0).gameObject;

        //    branch.transform.SetParent(null);

        //    //����Ʈ����
        //    Rigidbody rigid = branch.GetComponent<Rigidbody>();
        //    if (!rigid) return;
        //    rigid.isKinematic = false;
        //}
    }
}
