using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxInteraction : PlayerInteraction
{
    private void Update()
    {
        HitRayCast();
    }
    protected override void HitRayCast()
    {
        //����ĳ��Ʈ�� ���� ���̴� ������Ʈ�� ��ȣ�ۿ� 
        //��ĳ���Ͱ� flip �ϸ� ����ĳ��Ʈ ���� �ٲ��ֱ�
        Debug.DrawRay(transform.position, transform.forward * length, Color.red);
        if (Input.GetKeyDown(KeyCode.G))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, length))
            {
                IFoxInteractable interactable = hit.collider.GetComponent<IFoxInteractable>();
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
