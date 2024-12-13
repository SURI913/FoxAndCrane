using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneInteraction : PlayerInteraction
{
    private void Update()
    {
        HitRayCast();
    }
    protected override void HitRayCast()
    {
        //����ĳ��Ʈ�� ���� ���̴� ������Ʈ�� ��ȣ�ۿ� 
        //��ĳ���Ͱ� flip �ϸ� ����ĳ��Ʈ ���� �ٲ��ֱ�
        Debug.DrawRay(transform.position, transform.right * length, Color.red);
        if (Input.GetKeyDown(KeyCode.G))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.right, out hit, length))
            {
                ICraneInteractable interactable = hit.collider.GetComponent<ICraneInteractable>();
                {
                    if (interactable != null) //��ȣ�ۿ�
                    {
                        interactable.Interaction(this);
                    }
                }
            }
        }
    }
}
