using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFireFly : MonoBehaviour, IFoxInteractable
{
    public ObstacleManager obsManager;

    public void Interaction(FoxInteraction obj)
    {
        if (obj.transform.childCount == 0)
        {
            GameObject firefly = null;
            firefly = obsManager.SpawnObstacle("FireFly", obj.transform.position, Quaternion.identity);
            firefly.transform.SetParent(obj.transform);

            //�ڽ� ��ġ ����
            firefly.transform.localPosition = new Vector3(0, -0.1f, 0.8f);
            firefly.transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        //else //���� ���·� ����
        //{
        //    transform.SetParent(null);
        //    isCatch = false;
        //}
    }
}
