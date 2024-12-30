using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFruit : MonoBehaviour, ICraneInteractable
{
    public ObstacleManager obsManager;

    public void Interaction(CraneInteraction obj)
    {
        if (obj.transform.childCount == 0)
        {
            GameObject fruit = null;
            fruit = obsManager.SpawnObstacle("Fruit", obj.transform.position, Quaternion.identity);
            //�÷��̾� �ڽ����� ���� �����̱�
            fruit.transform.SetParent(obj.transform);

            //�ڽ� ��ġ ����
            fruit.transform.localPosition = new Vector3(0, -0.2f, 0.6f);   
        }
    }
}
